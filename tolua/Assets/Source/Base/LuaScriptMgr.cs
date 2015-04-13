//#define MULTI_STATE
using System;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.Collections;

public class LuaScriptMgr
{
    public static LuaScriptMgr Instance
    {
        get;
        private set;
    }

    public LuaState lua;
    HashSet<string> fileList = null;
    Dictionary<string, LuaBase> dict = null;
    //Dictionary<string, IAssetFile> dictBundle = null;    
    LuaFunction updateFunc = null;
    LuaFunction lateUpdateFunc = null;
    LuaFunction fixedUpdateFunc = null;    
    LuaFunction levelLoaded = null;

    LuaFunction unpackVec3 = null;    
    LuaFunction unpackVec2 = null;
    LuaFunction unpackVec4 = null;
    LuaFunction unpackQuat = null;
    LuaFunction unpackColor = null;
    LuaFunction unpackRay = null;

    LuaFunction packVec3 = null;
    LuaFunction packVec2 = null;
    LuaFunction packVec4 = null;
    LuaFunction packQuat = null;
    LuaFunction packTouch = null;
    LuaFunction packRay = null;
    LuaFunction packRaycastHit = null;
    LuaFunction packColor = null;    

    public static LockFreeQueue<LuaRef> refGCList = new LockFreeQueue<LuaRef>(1024);    
    static ObjectTranslator _translator = null;    

#if MULTI_STATE
    static List<LuaScriptMgr> mgrList = new List<LuaScriptMgr>();
    static int mgrPos = 0;
#else
    static LuaFunction traceback = null;
#endif

    string luaIndex =
    @"        
        local rawget = rawget
        local rawset = rawset
        local getmetatable = getmetatable      
        local type = type  
        local function index(obj,name)  
            local o = obj            
            local meta = getmetatable(o)            
            local parent = meta
            local v = nil
            
            while meta~= nil do
                v = rawget(meta, name)
                
                if v~= nil then
                    if parent ~= meta then rawset(parent, name, v) end

                    local t = type(v)

                    if t == 'function' then                    
                        return v
                    elseif t == 'table' then
                        local func = v[1]
                
                        if func ~= nil then
                            return func(obj, name)                         
                        end
                    end

                    break
                end
                
                meta = rawget(meta, 'base')
            end

           error('unknown member name '..name, 2)
           return nil	        
        end
        return index";

    string luaNewIndex =
    @"
        local rawget = rawget
        local getmetatable = getmetatable   
        local rawset = rawset     
        local function newindex(obj, name, val)           
            local meta = getmetatable(obj)            
            local parent = meta
            local v = nil
            
            while meta~= nil do
                v = rawget(meta, name)    
            
                if v~= nil then
                    local func = v[2]
                    
                    if func ~= nil then                        
                        return func(obj, name, val)                        
                    end             
                    break       
                end                
                meta = rawget(meta, 'base')                       
            end 
       
            error('field or property '..name..' does not exist', 2)
            return nil		
        end
        return newindex";

    string luaTableCall =
    @"
        local rawget = rawget
        local getmetatable = getmetatable     

        local function call(obj, ...)
            local meta = getmetatable(obj)
            local fun = rawget(meta, 'New')
            
            if fun ~= nil then
                return fun(...)
            else
                error('unknow function __call',2)
            end
        end

        return call
    ";

    string luaEnumIndex =
    @"
        local rawget = rawget                
        local getmetatable = getmetatable         

        local function indexEnum(obj,name)
            local v = rawget(obj, name)
            
            if v ~= nil then
                return v
            end

            local meta = getmetatable(obj)  
            local func = rawget(meta, name)            
            
            if func ~= nil then
                v = func()
                rawset(obj, name, v)
                return v
            else
                error('field '..name..' does not exist', 2)
            end
        end

        return indexEnum
    ";
    

    public LuaScriptMgr()
    {
        Instance = this;
        LuaStatic.Load = Loader;
        lua = new LuaState();
        _translator = lua.GetTranslator();

        LuaDLL.luaopen_pb(lua.L);               
        //LuaDLL.luaopen_pack(lua.L);
        //LuaDLL.luaopen_ffi(lua.L);
        //OpenXml();        
                
        fileList = new HashSet<string>();
        dict = new Dictionary<string,LuaBase>();        
        //dictBundle = new Dictionary<string, IAssetFile>();

        LuaDLL.lua_pushstring(lua.L, "ToLua_Index");
        LuaDLL.luaL_dostring(lua.L, luaIndex);        
        LuaDLL.lua_rawset(lua.L, (int)LuaIndexes.LUA_REGISTRYINDEX);

        LuaDLL.lua_pushstring(lua.L, "ToLua_NewIndex");
        LuaDLL.luaL_dostring(lua.L, luaNewIndex);
        LuaDLL.lua_rawset(lua.L, (int)LuaIndexes.LUA_REGISTRYINDEX);

        LuaDLL.lua_pushstring(lua.L, "ToLua_TableCall");
        LuaDLL.luaL_dostring(lua.L, luaTableCall);
        LuaDLL.lua_rawset(lua.L, (int)LuaIndexes.LUA_REGISTRYINDEX);

        LuaDLL.lua_pushstring(lua.L, "ToLua_EnumIndex");
        LuaDLL.luaL_dostring(lua.L, luaEnumIndex);
        LuaDLL.lua_rawset(lua.L, (int)LuaIndexes.LUA_REGISTRYINDEX);     

        Bind();                

#if MULTI_STATE
        mgrList.Add(this);
        LuaDLL.lua_pushnumber(lua.L, mgrPos);
        LuaDLL.lua_setglobal(lua.L, "_LuaScriptMgr");           

        ++mgrPos;
#else
        LuaDLL.lua_pushnumber(lua.L, 0);
        LuaDLL.lua_setglobal(lua.L, "_LuaScriptMgr");                
#endif
        //CmdTable.RegisterCommand("ToLua", ToLua.Generate);
        //CmdTable.RegisterCommand("LuaGC", LuaGC);
        //CmdTable.RegisterCommand("memory", LuaMem);
        //CmdTable.RegisterCommand("GM", SendGMmsg);                
    }

    void SendGMmsg(params string[] param)
    {
        Debugger.Log("SendGMmsg");
        string str = "";
        int i = 0;
        foreach (string p in param)
        {
            if (i >0)
            {
                str = str +" "+ p;
                Debugger.Log(p);
            }
            i++;
        }
        CallLuaFunction("GMMsg", str);
    }

    //void OpenXml()
    //{
    //    IntPtr L = lua.L;
    //    LuaDLL.luaopen_LuaXML(L);
    //    LuaDLL.lua_getglobal(L, "xml");

    //    LuaDLL.lua_pushstring(L, "read");
    //    LuaDLL.lua_pushstdcallcfunction(L, Xml_read);
    //    LuaDLL.lua_rawset(L, -3);

    //    LuaDLL.lua_settop(L, 0);
    //}

    void Bind()
    {
        IntPtr L = lua.L;
        BindArray(L);
        LuaBinder.Bind(L);        
    }

    void BindArray(IntPtr L)
    {
        LuaDLL.luaL_newmetatable(L, "luaNet_array");
        LuaDLL.lua_pushstring(L, "__index");
        LuaDLL.lua_pushstdcallcfunction(L, IndexArray);
        LuaDLL.lua_rawset(L, -3);
        LuaDLL.lua_pushstring(L, "__gc");
        LuaDLL.lua_pushstdcallcfunction(L, __gc);
        LuaDLL.lua_rawset(L, -3);
        LuaDLL.lua_pushstring(L, "__newindex");
        LuaDLL.lua_pushstdcallcfunction(L, NewIndexArray);
        LuaDLL.lua_rawset(L, -3);
        LuaDLL.lua_settop(L, 0);
    }

    public IntPtr GetL()
    {
        return lua.L;
    }

    void PrintLua(params string[] param)
    {
        if (param.Length != 2)
        {
            Debugger.Log("PrintLua [ModuleName]");
            return;
        }
        
        CallLuaFunction("PrintLua", param[1]);
    }

    public void LuaGC(params string[] param)
    {        
        LuaDLL.lua_gc(lua.L, LuaGCOptions.LUA_GCCOLLECT, 0);        
    }

    void LuaMem(params string[] param)
    {               
        CallLuaFunction("mem_report");
    }

    public void Start()
    {
        //CmdTable.RegisterCommand("PrintLua", PrintLua);    
        //AssetFileMgr.Instance.Open(Const.LuaResId, OnCommonLoad);
        /*List<AssetRecorder> table = TableMgr.Instance.Query<AssetRecorder>("select * from Assets where Type == 11");

        int total = table.Count;

        Action<IAssetFile> OnAssetLoad = (file) =>
        {
            --total;            
            dictBundle.Add(file.GetName(), file);

            if (total == 0)
            {
                OnBundleLoaded();
            }
        };
  
        for (int i = 0; i < table.Count; i++)
        {
            AssetFileMgr.Instance.Open(table[i].id, OnAssetLoad);
        }*/

        OnBundleLoaded();
    }


