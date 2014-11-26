using UnityEngine;
using System;
using LuaInterface;

public class WheelFrictionCurveWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateWheelFrictionCurve),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("extremumSlip", get_extremumSlip, set_extremumSlip),
		new LuaField("extremumValue", get_extremumValue, set_extremumValue),
		new LuaField("asymptoteSlip", get_asymptoteSlip, set_asymptoteSlip),
		new LuaField("asymptoteValue", get_asymptoteValue, set_asymptoteValue),
		new LuaField("stiffness", get_stiffness, set_stiffness),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateWheelFrictionCurve(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		WheelFrictionCurve obj = new WheelFrictionCurve();
		LuaScriptMgr.PushValue(L, obj);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(WheelFrictionCurve));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.WheelFrictionCurve", typeof(WheelFrictionCurve), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_extremumSlip(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name extremumSlip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index extremumSlip on a nil value");
			}
		}

		WheelFrictionCurve obj = (WheelFrictionCurve)o;
		LuaScriptMgr.Push(L, obj.extremumSlip);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_extremumValue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name extremumValue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index extremumValue on a nil value");
			}
		}

		WheelFrictionCurve obj = (WheelFrictionCurve)o;
		LuaScriptMgr.Push(L, obj.extremumValue);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_asymptoteSlip(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name asymptoteSlip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index asymptoteSlip on a nil value");
			}
		}

		WheelFrictionCurve obj = (WheelFrictionCurve)o;
		LuaScriptMgr.Push(L, obj.asymptoteSlip);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_asymptoteValue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name asymptoteValue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index asymptoteValue on a nil value");
			}
		}

		WheelFrictionCurve obj = (WheelFrictionCurve)o;
		LuaScriptMgr.Push(L, obj.asymptoteValue);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stiffness(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stiffness");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stiffness on a nil value");
			}
		}

		WheelFrictionCurve obj = (WheelFrictionCurve)o;
		LuaScriptMgr.Push(L, obj.stiffness);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_extremumSlip(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name extremumSlip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index extremumSlip on a nil value");
			}
		}

		WheelFrictionCurve obj = (WheelFrictionCurve)o;
		obj.extremumSlip = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_extremumValue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name extremumValue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index extremumValue on a nil value");
			}
		}

		WheelFrictionCurve obj = (WheelFrictionCurve)o;
		obj.extremumValue = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_asymptoteSlip(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name asymptoteSlip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index asymptoteSlip on a nil value");
			}
		}

		WheelFrictionCurve obj = (WheelFrictionCurve)o;
		obj.asymptoteSlip = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_asymptoteValue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name asymptoteValue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index asymptoteValue on a nil value");
			}
		}

		WheelFrictionCurve obj = (WheelFrictionCurve)o;
		obj.asymptoteValue = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stiffness(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stiffness");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stiffness on a nil value");
			}
		}

		WheelFrictionCurve obj = (WheelFrictionCurve)o;
		obj.stiffness = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}
}

