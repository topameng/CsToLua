using UnityEngine;
using System;
using LuaInterface;

public class JointDriveWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateJointDrive),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("mode", get_mode, set_mode),
		new LuaField("positionSpring", get_positionSpring, set_positionSpring),
		new LuaField("positionDamper", get_positionDamper, set_positionDamper),
		new LuaField("maximumForce", get_maximumForce, set_maximumForce),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateJointDrive(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		JointDrive obj = new JointDrive();
		LuaScriptMgr.PushValue(L, obj);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(JointDrive));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.JointDrive", typeof(JointDrive), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mode on a nil value");
			}
		}

		JointDrive obj = (JointDrive)o;
		LuaScriptMgr.PushEnum(L, obj.mode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_positionSpring(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name positionSpring");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index positionSpring on a nil value");
			}
		}

		JointDrive obj = (JointDrive)o;
		LuaScriptMgr.Push(L, obj.positionSpring);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_positionDamper(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name positionDamper");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index positionDamper on a nil value");
			}
		}

		JointDrive obj = (JointDrive)o;
		LuaScriptMgr.Push(L, obj.positionDamper);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maximumForce(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maximumForce");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maximumForce on a nil value");
			}
		}

		JointDrive obj = (JointDrive)o;
		LuaScriptMgr.Push(L, obj.maximumForce);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mode on a nil value");
			}
		}

		JointDrive obj = (JointDrive)o;
		obj.mode = LuaScriptMgr.GetNetObject<JointDriveMode>(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_positionSpring(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name positionSpring");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index positionSpring on a nil value");
			}
		}

		JointDrive obj = (JointDrive)o;
		obj.positionSpring = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_positionDamper(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name positionDamper");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index positionDamper on a nil value");
			}
		}

		JointDrive obj = (JointDrive)o;
		obj.positionDamper = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maximumForce(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maximumForce");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maximumForce on a nil value");
			}
		}

		JointDrive obj = (JointDrive)o;
		obj.maximumForce = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}
}