    void OnBundleLoaded()
    {
        DoFile("Golbal.lua");
        unpackVec3 = GetLuaFunction("Vector3.Get");
        unpackVec2 = GetLuaFunction("Vector2.Get");
        unpackVec4 = GetLuaFunction("Vector4.Get");
        unpackQuat = GetLuaFunction("Quaternion.Get");
        unpackColor = GetLuaFunction("Color.Get");
        unpackRay = GetLuaFunction("Ray.Get");

        packVec3 = GetLuaFunction("Vector3.New");        
        packVec2 = GetLuaFunction("Vector2.New");
        packVec4 = GetLuaFunction("Vector4.New");
        packQuat = GetLuaFunction("Quaternion.New");
        packRaycastHit = GetLuaFunction("Raycast.New");
        packColor = GetLuaFunction("Color.New");
        packRay = GetLuaFunction("Ray.New");
        packTouch = GetLuaFunction("Touch.New");

#if !MULTI_STATE
        traceback = GetLuaFunction("traceback");
#endif        

        DoFile("Main.lua");

        CallLuaFunction("Main");
        updateFunc = GetLuaFunction("Update");
        lateUpdateFunc = GetLuaFunction("LateUpdate");
        fixedUpdateFunc = GetLuaFunction("FixedUpdate");
        levelLoaded = GetLuaFunction("OnLevelWasLoaded");
    }

    public void OnLevelLoaded(int level)
    {
        levelLoaded.Call(level);
    }

    public void Update()
    {
        if (updateFunc != null)
        {
            updateFunc.Call(Time.deltaTime);
        }
        
        while (!refGCList.IsEmpty())
        {
            LuaRef lf = refGCList.Dequeue();
            LuaDLL.lua_unref(lf.L, lf.reference);
        }

        //if (LuaDLL.lua_gettop(lua.L) != 0)
        //{
        //    Debugger.Log("stack top {0}", LuaDLL.lua_gettop(lua.L));
        //}
    }

    public void LateUpate()
    {
        if (lateUpdateFunc != null)
        {
            lateUpdateFunc.Call();
        }        
    }

    public void FixedUpdate()
    {
        if (fixedUpdateFunc != null)
        {
            fixedUpdateFunc.Call(Time.fixedDeltaTime);            
        }
    }


    void SafeRelease(ref LuaFunction func)
    {
        if (func != null)
        {
            func.Release();
            func = null;
        }
    }

    public void Destroy()
    {        
        Instance = null;        
        SafeRelease(ref unpackVec3);        
        SafeRelease(ref unpackVec2);
        SafeRelease(ref unpackVec4);
        SafeRelease(ref unpackQuat);
        SafeRelease(ref unpackColor);
        SafeRelease(ref unpackRay);

        SafeRelease(ref packVec3);                
        SafeRelease(ref packVec2);
        SafeRelease(ref packVec4);
        SafeRelease(ref packQuat);
        SafeRelease(ref packRay);
        SafeRelease(ref packRaycastHit);        
        SafeRelease(ref packColor);
        SafeRelease(ref packTouch);

        SafeRelease(ref updateFunc);
        SafeRelease(ref lateUpdateFunc);
        SafeRelease(ref fixedUpdateFunc);       
 
#if !MULTI_STATE
        SafeRelease(ref traceback);
#endif

        LuaDLL.lua_gc(lua.L, LuaGCOptions.LUA_GCCOLLECT, 0);

        foreach(KeyValuePair<string, LuaBase> kv in dict)
        {
            kv.Value.Dispose();
        }        

        //foreach(KeyValuePair<string, IAssetFile> kv in dictBundle)
        //{
        //    kv.Value.Close();
        //}
        
        dict.Clear();
        fileList.Clear();

        lua.Close();
        lua.Dispose();
        lua = null;

        Debugger.Log("Lua module destroy");        
    }

    public object[] DoString(string str)
    {
        return lua.DoString(str);
    }

    public object[] DoFile(string fileName)
    {
        if (!fileList.Contains(fileName))
        {                            
            return lua.DoFile(fileName, null);                  
        }

        return null;
    }

    //不缓存LuaFunction
    public object[] CallLuaFunction(string name, params object[] args)
    {
        LuaBase lb = null;

        if (dict.TryGetValue(name, out lb))
        {
            LuaFunction func = lb as LuaFunction;
            return func.Call(args);
        }
        else
        {
            IntPtr L = lua.L;
            LuaFunction func = null;
            int oldTop = LuaDLL.lua_gettop(L);

            if (PushLuaFunction(L, name))
            {
                int reference = LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
                func = new LuaFunction(reference, lua);
                LuaDLL.lua_settop(L, oldTop);
                object[] objs = func.Call(args);
                func.Dispose();
                return objs;            
            }

            return null;
        }        
    }

    //会缓存LuaFunction
    public LuaFunction GetLuaFunction(string name)
    {
        LuaBase func = null;

        if (!dict.TryGetValue(name, out func))
        {
            IntPtr L = lua.L;
            int oldTop = LuaDLL.lua_gettop(L);

            if (PushLuaFunction(L, name))
            {
                int reference = LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
                func = new LuaFunction(reference, lua);                
                func.name = name;
                dict.Add(name, func);
            }
            else
            {
                Debugger.LogWarning("Lua function {0} not exists", name);
            }

            LuaDLL.lua_settop(L, oldTop);            
        }
        else
        {
            func.AddRef();
        }

        return func as LuaFunction;
    }

    public bool IsFuncExists(string name)
    {
        IntPtr L = lua.L;
        int oldTop = LuaDLL.lua_gettop(L);

        if (PushLuaFunction(L, name))
        {
            LuaDLL.lua_settop(L, oldTop);
            return true;
        }

        return false;
    }

    public byte[] Loader(string name)
    {
        byte[] str = null;       

#if !LUA_ZIP
        string path = Application.dataPath + "/Lua/" + name;

        try
        {
            //using (FileStream file = new FileStream(path, FileMode.Open))
            //{
            //    str = new byte[(int)file.Length];
            //    file.Read(str, 0, str.Length);                
            //    file.Close();
            //}

            str = File.ReadAllBytes(path);
        }
        catch
        {
            LuaDLL.luaL_error(lua.L, "Loader file failed: " + name);            
        }
#else
        IAssetFile zipFile = null;
        int pos = name.IndexOf('/');        

        if (pos > 0)
        {
            string zip = name.Substring(0, pos);
            zip = string.Format("Lua_{0}.unity3d", zip);
            zipFile = dictBundle[zip];
            name = name.Substring(pos + 1);
        }
        else
        {
            zipFile = dictBundle["Lua.unity3d"];
        }

        TextAsset luaCode = zipFile.Read<TextAsset>(name);
        str = luaCode.bytes;
        Resources.UnloadAsset(luaCode);
#endif
        fileList.Add(name);
        return str;
    }

    static bool PushLuaTable(IntPtr L, string fullPath)
    {        
        string[] path = fullPath.Split(new char[] { '.' });
        int oldTop = LuaDLL.lua_gettop(L);
        LuaDLL.lua_getglobal(L, path[0]);

        LuaTypes type = LuaDLL.lua_type(L, -1);

        if (type != LuaTypes.LUA_TTABLE)
        {
            LuaDLL.lua_settop(L, oldTop);
            Debugger.LogError("Push lua table {0} failed", path[0]);
            return false;
        }

        for (int i = 1; i < path.Length; i++)
        {
            LuaDLL.lua_pushstring(L, path[i]);
            LuaDLL.lua_rawget(L, -2);
            type = LuaDLL.lua_type(L, -1);

            if (type != LuaTypes.LUA_TTABLE)
            {
                LuaDLL.lua_settop(L, oldTop);
                Debugger.LogError("Push lua table {0} failed", fullPath);
                return false;
            }
        }

        if (path.Length > 1)
        {
            LuaDLL.lua_insert(L, oldTop + 1);
            LuaDLL.lua_settop(L, oldTop + 1);
        }

        return true;
    }

