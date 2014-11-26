using UnityEngine;
using System;
using LuaInterface;

public class ConfigurableJointWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateConfigurableJoint),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("secondaryAxis", get_secondaryAxis, set_secondaryAxis),
		new LuaField("xMotion", get_xMotion, set_xMotion),
		new LuaField("yMotion", get_yMotion, set_yMotion),
		new LuaField("zMotion", get_zMotion, set_zMotion),
		new LuaField("angularXMotion", get_angularXMotion, set_angularXMotion),
		new LuaField("angularYMotion", get_angularYMotion, set_angularYMotion),
		new LuaField("angularZMotion", get_angularZMotion, set_angularZMotion),
		new LuaField("linearLimit", get_linearLimit, set_linearLimit),
		new LuaField("lowAngularXLimit", get_lowAngularXLimit, set_lowAngularXLimit),
		new LuaField("highAngularXLimit", get_highAngularXLimit, set_highAngularXLimit),
		new LuaField("angularYLimit", get_angularYLimit, set_angularYLimit),
		new LuaField("angularZLimit", get_angularZLimit, set_angularZLimit),
		new LuaField("targetPosition", get_targetPosition, set_targetPosition),
		new LuaField("targetVelocity", get_targetVelocity, set_targetVelocity),
		new LuaField("xDrive", get_xDrive, set_xDrive),
		new LuaField("yDrive", get_yDrive, set_yDrive),
		new LuaField("zDrive", get_zDrive, set_zDrive),
		new LuaField("targetRotation", get_targetRotation, set_targetRotation),
		new LuaField("targetAngularVelocity", get_targetAngularVelocity, set_targetAngularVelocity),
		new LuaField("rotationDriveMode", get_rotationDriveMode, set_rotationDriveMode),
		new LuaField("angularXDrive", get_angularXDrive, set_angularXDrive),
		new LuaField("angularYZDrive", get_angularYZDrive, set_angularYZDrive),
		new LuaField("slerpDrive", get_slerpDrive, set_slerpDrive),
		new LuaField("projectionMode", get_projectionMode, set_projectionMode),
		new LuaField("projectionDistance", get_projectionDistance, set_projectionDistance),
		new LuaField("projectionAngle", get_projectionAngle, set_projectionAngle),
		new LuaField("configuredInWorldSpace", get_configuredInWorldSpace, set_configuredInWorldSpace),
		new LuaField("swapBodies", get_swapBodies, set_swapBodies),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateConfigurableJoint(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			ConfigurableJoint obj = new ConfigurableJoint();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ConfigurableJoint.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ConfigurableJoint));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ConfigurableJoint", typeof(ConfigurableJoint), regs, fields, "UnityEngine.Joint");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_secondaryAxis(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name secondaryAxis");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index secondaryAxis on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushValue(L, obj.secondaryAxis);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_xMotion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name xMotion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index xMotion on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushEnum(L, obj.xMotion);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_yMotion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name yMotion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index yMotion on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushEnum(L, obj.yMotion);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_zMotion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name zMotion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index zMotion on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushEnum(L, obj.zMotion);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_angularXMotion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularXMotion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularXMotion on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushEnum(L, obj.angularXMotion);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_angularYMotion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularYMotion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularYMotion on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushEnum(L, obj.angularYMotion);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_angularZMotion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularZMotion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularZMotion on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushEnum(L, obj.angularZMotion);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_linearLimit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name linearLimit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index linearLimit on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushValue(L, obj.linearLimit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lowAngularXLimit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lowAngularXLimit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lowAngularXLimit on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushValue(L, obj.lowAngularXLimit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_highAngularXLimit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name highAngularXLimit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index highAngularXLimit on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushValue(L, obj.highAngularXLimit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_angularYLimit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularYLimit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularYLimit on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushValue(L, obj.angularYLimit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_angularZLimit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularZLimit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularZLimit on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushValue(L, obj.angularZLimit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_targetPosition(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name targetPosition");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index targetPosition on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushValue(L, obj.targetPosition);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_targetVelocity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name targetVelocity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index targetVelocity on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushValue(L, obj.targetVelocity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_xDrive(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name xDrive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index xDrive on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushValue(L, obj.xDrive);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_yDrive(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name yDrive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index yDrive on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushValue(L, obj.yDrive);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_zDrive(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name zDrive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index zDrive on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushValue(L, obj.zDrive);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_targetRotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name targetRotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index targetRotation on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushValue(L, obj.targetRotation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_targetAngularVelocity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name targetAngularVelocity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index targetAngularVelocity on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushValue(L, obj.targetAngularVelocity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rotationDriveMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rotationDriveMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rotationDriveMode on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushEnum(L, obj.rotationDriveMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_angularXDrive(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularXDrive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularXDrive on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushValue(L, obj.angularXDrive);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_angularYZDrive(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularYZDrive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularYZDrive on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushValue(L, obj.angularYZDrive);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_slerpDrive(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name slerpDrive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index slerpDrive on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushValue(L, obj.slerpDrive);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_projectionMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name projectionMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index projectionMode on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.PushEnum(L, obj.projectionMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_projectionDistance(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name projectionDistance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index projectionDistance on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.Push(L, obj.projectionDistance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_projectionAngle(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name projectionAngle");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index projectionAngle on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.Push(L, obj.projectionAngle);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_configuredInWorldSpace(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name configuredInWorldSpace");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index configuredInWorldSpace on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.Push(L, obj.configuredInWorldSpace);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_swapBodies(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name swapBodies");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index swapBodies on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		LuaScriptMgr.Push(L, obj.swapBodies);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_secondaryAxis(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name secondaryAxis");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index secondaryAxis on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.secondaryAxis = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_xMotion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name xMotion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index xMotion on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.xMotion = LuaScriptMgr.GetNetObject<ConfigurableJointMotion>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_yMotion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name yMotion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index yMotion on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.yMotion = LuaScriptMgr.GetNetObject<ConfigurableJointMotion>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_zMotion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name zMotion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index zMotion on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.zMotion = LuaScriptMgr.GetNetObject<ConfigurableJointMotion>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_angularXMotion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularXMotion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularXMotion on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.angularXMotion = LuaScriptMgr.GetNetObject<ConfigurableJointMotion>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_angularYMotion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularYMotion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularYMotion on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.angularYMotion = LuaScriptMgr.GetNetObject<ConfigurableJointMotion>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_angularZMotion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularZMotion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularZMotion on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.angularZMotion = LuaScriptMgr.GetNetObject<ConfigurableJointMotion>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_linearLimit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name linearLimit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index linearLimit on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.linearLimit = LuaScriptMgr.GetNetObject<SoftJointLimit>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lowAngularXLimit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lowAngularXLimit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lowAngularXLimit on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.lowAngularXLimit = LuaScriptMgr.GetNetObject<SoftJointLimit>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_highAngularXLimit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name highAngularXLimit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index highAngularXLimit on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.highAngularXLimit = LuaScriptMgr.GetNetObject<SoftJointLimit>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_angularYLimit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularYLimit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularYLimit on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.angularYLimit = LuaScriptMgr.GetNetObject<SoftJointLimit>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_angularZLimit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularZLimit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularZLimit on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.angularZLimit = LuaScriptMgr.GetNetObject<SoftJointLimit>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_targetPosition(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name targetPosition");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index targetPosition on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.targetPosition = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_targetVelocity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name targetVelocity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index targetVelocity on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.targetVelocity = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_xDrive(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name xDrive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index xDrive on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.xDrive = LuaScriptMgr.GetNetObject<JointDrive>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_yDrive(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name yDrive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index yDrive on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.yDrive = LuaScriptMgr.GetNetObject<JointDrive>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_zDrive(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name zDrive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index zDrive on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.zDrive = LuaScriptMgr.GetNetObject<JointDrive>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_targetRotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name targetRotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index targetRotation on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.targetRotation = LuaScriptMgr.GetNetObject<Quaternion>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_targetAngularVelocity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name targetAngularVelocity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index targetAngularVelocity on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.targetAngularVelocity = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rotationDriveMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rotationDriveMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rotationDriveMode on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.rotationDriveMode = LuaScriptMgr.GetNetObject<RotationDriveMode>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_angularXDrive(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularXDrive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularXDrive on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.angularXDrive = LuaScriptMgr.GetNetObject<JointDrive>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_angularYZDrive(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularYZDrive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularYZDrive on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.angularYZDrive = LuaScriptMgr.GetNetObject<JointDrive>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_slerpDrive(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name slerpDrive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index slerpDrive on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.slerpDrive = LuaScriptMgr.GetNetObject<JointDrive>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_projectionMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name projectionMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index projectionMode on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.projectionMode = LuaScriptMgr.GetNetObject<JointProjectionMode>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_projectionDistance(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name projectionDistance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index projectionDistance on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.projectionDistance = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_projectionAngle(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name projectionAngle");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index projectionAngle on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.projectionAngle = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_configuredInWorldSpace(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name configuredInWorldSpace");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index configuredInWorldSpace on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.configuredInWorldSpace = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_swapBodies(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name swapBodies");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index swapBodies on a nil value");
			}
		}

		ConfigurableJoint obj = (ConfigurableJoint)o;
		obj.swapBodies = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}
}

