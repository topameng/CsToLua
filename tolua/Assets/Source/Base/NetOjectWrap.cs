using UnityEngine;
using System;
using LuaInterface;

public class objectWrap : ILuaWrap
{
    public static LuaScriptMgr luaMgr = null;
    public static int reference = -1;

    public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Equals", Equals),
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("GetType", GetType),
		new LuaMethod("ToString", ToString),
		new LuaMethod("ReferenceEquals", ReferenceEquals),
		new LuaMethod("New", Create),
        new LuaMethod("IsNull", IsNull),
	};

    static LuaField[] fields = new LuaField[]
	{
	};

    static int Create(IntPtr l)
    {
        int count = LuaDLL.lua_gettop(l);
        object obj = null;

        if (count == 0)
        {
            obj = new object();
        }
        else
        {
            LuaDLL.luaL_error(l, "The best overloaded method match for 'object.New' has some invalid arguments");
        }

        luaMgr.PushResult(obj);
        return 1;
    }

    public void Register()
    {
        LuaMethod[] metas = new LuaMethod[]
		{
			new LuaMethod("__index", Lua_Index),
			new LuaMethod("__newindex", Lua_NewIndex),
			new LuaMethod("__tostring", Lua_ToString),
		};

        luaMgr = LuaScriptMgr.Instance;
        reference = luaMgr.RegisterLib("object", regs);
        luaMgr.CreateMetaTable("object", metas, typeof(object));
        luaMgr.RegisterField(typeof(object), fields);
    }

    public static bool TryLuaIndex(IntPtr l)
    {
        string str = luaMgr.GetString(2);

        if (luaMgr.Index(reference, str, fields))
        {
            return true;
        }

        return false;
    }

    static int Lua_Index(IntPtr l)
    {
        if (TryLuaIndex(l))
        {
            return 1;
        }

        string str = luaMgr.GetString(2);
        LuaDLL.luaL_error(l, string.Format("'object' does not contain a definition for '{0}'", str));
        return 0;
    }

    public static bool TryLuaNewIndex(IntPtr l)
    {
        string str = luaMgr.GetString(2);

        if (luaMgr.NewIndex(reference, str, fields))
        {
            return true;
        }

        return false;
    }

    static int Lua_NewIndex(IntPtr l)
    {
        if (TryLuaNewIndex(l))
        {
            return 0;
        }

        string str = luaMgr.GetString(2);
        LuaDLL.luaL_error(l, string.Format("'object' does not contain a definition for '{0}'", str));
        return 0;
    }

    static int Lua_ToString(IntPtr l)
    {
        object obj = (object)luaMgr.GetNetObject(1);
        luaMgr.PushResult(obj.ToString());
        return 1;
    }

    static int Equals(IntPtr l)
    {
        luaMgr.CheckArgsCount(2);
        object obj = (object)luaMgr.GetNetObject(1);
        object arg0 = (object)luaMgr.GetNetObject(2);
        bool o = obj.Equals(arg0);
        luaMgr.PushResult(o);
        return 1;
    }

    static int GetHashCode(IntPtr l)
    {
        luaMgr.CheckArgsCount(1);
        object obj = (object)luaMgr.GetNetObject(1);
        int o = obj.GetHashCode();
        luaMgr.PushResult(o);
        return 1;
    }

    static int GetType(IntPtr l)
    {
        luaMgr.CheckArgsCount(1);
        object obj = (object)luaMgr.GetNetObject(1);
        Type o = obj.GetType();
        luaMgr.PushResult(o);
        return 1;
    }

    static int ToString(IntPtr l)
    {
        luaMgr.CheckArgsCount(1);
        object obj = (object)luaMgr.GetNetObject(1);
        string o = obj.ToString();
        luaMgr.PushResult(o);
        return 1;
    }

    static int ReferenceEquals(IntPtr l)
    {
        luaMgr.CheckArgsCount(2);
        object arg0 = (object)luaMgr.GetNetObject(1);
        object arg1 = (object)luaMgr.GetNetObject(2);
        bool o = object.ReferenceEquals(arg0, arg1);
        luaMgr.PushResult(o);
        return 1;
    }

    static int IsNull(IntPtr l)
    {
        object arg0 = luaMgr.GetLuaObject(1);
        bool o = arg0 == null;
        luaMgr.PushResult(o);
        return 1;
    }
}