    static bool PushLuaFunction(IntPtr L, string fullPath)
    {
        int oldTop = LuaDLL.lua_gettop(L);
        int pos = fullPath.LastIndexOf('.');

        if (pos > 0)
        {
            string tableName = fullPath.Substring(0, pos);

            if (PushLuaTable(L, tableName))
            {
                string funcName = fullPath.Substring(pos + 1);
                LuaDLL.lua_pushstring(L, funcName);
                LuaDLL.lua_rawget(L, -2);
            }

            LuaTypes type = LuaDLL.lua_type(L, -1);

            if (type != LuaTypes.LUA_TFUNCTION)
            {
                LuaDLL.lua_settop(L, oldTop);
                return false;
            }

            LuaDLL.lua_insert(L, oldTop + 1);
            LuaDLL.lua_settop(L, oldTop + 1);
        }
        else
        {
            LuaDLL.lua_getglobal(L, fullPath);
            LuaTypes type = LuaDLL.lua_type(L, -1);

            if (type != LuaTypes.LUA_TFUNCTION)
            {
                LuaDLL.lua_settop(L, oldTop);
                return false;
            }
        }

        return true;
    }

    public LuaTable GetLuaTable(string tableName)
    {
        LuaBase lt = null;

        if (!dict.TryGetValue(tableName, out lt))
        {            
            IntPtr L = lua.L;
            int oldTop = LuaDLL.lua_gettop(L);

            if (PushLuaTable(L, tableName))
            {
                int reference = LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
                lt = new LuaTable(reference, lua);
                lt.name = tableName;
                dict.Add(tableName, lt);           
            }

            LuaDLL.lua_settop(L, oldTop);             
        }
        else
        {
            lt.AddRef();
        }

        return lt as LuaTable;
    }

    public void RemoveLuaRes(string name)
    {
        dict.Remove(name);
    }

    static void CreateTable(IntPtr L, string fullPath)
    {        
        string[] path = fullPath.Split(new char[] { '.' });
        int oldTop = LuaDLL.lua_gettop(L);

        if (path.Length > 1)
        {            
            LuaDLL.lua_getglobal(L, path[0]);
            LuaTypes type = LuaDLL.lua_type(L, -1);

            if (type == LuaTypes.LUA_TNIL)
            {
                LuaDLL.lua_pop(L, 1);
                LuaDLL.lua_createtable(L, 0, 0);
                LuaDLL.lua_pushstring(L, path[0]);
                LuaDLL.lua_pushvalue(L, -2);
                LuaDLL.lua_settable(L, LuaIndexes.LUA_GLOBALSINDEX);
            }

            for (int i = 1; i < path.Length - 1; i++)
            {
                LuaDLL.lua_pushstring(L, path[i]);
                LuaDLL.lua_rawget(L, -2);

                type = LuaDLL.lua_type(L, -1);

                if (type == LuaTypes.LUA_TNIL)
                {
                    LuaDLL.lua_pop(L, 1);
                    LuaDLL.lua_createtable(L, 0, 0);
                    LuaDLL.lua_pushstring(L, path[i]);
                    LuaDLL.lua_pushvalue(L, -2);
                    LuaDLL.lua_rawset(L, -4);
                }
            }

            LuaDLL.lua_pushstring(L, path[path.Length - 1]);
            LuaDLL.lua_rawget(L, -2);

            type = LuaDLL.lua_type(L, -1);

            if (type == LuaTypes.LUA_TNIL)
            {
                LuaDLL.lua_pop(L, 1);
                LuaDLL.lua_createtable(L, 0, 0);
                LuaDLL.lua_pushstring(L, path[path.Length - 1]);
                LuaDLL.lua_pushvalue(L, -2);           
                LuaDLL.lua_rawset(L, -4);
            }            
        }
        else
        {
            LuaDLL.lua_getglobal(L, path[0]);
            LuaTypes type = LuaDLL.lua_type(L, -1);

            if (type == LuaTypes.LUA_TNIL)
            {
                LuaDLL.lua_pop(L, 1);
                LuaDLL.lua_createtable(L, 0, 0);
                LuaDLL.lua_pushstring(L, path[0]);
                LuaDLL.lua_pushvalue(L, -2);                
                LuaDLL.lua_settable(L, LuaIndexes.LUA_GLOBALSINDEX);
            }
        }

        LuaDLL.lua_insert(L, oldTop + 1);
        LuaDLL.lua_settop(L, oldTop + 1);
    }

    //注册一个枚举类型
    public static void RegisterLib(IntPtr L, string libName, Type t, LuaMethod[] regs)
    {
        CreateTable(L, libName);

        LuaDLL.luaL_getmetatable(L, t.AssemblyQualifiedName);

        if (LuaDLL.lua_isnil(L, -1))
        {
            LuaDLL.lua_pop(L, 1);
            LuaDLL.luaL_newmetatable(L, t.AssemblyQualifiedName);
        }

        LuaDLL.lua_pushstring(L, "ToLua_EnumIndex");
        LuaDLL.lua_rawget(L, (int)LuaIndexes.LUA_REGISTRYINDEX);
        LuaDLL.lua_setfield(L, -2, "__index");

        LuaDLL.lua_pushstring(L, "__gc");
        LuaDLL.lua_pushstdcallcfunction(L, __gc);
        LuaDLL.lua_rawset(L, -3);

        for (int i = 0; i < regs.Length - 1; i++)
        {
            LuaDLL.lua_pushstring(L, regs[i].name);            
            LuaDLL.lua_pushstdcallcfunction(L, regs[i].func);
            LuaDLL.lua_rawset(L, -3);
        }
                
        int pos = regs.Length - 1;
        LuaDLL.lua_pushstring(L, regs[pos].name);
        LuaDLL.lua_pushstdcallcfunction(L, regs[pos].func);
        LuaDLL.lua_rawset(L, -4);

        LuaDLL.lua_setmetatable(L, -2);
        LuaDLL.lua_settop(L, 0);     
    }

