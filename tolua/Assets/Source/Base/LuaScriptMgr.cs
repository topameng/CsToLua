using System;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;

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
    //IAssetFile file = null;

    public LockFreeQueue<int> refGCList = null;
    static ObjectTranslator _translator = null;

#if MULTI_STATE
    static List<LuaScriptMgr> mgrList = new List<LuaScriptMgr>();
#endif

    string luaIndex =
    @"        
        local rawget = rawget
        local getmetatable = getmetatable      
        local type = type  
        local function index(obj,name)  
            local o = obj
            repeat                      
	            local meta = getmetatable(o)
	            local v = rawget(meta, name)

	            if type(v) == 'function' then
		            return v
                elseif type(v) == 'table' then
                    local func = v[1]
                    if func ~= nil then
                        return func(obj)
                    end
                end

                o = rawget(meta,'base')
            until o == nil

            error('unknown member name '..name, 2)
            return null	        
        end
        return index";

    string luaNewIndex =
    @"
        local rawget = rawget
        local getmetatable = getmetatable        
        local function newindex(obj, name, val)
            local o = obj
            repeat
		        local meta = getmetatable(o)
	            local v = rawget(meta, name)

		        if v ~= nil then
			        local func = v[2]
                    if func ~= nil then
                        return func(obj, name, val)
                    end
                end

                o = rawget(meta, 'base')
            until o == nil
       
            error('field or property '..name..' does not exist', 2)
            return null		
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
    

    public LuaScriptMgr()
    {
        Instance = this;
        LuaStatic.Load = Loader;
        lua = new LuaState();
        _translator = lua.GetTranslator();             
        LuaDLL.luaopen_pb(lua.L);                       
        //LuaDLL.luaopen_ffi(lua.L);
        //OpenXml();
        //OpenLuaCmd();
                
        fileList = new HashSet<string>();
        dict = new Dictionary<string,LuaBase>();
        refGCList = new LockFreeQueue<int>(2048);

        LuaDLL.lua_pushstring(lua.L, "ToLua_Index");
        LuaDLL.luaL_dostring(lua.L, luaIndex);        
        LuaDLL.lua_rawset(lua.L, (int)LuaIndexes.LUA_REGISTRYINDEX);

        LuaDLL.lua_pushstring(lua.L, "ToLua_NewIndex");
        LuaDLL.luaL_dostring(lua.L, luaNewIndex);
        LuaDLL.lua_rawset(lua.L, (int)LuaIndexes.LUA_REGISTRYINDEX);

        LuaDLL.lua_pushstring(lua.L, "luaTableCall");
        LuaDLL.luaL_dostring(lua.L, luaTableCall);
        LuaDLL.lua_rawset(lua.L, (int)LuaIndexes.LUA_REGISTRYINDEX);        

        Bind();

#if MULTI_STATE
        mgrList.Add(this);
#endif
        //CmdTable.RegisterCommand("ToLua", ToLua.Generate);
        //CmdTable.RegisterCommand("LuaGC", LuaGC);        
    }

    void OpenXml()
    {
        IntPtr L = lua.L;
        LuaDLL.luaopen_LuaXML(L);
        LuaDLL.lua_getglobal(L, "xml");

        LuaDLL.lua_pushstring(L, "read");
        LuaDLL.lua_pushstdcallcfunction(L, Xml_read);
        LuaDLL.lua_rawset(L, -3);

        LuaDLL.lua_settop(L, 0);
    }

    void Bind()
    {
        IntPtr L = lua.L;
        LuaBinder.Bind(L);                
    }

    public void ReloadAll()
    {
        foreach (string str in fileList)
        {
            lua.DoFile(str, null);
        }
        
        //foreach (KeyValuePair<string, LuaFunction> kv in dict)
        //{

        //}
        
        Debugger.Log("Reload lua files over");
    }

    public void Update()
    {
        while (!refGCList.IsEmpty())
        {
            int reference = refGCList.Dequeue();
            LuaDLL.lua_unref(lua.L, reference);
        }
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

    void LuaGC(params string[] param)
    {        
        LuaDLL.lua_gc(lua.L, LuaGCOptions.LUA_GCCOLLECT, 0);        
    }

    public void Start()
    {
        //AssetFileMgr.Instance.Open(Const.LuaResId, OnCommonLoad);
        //CmdTable.RegisterCommand("PrintLua", PrintLua);        
    }

    //void OnCommonLoad(IAssetFile assetFile)
    //{
        //file = assetFile;        
        //DoFile("Golbal.lua");                
        //Debugger.Log("Lua module start");
    //}

    public void Destroy()
    {        
        Instance = null;        

        foreach(KeyValuePair<string, LuaBase> kv in dict)
        {
            kv.Value.Dispose();
        }        

        //file.Close();
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
#if LUA_ZIP
        if (file == null || !file.Contains(fileName))
        {
            return null;
        }
#endif

        if (!fileList.Contains(fileName))
        {
            fileList.Add(fileName);                           
            return lua.DoFile(fileName, null);                  
        }

        return null;
    }

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

        using (FileStream file = new FileStream(path, FileMode.Open))
        {
            str = new byte[(int)file.Length];
            file.Read(str, 0, str.Length);    
            file.Close();        
        }                        
#else
        TextAsset luaCode = file.Read<TextAsset>(name);
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

    public static void RegisterLib(IntPtr L, string libName, LuaEnum[] enums)
    {
        CreateTable(L, libName);

        for (int i = 0; i < enums.Length; i++)
        {
            LuaDLL.lua_pushstring(L, enums[i].name);
            PushEnum(L, enums[i].val);
            LuaDLL.lua_rawset(L, -3);
        }
        
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

    public static void RegisterFunc(IntPtr L, string libName, LuaCSFunction func, string name)
    {
        CreateTable(L, libName);
        
        LuaDLL.lua_pushstring(L, name);
        LuaDLL.lua_pushstdcallcfunction(L, func);
        LuaDLL.lua_rawset(L, -3);

        LuaDLL.lua_settop(L, 0);        
    }

    public static int CreateMetaTable(IntPtr L, string name, LuaMethod[] regs, Type t)
    {        
        LuaDLL.lua_getglobal(L, name);
        LuaDLL.luaL_getmetatable(L, t.AssemblyQualifiedName);

        if (LuaDLL.lua_isnil(L, -1))
        {
            LuaDLL.lua_pop(L, 1);
            LuaDLL.luaL_newmetatable(L, t.AssemblyQualifiedName);
        }

        LuaDLL.lua_pushstring(L, "ToLua_Index");
        LuaDLL.lua_rawget(L, (int)LuaIndexes.LUA_REGISTRYINDEX);
        LuaDLL.lua_setfield(L, -2, "__index");

        LuaDLL.lua_pushstring(L, "ToLua_NewIndex");
        LuaDLL.lua_rawget(L, (int)LuaIndexes.LUA_REGISTRYINDEX);
        LuaDLL.lua_setfield(L, -2, "__newindex");  

        for (int i = 0; i < regs.Length; i++)
        {
            IntPtr fn = Marshal.GetFunctionPointerForDelegate(regs[i].func);
            LuaDLL.lua_pushstring(L, regs[i].name);
            LuaDLL.lua_pushstdcallcfunction(L, fn);
            LuaDLL.lua_rawset(L, -3);            
        }

        LuaDLL.lua_pushvalue(L, -1);
        int refence = LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
        LuaDLL.lua_setmetatable(L, -2);        
        LuaDLL.lua_settop(L, 0);

        return refence;
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

    public static void RegisterLib(IntPtr L, string libName, Type t, LuaMethod[] regs, LuaField[] fields, string baseName)
    {
        CreateTable(L, libName);

        LuaDLL.luaL_getmetatable(L, t.AssemblyQualifiedName);

        if (LuaDLL.lua_isnil(L, -1))
        {
            LuaDLL.lua_pop(L, 1);
            LuaDLL.luaL_newmetatable(L, t.AssemblyQualifiedName);
        }

        if (baseName != null)
        {            
            LuaDLL.lua_pushstring(L, "base");            

            if (PushLuaTable(L, baseName))                                
            {
                LuaDLL.lua_rawset(L, -3);
            }
            else
            {                                
                CreateTable(L, baseName);
                LuaDLL.lua_rawset(L, -3);
            }
        }

        //LuaDLL.lua_pushlightuserdata(L, LuaDLL.luanet_gettag());
        //LuaDLL.lua_pushnumber(L, 1);
        //LuaDLL.lua_rawset(L, -3);

        LuaDLL.lua_pushstring(L, "__index");
        LuaDLL.lua_pushstring(L, "ToLua_Index");
        LuaDLL.lua_rawget(L, (int)LuaIndexes.LUA_REGISTRYINDEX);
        LuaDLL.lua_rawset(L, -3);        

        LuaDLL.lua_pushstring(L, "__newindex");
        LuaDLL.lua_pushstring(L, "ToLua_NewIndex");
        LuaDLL.lua_rawget(L, (int)LuaIndexes.LUA_REGISTRYINDEX);        
        LuaDLL.lua_rawset(L, -3);

        LuaDLL.lua_pushstring(L, "__call");
        LuaDLL.lua_pushstring(L, "luaTableCall");
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
            LuaDLL.lua_createtable(L, 2, 2);

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

        LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}", GetErrorFunc(1)));
        return 0;
    }

    public static bool GetBoolean(IntPtr L, int stackPos)
    {
        if (LuaDLL.lua_isboolean(L, stackPos))
        {
            return LuaDLL.lua_toboolean(L, stackPos);
        }

        LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}", GetErrorFunc(1)));
        return false;
    }

    public static string GetString(IntPtr L, int stackPos)
    {
        string str = GetLuaString(L, stackPos);

        if (str == null)
        {
            LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}", GetErrorFunc(1)));
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
        return new LuaFunction(LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX), L);
    }

    public static LuaFunction GetLuaFunction(IntPtr L, int stackPos)
    {
        LuaFunction func = GetFunction(L, stackPos);

        if (func == null)
        {
            LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}", GetErrorFunc(1)));
            return null;
        }

        return func;
    }

    public static LuaTable GetTable(IntPtr L, int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);

        if (luatype != LuaTypes.LUA_TTABLE)
        {
            return null;
        }

        LuaDLL.lua_pushvalue(L, stackPos);
        return new LuaTable(LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX), L);
    }

    public static LuaTable GetLuaTable(IntPtr L, int stackPos)
    {
        LuaTable table = GetTable(L, stackPos);

        if (table == null)
        {
            LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}", GetErrorFunc(1)));
            return null;
        }

        return table;
    }

    public static object GetLuaObject(IntPtr L, int stackPos)
    {           
#if MULTI_STATE
        ObjectTranslator translator = ObjectTranslator.FromState(L);
#else
        ObjectTranslator translator = _translator;
#endif
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);
        object o = null;

        if (luatype == LuaTypes.LUA_TUSERDATA)
        {
            o = translator.getRawNetObject(L, stackPos);
        }
        
        return o;        
    }

    public static T GetNetObject<T>(IntPtr L, int stackPos)
    {
        object obj = GetLuaObject(L, stackPos);

        if (obj == null || (obj.GetType() != typeof(T) && !typeof(T).IsAssignableFrom(obj.GetType())))
        {
            LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}", GetErrorFunc(1)));
        }

        return (T)obj;        
    }

    public static Type GetTypeObject(IntPtr L, int stackPos)
    {
        object obj = GetLuaObject(L, stackPos);

        if (obj == null || !obj.GetType().Name.Contains("MonoType"))
        {
            LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}", GetErrorFunc(1)));
        }

        return (Type)obj;    
    }

    //压入一个object变量
    public static void PushVarObject(IntPtr L, object o)
    {
#if MULTI_STATE
        ObjectTranslator translator = ObjectTranslator.FromState(L);
#else
        ObjectTranslator translator = _translator;
#endif
        translator.push(L, o);
    }

    public static void Push(IntPtr L, Type t)
    {
        PushObject(L, t);
    }

    public static void Push(IntPtr L, UnityEngine.Object obj)
    {
        PushObject(L, obj == null ? null : obj);
    }

    //压入一个从object派生的变量
    public static void PushObject(IntPtr L, object o)
    {
#if MULTI_STATE
        ObjectTranslator translator = ObjectTranslator.FromState(L);
#else
        ObjectTranslator translator = _translator;
#endif
        translator.pushObject(L, o, "luaNet_metatable");
    }

    public static void PushValue(IntPtr L, object obj)
    {
#if MULTI_STATE
        ObjectTranslator translator = ObjectTranslator.FromState(L);
#else
        ObjectTranslator translator = _translator;
#endif
        translator.PushValueResult(L, obj);
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

    public static void Push(IntPtr L, LuaTable lt)
    {
        if (lt == null)
        {
            LuaDLL.lua_pushnil(L);            
        }
        else
        {
            lt.push(L);
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

#if MULTI_STATE
        ObjectTranslator translator = ObjectTranslator.FromState(L);
#else
        ObjectTranslator translator = _translator;
#endif
        translator.pushFunction(L, func);
    }

    /*public void SetMetaTable(string name1, string name2)
    {
        IntPtr L = l.L;
        LuaDLL.lua_getglobal(l.L, name1);
        LuaDLL.lua_getglobal(L, name2);
        LuaDLL.lua_pushstring(L, "__index");
        LuaDLL.lua_pushvalue(L, -2);
        LuaDLL.lua_settable(L, -4);          
        LuaDLL.lua_settop(L, 0);
    }*/

    public static bool CheckTypes(IntPtr L, Type[] types, int begin)
    {        
        for (int i = 0; i < types.Length; i++)
        {
            LuaTypes luaType = LuaDLL.lua_type(L, i + begin);

            if (!CheckType(L, luaType, types[i], i + begin))
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
            LuaTypes luaType = LuaDLL.lua_type(L, i + begin);

            if (!CheckType(L, luaType, t, i + begin))
            {
                return false;
            }
        }

        return true;
    }

    static bool CheckType(IntPtr L, LuaTypes luaType, Type t, int pos)
    {
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
                return t == typeof(LuaTable) || t.IsArray;
            case LuaTypes.LUA_TNIL:
                break;
            default:
                break;
        }

        return false;
    }

    static bool CheckUserData(IntPtr L, LuaTypes luaType, Type t, int pos)
    {
        if (t == typeof(object))
        {
            return true;
        }

        object obj = GetLuaObject(L, pos);

        if (t.IsEnum || t == typeof(string))
        {
            return obj.GetType() == t;
        }
        else if (t == typeof(Type))
        {
            string name = obj.GetType().Name;
            return name == "MonoType" || name == "System.MonoType";
        }
        else
        {
            return obj.GetType() == t || t.IsAssignableFrom(obj.GetType());
        }
    }

    /*static bool CheckType(IntPtr L, LuaTypes luaType, Type t, int pos)
    {                
        if (t == typeof(bool))
        {
            return luaType == LuaTypes.LUA_TBOOLEAN;
        }
        else if (t == typeof(string))
        {            
            if (luaType == LuaTypes.LUA_TSTRING)
            {
                return true;
            }
            else if (luaType == LuaTypes.LUA_TUSERDATA)
            {
                object obj = GetLuaObject(L, pos);
                return obj.GetType() == t;
            }

            return false;
        }
        else if (t.IsEnum)
        {
            if (luaType != LuaTypes.LUA_TUSERDATA)
            {
                return false;
            }
            else
            {
                object obj = GetLuaObject(L, pos);
                return obj.GetType() == t;
            }
        }
        else if (t.IsPrimitive)
        {
            return luaType == LuaTypes.LUA_TNUMBER;
        }
        else if (t.IsArray)
        {
            return luaType == LuaTypes.LUA_TTABLE || luaType == LuaTypes.LUA_TUSERDATA;
        }
        else if (t == typeof(object))
        {
            return true;
        }
        else if (t.IsInterface || t.IsClass || t.IsValueType)
        {
            if (luaType != LuaTypes.LUA_TUSERDATA)
            {
                return false;
            }
            else if (t == typeof(Type))
            {
                object obj = GetLuaObject(L, pos);
                string name = obj.GetType().Name;
                return name == "MonoType" || name == "System.MonoType";
            }
            else
            {
                object obj = GetLuaObject(L, pos);
                return obj.GetType() == t || t.IsAssignableFrom(obj.GetType());
            }
        }
        else if (t == typeof(LuaFunction))
        {
            return luaType == LuaTypes.LUA_TFUNCTION;        
        }
        else if (t == typeof(LuaTable))
        {
            return luaType == LuaTypes.LUA_TTABLE;
        }
        else if (t == typeof(LuaUserData))
        {
            return luaType == LuaTypes.LUA_TUSERDATA;
        }

        return false;
    }*/

    public static object[] GetParamsObject(IntPtr L, int stackPos, int count)
    {
#if MULTI_STATE
        ObjectTranslator translator = ObjectTranslator.FromState(L);
#else
        ObjectTranslator translator = _translator;
#endif
        List<object> list = new List<object>();    
        object obj = null;    

        while (count > 0)
        {
            //LuaTypes luatype = LuaDLL.lua_type(L, stackPos);
            obj = translator.getObject(L, stackPos);

            ++stackPos;
            --count;

            if (obj != null)
            {
                list.Add(obj);
            }
            else
            {
                LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}", GetErrorFunc(1)));
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
            obj = (T)GetLuaObject(L, stackPos);                        

            ++stackPos;
            --count;

            if (obj != null && obj.GetType() == typeof(T))
            {
                list.Add(obj);
            }
            else
            {
                LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}", GetErrorFunc(1)));
                break;
            }
        } 

        return list.ToArray();
    }

    public static T[] GetArrayObject<T>(IntPtr L, int stackPos)
    {
#if MULTI_STATE
        ObjectTranslator translator = ObjectTranslator.FromState(L);
#else
        ObjectTranslator translator = _translator;
#endif
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);

        if (luatype == LuaTypes.LUA_TTABLE)
        {
            int index = 1;
            T val = default(T);
            List<T> list = new List<T>();
            LuaDLL.lua_pushvalue(L, stackPos);

            do
            {                
                LuaDLL.lua_rawgeti(L, -1, index);
                luatype = LuaDLL.lua_type(L, -1);

                if (luatype == LuaTypes.LUA_TNIL)
                {
                    return list.ToArray(); ;
                }
                else if (luatype != LuaTypes.LUA_TUSERDATA)
                {
                    break;
                }

                val = (T)translator.getRawNetObject(L, -1);
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

        LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}", GetErrorFunc(1)));
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
                LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}", GetErrorFunc(1)));   
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

        LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}", GetErrorFunc(1)));   
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

        LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}", GetErrorFunc(1)));   
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

        LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}", GetErrorFunc(1)));
        return null;
    }    

    public static LuaStringBuffer GetStringBuffer(IntPtr L, int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);

        if (luatype != LuaTypes.LUA_TSTRING)
        {
            LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}", GetErrorFunc(1)));
            return null;
        }

        int len = 0;
        IntPtr buffer = LuaDLL.lua_tolstring(L, stackPos, out len);
        return new LuaStringBuffer(buffer, len);                
    }

    public static void SetValueObject(IntPtr L, int pos, object obj)
    {
#if MULTI_STATE
        ObjectTranslator translator = ObjectTranslator.FromState(L);
#else
        ObjectTranslator translator = _translator;
#endif

        translator.SetValueObject(L, pos, obj);
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

    //读取object类型，object为万用类型
    public static object GetVarObject(IntPtr L, int stackPos)
    {
#if MULTI_STATE
        ObjectTranslator translator = ObjectTranslator.FromState(L);
#else
        ObjectTranslator translator = _translator;
#endif
        return translator.getObject(L, stackPos);
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    public static int Xml_read (IntPtr L) 
    {
        string xml = GetLuaString(L, 1);
        Debugger.Log("read {0}", xml);
        TextAsset ta = Resources.Load(xml, typeof(TextAsset)) as TextAsset;
        IntPtr buffer = LuaDLL.lua_tocbuffer(ta.bytes, ta.bytes.Length);        
        LuaDLL.lua_pushlightuserdata(L, buffer);
        return 1;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    public static int IndexArray(IntPtr L)
    {
#if MULTI_STATE
        ObjectTranslator translator = ObjectTranslator.FromState(L);
#else
        ObjectTranslator translator = _translator;
#endif        
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
            translator.push(L, val);
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
        LuaTypes luaType = LuaDLL.lua_type(L, 3);

        if (!CheckType(L, luaType, type, 3))
        {
            LuaDLL.luaL_error(L, "trying to set object type is not correct");
            return 0;
        }

        val = Convert.ChangeType(val, type);
        obj.SetValue(val, index);

        return 0;
    }

    public static void PushArray(IntPtr L, object o)
    {
#if MULTI_STATE
        ObjectTranslator translator = ObjectTranslator.FromState(L);
#else
        ObjectTranslator translator = _translator;
#endif
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
        LuaDLL.luaL_getmetatable(L, "luaNet_array");

        if (LuaDLL.lua_isnil(L, -1))
        {
            LuaDLL.lua_pop(L, 1);
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
        }

        LuaDLL.luaL_getmetatable(L, "luaNet_objects");
        LuaDLL.luanet_newudata(L, index);
        LuaDLL.lua_pushvalue(L, -3);
        LuaDLL.lua_remove(L, -4);
        LuaDLL.lua_setmetatable(L, -2);
        LuaDLL.lua_pushvalue(L, -1);
        LuaDLL.lua_rawseti(L, -3, index);
        LuaDLL.lua_remove(L, -2);
    }

    //static void CreateArrayMetatable(IntPtr L)
    //{
    //    LuaDLL.luaL_newmetatable(L, "luaNet_array");
    //    LuaDLL.lua_pushstring(L, "__index");
    //    LuaDLL.lua_pushstdcallcfunction(L, IndexArray);
    //    LuaDLL.lua_rawset(L, -3);
    //    LuaDLL.lua_pushstring(L, "__gc");
    //    LuaDLL.lua_pushstdcallcfunction(L, __gc);
    //    LuaDLL.lua_rawset(L, -3);
    //    LuaDLL.lua_pushstring(L, "__newindex");
    //    LuaDLL.lua_pushstdcallcfunction(L, NewIndexArray);
    //    LuaDLL.lua_rawset(L, -3);
    //}

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
                    Debugger.Log(LuaDLL.lua_typename(L, t));
                    break;
            }
        }
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    public static int IsEnumEquals(IntPtr L)
    {
        object arg0 = LuaScriptMgr.GetLuaObject(L, 1);
        object arg1 = LuaScriptMgr.GetLuaObject(L, 1);

        if (arg0 == arg1)
        {
            LuaScriptMgr.Push(L, true);
            return 1;
        }

        bool ret = false;

        if (arg0.GetType() == arg1.GetType())
        {
            try
            {
                int a0 = (int)arg0;
                int a1 = (int)arg1;

                ret = a0 == a1;
            }
            catch
            {
            	
            }
        }

        LuaScriptMgr.Push(L, ret);
        return 1;
    }

    public static void PushEnum(IntPtr L, object o)
    {
#if MULTI_STATE
        ObjectTranslator translator = ObjectTranslator.FromState(L);
#else
        ObjectTranslator translator = _translator;
#endif
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

        LuaDLL.luaL_getmetatable(L, "luaNet_enum");

        if (LuaDLL.lua_isnil(L, -1))
        {
            LuaDLL.lua_pop(L, 1);
            LuaDLL.luaL_newmetatable(L, "luaNet_enum");
            LuaDLL.lua_pushstring(L, "__gc");
            LuaDLL.lua_pushstdcallcfunction(L, __gc);
            LuaDLL.lua_rawset(L, -3);
            LuaDLL.lua_pushstring(L, "__eq");
            LuaDLL.lua_pushstdcallcfunction(L, LuaScriptMgr.IsEnumEquals);
            LuaDLL.lua_rawset(L, -3);
        }

        LuaDLL.luaL_getmetatable(L, "luaNet_objects");
        LuaDLL.luanet_newudata(L, index);
        LuaDLL.lua_pushvalue(L, -3);
        LuaDLL.lua_remove(L, -4);
        LuaDLL.lua_setmetatable(L, -2);
        LuaDLL.lua_pushvalue(L, -1);
        LuaDLL.lua_rawseti(L, -3, index);
        LuaDLL.lua_remove(L, -2);
    }

    public static LuaScriptMgr GetMgrFromLuaState(IntPtr L)
    {
#if MULTI_STATE
        return mgrList.Find((p) => { return p.lua.L == L; });
#else
        return Instance;
#endif        
    }
}
