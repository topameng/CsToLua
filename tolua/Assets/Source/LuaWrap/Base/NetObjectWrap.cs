using System;
using UnityEngine;
using LuaInterface;

public class objectWrap
{
    public static LuaScriptMgr luaMgr = null;

    public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Equals", Equals),
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("GetType", GetType),
		new LuaMethod("ToString", ToString),
		new LuaMethod("ReferenceEquals", ReferenceEquals),
		new LuaMethod("New", Create),
        new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__tostring", Lua_ToString),
        new LuaMethod("IsNull", IsNull),
	};

    static LuaField[] fields = new LuaField[]
	{
	};

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int Create(IntPtr L)
    {
        int count = LuaDLL.lua_gettop(L);
        object obj = null;

        if (count == 0)
        {
            obj = new object();
            LuaScriptMgr.PushVarObject(L, obj);
            return 1;
        }
        else
        {
            LuaDLL.luaL_error(L, "invalid arguments to method: object.New");
        }

        return 0;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int GetClassType(IntPtr L)
    {
        LuaScriptMgr.Push(L, typeof(object));
        return 1;
    }

    public static void Register(IntPtr L)
    {
        LuaScriptMgr.RegisterLib(L, "System.Object", typeof(object), regs, fields, null);
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int Lua_ToString(IntPtr L)
    {
        object obj = (object)LuaScriptMgr.GetLuaObject(L, 1);

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
        object obj = (object)LuaScriptMgr.GetVarObject(L, 1);
        object arg0 = (object)LuaScriptMgr.GetVarObject(L, 2);
        bool o = obj.Equals(arg0);
        LuaScriptMgr.Push(L, o);
        return 1;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int GetHashCode(IntPtr L)
    {
        LuaScriptMgr.CheckArgsCount(L, 1);
        object obj = (object)LuaScriptMgr.GetVarObject(L, 1);
        int o = obj.GetHashCode();
        LuaScriptMgr.Push(L, o);
        return 1;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int GetType(IntPtr L)
    {
        LuaScriptMgr.CheckArgsCount(L, 1);
        object obj = (object)LuaScriptMgr.GetVarObject(L, 1);
        Type o = obj.GetType();
        LuaScriptMgr.Push(L, o);
        return 1;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int ToString(IntPtr L)
    {
        LuaScriptMgr.CheckArgsCount(L, 1);
        object obj = (object)LuaScriptMgr.GetVarObject(L, 1);
        string o = obj.ToString();
        LuaScriptMgr.Push(L, o);
        return 1;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int ReferenceEquals(IntPtr L)
    {
        LuaScriptMgr.CheckArgsCount(L, 2);
        object arg0 = (object)LuaScriptMgr.GetVarObject(L, 1);
        object arg1 = (object)LuaScriptMgr.GetVarObject(L, 2);
        bool o = object.ReferenceEquals(arg0, arg1);
        LuaScriptMgr.Push(L, o);
        return 1;
    }


    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int IsNull(IntPtr L)
    {
        object arg0 = LuaScriptMgr.GetLuaObject(L, 1);
        bool o = arg0 == null;
        LuaScriptMgr.Push(L, o);
        return 1;
    }
}