    public static void RegisterLib(IntPtr L, string libName, LuaMethod[] regs)
    {
        CreateTable(L, libName);

        for (int i = 0; i < regs.Length; i++)
        {                        
            LuaDLL.lua_pushstring(L, regs[i].name);
            LuaDLL.lua_pushstdcallcfunction(L, regs[i].func);
            LuaDLL.lua_rawset(L, -3);                    
        }
          
        LuaDLL.lua_settop(L, 0);        
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    public static int __gc(IntPtr luaState)
    {
        int udata = LuaDLL.luanet_rawnetobj(luaState, 1);

        if (udata != -1)
        {
            ObjectTranslator translator = ObjectTranslator.FromState(luaState);
            translator.collectObject(udata);
        }

        return 0;
    }
    

    public static void RegisterLib(IntPtr L, string libName, Type t, LuaMethod[] regs, LuaField[] fields, Type baseType)
    {
        CreateTable(L, libName);

        LuaDLL.luaL_getmetatable(L, t.AssemblyQualifiedName);

        if (LuaDLL.lua_isnil(L, -1))
        {
            LuaDLL.lua_pop(L, 1);
            LuaDLL.luaL_newmetatable(L, t.AssemblyQualifiedName);
        }

        if (baseType != null)
        {
            LuaDLL.lua_pushstring(L, "base");
            LuaDLL.luaL_getmetatable(L, baseType.AssemblyQualifiedName);

            if (LuaDLL.lua_isnil(L, -1))
            {
                LuaDLL.lua_pop(L, 1);
                LuaDLL.luaL_newmetatable(L, baseType.AssemblyQualifiedName);
            }

            LuaDLL.lua_rawset(L, -3);
        }

        LuaDLL.lua_pushstring(L, "__index");
        LuaDLL.lua_pushstring(L, "ToLua_Index");
        LuaDLL.lua_rawget(L, (int)LuaIndexes.LUA_REGISTRYINDEX);
        LuaDLL.lua_rawset(L, -3);

        LuaDLL.lua_pushstring(L, "__newindex");
        LuaDLL.lua_pushstring(L, "ToLua_NewIndex");
        LuaDLL.lua_rawget(L, (int)LuaIndexes.LUA_REGISTRYINDEX);
        LuaDLL.lua_rawset(L, -3);

        LuaDLL.lua_pushstring(L, "__call");
        LuaDLL.lua_pushstring(L, "ToLua_TableCall");
        LuaDLL.lua_rawget(L, (int)LuaIndexes.LUA_REGISTRYINDEX);
        LuaDLL.lua_rawset(L, -3);

        LuaDLL.lua_pushstring(L, "__gc");
        LuaDLL.lua_pushstdcallcfunction(L, __gc);
        LuaDLL.lua_rawset(L, -3);

        for (int i = 0; i < regs.Length; i++)
        {
            LuaDLL.lua_pushstring(L, regs[i].name);
            LuaDLL.lua_pushstdcallcfunction(L, regs[i].func);
            LuaDLL.lua_rawset(L, -3);
        }

        for (int i = 0; i < fields.Length; i++)
        {
            LuaDLL.lua_pushstring(L, fields[i].name);
            LuaDLL.lua_createtable(L, 2, 0);

            if (fields[i].getter != null)
            {
                LuaDLL.lua_pushstdcallcfunction(L, fields[i].getter);
                LuaDLL.lua_rawseti(L, -2, 1);
            }

            if (fields[i].setter != null)
            {
                LuaDLL.lua_pushstdcallcfunction(L, fields[i].setter);
                LuaDLL.lua_rawseti(L, -2, 2);
            }

            LuaDLL.lua_rawset(L, -3);
        }

        LuaDLL.lua_setmetatable(L, -2);
        LuaDLL.lua_settop(L, 0);
    }

    public static double GetNumber(IntPtr L, int stackPos)
    {        
        if (LuaDLL.lua_isnumber(L, stackPos))
        {            
            return LuaDLL.lua_tonumber(L, stackPos);
        }
        
        LuaDLL.luaL_typerror(L, stackPos, "number");
        return 0;
    }

    public static bool GetBoolean(IntPtr L, int stackPos)
    {
        if (LuaDLL.lua_isboolean(L, stackPos))
        {            
            return LuaDLL.lua_toboolean(L, stackPos);
        }
        
        LuaDLL.luaL_typerror(L, stackPos, "boolean");
        return false;
    }

    public static string GetString(IntPtr L, int stackPos)
    {
        string str = GetLuaString(L, stackPos);        

        if (str == null)
        {            
            LuaDLL.luaL_typerror(L, stackPos, "string");
        }

        return str;
    }

    public static LuaFunction GetFunction(IntPtr L, int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);

        if (luatype != LuaTypes.LUA_TFUNCTION)
        {
            return null;
        }

        LuaDLL.lua_pushvalue(L, stackPos);        
        return new LuaFunction(LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX), GetTranslator(L).interpreter);   
    }

    public static LuaFunction GetLuaFunction(IntPtr L, int stackPos)
    {
        LuaFunction func = GetFunction(L, stackPos);        

        if (func == null)
        {            
            LuaDLL.luaL_typerror(L, stackPos, "function");
            return null;
        }

        return func;
    }

    static LuaTable GetTable(IntPtr L, int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);        

        if (luatype != LuaTypes.LUA_TTABLE)
        {
            return null;
        }

        LuaDLL.lua_pushvalue(L, stackPos);
        return new LuaTable(LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX), GetTranslator(L).interpreter);
    }

    public static LuaTable GetLuaTable(IntPtr L, int stackPos)
    {
        LuaTable table = GetTable(L, stackPos);

        if (table == null)
        {            
            LuaDLL.luaL_typerror(L, stackPos, "table");
            return null;
        }

        return table;
    }

    public static object GetLuaObject(IntPtr L, int stackPos)
    {           
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);
        object o = null;

        if (luatype == LuaTypes.LUA_TUSERDATA)
        {
            o = GetTranslator(L).getRawNetObject(L, stackPos);
        }
        
        return o;        
    }

    public static T GetNetObject<T>(IntPtr L, int stackPos)
    {
        object obj = GetLuaObject(L, stackPos);        
        

        if (obj == null)
        {
            LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", typeof(T).Name));            
        }

        if (!IsClassOf(obj.GetType(), typeof(T)))
        {
            LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got {1}", typeof(T).Name, obj.GetType().Name));
        }

        return (T)obj;        
    }

    public static T GetUnityObject<T>(IntPtr L, int stackPos)
    {
        object obj = GetLuaObject(L, stackPos);
        Type type = typeof(T);        

        if (obj == null)
        {
            LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", type.Name));
        }
        else
        {
            UnityEngine.Object uObj = obj as UnityEngine.Object;

            if (uObj == null)
            {
                LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", type.Name));
            }
        }

        Type objType = obj.GetType();

        if (type != objType && !objType.IsSubclassOf(type))
        {
            LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got {1}", type.Name, objType.Name));
        }

        return (T)obj;
    }

    public static T GetTrackedObject<T>(IntPtr L, int stackPos)
    {
        object obj = GetLuaObject(L, stackPos);
        Type type = typeof(T);        

        if (obj == null)
        {
            LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", type.Name));
        }
        else
        {
            UnityEngine.TrackedReference uObj = obj as UnityEngine.TrackedReference;

            if (uObj == null)
            {
                LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", type.Name));
            }
        }

        Type objType = obj.GetType();

        if (type != objType && !objType.IsSubclassOf(type))
        {
            LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got {1}", type.Name, objType.Name));
        }

        return (T)obj;
    }

    public static Type GetTypeObject(IntPtr L, int stackPos)
    {
        object obj = GetLuaObject(L, stackPos);

        if (obj == null || obj.GetType() != monoType)
        {            
            LuaDLL.luaL_argerror(L, stackPos, string.Format("Type expected, got {0}", obj == null ? "nil" : obj.GetType().Name));
        }

        return (Type)obj;    
    }

    public static bool IsClassOf(Type child, Type parent)
    {
        return child == parent || parent.IsAssignableFrom(child);
    }

    static ObjectTranslator GetTranslator(IntPtr L)
    {
#if MULTI_STATE
            return ObjectTranslator.FromState(L);
#else
            return _translator;
#endif        
    }

    //压入一个object变量
    public static void PushVarObject(IntPtr L, object o)
    {           
        if (o == null)
        {
            LuaDLL.lua_pushnil(L);
            return;
        }

        Type t = o.GetType();

        if (t.IsValueType)
        {
            if (t == typeof(bool))
            {
                bool b = (bool)o;
                LuaDLL.lua_pushboolean(L, b);
            }
            else if (t.IsEnum)
            {
                Push(L, (System.Enum)o);
            }
            else if (t.IsPrimitive)
            {
                double d = Convert.ToDouble(o);
                LuaDLL.lua_pushnumber(L, d);
            }
            else if (t == typeof(Vector3))
            {
                Push(L, (Vector3)o);
            }
            else if (t == typeof(Vector2))
            {
                Push(L, (Vector2)o);
            }
            else if (t == typeof(Vector4))
            {
                Push(L, (Vector4)o);
            }
            else if (t == typeof(Quaternion))
            {
                Push(L, (Quaternion)o);
            }
            else if (t == typeof(Color))
            {
                Push(L, (Color)o);
            }
            else if (t == typeof(RaycastHit))
            {
                Push(L, (RaycastHit)o);
            }
            else if (t == typeof(Touch))
            {
                Push(L, (Touch)o);
            }
            else if (t == typeof(Ray))
            {
                Push(L, (Ray)o);
            }
            else
            {
                PushValue(L, o);                                
            }
        }
        else
        {
            if (t.IsArray)
            {
                PushArray(L, (System.Array)o);
            }
            else if (t.IsSubclassOf(typeof(Delegate)))
            {
                Push(L, (Delegate)o);
            }
            else if (IsClassOf(t, typeof(IEnumerator)))
            {
                Push(L, (IEnumerator)o);
            }
            else if (t == typeof(string))
            {
                string str = (string)o;
                LuaDLL.lua_pushstring(L, str);
            }
            else if (t.IsSubclassOf(typeof(UnityEngine.Object)))
            {
                UnityEngine.Object obj = (UnityEngine.Object)o;

                if (obj == null)
                {
                    LuaDLL.lua_pushnil(L);                    
                }
                else
                {
                    GetTranslator(L).pushObject(L, o, "luaNet_metatable");                    
                }
            }
            else if (t == typeof(LuaTable))
            {
                ((LuaTable)o).push(L);
            }
            else if (t == typeof(LuaFunction))
            {
                ((LuaFunction)o).push(L);
            }
            else if (t == typeof(LuaCSFunction))
            {
                GetTranslator(L).pushFunction(L, (LuaCSFunction)o);
            }
            else if (t == typeof(Type))
            {
                Push(L, (Type)o);
            }
            else if (t.IsSubclassOf(typeof(TrackedReference)))
            {
                UnityEngine.TrackedReference obj = (UnityEngine.TrackedReference)o;

                if (obj == null)
                {
                    LuaDLL.lua_pushnil(L);                    
                }
                else
                {
                    GetTranslator(L).pushObject(L, o, "luaNet_metatable");
                }
            }
            else
            {
                GetTranslator(L).pushObject(L, o, "luaNet_metatable");
            }
        }
    }

    //压入一个从object派生的变量
    public static void PushObject(IntPtr L, object o)
    {
        GetTranslator(L).pushObject(L, o, "luaNet_metatable");
    }

    public static void Push(IntPtr L, UnityEngine.Object obj)
    {
        PushObject(L, obj == null ? null : obj);
    }

    public static void Push(IntPtr L, TrackedReference obj)
    {
        PushObject(L, obj == null ? null : obj);
    }

    static void PushMetaObject(IntPtr L, object o, string metaName)
    {
        ObjectTranslator translator = GetTranslator(L);
        int index = -1;
        bool found = translator.objectsBackMap.TryGetValue(o, out index);

        if (found)
        {
            LuaDLL.luaL_getmetatable(L, "luaNet_objects");
            LuaDLL.lua_rawgeti(L, -1, index);
            LuaTypes type = LuaDLL.lua_type(L, -1);

            if (type != LuaTypes.LUA_TNIL)
            {
                LuaDLL.lua_remove(L, -2);
                return;
            }

            LuaDLL.lua_remove(L, -1);
            LuaDLL.lua_remove(L, -1);
            translator.collectObject(index);
        }

        index = translator.addObject(o);
        LuaDLL.luaL_getmetatable(L, "luaNet_objects");
        LuaDLL.luanet_newudata(L, index);
        LuaDLL.luaL_getmetatable(L, metaName);
        LuaDLL.lua_setmetatable(L, -2);
        LuaDLL.lua_pushvalue(L, -1);
        LuaDLL.lua_rawseti(L, -3, index);
        LuaDLL.lua_remove(L, -2);
    }

    public static void Push(IntPtr L, Type o)
    {
        PushMetaObject(L, o, typeof(System.Type).AssemblyQualifiedName);
    }

    public static void Push(IntPtr L, Delegate o)
    {
        PushMetaObject(L, o, typeof(Delegate).AssemblyQualifiedName);
    }

    public static void Push(IntPtr L, IEnumerator o)
    {
        PushMetaObject(L, o, typeof(IEnumerator).AssemblyQualifiedName);
    }

    public static void PushArray(IntPtr L, System.Array o)
    {
        PushMetaObject(L, o, "luaNet_array");
    }    

    public static void PushValue(IntPtr L, object obj)
    {
        GetTranslator(L).PushValueResult(L, obj);
    }  

    public static void Push(IntPtr L, bool b)
    {
        LuaDLL.lua_pushboolean(L, b);        
    }

    public static void Push(IntPtr L, string str)
    {
        LuaDLL.lua_pushstring(L, str);
    }

    public static void Push(IntPtr L, char d)
    {
        LuaDLL.lua_pushinteger(L, d);
    }

    public static void Push(IntPtr L, sbyte d)
    {
        LuaDLL.lua_pushinteger(L, d);
    }

    public static void Push(IntPtr L, byte d)
    {
        LuaDLL.lua_pushinteger(L, d);
    }

    public static void Push(IntPtr L, short d)
    {
        LuaDLL.lua_pushinteger(L, d);
    }

    public static void Push(IntPtr L, ushort d)
    {
        LuaDLL.lua_pushinteger(L, d);
    }

    public static void Push(IntPtr L, int d)
    {
        LuaDLL.lua_pushinteger(L, d);
    }

    public static void Push(IntPtr L, uint d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void Push(IntPtr L, long d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void Push(IntPtr L, ulong d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void Push(IntPtr L, float d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void Push(IntPtr L, decimal d)
    {
        LuaDLL.lua_pushnumber(L, (double)d);
    }

    public static void Push(IntPtr L, double d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void Push(IntPtr L, IntPtr p)
    {
        LuaDLL.lua_pushlightuserdata(L, p);
    }

    public static void Push(IntPtr L, ILuaGeneratedType o)
    {
        if (o == null)
        {
            LuaDLL.lua_pushnil(L);
        }
        else
        {
            LuaTable table = o.__luaInterface_getLuaTable();
            table.push(L);
        }
    }

    public static void Push(IntPtr L, LuaTable table)
    {
        if (table == null)
        {
            LuaDLL.lua_pushnil(L);
        }
        else
        {
            table.push(L);
        }
    }

    public static void Push(IntPtr L, LuaFunction func)
    {
        if (func == null)
        {
            LuaDLL.lua_pushnil(L);   
        }
        else
        {
            func.push(L);
        }
    }

    public static void Push(IntPtr L, LuaCSFunction func)
    {
        if (func == null)
        {
            LuaDLL.lua_pushnil(L);
            return;
        }

        GetTranslator(L).pushFunction(L, func);
    }

    public static bool CheckTypes(IntPtr L, int begin, Type type0)
    {
        return CheckType(L, type0, begin);
    }

    public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1)
    {
        return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1);
    }

    public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2)
    {
        return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2);
    }

    public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3)
    {
        return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3);
    }

    public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4)
    {
        return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4);
    }

    public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5)
    {
        return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
               CheckType(L, type5, begin + 5);
    }

    public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6)
    {
        return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
               CheckType(L, type5, begin + 5) && CheckType(L, type6, begin + 6);
    }

    public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7)
    {
        return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
               CheckType(L, type5, begin + 5) && CheckType(L, type6, begin + 6) && CheckType(L, type7, begin + 7);
    }

    public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8)
    {
        return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
               CheckType(L, type5, begin + 5) && CheckType(L, type6, begin + 6) && CheckType(L, type7, begin + 7) && CheckType(L, type8, begin + 8);
    }

    public static bool CheckTypes(IntPtr L, int begin, Type type0, Type type1, Type type2, Type type3, Type type4, Type type5, Type type6, Type type7, Type type8, Type type9)
    {
        return CheckType(L, type0, begin) && CheckType(L, type1, begin + 1) && CheckType(L, type2, begin + 2) && CheckType(L, type3, begin + 3) && CheckType(L, type4, begin + 4) &&
               CheckType(L, type5, begin + 5) && CheckType(L, type6, begin + 6) && CheckType(L, type7, begin + 7) && CheckType(L, type8, begin + 8) && CheckType(L, type9, begin + 9);
    }

    //当进入这里时势必会有一定的gc alloc, 因为params Type[]会分配内存, 可以像上面扩展来避免gc alloc
    public static bool CheckTypes(IntPtr L, int begin, params Type[] types)
    {
        for (int i = 0; i < types.Length; i++)
        {            
            if (!CheckType(L, types[i], i + begin))
            {
                return false;
            }
        }

        return true;
    }

    public static bool CheckParamsType(IntPtr L, Type t, int begin, int count)
    {        
        //默认都可以转 object
        if (t == typeof(object))
        {
            return true;
        }

        for (int i = 0; i < count; i++)
        {            
            if (!CheckType(L, t, i + begin))
            {
                return false;
            }
        }

        return true;
    }    

    static bool CheckTableType(IntPtr L, Type t, int stackPos)
    {
        if (t.IsArray)
        {
            return true;
        }
        else if (t == typeof(LuaTable))
        {
            return true;
        }
        else if (t.IsValueType)
        {
            int oldTop = LuaDLL.lua_gettop(L);
            LuaDLL.lua_pushvalue(L, stackPos);
            LuaDLL.lua_pushstring(L, "class");
            LuaDLL.lua_gettable(L, -2);

            string cls = LuaDLL.lua_tostring(L, -1);
            LuaDLL.lua_settop(L, oldTop);            

            if (cls == "Vector3")
            {
                return t == typeof(Vector3);
            }
            else if (cls == "Vector2")
            {
                return t == typeof(Vector2);
            }
            else if (cls == "Quaternion")
            {
                return t == typeof(Quaternion);
            }
            else if (cls == "Color")
            {
                return t == typeof(Color);
            }
            else if (cls == "Vector4")
            {
                return t == typeof(Vector4);
            }
            else if (cls == "Ray")
            {
                return t == typeof(Ray);
            }
        }

        return false;
    }

    public static bool CheckType(IntPtr L, Type t, int pos)
    {
        if (t == typeof(object))
        {
            return true;
        }

        LuaTypes luaType = LuaDLL.lua_type(L, pos);

        switch (luaType)
        {
            case LuaTypes.LUA_TNUMBER:
                return t.IsPrimitive;
            case LuaTypes.LUA_TSTRING:
                return t == typeof(string);
            case LuaTypes.LUA_TUSERDATA:
                return CheckUserData(L, luaType, t, pos);
            case LuaTypes.LUA_TBOOLEAN:
                return t == typeof(bool);
            case LuaTypes.LUA_TFUNCTION:
                return t == typeof(LuaFunction);
            case LuaTypes.LUA_TTABLE:
                return CheckTableType(L, t, pos);
            case LuaTypes.LUA_TNIL:
                return t == null;
            default:
                break;
        }

        return false;
    }

    static Type monoType = typeof(Type).GetType();

    static bool CheckUserData(IntPtr L, LuaTypes luaType, Type t, int pos)
    {
        if (t == typeof(object))
        {
            return true;
        }

        object obj = GetLuaObject(L, pos);
        Type type = obj.GetType();

        if (t == typeof(Type))
        {                                    
            return type == monoType;
        }  
        else
        {            
            return IsClassOf(type, t);
        }        
    }

    public static object[] GetParamsObject(IntPtr L, int stackPos, int count)
    {
        //ObjectTranslator translator = GetTranslator(L);
        List<object> list = new List<object>();    
        object obj = null;    

        while (count > 0)
        {
            obj = GetVarObject(L, stackPos);

            ++stackPos;
            --count;

            if (obj != null)
            {
                list.Add(obj);
            }
            else
            {
                LuaDLL.luaL_argerror(L, stackPos, "object expected, got nil");                         
                break;
            }
        } 

        return list.ToArray();
    }

    public static T[] GetParamsObject<T>(IntPtr L, int stackPos, int count)
    {
        List<T> list = new List<T>();        
        T obj = default(T);

        while (count > 0)
        {            
            object tmp = GetLuaObject(L, stackPos);

            ++stackPos;
            --count;

            if (tmp != null && tmp.GetType() == typeof(T))
            {
                obj = (T)tmp;
                list.Add(obj);
            }
            else
            {                
                LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", typeof(T).Name));        
                break;
            }
        } 

        return list.ToArray();
    }

    public static T[] GetArrayObject<T>(IntPtr L, int stackPos)
    {
        ObjectTranslator translator = GetTranslator(L);
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);

        if (luatype == LuaTypes.LUA_TTABLE)
        {
            int index = 1;
            T val = default(T);
            List<T> list = new List<T>();
            LuaDLL.lua_pushvalue(L, stackPos);
            Type t = typeof(T);

            do
            {                
                LuaDLL.lua_rawgeti(L, -1, index);
                luatype = LuaDLL.lua_type(L, -1);

                if (luatype == LuaTypes.LUA_TNIL)
                {
                    LuaDLL.lua_pop(L, 1);
                    return list.ToArray();
                }
                else if (!CheckType(L, t, -1))
                {
                    LuaDLL.lua_pop(L, 1);
                    break;
                }                

                val = (T)GetVarObject(L, -1);
                list.Add(val);
                LuaDLL.lua_pop(L, 1);
                ++index;
            } while (true);            
        }
        else if (luatype == LuaTypes.LUA_TUSERDATA)
        {
            T[] ret = GetNetObject<T[]>(L, stackPos);

            if (ret != null)
            {
                return (T[])ret;
            }            
        }

        LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}, pos {1}", GetErrorFunc(1), stackPos));
        return null;
    }

    static string GetErrorFunc(int skip)
    {
        StackFrame sf = null;
        string file = string.Empty;
        StackTrace st = new StackTrace(skip, true);
        int pos = 0;

        do
        {
            sf = st.GetFrame(pos++);
            file = sf.GetFileName();
        } while (!file.Contains("Wrap"));

        int index1 = file.LastIndexOf('\\');
        int index2 = file.LastIndexOf("Wrap");
        string className = file.Substring(index1 + 1, index2 - index1 - 1);
        return string.Format("{0}.{1}", className, sf.GetMethod().Name);                
    }

    public static string GetLuaString(IntPtr L, int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);
        string retVal = null;

        if (luatype == LuaTypes.LUA_TSTRING)
        {
            retVal = LuaDLL.lua_tostring(L, stackPos);
        }
        else if (luatype == LuaTypes.LUA_TUSERDATA)
        {
            object obj = GetLuaObject(L, stackPos);

            if (obj == null)
            {                
                LuaDLL.luaL_argerror(L, stackPos, "string expected, got nil");                
                return string.Empty;
            }

            if (obj.GetType() == typeof(string))
            {
                retVal = (string)obj;
            }
            else
            {
                retVal = obj.ToString();
            }
        }
        else if (luatype == LuaTypes.LUA_TNUMBER)
        {
            double d = LuaDLL.lua_tonumber(L, stackPos);
            retVal = d.ToString();
        }
        else if (luatype == LuaTypes.LUA_TBOOLEAN)
        {
            bool b = LuaDLL.lua_toboolean(L, stackPos);
            retVal = b.ToString();
        }
        else if (luatype == LuaTypes.LUA_TNIL)
        {
            return retVal;
        }
        else
        {
            LuaDLL.lua_getglobal(L, "tostring");
            LuaDLL.lua_pushvalue(L, stackPos);
            LuaDLL.lua_call(L, 1, 1);
            retVal = LuaDLL.lua_tostring(L, -1);
            LuaDLL.lua_pop(L, 1);
        }

        return retVal;
    }

    public static string[] GetParamsString(IntPtr L, int stackPos, int count)
    {
        List<string> list = new List<string>();
        string obj = null;

        while (count > 0)
        {
            obj = GetLuaString(L, stackPos);
            ++stackPos;
            --count;

            if (obj == null)
            {                
                LuaDLL.luaL_argerror(L, stackPos, "string expected, got nil");    
                break;
            }

            list.Add(obj);
        } 

        return list.ToArray();
    }

    public static string[] GetArrayString(IntPtr L, int stackPos)
    {        
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);

        if (luatype == LuaTypes.LUA_TTABLE)
        {
            int index = 1;
            string retVal = null;
            List<string> list = new List<string>();
            LuaDLL.lua_pushvalue(L, stackPos);

            while(true)
            {                
                LuaDLL.lua_rawgeti(L, -1, index);
                luatype = LuaDLL.lua_type(L, -1);

                if (luatype == LuaTypes.LUA_TNIL)
                {
                    return list.ToArray();
                }
                else
                {
                    retVal = GetLuaString(L, -1);
                }
                
                list.Add(retVal);
                LuaDLL.lua_pop(L, 1);
                ++index;
            }
        }
        else if (luatype == LuaTypes.LUA_TUSERDATA)
        {
            string[] ret = GetNetObject<string[]>(L, stackPos);

            if (ret != null)
            {
                return (string[])ret;
            }
        }

        LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}, pos {1}", GetErrorFunc(1), stackPos));           
        return null;
    }

    public static T[] GetArrayNumber<T>(IntPtr L, int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);

        if (luatype == LuaTypes.LUA_TTABLE)
        {
            int index = 1;
            T ret = default(T);
            List<T> list = new List<T>();
            LuaDLL.lua_pushvalue(L, stackPos);

            while(true)
            {
                LuaDLL.lua_rawgeti(L, -1, index);
                luatype = LuaDLL.lua_type(L, -1);

                if (luatype == LuaTypes.LUA_TNIL)
                {
                    return list.ToArray();
                }
                else if (luatype != LuaTypes.LUA_TNUMBER)
                {
                    break;
                }

                ret = (T)Convert.ChangeType(LuaDLL.lua_tonumber(L, -1), typeof(T));
                list.Add(ret);
                LuaDLL.lua_pop(L, 1);
                ++index;
            }
        }
        else if (luatype == LuaTypes.LUA_TUSERDATA)
        {
            T[] ret = GetNetObject<T[]>(L, stackPos);

            if (ret != null)
            {
                return (T[])ret;
            }            
        }

        LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}, pos {1}", GetErrorFunc(1), stackPos));   
        return null;
    }

    public static bool[] GetArrayBool(IntPtr L, int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);

        if (luatype == LuaTypes.LUA_TTABLE)
        {
            int index = 1;            
            List<bool> list = new List<bool>();
            LuaDLL.lua_pushvalue(L, stackPos);

            while (true)
            {
                LuaDLL.lua_rawgeti(L, -1, index);
                luatype = LuaDLL.lua_type(L, -1);

                if (luatype == LuaTypes.LUA_TNIL)
                {
                    return list.ToArray();
                }
                else if (luatype != LuaTypes.LUA_TNUMBER)
                {
                    break;
                }

                bool ret = LuaDLL.lua_toboolean(L, -1);
                list.Add(ret);
                LuaDLL.lua_pop(L, 1);
                ++index;
            }
        }
        else if (luatype == LuaTypes.LUA_TUSERDATA)
        {
            bool[] ret = GetNetObject<bool[]>(L, stackPos);

            if (ret != null)
            {
                return (bool[])ret;
            }
        }

        LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}, pos {1}", GetErrorFunc(1), stackPos));
        return null;
    }    

    public static LuaStringBuffer GetStringBuffer(IntPtr L, int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);

        if (luatype == LuaTypes.LUA_TNIL)
        {
            return null;
        }
        else if (luatype != LuaTypes.LUA_TSTRING)
        {            
            LuaDLL.luaL_typerror(L, stackPos, "string");
            return null;
        }

        int len = 0;
        IntPtr buffer = LuaDLL.lua_tolstring(L, stackPos, out len);
        return new LuaStringBuffer(buffer, (int)len);                
    }

    public static void SetValueObject(IntPtr L, int pos, object obj)
    {
        GetTranslator(L).SetValueObject(L, pos, obj);
    }

    public static void CheckArgsCount(IntPtr L, int count)
    {
        int c = LuaDLL.lua_gettop(L);

        if (c != count)
        {
            string str = string.Format("no overload for method '{0}' takes '{1}' arguments", GetErrorFunc(1), c);
            LuaDLL.luaL_error(L, str);
        }
    }

    public static object GetVarTable(IntPtr L, int stackPos)
    {
        object o = null;
        int oldTop = LuaDLL.lua_gettop(L);
        LuaDLL.lua_pushvalue(L, stackPos);
        LuaDLL.lua_pushstring(L, "class");
        LuaDLL.lua_gettable(L, -2);

        if (LuaDLL.lua_isnil(L, -1))
        {
            LuaDLL.lua_settop(L, oldTop);
            LuaDLL.lua_pushvalue(L, stackPos);
            o = new LuaTable(LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX), GetTranslator(L).interpreter);            
        }
        else
        {
            string cls = LuaDLL.lua_tostring(L, -1);
            LuaDLL.lua_settop(L, oldTop);

            stackPos = stackPos > 0 ? stackPos : stackPos + oldTop;

            if (cls == "Vector3")
            {                
                o = GetVector3(L, stackPos);
            }
            else if (cls == "Vector2")
            {
                o = GetVector2(L, stackPos);
            }
            else if (cls == "Quaternion")
            {
                o = GetQuaternion(L, stackPos);
            }
            else if (cls == "Color")
            {
                o = GetColor(L, stackPos);
            }
            else if (cls == "Vector4")
            {
                o = GetVector4(L, stackPos);
            }
            else if (cls == "Ray")
            {
                o = GetRay(L, stackPos);
            }
            else
            {
                LuaDLL.lua_pushvalue(L, stackPos);
                o = new LuaTable(LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX), GetTranslator(L).interpreter);      
            }
        }
        
        return o;
    }

    //读取object类型，object为万用类型
    public static object GetVarObject(IntPtr L, int stackPos)
    {        
        LuaTypes type = LuaDLL.lua_type(L, stackPos);

        switch (type)
        {
            case LuaTypes.LUA_TNUMBER:                
                return LuaDLL.lua_tonumber(L, stackPos);                
            case LuaTypes.LUA_TSTRING:                
                return LuaDLL.lua_tostring(L, stackPos);                
            case LuaTypes.LUA_TUSERDATA:
                {
                    int udata = LuaDLL.luanet_rawnetobj(L, stackPos);

                    if (udata != -1)
                    {
                        object obj = null;
                        GetTranslator(L).objects.TryGetValue(udata, out obj);
                        return obj;
                    }
                    else
                    {                        
                        return null;
                    }
                }
            case LuaTypes.LUA_TBOOLEAN:
                return LuaDLL.lua_toboolean(L, stackPos);
            case LuaTypes.LUA_TTABLE:
                return GetVarTable(L, stackPos);
            case LuaTypes.LUA_TFUNCTION:
                LuaDLL.lua_pushvalue(L, stackPos);
                return new LuaFunction(LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX), GetTranslator(L).interpreter);
            default:
                return null;
        }        
    }

    //[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    //public static int Xml_read (IntPtr L) 
    //{
    //    string xml = GetLuaString(L, 1);
    //    Debugger.Log("read {0}", xml);
    //    TextAsset ta = Resources.Load(xml, typeof(TextAsset)) as TextAsset;
    //    IntPtr buffer = LuaDLL.lua_tocbuffer(ta.bytes, ta.bytes.Length);        
    //    LuaDLL.lua_pushlightuserdata(L, buffer);
    //    return 1;
    //}

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    public static int IndexArray(IntPtr L)
    { 
        Array obj = GetLuaObject(L, 1) as Array;

        if (obj == null)
        {
            LuaDLL.luaL_error(L, "trying to index an invalid object reference");
            LuaDLL.lua_pushnil(L);
            return 1;
        }

        LuaTypes luaType = LuaDLL.lua_type(L, 2);

        if (luaType == LuaTypes.LUA_TNUMBER)
        {
            int index = (int)GetNumber(L, 2);            

            if (index >= obj.Length)
            {
                LuaDLL.luaL_error(L, "array index out of bounds: " + index + " " + obj.Length);
                return 0;
            }
            
            object val = obj.GetValue(index);

            if (val == null)
            {
                LuaDLL.luaL_error(L, string.Format("array index {0} is null", index));
                return 0;
            }

            Type et = val.GetType();

            if (et.IsValueType)
            {
                if (et == typeof(Vector3))
                {
                    Push(L, (Vector3)val);                    
                }
                else
                {
                    GetTranslator(L).push(L, val);
                }
            }
            else
            {
                PushObject(L, val);                
            }            
        }
        else if (luaType == LuaTypes.LUA_TSTRING)
        {
            string field = GetLuaString(L, 2);

            if (field == "Length")
            {                
                Push(L, obj.Length);
            }
        }

        return 1;
    }


    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    public static int NewIndexArray(IntPtr L)
    {
        Array obj = GetLuaObject(L, 1) as Array;

        if (obj == null)
        {
            LuaDLL.luaL_error(L, "trying to index and invalid object reference");
            return 0;
        }

        int index = (int)GetNumber(L, 2);
        object val = GetVarObject(L, 3);
        Type type = obj.GetType().GetElementType();        

        if (!CheckType(L, type, 3))
        {
            LuaDLL.luaL_error(L, "trying to set object type is not correct");
            return 0;
        }

        val = Convert.ChangeType(val, type);
        obj.SetValue(val, index);

        return 0;
    }


    public static void DumpStack(IntPtr L)
    {
        int top = LuaDLL.lua_gettop(L);

        for (int i = 1; i < top; i++)
        {
            LuaTypes t = LuaDLL.lua_type(L, i);

            switch(t)
            {
                case LuaTypes.LUA_TSTRING:
                    Debugger.Log(LuaDLL.lua_tostring(L, i));
                    break;
                case LuaTypes.LUA_TBOOLEAN:
                    Debugger.Log(LuaDLL.lua_toboolean(L, i).ToString());
                    break;
                case LuaTypes.LUA_TNUMBER:
                    Debugger.Log(LuaDLL.lua_tonumber(L, i).ToString());
                    break;                
                default:
                    Debugger.Log(LuaDLL.lua_tostring(L, i));
                    break;
            }
        }
    }

    //枚举是值类型
    public static void Push(IntPtr L, System.Enum o)
    {
        int index = GetTranslator(L).addObject(o);
        string metaName = typeof(System.Enum).AssemblyQualifiedName;

        LuaDLL.luanet_newudata(L, index);
        LuaDLL.luaL_getmetatable(L, metaName);                        
        LuaDLL.lua_setmetatable(L, -2);
    }

    public static LuaScriptMgr GetMgrFromLuaState(IntPtr L)
    {
#if MULTI_STATE      
        
        LuaDLL.lua_getglobal(L, "_LuaScriptMgr");
        int pos = (int)GetNumber(L, -1);
        LuaDLL.lua_pop(L, 1);        
        return mgrList[pos];        
#else
        return Instance;
#endif        
    }

    public static void ThrowLuaException(IntPtr L)
    {
        string err = LuaDLL.lua_tostring(L, -1);        
        if (err == null) err = "Unknown Lua Error";
        throw new LuaScriptException(err.ToString(), "");    
    }

    //无缝兼容原生写法 transform.position = v3    
    public static Vector3 GetVector3(IntPtr L, int stackPos)
    {
        int oldTop = LuaDLL.lua_gettop(L);         
        LuaScriptMgr luaMgr = GetMgrFromLuaState(L);                               
        luaMgr.unpackVec3.push(L);        

        LuaDLL.lua_pushvalue(L, stackPos);  
        float x = 0,y = 0,z = 0;

        if (LuaDLL.lua_pcall(L, 1, -1, 0) == 0)
        {
            x = (float)LuaDLL.lua_tonumber(L, oldTop + 1);
            y = (float)LuaDLL.lua_tonumber(L, oldTop + 2);
            z = (float)LuaDLL.lua_tonumber(L, oldTop + 3);
        }
        else
        {
            ThrowLuaException(L);
        }
            
        LuaDLL.lua_settop(L, oldTop);
        return new Vector3(x, y, z);
    }

    public static void Push(IntPtr L, Vector3 v3)
    {
        LuaScriptMgr luaMgr = GetMgrFromLuaState(L);        
        luaMgr.packVec3.push(L);
        LuaScriptMgr.Push(L, v3.x);
        LuaScriptMgr.Push(L, v3.y);
        LuaScriptMgr.Push(L, v3.z);

        if (LuaDLL.lua_pcall(L, 3, -1, 0) != 0)
        {
            ThrowLuaException(L);
        }        
    }

    public static void Push(IntPtr L, Quaternion q)
    {
        LuaScriptMgr luaMgr = GetMgrFromLuaState(L);        
        luaMgr.packQuat.push(L);
        LuaScriptMgr.Push(L, q.x);
        LuaScriptMgr.Push(L, q.y);
        LuaScriptMgr.Push(L, q.z);
        LuaScriptMgr.Push(L, q.w);

        if (LuaDLL.lua_pcall(L, 4, -1, 0) != 0)
        {
            ThrowLuaException(L);
        }        
    }

    public static Quaternion GetQuaternion(IntPtr L, int stackPos)
    {
        int oldTop = LuaDLL.lua_gettop(L);
        LuaScriptMgr luaMgr = GetMgrFromLuaState(L);        
        luaMgr.unpackQuat.push(L);

        LuaDLL.lua_pushvalue(L, stackPos);
        float x = 0, y = 0, z = 0, w =1;

        if (LuaDLL.lua_pcall(L, 1, -1, 0) == 0)
        {
            x = (float)LuaDLL.lua_tonumber(L, oldTop + 1);
            y = (float)LuaDLL.lua_tonumber(L, oldTop + 2);
            z = (float)LuaDLL.lua_tonumber(L, oldTop + 3);
            w = (float)LuaDLL.lua_tonumber(L, oldTop + 4);
        }
        else
        {
            ThrowLuaException(L);
        }

        LuaDLL.lua_settop(L, oldTop);
        return new Quaternion(x, y, z, w);
    }

    public static Vector2 GetVector2(IntPtr L, int stackPos)
    {
        int oldTop = LuaDLL.lua_gettop(L);
        LuaScriptMgr luaMgr = GetMgrFromLuaState(L);        
        luaMgr.unpackVec2.push(L);

        LuaDLL.lua_pushvalue(L, stackPos);
        float x = 0, y = 0;

        if (LuaDLL.lua_pcall(L, 1, -1, 0) == 0)
        {
            x = (float)LuaDLL.lua_tonumber(L, oldTop + 1);
            y = (float)LuaDLL.lua_tonumber(L, oldTop + 2);            
        }
        else
        {
            ThrowLuaException(L);
        }

        LuaDLL.lua_settop(L, oldTop);
        return new Vector2(x, y);
    }

    public static void Push(IntPtr L, Vector2 v2)
    {
        LuaScriptMgr luaMgr = GetMgrFromLuaState(L);
        luaMgr.packVec2.push(L);
        LuaScriptMgr.Push(L, v2.x);
        LuaScriptMgr.Push(L, v2.y);        

        if (LuaDLL.lua_pcall(L, 2, -1, 0) != 0)
        {
            ThrowLuaException(L);
        }
    }

    public static Vector4 GetVector4(IntPtr L, int stackPos)
    {
        int oldTop = LuaDLL.lua_gettop(L);
        LuaScriptMgr luaMgr = GetMgrFromLuaState(L);
        luaMgr.unpackVec4.push(L);

        LuaDLL.lua_pushvalue(L, stackPos);
        float x = 0, y = 0, z = 0, w = 0;

        if (LuaDLL.lua_pcall(L, 1, -1, 0) == 0)
        {
            x = (float)LuaDLL.lua_tonumber(L, oldTop + 1);
            y = (float)LuaDLL.lua_tonumber(L, oldTop + 2);
            z = (float)LuaDLL.lua_tonumber(L, oldTop + 3);
            w = (float)LuaDLL.lua_tonumber(L, oldTop + 4);
        }
        else
        {
            ThrowLuaException(L);
        }

        LuaDLL.lua_settop(L, oldTop);
        return new Vector4(x, y, z, w);
    }

    public static void Push(IntPtr L, Vector4 v4)
    {
        LuaScriptMgr luaMgr = GetMgrFromLuaState(L);
        luaMgr.packVec4.push(L);
        LuaScriptMgr.Push(L, v4.x);
        LuaScriptMgr.Push(L, v4.y);
        LuaScriptMgr.Push(L, v4.z);
        LuaScriptMgr.Push(L, v4.w);

        if (LuaDLL.lua_pcall(L, 4, -1, 0) != 0)
        {
            ThrowLuaException(L);
        }  
    }

    public static void Push(IntPtr L, RaycastHit hit)
    {
        LuaScriptMgr luaMgr = GetMgrFromLuaState(L);
        luaMgr.packRaycastHit.push(L);

        Push(L, hit.collider);
        Push(L, hit.distance);
        Push(L, hit.normal);
        Push(L, hit.point);
        Push(L, hit.rigidbody);
        Push(L, hit.transform);

        if (LuaDLL.lua_pcall(L, 6, -1, 0) != 0)
        {
            ThrowLuaException(L);
        }    
    }

    public static void Push(IntPtr L, Ray ray)
    {        
        LuaScriptMgr luaMgr = GetMgrFromLuaState(L);        
        luaMgr.packRay.push(L);

        Push(L, ray.direction);
        Push(L, ray.origin);

        if (LuaDLL.lua_pcall(L, 2, -1, 0) != 0)
        {
            ThrowLuaException(L);
        }        
    }

    public static Ray GetRay(IntPtr L, int stackPos)
    {
        int oldTop = LuaDLL.lua_gettop(L);
        LuaScriptMgr luaMgr = GetMgrFromLuaState(L);
        luaMgr.unpackRay.push(L);

        LuaDLL.lua_pushvalue(L, stackPos);
        float x = 0, y = 0, z = 0;
        Vector3 dir = new Vector3();
        Vector3 origin = new Vector3();

        if (LuaDLL.lua_pcall(L, 1, -1, 0) == 0)
        {
            x = (float)LuaDLL.lua_tonumber(L, oldTop + 1);
            y = (float)LuaDLL.lua_tonumber(L, oldTop + 2);
            z = (float)LuaDLL.lua_tonumber(L, oldTop + 3);
            origin.Set(x, y, z);
            x = (float)LuaDLL.lua_tonumber(L, oldTop + 4);
            y = (float)LuaDLL.lua_tonumber(L, oldTop + 5);
            z = (float)LuaDLL.lua_tonumber(L, oldTop + 6);
            dir.Set(x, y, z);
        }
        else
        {
            ThrowLuaException(L);
        }

        LuaDLL.lua_settop(L, oldTop);
        return new Ray(origin, dir);
    }    

    public static Color GetColor(IntPtr L, int stackPos)
    {
        int oldTop = LuaDLL.lua_gettop(L);      
        LuaScriptMgr luaMgr = GetMgrFromLuaState(L);                          
        luaMgr.unpackColor.push(L);

        LuaDLL.lua_pushvalue(L, stackPos);
        float r = 0, g = 0, b = 0, a = 0;

        if (LuaDLL.lua_pcall(L, 1, -1, 0) == 0)
        {
            r = (float)LuaDLL.lua_tonumber(L, oldTop + 1);
            g = (float)LuaDLL.lua_tonumber(L, oldTop + 2);
            b = (float)LuaDLL.lua_tonumber(L, oldTop + 3);
            a = (float)LuaDLL.lua_tonumber(L, oldTop + 4);
        }
        else
        {
            ThrowLuaException(L);
        }

        LuaDLL.lua_settop(L, oldTop);
        return new Color(r, g, b, a);
    }

    public static void Push(IntPtr L, Color clr)
    {
        LuaScriptMgr luaMgr = GetMgrFromLuaState(L);            
        luaMgr.packColor.push(L);
        LuaScriptMgr.Push(L, clr.r);
        LuaScriptMgr.Push(L, clr.g);
        LuaScriptMgr.Push(L, clr.b);
        LuaScriptMgr.Push(L, clr.a);

        if (LuaDLL.lua_pcall(L, 4, -1, 0) != 0)
        {
            ThrowLuaException(L);
        }        
    }

    public static void Push(IntPtr L, Touch touch)
    {
        LuaScriptMgr luaMgr = GetMgrFromLuaState(L);           
        luaMgr.packTouch.push(L);

        Push(L, touch.fingerId);
        Push(L, touch.position);
        Push(L, touch.rawPosition);
        Push(L, touch.deltaPosition);
        Push(L, touch.deltaTime);
        Push(L, touch.tapCount);
        Push(L, touch.phase);

        if (LuaDLL.lua_pcall(L, 7, -1, 0) != 0)
        {
            ThrowLuaException(L);
        }        
    }


    public static void PushTraceBack(IntPtr L)
    {
#if !MULTI_STATE
        traceback.push();
#else
        LuaDLL.lua_getglobal(L, "traceback");
#endif
    }

}
