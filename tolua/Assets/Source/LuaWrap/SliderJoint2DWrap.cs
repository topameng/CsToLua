using UnityEngine;
using System;
using LuaInterface;

public class SliderJoint2DWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetMotorForce", GetMotorForce),
		new LuaMethod("New", _CreateSliderJoint2D),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("angle", get_angle, set_angle),
		new LuaField("useMotor", get_useMotor, set_useMotor),
		new LuaField("useLimits", get_useLimits, set_useLimits),
		new LuaField("motor", get_motor, set_motor),
		new LuaField("limits", get_limits, set_limits),
		new LuaField("limitState", get_limitState, null),
		new LuaField("referenceAngle", get_referenceAngle, null),
		new LuaField("jointTranslation", get_jointTranslation, null),
		new LuaField("jointSpeed", get_jointSpeed, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSliderJoint2D(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			SliderJoint2D obj = new SliderJoint2D();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SliderJoint2D.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(SliderJoint2D));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.SliderJoint2D", typeof(SliderJoint2D), regs, fields, "UnityEngine.AnchoredJoint2D");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_angle(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angle");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angle on a nil value");
			}
		}

		SliderJoint2D obj = (SliderJoint2D)o;
		LuaScriptMgr.Push(L, obj.angle);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useMotor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useMotor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useMotor on a nil value");
			}
		}

		SliderJoint2D obj = (SliderJoint2D)o;
		LuaScriptMgr.Push(L, obj.useMotor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useLimits(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useLimits");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useLimits on a nil value");
			}
		}

		SliderJoint2D obj = (SliderJoint2D)o;
		LuaScriptMgr.Push(L, obj.useLimits);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_motor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name motor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index motor on a nil value");
			}
		}

		SliderJoint2D obj = (SliderJoint2D)o;
		LuaScriptMgr.PushValue(L, obj.motor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_limits(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name limits");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index limits on a nil value");
			}
		}

		SliderJoint2D obj = (SliderJoint2D)o;
		LuaScriptMgr.PushValue(L, obj.limits);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_limitState(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name limitState");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index limitState on a nil value");
			}
		}

		SliderJoint2D obj = (SliderJoint2D)o;
		LuaScriptMgr.PushEnum(L, obj.limitState);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_referenceAngle(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name referenceAngle");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index referenceAngle on a nil value");
			}
		}

		SliderJoint2D obj = (SliderJoint2D)o;
		LuaScriptMgr.Push(L, obj.referenceAngle);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_jointTranslation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name jointTranslation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index jointTranslation on a nil value");
			}
		}

		SliderJoint2D obj = (SliderJoint2D)o;
		LuaScriptMgr.Push(L, obj.jointTranslation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_jointSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name jointSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index jointSpeed on a nil value");
			}
		}

		SliderJoint2D obj = (SliderJoint2D)o;
		LuaScriptMgr.Push(L, obj.jointSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_angle(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angle");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angle on a nil value");
			}
		}

		SliderJoint2D obj = (SliderJoint2D)o;
		obj.angle = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useMotor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useMotor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useMotor on a nil value");
			}
		}

		SliderJoint2D obj = (SliderJoint2D)o;
		obj.useMotor = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useLimits(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useLimits");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useLimits on a nil value");
			}
		}

		SliderJoint2D obj = (SliderJoint2D)o;
		obj.useLimits = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_motor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name motor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index motor on a nil value");
			}
		}

		SliderJoint2D obj = (SliderJoint2D)o;
		obj.motor = LuaScriptMgr.GetNetObject<JointMotor2D>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_limits(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name limits");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index limits on a nil value");
			}
		}

		SliderJoint2D obj = (SliderJoint2D)o;
		obj.limits = LuaScriptMgr.GetNetObject<JointTranslationLimits2D>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMotorForce(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SliderJoint2D obj = LuaScriptMgr.GetNetObject<SliderJoint2D>(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		float o = obj.GetMotorForce(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

