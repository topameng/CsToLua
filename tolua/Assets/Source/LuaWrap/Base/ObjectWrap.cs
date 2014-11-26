using UnityEngine;
using System;
using LuaInterface;
using Object = UnityEngine.Object;

public class ObjectWrap
{
    public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Equals", Equals),
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("GetInstanceID", GetInstanceID),
		new LuaMethod("Instantiate", Instantiate),
		new LuaMethod("Destroy", Destroy),
		new LuaMethod("DestroyImmediate", DestroyImmediate),
		new LuaMethod("FindObjectsOfType", FindObjectsOfType),
		new LuaMethod("FindObjectOfType", FindObjectOfType),
		new LuaMethod("DontDestroyOnLoad", DontDestroyOnLoad),
		new LuaMethod("DestroyObject", DestroyObject),
		new LuaMethod("ToString", ToString),
		new LuaMethod("New", Create),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__tostring", Lua_ToString),
		new LuaMethod("__eq", Lua_Eq),
	};

    static LuaField[] fields = new LuaField[]
	{
		new LuaField("name", get_name, set_name),
		new LuaField("hideFlags", get_hideFlags, set_hideFlags),
	};

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int Create(IntPtr L)
    {
        int count = LuaDLL.lua_gettop(L);

        if (count == 0)
        {
            Object obj = new Object();
            LuaScriptMgr.Push(L, obj);
            return 1;
        }
        else
        {
            LuaDLL.luaL_error(L, "invalid arguments to method: Object.New");
        }

        return 0;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int GetClassType(IntPtr L)
    {
        LuaScriptMgr.Push(L, typeof(Object));
        return 1;
    }

    public static void Register(IntPtr L)
    {
        LuaScriptMgr.RegisterLib(L, "UnityEngine.Object", typeof(Object), regs, fields, "System.Object");
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int get_name(IntPtr L)
    {
        object o = LuaScriptMgr.GetLuaObject(L, 1);

        if (o == null)
        {
            LuaDLL.luaL_error(L, "unknown member name name");
        }

        Object obj = (Object)o;
        LuaScriptMgr.Push(L, obj.name);
        return 1;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int get_hideFlags(IntPtr L)
    {
        object o = LuaScriptMgr.GetLuaObject(L, 1);

        if (o == null)
        {
            LuaDLL.luaL_error(L, "unknown member name hideFlags");
        }

        Object obj = (Object)o;
        LuaScriptMgr.PushEnum(L, obj.hideFlags);
        return 1;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int set_name(IntPtr L)
    {
        object o = LuaScriptMgr.GetLuaObject(L, 1);

        if (o == null)
        {
            LuaDLL.luaL_error(L, "unknown member name name");
        }

        Object obj = (Object)o;
        obj.name = LuaScriptMgr.GetString(L, 3);
        return 0;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int set_hideFlags(IntPtr L)
    {
        object o = LuaScriptMgr.GetLuaObject(L, 1);

        if (o == null)
        {
            LuaDLL.luaL_error(L, "unknown member name hideFlags");
        }

        Object obj = (Object)o;
        obj.hideFlags = LuaScriptMgr.GetNetObject<HideFlags>(L, 3);
        return 0;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int Lua_ToString(IntPtr L)
    {
        object obj = LuaScriptMgr.GetLuaObject(L, 1);

        if (obj != null)
        {
            LuaScriptMgr.Push(L, obj.ToString());
        }
        else
        {
            LuaScriptMgr.Push(L, "Table: System.Object");
        }

        return 1;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int Equals(IntPtr L)
    {
        LuaScriptMgr.CheckArgsCount(L, 2);
        Object obj = LuaScriptMgr.GetNetObject<Object>(L, 1);
        object arg0 = LuaScriptMgr.GetVarObject(L, 2);
        bool o = obj.Equals(arg0);
        LuaScriptMgr.Push(L, o);
        return 1;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int GetHashCode(IntPtr L)
    {
        LuaScriptMgr.CheckArgsCount(L, 1);
        Object obj = LuaScriptMgr.GetNetObject<Object>(L, 1);
        int o = obj.GetHashCode();
        LuaScriptMgr.Push(L, o);
        return 1;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int GetInstanceID(IntPtr L)
    {
        LuaScriptMgr.CheckArgsCount(L, 1);
        Object obj = LuaScriptMgr.GetNetObject<Object>(L, 1);
        int o = obj.GetInstanceID();
        LuaScriptMgr.Push(L, o);
        return 1;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int Instantiate(IntPtr L)
    {
        int count = LuaDLL.lua_gettop(L);

        if (count == 1)
        {
            Object arg0 = LuaScriptMgr.GetNetObject<Object>(L, 1);
            Object o = Object.Instantiate(arg0);
            LuaScriptMgr.Push(L, o);
            return 1;
        }
        else if (count == 3)
        {
            Object arg0 = LuaScriptMgr.GetNetObject<Object>(L, 1);
            Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
            Quaternion arg2 = LuaScriptMgr.GetNetObject<Quaternion>(L, 3);
            Object o = Object.Instantiate(arg0, arg1, arg2);
            LuaScriptMgr.Push(L, o);
            return 1;
        }
        else
        {
            LuaDLL.luaL_error(L, "invalid arguments to method: Object.Instantiate");
        }

        return 0;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int Destroy(IntPtr L)
    {
        int count = LuaDLL.lua_gettop(L);

        if (count == 1)
        {
            Object arg0 = LuaScriptMgr.GetNetObject<Object>(L, 1);            
            LuaScriptMgr.__gc(L);
            Object.Destroy(arg0);
            return 0;
        }
        else if (count == 2)
        {
            Object arg0 = LuaScriptMgr.GetNetObject<Object>(L, 1);
            float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);            
            LuaScriptMgr.__gc(L);
            Object.Destroy(arg0, arg1);
            return 0;
        }
        else
        {
            LuaDLL.luaL_error(L, "invalid arguments to method: Object.Destroy");
        }

        return 0;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int DestroyImmediate(IntPtr L)
    {
        int count = LuaDLL.lua_gettop(L);

        if (count == 1)
        {
            Object arg0 = LuaScriptMgr.GetNetObject<Object>(L, 1);            
            LuaScriptMgr.__gc(L);
            Object.DestroyImmediate(arg0);
            return 0;
        }
        else if (count == 2)
        {
            Object arg0 = LuaScriptMgr.GetNetObject<Object>(L, 1);
            bool arg1 = LuaScriptMgr.GetBoolean(L, 2);            
            LuaScriptMgr.__gc(L);
            Object.DestroyImmediate(arg0, arg1);
            return 0;
        }
        else
        {
            LuaDLL.luaL_error(L, "invalid arguments to method: Object.DestroyImmediate");
        }

        return 0;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int FindObjectsOfType(IntPtr L)
    {
        LuaScriptMgr.CheckArgsCount(L, 1);
        Type arg0 = LuaScriptMgr.GetNetObject<Type>(L, 1);
        Object[] o = Object.FindObjectsOfType(arg0);
        LuaScriptMgr.PushArray(L, o);
        return 1;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int FindObjectOfType(IntPtr L)
    {
        LuaScriptMgr.CheckArgsCount(L, 1);
        Type arg0 = LuaScriptMgr.GetNetObject<Type>(L, 1);
        Object o = Object.FindObjectOfType(arg0);
        LuaScriptMgr.Push(L, o);
        return 1;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int DontDestroyOnLoad(IntPtr L)
    {
        LuaScriptMgr.CheckArgsCount(L, 1);
        Object arg0 = LuaScriptMgr.GetNetObject<Object>(L, 1);
        Object.DontDestroyOnLoad(arg0);
        return 0;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int DestroyObject(IntPtr L)
    {
        int count = LuaDLL.lua_gettop(L);

        if (count == 1)
        {
            Object arg0 = LuaScriptMgr.GetNetObject<Object>(L, 1);            
            LuaScriptMgr.__gc(L);
            Object.DestroyObject(arg0);
            return 0;
        }
        else if (count == 2)
        {
            Object arg0 = LuaScriptMgr.GetNetObject<Object>(L, 1);
            float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);            
            LuaScriptMgr.__gc(L);
            Object.DestroyObject(arg0, arg1);
            return 0;
        }
        else
        {
            LuaDLL.luaL_error(L, "invalid arguments to method: Object.DestroyObject");
        }

        return 0;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int ToString(IntPtr L)
    {
        LuaScriptMgr.CheckArgsCount(L, 1);
        Object obj = LuaScriptMgr.GetNetObject<Object>(L, 1);
        string o = obj.ToString();
        LuaScriptMgr.Push(L, o);
        return 1;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int Lua_Eq(IntPtr L)
    {
        LuaScriptMgr.CheckArgsCount(L, 2);
        Object arg0 = LuaScriptMgr.GetNetObject<Object>(L, 1);
        Object arg1 = LuaScriptMgr.GetNetObject<Object>(L, 2);
        bool o = arg0 == arg1;
        LuaScriptMgr.Push(L, o);
        return 1;
    }
}

