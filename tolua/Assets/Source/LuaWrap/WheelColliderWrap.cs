using UnityEngine;
using System;
using LuaInterface;

public class WheelColliderWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetGroundHit", GetGroundHit),
		new LuaMethod("New", _CreateWheelCollider),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("center", get_center, set_center),
		new LuaField("radius", get_radius, set_radius),
		new LuaField("suspensionDistance", get_suspensionDistance, set_suspensionDistance),
		new LuaField("suspensionSpring", get_suspensionSpring, set_suspensionSpring),
		new LuaField("mass", get_mass, set_mass),
		new LuaField("forwardFriction", get_forwardFriction, set_forwardFriction),
		new LuaField("sidewaysFriction", get_sidewaysFriction, set_sidewaysFriction),
		new LuaField("motorTorque", get_motorTorque, set_motorTorque),
		new LuaField("brakeTorque", get_brakeTorque, set_brakeTorque),
		new LuaField("steerAngle", get_steerAngle, set_steerAngle),
		new LuaField("isGrounded", get_isGrounded, null),
		new LuaField("rpm", get_rpm, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateWheelCollider(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			WheelCollider obj = new WheelCollider();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: WheelCollider.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(WheelCollider));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.WheelCollider", typeof(WheelCollider), regs, fields, "UnityEngine.Collider");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_center(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name center");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index center on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		LuaScriptMgr.PushValue(L, obj.center);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_radius(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name radius");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index radius on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		LuaScriptMgr.Push(L, obj.radius);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_suspensionDistance(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name suspensionDistance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index suspensionDistance on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		LuaScriptMgr.Push(L, obj.suspensionDistance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_suspensionSpring(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name suspensionSpring");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index suspensionSpring on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		LuaScriptMgr.PushValue(L, obj.suspensionSpring);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mass(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mass");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mass on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		LuaScriptMgr.Push(L, obj.mass);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_forwardFriction(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name forwardFriction");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index forwardFriction on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		LuaScriptMgr.PushValue(L, obj.forwardFriction);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sidewaysFriction(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sidewaysFriction");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sidewaysFriction on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		LuaScriptMgr.PushValue(L, obj.sidewaysFriction);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_motorTorque(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name motorTorque");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index motorTorque on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		LuaScriptMgr.Push(L, obj.motorTorque);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_brakeTorque(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name brakeTorque");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index brakeTorque on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		LuaScriptMgr.Push(L, obj.brakeTorque);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_steerAngle(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name steerAngle");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index steerAngle on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		LuaScriptMgr.Push(L, obj.steerAngle);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isGrounded(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isGrounded");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isGrounded on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		LuaScriptMgr.Push(L, obj.isGrounded);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rpm(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rpm");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rpm on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		LuaScriptMgr.Push(L, obj.rpm);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_center(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name center");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index center on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		obj.center = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_radius(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name radius");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index radius on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		obj.radius = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_suspensionDistance(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name suspensionDistance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index suspensionDistance on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		obj.suspensionDistance = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_suspensionSpring(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name suspensionSpring");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index suspensionSpring on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		obj.suspensionSpring = LuaScriptMgr.GetNetObject<JointSpring>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mass(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mass");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mass on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		obj.mass = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_forwardFriction(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name forwardFriction");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index forwardFriction on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		obj.forwardFriction = LuaScriptMgr.GetNetObject<WheelFrictionCurve>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sidewaysFriction(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sidewaysFriction");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sidewaysFriction on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		obj.sidewaysFriction = LuaScriptMgr.GetNetObject<WheelFrictionCurve>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_motorTorque(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name motorTorque");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index motorTorque on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		obj.motorTorque = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_brakeTorque(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name brakeTorque");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index brakeTorque on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		obj.brakeTorque = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_steerAngle(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name steerAngle");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index steerAngle on a nil value");
			}
		}

		WheelCollider obj = (WheelCollider)o;
		obj.steerAngle = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetGroundHit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		WheelCollider obj = LuaScriptMgr.GetNetObject<WheelCollider>(L, 1);
		WheelHit arg0 = LuaScriptMgr.GetNetObject<WheelHit>(L, 2);
		bool o = obj.GetGroundHit(out arg0);
		LuaScriptMgr.Push(L, o);
		LuaScriptMgr.PushValue(L, arg0);
		return 2;
	}
}

