using System;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Reflection;
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
    Dictionary<string, LuaFunction> dict = null;
    Dictionary<string, LuaTable> luaTables = null;
    //IAssetFile file = null;
    static ObjectTranslator _translator = null;

    //List<GCHandle> handleList = null;

    string luaIndex =
    @"        
        local rawget = rawget
        local getmetatable = getmetatable
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

    public LuaScriptMgr()
    {
        Instance = this;
        LuaStatic.LoadLua = Loader;
        lua = new LuaState();
        _translator = lua.GetTranslator();        
        LuaDLL.luaopen_pb(lua.L);
        //LuaDLL.luaopen_LuaXML(l.L);
                
        fileList = new HashSet<string>();
        dict = new Dictionary<string,LuaFunction>();
        luaTables = new Dictionary<string, LuaTable>();        

        LuaDLL.lua_pushstring(lua.L, "ToLua_Index");
        LuaDLL.luaL_dostring(lua.L, luaIndex);        
        LuaDLL.lua_rawset(lua.L, (int)LuaIndexes.LUA_REGISTRYINDEX);

        LuaDLL.lua_pushstring(lua.L, "ToLua_NewIndex");
        LuaDLL.luaL_dostring(lua.L, luaNewIndex);
        LuaDLL.lua_rawset(lua.L, (int)LuaIndexes.LUA_REGISTRYINDEX);

        Bind();

        //CmdTable.RegisterCommand("ToLua", ToLua.Generate);
        //CmdTable.RegisterCommand("LuaGC", LuaGC);        
    }

    void Bind()
    {
        IntPtr L = lua.L;
        LuaBinder.Bind(L);
    }

    public void ReloadAll()
    {
        dict.Clear();

        foreach (string str in fileList)
        {
            lua.DoFile(str, null);
        }        

        CallLuaFunction("RegisterTypes");

        Debugger.Log("Reload lua files over");
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
        CallLuaFunction("LuaGC");
    }

    public void Start()
    {
        //AssetFileMgr.Instance.Open(Const.LuaResId, OnCommonLoad);
        //CmdTable.RegisterCommand("PrintLua", PrintLua);        
    }

    //void OnCommonLoad(IAssetFile assetFile)
    //{
    //    file = assetFile;        
    //    DoFile("Golbal.lua");        
                                             
    //    CallLuaFunction("RegisterTypes");                                

    //    //DoFile("person_pb.lua");
    //    //DoFile("test.lua");
    //    Debugger.Log("Lua module start");
    //}

    public void TestLua()
    {
        CallLuaFunction("Test11");                
    }

    public void Destroy()
    {        
        Instance = null;        

        foreach(KeyValuePair<string, LuaFunction> kv in dict)
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
        LuaFunction func = null;

        if (!dict.TryGetValue(name, out func))
        {
            func = lua.GetFunction(name);

            if (func == null)
            {
                Debugger.LogError(string.Format("Lua Function {0} does not exist", name));
                return null;
            }

            dict.Add(name, func);
        }

        return func.Call(args);
    }

    public LuaFunction GetLuaFunction(string name)
    {
        LuaFunction func = null;

        if (!dict.TryGetValue(name, out func))
        {
            func = lua.GetFunction(name);

            if (func == null)
            {
                Debugger.LogError(string.Format("Lua Function {0} does not exist", name));
                return null;
            }

            dict.Add(name, func);
        }

        return func;
    }

    public bool IsFuncExists(string name)
    {
        return lua.GetFunction(name) != null;
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

        return str;
    }

    public LuaTable GetLuaTable(string tableName)
    {
        LuaTable lt = null;

        if (!luaTables.TryGetValue(tableName, out lt))
        {
            lt = lua.GetTable(tableName);
            luaTables.Add(tableName, lt);            
        }

        return lt;
    }

    public static void RegisterLib(IntPtr L, string libName, LuaEnum[] enums)
    {
        LuaDLL.lua_getglobal(L, libName);

        if (LuaDLL.lua_isnil(L, -1))
        {
            LuaDLL.lua_pop(L, 1);
            LuaDLL.lua_createtable(L, 0, enums.Length);
        }

        for (int i = 0; i < enums.Length; i++)
        {
            LuaDLL.lua_pushstring(L, enums[i].name);
            LuaDLL.lua_pushnumber(L, enums[i].val);
            LuaDLL.lua_rawset(L, -3);
        }

        LuaDLL.lua_setglobal(L, libName);
        LuaDLL.lua_settop(L, 0);
    }

    public static void RegisterLib(IntPtr L, string libName, LuaMethod[] regs)
    {           
        LuaDLL.lua_getglobal(L, libName);

        if (LuaDLL.lua_isnil(L, -1))
        {
            LuaDLL.lua_pop(L, 1);
            LuaDLL.lua_createtable(L, 0, regs.Length);                  
        }

        for (int i = 0; i < regs.Length; i++)
        {                        
            LuaDLL.lua_pushstring(L, regs[i].name);
            LuaDLL.lua_pushstdcallcfunction(L, regs[i].func);
            LuaDLL.lua_rawset(L, -3);                    
        }

        LuaDLL.lua_setglobal(L, libName);        
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

    public static void RegisterLib(IntPtr L, string name, Type t, LuaMethod[] regs, LuaField[] fields, string baseName)
    {        
        LuaDLL.lua_getglobal(L, name);

        if (LuaDLL.lua_isnil(L, -1))
        {
            LuaDLL.lua_pop(L, 1);
            LuaDLL.lua_createtable(L, 0, regs.Length);
            LuaDLL.lua_pushvalue(L, -1);
            LuaDLL.lua_setglobal(L, name);
        }

        LuaDLL.luaL_getmetatable(L, t.AssemblyQualifiedName);

        if (LuaDLL.lua_isnil(L, -1))
        {
            LuaDLL.lua_pop(L, 1);
            LuaDLL.luaL_newmetatable(L, t.AssemblyQualifiedName);
        }

        if (baseName != null)
        {            
            LuaDLL.lua_pushstring(L, "base");
            LuaDLL.lua_getglobal(L, baseName);                        
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

    public static object GetLuaObject(IntPtr L, int stackPos)
    {
#if MULTI_STATE
        ObjectTranslator translator = ObjectTranslator.FromState(L);
#else
        ObjectTranslator translator = _translator;
#endif
        LuaTypes luatype = LuaDLL.lua_type(L, stackPos);

        if (luatype == LuaTypes.LUA_TUSERDATA)
        {
            return translator.getRawNetObject(L, stackPos);
        }

        return null;        
    }

    public static object GetNetObject(IntPtr L, int stackPos)
    {
        object obj = GetLuaObject(L, stackPos);

        if (obj == null)
        {
            LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}", GetErrorFunc(1)));
        }

        return obj;        
    }

    public static void PushResult(IntPtr L, object o)
    {
#if MULTI_STATE
        ObjectTranslator translator = ObjectTranslator.FromState(L);
#else
        ObjectTranslator translator = _translator;
#endif
        translator.PushResult(L, o);
    }

    public static void PushResult(IntPtr L, UnityEngine.Object obj)
    {
        object o = (object)obj;
        PushResult(L, o);
    }

    public static void PushResult(IntPtr L, bool b)
    {
        LuaDLL.lua_pushboolean(L, b);
    }

    public static void PushResult(IntPtr L, string str)
    {
        LuaDLL.lua_pushstring(L, str);
    }

    public static void PushResult(IntPtr L, char d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void PushResult(IntPtr L, sbyte d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void PushResult(IntPtr L, byte d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void PushResult(IntPtr L, short d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void PushResult(IntPtr L, ushort d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void PushResult(IntPtr L, int d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void PushResult(IntPtr L, uint d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void PushResult(IntPtr L, long d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void PushResult(IntPtr L, ulong d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void PushResult(IntPtr L, float d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void PushResult(IntPtr L, decimal d)
    {
        LuaDLL.lua_pushnumber(L, (double)d);
    }

    public static void PushResult(IntPtr L, double d)
    {
        LuaDLL.lua_pushnumber(L, d);
    }

    public static void PushResult(IntPtr L, ILuaGeneratedType o)
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

    public static void PushResult(IntPtr L, LuaTable lt)
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

    public static void PushResult(IntPtr L, LuaFunction func)
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

    public static void PushResult(IntPtr L, LuaCSFunction func)
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
        //默认都可以转 string
        if (t == typeof(string) || t == typeof(object))
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
        if (t == typeof(bool))
        {
            return luaType == LuaTypes.LUA_TBOOLEAN;
        }
        else if (t == typeof(string))
        {
            return luaType == LuaTypes.LUA_TSTRING || luaType == LuaTypes.LUA_TUSERDATA;
        }
        else if (t.IsPrimitive || t.IsEnum)
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
    }

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
            LuaTypes luatype = LuaDLL.lua_type(L, stackPos);            
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
            object ret = GetNetObject(L, stackPos);

            if (ret.GetType() == typeof(T[]))
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
            object ret = GetNetObject(L, stackPos);

            if (ret.GetType() == typeof(string[]))
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

            do
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
            } while (true);            
        }
        else if (luatype == LuaTypes.LUA_TUSERDATA)
        {
            object ret = GetNetObject(L, stackPos);

            if (ret.GetType() == typeof(T[]))
            {
                return (T[])ret;
            }            
        }

        LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}", GetErrorFunc(1)));   
        return null;
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

    public static object GetVarObject(IntPtr L, int stackPos)
    {
#if MULTI_STATE
        ObjectTranslator translator = ObjectTranslator.FromState(L);
#else
        ObjectTranslator translator = _translator;
#endif
        return translator.getObject(L, stackPos);
    }
}
