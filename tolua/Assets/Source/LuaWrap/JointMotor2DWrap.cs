using UnityEngine;
using System;
using LuaInterface;

public class JointMotor2DWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateJointMotor2D),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("motorSpeed", get_motorSpeed, set_motorSpeed),
		new LuaField("maxMotorTorque", get_maxMotorTorque, set_maxMotorTorque),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateJointMotor2D(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		JointMotor2D obj = new JointMotor2D();
		LuaScriptMgr.PushValue(L, obj);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(JointMotor2D));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.JointMotor2D", typeof(JointMotor2D), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_motorSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name motorSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index motorSpeed on a nil value");
			}
		}

		JointMotor2D obj = (JointMotor2D)o;
		LuaScriptMgr.Push(L, obj.motorSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxMotorTorque(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxMotorTorque");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxMotorTorque on a nil value");
			}
		}

		JointMotor2D obj = (JointMotor2D)o;
		LuaScriptMgr.Push(L, obj.maxMotorTorque);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_motorSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name motorSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index motorSpeed on a nil value");
			}
		}

		JointMotor2D obj = (JointMotor2D)o;
		obj.motorSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxMotorTorque(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxMotorTorque");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxMotorTorque on a nil value");
			}
		}

		JointMotor2D obj = (JointMotor2D)o;
		obj.maxMotorTorque = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}
}

