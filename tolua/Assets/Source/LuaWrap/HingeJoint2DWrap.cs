using UnityEngine;
using System;
using LuaInterface;

public class HingeJoint2DWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetReactionForce", GetReactionForce),
		new LuaMethod("GetReactionTorque", GetReactionTorque),
		new LuaMethod("GetMotorTorque", GetMotorTorque),
		new LuaMethod("New", _CreateHingeJoint2D),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("useMotor", get_useMotor, set_useMotor),
		new LuaField("useLimits", get_useLimits, set_useLimits),
		new LuaField("motor", get_motor, set_motor),
		new LuaField("limits", get_limits, set_limits),
		new LuaField("limitState", get_limitState, null),
		new LuaField("referenceAngle", get_referenceAngle, null),
		new LuaField("jointAngle", get_jointAngle, null),
		new LuaField("jointSpeed", get_jointSpeed, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateHingeJoint2D(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			HingeJoint2D obj = new HingeJoint2D();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: HingeJoint2D.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(HingeJoint2D));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.HingeJoint2D", typeof(HingeJoint2D), regs, fields, "UnityEngine.AnchoredJoint2D");
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

		HingeJoint2D obj = (HingeJoint2D)o;
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

		HingeJoint2D obj = (HingeJoint2D)o;
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

		HingeJoint2D obj = (HingeJoint2D)o;
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

		HingeJoint2D obj = (HingeJoint2D)o;
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

		HingeJoint2D obj = (HingeJoint2D)o;
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

		HingeJoint2D obj = (HingeJoint2D)o;
		LuaScriptMgr.Push(L, obj.referenceAngle);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_jointAngle(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name jointAngle");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index jointAngle on a nil value");
			}
		}

		HingeJoint2D obj = (HingeJoint2D)o;
		LuaScriptMgr.Push(L, obj.jointAngle);
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

		HingeJoint2D obj = (HingeJoint2D)o;
		LuaScriptMgr.Push(L, obj.jointSpeed);
		return 1;
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

		HingeJoint2D obj = (HingeJoint2D)o;
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

		HingeJoint2D obj = (HingeJoint2D)o;
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

		HingeJoint2D obj = (HingeJoint2D)o;
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

		HingeJoint2D obj = (HingeJoint2D)o;
		obj.limits = LuaScriptMgr.GetNetObject<JointAngleLimits2D>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetReactionForce(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		HingeJoint2D obj = LuaScriptMgr.GetNetObject<HingeJoint2D>(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		Vector2 o = obj.GetReactionForce(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetReactionTorque(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		HingeJoint2D obj = LuaScriptMgr.GetNetObject<HingeJoint2D>(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		float o = obj.GetReactionTorque(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMotorTorque(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		HingeJoint2D obj = LuaScriptMgr.GetNetObject<HingeJoint2D>(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		float o = obj.GetMotorTorque(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

