using UnityEngine;
using System;
using LuaInterface;

public class WheelJoint2DWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetMotorTorque", GetMotorTorque),
		new LuaMethod("New", _CreateWheelJoint2D),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("suspension", get_suspension, set_suspension),
		new LuaField("useMotor", get_useMotor, set_useMotor),
		new LuaField("motor", get_motor, set_motor),
		new LuaField("jointTranslation", get_jointTranslation, null),
		new LuaField("jointSpeed", get_jointSpeed, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateWheelJoint2D(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			WheelJoint2D obj = new WheelJoint2D();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: WheelJoint2D.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(WheelJoint2D));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.WheelJoint2D", typeof(WheelJoint2D), regs, fields, "UnityEngine.AnchoredJoint2D");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_suspension(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name suspension");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index suspension on a nil value");
			}
		}

		WheelJoint2D obj = (WheelJoint2D)o;
		LuaScriptMgr.PushValue(L, obj.suspension);
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

		WheelJoint2D obj = (WheelJoint2D)o;
		LuaScriptMgr.Push(L, obj.useMotor);
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

		WheelJoint2D obj = (WheelJoint2D)o;
		LuaScriptMgr.PushValue(L, obj.motor);
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

		WheelJoint2D obj = (WheelJoint2D)o;
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

		WheelJoint2D obj = (WheelJoint2D)o;
		LuaScriptMgr.Push(L, obj.jointSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_suspension(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name suspension");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index suspension on a nil value");
			}
		}

		WheelJoint2D obj = (WheelJoint2D)o;
		obj.suspension = LuaScriptMgr.GetNetObject<JointSuspension2D>(L, 3);
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

		WheelJoint2D obj = (WheelJoint2D)o;
		obj.useMotor = LuaScriptMgr.GetBoolean(L, 3);
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

		WheelJoint2D obj = (WheelJoint2D)o;
		obj.motor = LuaScriptMgr.GetNetObject<JointMotor2D>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMotorTorque(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		WheelJoint2D obj = LuaScriptMgr.GetNetObject<WheelJoint2D>(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		float o = obj.GetMotorTorque(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

