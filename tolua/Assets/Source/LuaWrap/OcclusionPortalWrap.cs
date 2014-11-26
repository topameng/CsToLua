using UnityEngine;
using System;
using LuaInterface;

public class OcclusionPortalWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateOcclusionPortal),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("open", get_open, set_open),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateOcclusionPortal(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			OcclusionPortal obj = new OcclusionPortal();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: OcclusionPortal.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(OcclusionPortal));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.OcclusionPortal", typeof(OcclusionPortal), regs, fields, "UnityEngine.Component");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_open(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name open");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index open on a nil value");
			}
		}

		OcclusionPortal obj = (OcclusionPortal)o;
		LuaScriptMgr.Push(L, obj.open);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_open(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name open");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index open on a nil value");
			}
		}

		OcclusionPortal obj = (OcclusionPortal)o;
		obj.open = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}
}

