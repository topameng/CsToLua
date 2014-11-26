using UnityEngine;
using System;
using LuaInterface;

public class SoftJointLimitWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateSoftJointLimit),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("limit", get_limit, set_limit),
		new LuaField("spring", get_spring, set_spring),
		new LuaField("damper", get_damper, set_damper),
		new LuaField("bounciness", get_bounciness, set_bounciness),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSoftJointLimit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		SoftJointLimit obj = new SoftJointLimit();
		LuaScriptMgr.PushValue(L, obj);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(SoftJointLimit));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.SoftJointLimit", typeof(SoftJointLimit), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_limit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name limit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index limit on a nil value");
			}
		}

		SoftJointLimit obj = (SoftJointLimit)o;
		LuaScriptMgr.Push(L, obj.limit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spring(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spring");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spring on a nil value");
			}
		}

		SoftJointLimit obj = (SoftJointLimit)o;
		LuaScriptMgr.Push(L, obj.spring);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_damper(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name damper");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index damper on a nil value");
			}
		}

		SoftJointLimit obj = (SoftJointLimit)o;
		LuaScriptMgr.Push(L, obj.damper);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bounciness(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bounciness");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bounciness on a nil value");
			}
		}

		SoftJointLimit obj = (SoftJointLimit)o;
		LuaScriptMgr.Push(L, obj.bounciness);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_limit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name limit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index limit on a nil value");
			}
		}

		SoftJointLimit obj = (SoftJointLimit)o;
		obj.limit = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_spring(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spring");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spring on a nil value");
			}
		}

		SoftJointLimit obj = (SoftJointLimit)o;
		obj.spring = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_damper(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name damper");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index damper on a nil value");
			}
		}

		SoftJointLimit obj = (SoftJointLimit)o;
		obj.damper = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bounciness(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bounciness");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bounciness on a nil value");
			}
		}

		SoftJointLimit obj = (SoftJointLimit)o;
		obj.bounciness = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}
}

