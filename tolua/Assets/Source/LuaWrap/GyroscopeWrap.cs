using UnityEngine;
using System;
using LuaInterface;

public class GyroscopeWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateGyroscope),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("rotationRate", get_rotationRate, null),
		new LuaField("rotationRateUnbiased", get_rotationRateUnbiased, null),
		new LuaField("gravity", get_gravity, null),
		new LuaField("userAcceleration", get_userAcceleration, null),
		new LuaField("attitude", get_attitude, null),
		new LuaField("enabled", get_enabled, set_enabled),
		new LuaField("updateInterval", get_updateInterval, set_updateInterval),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGyroscope(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Gyroscope class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Gyroscope));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Gyroscope", typeof(Gyroscope), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rotationRate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rotationRate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rotationRate on a nil value");
			}
		}

		Gyroscope obj = (Gyroscope)o;
		LuaScriptMgr.PushValue(L, obj.rotationRate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rotationRateUnbiased(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rotationRateUnbiased");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rotationRateUnbiased on a nil value");
			}
		}

		Gyroscope obj = (Gyroscope)o;
		LuaScriptMgr.PushValue(L, obj.rotationRateUnbiased);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gravity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gravity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gravity on a nil value");
			}
		}

		Gyroscope obj = (Gyroscope)o;
		LuaScriptMgr.PushValue(L, obj.gravity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_userAcceleration(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name userAcceleration");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index userAcceleration on a nil value");
			}
		}

		Gyroscope obj = (Gyroscope)o;
		LuaScriptMgr.PushValue(L, obj.userAcceleration);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_attitude(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name attitude");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index attitude on a nil value");
			}
		}

		Gyroscope obj = (Gyroscope)o;
		LuaScriptMgr.PushValue(L, obj.attitude);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enabled on a nil value");
			}
		}

		Gyroscope obj = (Gyroscope)o;
		LuaScriptMgr.Push(L, obj.enabled);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_updateInterval(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name updateInterval");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index updateInterval on a nil value");
			}
		}

		Gyroscope obj = (Gyroscope)o;
		LuaScriptMgr.Push(L, obj.updateInterval);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enabled on a nil value");
			}
		}

		Gyroscope obj = (Gyroscope)o;
		obj.enabled = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_updateInterval(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name updateInterval");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index updateInterval on a nil value");
			}
		}

		Gyroscope obj = (Gyroscope)o;
		obj.updateInterval = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}

