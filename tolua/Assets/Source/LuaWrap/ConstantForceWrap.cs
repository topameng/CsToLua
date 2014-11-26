using UnityEngine;
using System;
using LuaInterface;

public class ConstantForceWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateConstantForce),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("force", get_force, set_force),
		new LuaField("relativeForce", get_relativeForce, set_relativeForce),
		new LuaField("torque", get_torque, set_torque),
		new LuaField("relativeTorque", get_relativeTorque, set_relativeTorque),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateConstantForce(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			ConstantForce obj = new ConstantForce();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ConstantForce.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ConstantForce));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ConstantForce", typeof(ConstantForce), regs, fields, "UnityEngine.Behaviour");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_force(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name force");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index force on a nil value");
			}
		}

		ConstantForce obj = (ConstantForce)o;
		LuaScriptMgr.PushValue(L, obj.force);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_relativeForce(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name relativeForce");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index relativeForce on a nil value");
			}
		}

		ConstantForce obj = (ConstantForce)o;
		LuaScriptMgr.PushValue(L, obj.relativeForce);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_torque(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name torque");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index torque on a nil value");
			}
		}

		ConstantForce obj = (ConstantForce)o;
		LuaScriptMgr.PushValue(L, obj.torque);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_relativeTorque(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name relativeTorque");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index relativeTorque on a nil value");
			}
		}

		ConstantForce obj = (ConstantForce)o;
		LuaScriptMgr.PushValue(L, obj.relativeTorque);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_force(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name force");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index force on a nil value");
			}
		}

		ConstantForce obj = (ConstantForce)o;
		obj.force = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_relativeForce(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name relativeForce");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index relativeForce on a nil value");
			}
		}

		ConstantForce obj = (ConstantForce)o;
		obj.relativeForce = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_torque(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name torque");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index torque on a nil value");
			}
		}

		ConstantForce obj = (ConstantForce)o;
		obj.torque = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_relativeTorque(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name relativeTorque");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index relativeTorque on a nil value");
			}
		}

		ConstantForce obj = (ConstantForce)o;
		obj.relativeTorque = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}
}

