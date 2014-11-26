using UnityEngine;
using System;
using LuaInterface;

public class RigidbodyWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("SetDensity", SetDensity),
		new LuaMethod("AddForce", AddForce),
		new LuaMethod("AddRelativeForce", AddRelativeForce),
		new LuaMethod("AddTorque", AddTorque),
		new LuaMethod("AddRelativeTorque", AddRelativeTorque),
		new LuaMethod("AddForceAtPosition", AddForceAtPosition),
		new LuaMethod("AddExplosionForce", AddExplosionForce),
		new LuaMethod("ClosestPointOnBounds", ClosestPointOnBounds),
		new LuaMethod("GetRelativePointVelocity", GetRelativePointVelocity),
		new LuaMethod("GetPointVelocity", GetPointVelocity),
		new LuaMethod("MovePosition", MovePosition),
		new LuaMethod("MoveRotation", MoveRotation),
		new LuaMethod("Sleep", Sleep),
		new LuaMethod("IsSleeping", IsSleeping),
		new LuaMethod("WakeUp", WakeUp),
		new LuaMethod("SweepTest", SweepTest),
		new LuaMethod("SweepTestAll", SweepTestAll),
		new LuaMethod("New", _CreateRigidbody),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("velocity", get_velocity, set_velocity),
		new LuaField("angularVelocity", get_angularVelocity, set_angularVelocity),
		new LuaField("drag", get_drag, set_drag),
		new LuaField("angularDrag", get_angularDrag, set_angularDrag),
		new LuaField("mass", get_mass, set_mass),
		new LuaField("useGravity", get_useGravity, set_useGravity),
		new LuaField("isKinematic", get_isKinematic, set_isKinematic),
		new LuaField("freezeRotation", get_freezeRotation, set_freezeRotation),
		new LuaField("constraints", get_constraints, set_constraints),
		new LuaField("collisionDetectionMode", get_collisionDetectionMode, set_collisionDetectionMode),
		new LuaField("centerOfMass", get_centerOfMass, set_centerOfMass),
		new LuaField("worldCenterOfMass", get_worldCenterOfMass, null),
		new LuaField("inertiaTensorRotation", get_inertiaTensorRotation, set_inertiaTensorRotation),
		new LuaField("inertiaTensor", get_inertiaTensor, set_inertiaTensor),
		new LuaField("detectCollisions", get_detectCollisions, set_detectCollisions),
		new LuaField("useConeFriction", get_useConeFriction, set_useConeFriction),
		new LuaField("position", get_position, set_position),
		new LuaField("rotation", get_rotation, set_rotation),
		new LuaField("interpolation", get_interpolation, set_interpolation),
		new LuaField("solverIterationCount", get_solverIterationCount, set_solverIterationCount),
		new LuaField("sleepVelocity", get_sleepVelocity, set_sleepVelocity),
		new LuaField("sleepAngularVelocity", get_sleepAngularVelocity, set_sleepAngularVelocity),
		new LuaField("maxAngularVelocity", get_maxAngularVelocity, set_maxAngularVelocity),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateRigidbody(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Rigidbody obj = new Rigidbody();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Rigidbody.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Rigidbody));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Rigidbody", typeof(Rigidbody), regs, fields, "UnityEngine.Component");
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

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.PushValue(L, obj.velocity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_angularVelocity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularVelocity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularVelocity on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.PushValue(L, obj.angularVelocity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_drag(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name drag");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index drag on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.Push(L, obj.drag);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_angularDrag(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularDrag");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularDrag on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.Push(L, obj.angularDrag);
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

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.Push(L, obj.mass);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useGravity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useGravity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useGravity on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.Push(L, obj.useGravity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isKinematic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isKinematic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isKinematic on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.Push(L, obj.isKinematic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_freezeRotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name freezeRotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index freezeRotation on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.Push(L, obj.freezeRotation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_constraints(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name constraints");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index constraints on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.PushEnum(L, obj.constraints);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_collisionDetectionMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name collisionDetectionMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index collisionDetectionMode on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.PushEnum(L, obj.collisionDetectionMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_centerOfMass(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name centerOfMass");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index centerOfMass on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.PushValue(L, obj.centerOfMass);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_worldCenterOfMass(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name worldCenterOfMass");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index worldCenterOfMass on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.PushValue(L, obj.worldCenterOfMass);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_inertiaTensorRotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name inertiaTensorRotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index inertiaTensorRotation on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.PushValue(L, obj.inertiaTensorRotation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_inertiaTensor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name inertiaTensor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index inertiaTensor on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.PushValue(L, obj.inertiaTensor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_detectCollisions(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name detectCollisions");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index detectCollisions on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.Push(L, obj.detectCollisions);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useConeFriction(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useConeFriction");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useConeFriction on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.Push(L, obj.useConeFriction);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_position(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name position");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index position on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.PushValue(L, obj.position);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rotation on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.PushValue(L, obj.rotation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_interpolation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name interpolation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index interpolation on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.PushEnum(L, obj.interpolation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_solverIterationCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name solverIterationCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index solverIterationCount on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.Push(L, obj.solverIterationCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sleepVelocity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sleepVelocity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sleepVelocity on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.Push(L, obj.sleepVelocity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sleepAngularVelocity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sleepAngularVelocity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sleepAngularVelocity on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.Push(L, obj.sleepAngularVelocity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxAngularVelocity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxAngularVelocity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxAngularVelocity on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		LuaScriptMgr.Push(L, obj.maxAngularVelocity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_velocity(IntPtr L)
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

		Rigidbody obj = (Rigidbody)o;
		obj.velocity = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_angularVelocity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularVelocity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularVelocity on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.angularVelocity = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_drag(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name drag");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index drag on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.drag = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_angularDrag(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularDrag");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularDrag on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.angularDrag = (float)LuaScriptMgr.GetNumber(L, 3);
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

		Rigidbody obj = (Rigidbody)o;
		obj.mass = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useGravity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useGravity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useGravity on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.useGravity = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isKinematic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isKinematic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isKinematic on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.isKinematic = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_freezeRotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name freezeRotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index freezeRotation on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.freezeRotation = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_constraints(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name constraints");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index constraints on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.constraints = LuaScriptMgr.GetNetObject<RigidbodyConstraints>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_collisionDetectionMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name collisionDetectionMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index collisionDetectionMode on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.collisionDetectionMode = LuaScriptMgr.GetNetObject<CollisionDetectionMode>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_centerOfMass(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name centerOfMass");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index centerOfMass on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.centerOfMass = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_inertiaTensorRotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name inertiaTensorRotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index inertiaTensorRotation on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.inertiaTensorRotation = LuaScriptMgr.GetNetObject<Quaternion>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_inertiaTensor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name inertiaTensor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index inertiaTensor on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.inertiaTensor = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_detectCollisions(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name detectCollisions");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index detectCollisions on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.detectCollisions = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useConeFriction(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useConeFriction");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useConeFriction on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.useConeFriction = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_position(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name position");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index position on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.position = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rotation on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.rotation = LuaScriptMgr.GetNetObject<Quaternion>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_interpolation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name interpolation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index interpolation on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.interpolation = LuaScriptMgr.GetNetObject<RigidbodyInterpolation>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_solverIterationCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name solverIterationCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index solverIterationCount on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.solverIterationCount = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sleepVelocity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sleepVelocity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sleepVelocity on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.sleepVelocity = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sleepAngularVelocity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sleepAngularVelocity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sleepAngularVelocity on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.sleepAngularVelocity = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxAngularVelocity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxAngularVelocity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxAngularVelocity on a nil value");
			}
		}

		Rigidbody obj = (Rigidbody)o;
		obj.maxAngularVelocity = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetDensity(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		obj.SetDensity(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddForce(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			obj.AddForce(arg0);
			return 0;
		}
		else if (count == 3)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			ForceMode arg1 = LuaScriptMgr.GetNetObject<ForceMode>(L, 3);
			obj.AddForce(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			obj.AddForce(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 5)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			ForceMode arg3 = LuaScriptMgr.GetNetObject<ForceMode>(L, 5);
			obj.AddForce(arg0,arg1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Rigidbody.AddForce");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddRelativeForce(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			obj.AddRelativeForce(arg0);
			return 0;
		}
		else if (count == 3)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			ForceMode arg1 = LuaScriptMgr.GetNetObject<ForceMode>(L, 3);
			obj.AddRelativeForce(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			obj.AddRelativeForce(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 5)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			ForceMode arg3 = LuaScriptMgr.GetNetObject<ForceMode>(L, 5);
			obj.AddRelativeForce(arg0,arg1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Rigidbody.AddRelativeForce");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddTorque(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			obj.AddTorque(arg0);
			return 0;
		}
		else if (count == 3)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			ForceMode arg1 = LuaScriptMgr.GetNetObject<ForceMode>(L, 3);
			obj.AddTorque(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			obj.AddTorque(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 5)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			ForceMode arg3 = LuaScriptMgr.GetNetObject<ForceMode>(L, 5);
			obj.AddTorque(arg0,arg1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Rigidbody.AddTorque");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddRelativeTorque(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			obj.AddRelativeTorque(arg0);
			return 0;
		}
		else if (count == 3)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			ForceMode arg1 = LuaScriptMgr.GetNetObject<ForceMode>(L, 3);
			obj.AddRelativeTorque(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			obj.AddRelativeTorque(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 5)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			ForceMode arg3 = LuaScriptMgr.GetNetObject<ForceMode>(L, 5);
			obj.AddRelativeTorque(arg0,arg1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Rigidbody.AddRelativeTorque");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddForceAtPosition(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
			obj.AddForceAtPosition(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
			ForceMode arg2 = LuaScriptMgr.GetNetObject<ForceMode>(L, 4);
			obj.AddForceAtPosition(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Rigidbody.AddForceAtPosition");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddExplosionForce(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			obj.AddExplosionForce(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 5)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 5);
			obj.AddExplosionForce(arg0,arg1,arg2,arg3);
			return 0;
		}
		else if (count == 6)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 5);
			ForceMode arg4 = LuaScriptMgr.GetNetObject<ForceMode>(L, 6);
			obj.AddExplosionForce(arg0,arg1,arg2,arg3,arg4);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Rigidbody.AddExplosionForce");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClosestPointOnBounds(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Vector3 o = obj.ClosestPointOnBounds(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRelativePointVelocity(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Vector3 o = obj.GetRelativePointVelocity(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPointVelocity(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Vector3 o = obj.GetPointVelocity(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MovePosition(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		obj.MovePosition(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MoveRotation(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
		Quaternion arg0 = LuaScriptMgr.GetNetObject<Quaternion>(L, 2);
		obj.MoveRotation(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Sleep(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
		obj.Sleep();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsSleeping(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
		bool o = obj.IsSleeping();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WakeUp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
		obj.WakeUp();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SweepTest(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			RaycastHit arg1 = LuaScriptMgr.GetNetObject<RaycastHit>(L, 3);
			bool o = obj.SweepTest(arg0,out arg1);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg1);
			return 2;
		}
		else if (count == 4)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			RaycastHit arg1 = LuaScriptMgr.GetNetObject<RaycastHit>(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			bool o = obj.SweepTest(arg0,out arg1,arg2);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg1);
			return 2;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Rigidbody.SweepTest");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SweepTestAll(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			RaycastHit[] o = obj.SweepTestAll(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Rigidbody obj = LuaScriptMgr.GetNetObject<Rigidbody>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			RaycastHit[] o = obj.SweepTestAll(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Rigidbody.SweepTestAll");
		}

		return 0;
	}
}

