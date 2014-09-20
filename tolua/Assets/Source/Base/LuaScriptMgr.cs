/* designed by topameng. this is only ver0.9
 * 1.0 more fast version is coming soon
*/

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

    LuaState l;
    HashSet<string> fileList = null;
    Dictionary<string, LuaFunction> dict = null;
    Dictionary<string, LuaTable> luaTables = null;    
    ObjectTranslator translator = null;
    List<GCHandle> handleList = null;

    public LuaScriptMgr()
    {
        Instance = this;
        l = new LuaState();
        translator = l.GetTranslator();        
        //LuaDLL.luaopen_pb(l.L);                                
                
        fileList = new HashSet<string>();
        dict = new Dictionary<string,LuaFunction>();
        luaTables = new Dictionary<string, LuaTable>();
        InitHandleList();

        //CmdTable.RegisterCommand("GenLua", GenLuaWrap.Generate);
        //CmdTable.RegisterCommand("LuaGC", LuaGC);
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

    void InitHandleList()
    {
        handleList = new List<GCHandle>(128);

        for (int i = 0; i < 128; i++)
        {
            GCHandle handle = GCHandle.Alloc(i, GCHandleType.Pinned);
            handleList.Add(handle);
        }
    }

    public IntPtr GetLuaPtr()
    {
        return l.L;
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

    //    DoFile("person_pb.lua");
    //    DoFile("test.lua");
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

        l.Close();
        l.Dispose();
        l = null;

        for (int i = 0; i < handleList.Count; i++)
        {
            handleList[i].Free();
        }

        handleList.Clear();
        Debugger.Log("Lua module destroy");
    }

    public object[] DoString(string str)
    {
        return l.DoString(str);
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
            return l.DoFile(fileName, null);                  
        }

        return null;
    }

    public object[] CallLuaFunction(string name, params object[] args)
    {
        LuaFunction func = null;

        if (!dict.TryGetValue(name, out func))
        {
            func = l.GetFunction(name);

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
            func = l.GetFunction(name);

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
        return l.GetFunction(name) != null;
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
            lt = l.GetTable(tableName);
            luaTables.Add(tableName, lt);            
        }

        return lt;
    }

    public void ReloadAll()
    {
        dict.Clear();

        foreach (string str in fileList)
        {
            l.DoFile(str, null);
        }

        CallLuaFunction("RegisterTypes");

        Debugger.Log("Reload lua files over");
    }

    public int RegisterLib(string libName, LuaMethod[] regs)
    {
        IntPtr L = l.L;        
        LuaDLL.lua_getglobal(L, libName);

        if (LuaDLL.lua_isnil(L, -1))
        {
            LuaDLL.lua_pop(L, 1);
            LuaDLL.lua_createtable(L, 0, regs.Length);                  
        }

        for (int i = 0; i < regs.Length; i++)
        {            
            IntPtr fn = Marshal.GetFunctionPointerForDelegate(regs[i].func);            
            LuaDLL.lua_pushstdcallcfunction(L, fn);            
            LuaDLL.lua_setfield(L, -2, regs[i].name);            
        }

        LuaDLL.lua_pushvalue(l.L, -1);
        int refence = LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
        LuaDLL.lua_setglobal(L, libName);        
        LuaDLL.lua_settop(L, 0);
        return refence;
    }

    public void CreateMetaTable(string name, LuaMethod[] regs, Type t)
    {
        IntPtr L = l.L;
        LuaDLL.lua_getglobal(l.L, name);

        LuaDLL.luaL_getmetatable(L, t.AssemblyQualifiedName);

        if (LuaDLL.lua_isnil(L, -1))
        {
            LuaDLL.lua_pop(L, 1);
            LuaDLL.luaL_newmetatable(L, t.AssemblyQualifiedName);
        }

        for (int i = 0; i < regs.Length; i++)
        {
            IntPtr fn = Marshal.GetFunctionPointerForDelegate(regs[i].func);
            LuaDLL.lua_pushstdcallcfunction(L, fn);
            LuaDLL.lua_setfield(L, -2, regs[i].name);
        }
        
        LuaDLL.lua_pushstdcallcfunction(L, __gc);
        LuaDLL.lua_setfield(L, -2, "__gc");

        LuaDLL.lua_setmetatable(l.L, -2);
        LuaDLL.lua_settop(L, 0);
    }

    //public void RegLibFunc(string lib, string name, LuaCSFunction func)
    //{
    //    IntPtr L = l.L;
    //    LuaDLL.lua_getglobal(L, lib);

    //    IntPtr fn = Marshal.GetFunctionPointerForDelegate(func);
    //    LuaDLL.lua_pushstdcallcfunction(L, fn);
    //    LuaDLL.lua_setfield(L, -2, name);

    //    LuaDLL.lua_settop(L, 0);
    //}

    public void RegisterField(Type t, LuaField[] regs)
    {
        IntPtr L = l.L;
        LuaDLL.luaL_getmetatable(L, t.AssemblyQualifiedName);

        for (int i = 0; i < regs.Length; i++)
        {                
            IntPtr ptr = GCHandle.ToIntPtr(handleList[i]);
            LuaDLL.lua_pushlightuserdata(L, ptr);
            LuaDLL.lua_setfield(L, -2, regs[i].name);
        }

        LuaDLL.lua_settop(L, 0);
    }

    void RawGetField(IntPtr L, int reference, string field)
    {
        LuaDLL.lua_getref(L, reference);
        LuaDLL.lua_pushstring(L, field);
        LuaDLL.lua_rawget(L, -2);

        if (LuaDLL.lua_isnil(L, -1))
        {
            LuaDLL.lua_pop(L, 1);

            if (LuaDLL.lua_getmetatable(L, -1) > 0)
            {
                LuaDLL.lua_pushstring(L, field);
                LuaDLL.lua_rawget(L, -2);
            }
        }
    }

    public bool Index(int reference, string field, LuaField[] getter)
    {
        IntPtr L = l.L;
        RawGetField(L, reference, field);
        LuaTypes type = LuaDLL.lua_type(L, -1);

        if (type == LuaTypes.LUA_TFUNCTION)
        {
            return true;
        }
        else if (type == LuaTypes.LUA_TLIGHTUSERDATA)
        {
            IntPtr ptr = LuaDLL.lua_touserdata(L, -1);
            LuaDLL.lua_pop(L, 1);
            
            GCHandle handle = GCHandle.FromIntPtr(ptr);
            int pos = (int)handle.Target;
            Func<IntPtr, bool> func = getter[pos].getter;

            if (func != null)
            {
                return func(L);                
            }            
        }

        return false;
    }

    public bool NewIndex(int reference, string field, LuaField[] setter)
    {
        IntPtr L = l.L;
        RawGetField(L, reference, field);
        LuaTypes type = LuaDLL.lua_type(L, -1);

        if (type == LuaTypes.LUA_TLIGHTUSERDATA)
        {
            IntPtr thisptr = LuaDLL.lua_touserdata(L, -1);
            LuaDLL.lua_pop(L, 1);
            GCHandle handle = GCHandle.FromIntPtr(thisptr);
            int pos = (int)handle.Target;
            Func<IntPtr, bool> func = setter[pos].getter;

            if (func != null)
            {
                return setter[pos].setter(L);                
            }
        }

        return false;
    }

    public double GetNumber(int stackPos)
    {        
        if (LuaDLL.lua_isnumber(l.L, stackPos))
        {
            return LuaDLL.lua_tonumber(l.L, stackPos);
        }
        
        LuaDLL.luaL_error(l.L, string.Format("The best overloaded method match for '{0}' has some invalid arguments", GetErrorFunc(1)));
        return 0;
    }

    public bool GetBoolean(int stackPos)
    {
        if (LuaDLL.lua_isboolean(l.L, stackPos))
        {
            return LuaDLL.lua_toboolean(l.L, stackPos);
        }
        
        LuaDLL.luaL_error(l.L, string.Format("The best overloaded method match for '{0}' has some invalid arguments", GetErrorFunc(1)));
        return false;
    }

    public string GetString(int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(l.L, stackPos);        

        if (luatype == LuaTypes.LUA_TSTRING)
        {            
            return LuaDLL.lua_tostring(l.L, stackPos);
        }
        else if (luatype == LuaTypes.LUA_TUSERDATA)
        {
           object obj = GetLuaObject(stackPos);

           if (obj != null)
           {
               if (obj.GetType() == typeof(string))
               {
                   return (string)obj;
               }
               else
               {
                   return obj.ToString();
               }
           }
        }
        else if (luatype == LuaTypes.LUA_TNIL)
        {
            return null;
        }
        
        LuaDLL.luaL_error(l.L, string.Format("The best overloaded method match for '{0}' has some invalid arguments", GetErrorFunc(1)));
        return null;
    }

    public LuaFunction GetLuaFunction(int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(l.L, stackPos);

        if (luatype != LuaTypes.LUA_TFUNCTION)
        {
            LuaDLL.luaL_error(l.L, string.Format("The best overloaded method match for '{0}' has some invalid arguments", GetErrorFunc(1)));
            return null;
        }

        LuaDLL.lua_pushvalue(l.L, stackPos);
        return new LuaFunction(LuaDLL.luaL_ref(l.L, LuaIndexes.LUA_REGISTRYINDEX), l);
    }

    public object GetLuaObject(int stackPos)
    {        
        LuaTypes luatype = LuaDLL.lua_type(l.L, stackPos);

        if (luatype == LuaTypes.LUA_TUSERDATA)
        {
            return translator.getRawNetObject(l.L, stackPos);
        }

        return null;        
    }

    public object GetNetObject(int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(l.L, stackPos);

        if (luatype == LuaTypes.LUA_TUSERDATA)
        {
            return translator.getRawNetObject(l.L, stackPos);
        }
        else if (luatype == LuaTypes.LUA_TNIL)
        {
            return null;
        }
    
        LuaDLL.luaL_error(l.L, string.Format("The best overloaded method match for '{0}' has some invalid arguments", GetErrorFunc(1)));        
        return null;        
    }

    public void PushResult(object o)
    {
        translator.push(l.L, o);
    }

    public void LuaBinding(List<Type> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Type t = list[i];
            ILuaWrap wrap = Activator.CreateInstance(t) as ILuaWrap;
            wrap.Register();
        }
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    public static int __gc(IntPtr L)
    {
        int udata = LuaDLL.luanet_rawnetobj(L, 1);

        if (udata != -1 && LuaScriptMgr.Instance != null)
        {            
            LuaScriptMgr.Instance.translator.collectObject(udata);
        }
        else
        {
            //Debugger.Log("not found: " + udata);
        }        

        return 1;
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

    public bool CheckTypes(Type[] types, int begin)
    {
        IntPtr L = l.L;

        for (int i = 0; i < types.Length; i++)
        {
            LuaTypes luaType = LuaDLL.lua_type(L, i + begin);

            if (!CheckType(luaType, types[i], i + begin))
            {
                return false;
            }
        }

        return true;
    }

    bool CheckType(LuaTypes luaType, Type t, int pos)
    {                
        if (t == typeof(bool))
        {
            return luaType == LuaTypes.LUA_TBOOLEAN;
        }
        else if (t == typeof(string))
        {
            return luaType == LuaTypes.LUA_TSTRING;
        }
        else if (t.IsPrimitive || t.IsEnum)
        {
            return luaType == LuaTypes.LUA_TNUMBER;
        }
        else if (t.IsArray)
        {
            return luaType == LuaTypes.LUA_TTABLE || luaType == LuaTypes.LUA_TUSERDATA;
        }
        else if (t.IsInterface || t.IsClass || t.IsValueType)
        {
            if (luaType != LuaTypes.LUA_TUSERDATA)
            {
                return false;
            }
            else if (t == typeof(Type))
            {
                object obj = GetLuaObject(pos);
                string name = obj.GetType().Name;
                return name == "MonoType" || name == "System.MonoType";
            }
            else
            {
                object obj = GetLuaObject(pos);
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

    public T[] GetParamsObject<T>(int stackPos, int count)
    {
        List<T> list = new List<T>();
        T obj = default(T);   

        do
        {            
            obj = (T)GetLuaObject(stackPos);            
            ++stackPos;
            --count;

            if (obj != null && obj.GetType() == typeof(T))
            {
                list.Add(obj);
            }
            else
            {
                LuaDLL.luaL_error(l.L, string.Format("The best overloaded method match for '{0}' has some invalid arguments", GetErrorFunc(1)));
                break;
            }

        } while (count > 0);

        return list.ToArray();
    }

    public T[] GetArrayObject<T>(int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(l.L, stackPos);

        if (luatype == LuaTypes.LUA_TTABLE)
        {
            int index = 1;
            T val = default(T);
            List<T> list = new List<T>();
            LuaDLL.lua_pushvalue(l.L, stackPos);

            do
            {                
                LuaDLL.lua_rawgeti(l.L, -1, index);
                luatype = LuaDLL.lua_type(l.L, -1);

                if (luatype == LuaTypes.LUA_TNIL)
                {
                    return list.ToArray(); ;
                }
                else if (luatype != LuaTypes.LUA_TUSERDATA)
                {
                    break;
                }

                val = (T)translator.getRawNetObject(l.L, -1);
                list.Add(val);
                LuaDLL.lua_pop(l.L, 1);
                ++index;
            } while (true);            
        }
        else if (luatype == LuaTypes.LUA_TUSERDATA)
        {
            object ret = GetNetObject(stackPos);

            if (ret.GetType() == typeof(T[]))
            {
                return (T[])ret;
            }            
        }
        
        LuaDLL.luaL_error(l.L, string.Format("The best overloaded method match for '{0}' has some invalid arguments", GetErrorFunc(1)));
        return null;
    }

    string GetErrorFunc(int skip)
    {
        StackFrame sf = null;
        string file = string.Empty;
        StackTrace st = new StackTrace(skip + 1, true);
        int pos = 0;

        do
        {
            sf = st.GetFrame(pos++);
            file = sf.GetFileName();
        } while (!file.Contains("Wrap"));

        int index1 = file.LastIndexOf('\\');
        int index2 = file.IndexOf("Wrap");
        string className = file.Substring(index1 + 1, index2 - index1 - 1);
        return string.Format("{0}.{1}", className, sf.GetMethod().Name);                
    }

    string GetLuaString(int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(l.L, stackPos);
        string retVal = null;

        if (luatype == LuaTypes.LUA_TSTRING)
        {
            if (!LuaDLL.lua_isstring(l.L, stackPos))
            {                
                return null;
            }

            retVal = LuaDLL.lua_tostring(l.L, stackPos);
        }
        else if (luatype == LuaTypes.LUA_TUSERDATA)
        {
            object obj = GetLuaObject(stackPos);

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
            retVal = (LuaDLL.lua_tonumber(l.L, stackPos)).ToString();
        }
        else if (luatype == LuaTypes.LUA_TBOOLEAN)
        {
            bool b = LuaDLL.lua_toboolean(l.L, stackPos);
            retVal = b.ToString();
        }

        return retVal;
    }

    public string[] GetParamsString(int stackPos, int count)
    {
        List<string> list = new List<string>();
        string obj = null;

        do
        {
            obj = GetLuaString(stackPos);
            ++stackPos;
            --count;

            if (obj == null)
            {
                LuaDLL.luaL_error(l.L, string.Format("The best overloaded method match for '{0}' has some invalid arguments", GetErrorFunc(1)));   
                break;
            }

            list.Add(obj);

        } while (count > 0);

        return list.ToArray();
    }

    public string[] GetArrayString(int stackPos)
    {        
        LuaTypes luatype = LuaDLL.lua_type(l.L, stackPos);

        if (luatype == LuaTypes.LUA_TTABLE)
        {
            int index = 1;
            string retVal = null;
            List<string> list = new List<string>();
            LuaDLL.lua_pushvalue(l.L, stackPos);

            do
            {                
                LuaDLL.lua_rawgeti(l.L, -1, index);
                luatype = LuaDLL.lua_type(l.L, -1);

                if (luatype == LuaTypes.LUA_TNIL)
                {
                    return list.ToArray();
                }
                else if (luatype == LuaTypes.LUA_TUSERDATA)
                {
                    object obj = GetLuaObject(-1);

                    if (obj != null && obj.GetType() == typeof(string))
                    {
                        retVal = (string)obj;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (luatype == LuaTypes.LUA_TSTRING)
                {
                    retVal = LuaDLL.lua_tostring(l.L, -1);                    
                }
                else
                {
                    break;
                }
                
                list.Add(retVal);
                LuaDLL.lua_pop(l.L, 1);
                ++index;
            } while (true);            
        }
        else if (luatype == LuaTypes.LUA_TUSERDATA)
        {
            object ret = GetNetObject(stackPos);

            if (ret.GetType() == typeof(string[]))
            {
                return (string[])ret;
            }
        }

        LuaDLL.luaL_error(l.L, string.Format("The best overloaded method match for '{0}' has some invalid arguments", GetErrorFunc(1)));   
        return null;
    }

    /*public bool GetLuaBool(int stackPos)
    {
        if (!LuaDLL.lua_isboolean(l.L, stackPos))
        {
            LuaDLL.luaL_error(l.L, "invalid bool arguments");
            return false;
        }

        return LuaDLL.lua_toboolean(l.L, stackPos);
    }

    public bool[] GetArrayBool(int stackPos, int count)
    {
        List<bool> list = new List<bool>();
        
        do
        {
            if (!LuaDLL.lua_isboolean(l.L, stackPos))
            {
                break;
            }

            list.Add(LuaDLL.lua_toboolean(l.L, stackPos));
            ++stackPos;
            --count;                
        } while (count > 0);

        return list.ToArray();
    }*/

    /*public T[] GetArrayNumber<T>(int stackPos, int count) where T: struct
    {
        List<T> list = new List<T>();

        do
        {
            if (!LuaDLL.lua_isnumber(l.L, stackPos))
            {
                break;
            }

            T t = (T)Convert.ChangeType(LuaDLL.lua_tonumber(l.L, stackPos), typeof(T));
            list.Add(t);
            ++stackPos;
            --count;
        } while (count > 0);

        return list.ToArray();
    }*/

    public T[] GetArrayNumber<T>(int stackPos)
    {
        LuaTypes luatype = LuaDLL.lua_type(l.L, stackPos);

        if (luatype == LuaTypes.LUA_TTABLE)
        {
            int index = 1;
            T ret = default(T);
            List<T> list = new List<T>();
            LuaDLL.lua_pushvalue(l.L, stackPos);

            do
            {
                LuaDLL.lua_rawgeti(l.L, -1, index);
                luatype = LuaDLL.lua_type(l.L, -1);

                if (luatype == LuaTypes.LUA_TNIL)
                {
                    return list.ToArray();
                }
                else if (luatype != LuaTypes.LUA_TNUMBER)
                {
                    break;
                }

                ret = (T)Convert.ChangeType(LuaDLL.lua_tonumber(l.L, -1), typeof(T));
                list.Add(ret);
                LuaDLL.lua_pop(l.L, 1);
                ++index;
            } while (true);            
        }
        else if (luatype == LuaTypes.LUA_TUSERDATA)
        {
            object ret = GetNetObject(stackPos);

            if (ret.GetType() == typeof(T[]))
            {
                return (T[])ret;
            }            
        }
        
        LuaDLL.luaL_error(l.L, string.Format("The best overloaded method match for '{0}' has some invalid arguments", GetErrorFunc(1)));   
        return null;
    }

    public void PrintStack()
    {
        IntPtr L = l.L;        
        int count = LuaDLL.lua_gettop(L);
        StringBuilder sb = new StringBuilder();        

        for (int i = 0; i < count; i++)
        {
            string str = LuaDLL.lua_tostring(L, i);
            sb.AppendFormat("s{0}:{1}\r\n", i, str);
        }

        Debugger.Log(sb.ToString());
    }

    //public int LuaCall()
    //{
    //    ObjectTranslator translator = ObjectTranslator.FromState(l.L);
    //    LuaCSFunction func = (LuaCSFunction)translator.getRawNetObject(l.L, 1);
    //    LuaDLL.lua_remove(l.L, 1);
    //    return func(l.L);
    //}

    //public bool GetLuaBindingFunc(int reference, string name, int pos)
    //{
    //    //LuaDLL.lua_getglobal(l.L, lib);
    //    LuaDLL.lua_getref(l.L, reference);
    //    LuaDLL.lua_pushstring(l.L, name);
    //    LuaDLL.lua_rawget(l.L, -2);        
    //    LuaTypes type = LuaDLL.lua_type(l.L, -1);
        
    //    if (type == LuaTypes.LUA_TFUNCTION)
    //    {                        
    //        return true;
    //    }

    //    return false;
    //}

    public void SetValueObject(int pos, object obj)
    {
        translator.SetValueObject(l.L, pos, obj);
    }

    public void CheckArgsCount(int count)
    {
        int c = LuaDLL.lua_gettop(l.L);

        if (c != count)
        {
            string str = string.Format("no overload for method '{0}' takes '{1}' arguments", GetErrorFunc(1), c);
            LuaDLL.luaL_error(l.L, str);
        }
    }
}
