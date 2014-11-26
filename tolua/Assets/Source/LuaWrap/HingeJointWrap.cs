using UnityEngine;
using System;
using LuaInterface;

public class HingeJointWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateHingeJoint),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("motor", get_motor, set_motor),
		new LuaField("limits", get_limits, set_limits),
		new LuaField("spring", get_spring, set_spring),
		new LuaField("useMotor", get_useMotor, set_useMotor),
		new LuaField("useLimits", get_useLimits, set_useLimits),
		new LuaField("useSpring", get_useSpring, set_useSpring),
		new LuaField("velocity", get_velocity, null),
		new LuaField("angle", get_angle, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateHingeJoint(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			HingeJoint obj = new HingeJoint();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: HingeJoint.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(HingeJoint));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.HingeJoint", typeof(HingeJoint), regs, fields, "UnityEngine.Joint");
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

		HingeJoint obj = (HingeJoint)o;
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

		HingeJoint obj = (HingeJoint)o;
		LuaScriptMgr.PushValue(L, obj.limits);
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

		HingeJoint obj = (HingeJoint)o;
		LuaScriptMgr.PushValue(L, obj.spring);
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

		HingeJoint obj = (HingeJoint)o;
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

		HingeJoint obj = (HingeJoint)o;
		LuaScriptMgr.Push(L, obj.useLimits);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useSpring(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useSpring");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useSpring on a nil value");
			}
		}

		HingeJoint obj = (HingeJoint)o;
		LuaScriptMgr.Push(L, obj.useSpring);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_velocity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name velocity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index velocity on a nil value");
			}
		}

		HingeJoint obj = (HingeJoint)o;
		LuaScriptMgr.Push(L, obj.velocity);
		return 1;
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

		HingeJoint obj = (HingeJoint)o;
		LuaScriptMgr.Push(L, obj.angle);
		return 1;
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

		HingeJoint obj = (HingeJoint)o;
		obj.motor = LuaScriptMgr.GetNetObject<JointMotor>(L, 3);
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

		HingeJoint obj = (HingeJoint)o;
		obj.limits = LuaScriptMgr.GetNetObject<JointLimits>(L, 3);
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

		HingeJoint obj = (HingeJoint)o;
		obj.spring = LuaScriptMgr.GetNetObject<JointSpring>(L, 3);
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

		HingeJoint obj = (HingeJoint)o;
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

		HingeJoint obj = (HingeJoint)o;
		obj.useLimits = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useSpring(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useSpring");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useSpring on a nil value");
			}
		}

		HingeJoint obj = (HingeJoint)o;
		obj.useSpring = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}
}

