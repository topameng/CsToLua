using UnityEngine;
using System;
using LuaInterface;

public class PhysicsWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Raycast", Raycast),
		new LuaMethod("RaycastAll", RaycastAll),
		new LuaMethod("Linecast", Linecast),
		new LuaMethod("OverlapSphere", OverlapSphere),
		new LuaMethod("CapsuleCast", CapsuleCast),
		new LuaMethod("SphereCast", SphereCast),
		new LuaMethod("CapsuleCastAll", CapsuleCastAll),
		new LuaMethod("SphereCastAll", SphereCastAll),
		new LuaMethod("CheckSphere", CheckSphere),
		new LuaMethod("CheckCapsule", CheckCapsule),
		new LuaMethod("IgnoreCollision", IgnoreCollision),
		new LuaMethod("IgnoreLayerCollision", IgnoreLayerCollision),
		new LuaMethod("GetIgnoreLayerCollision", GetIgnoreLayerCollision),
		new LuaMethod("New", _CreatePhysics),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("kIgnoreRaycastLayer", get_kIgnoreRaycastLayer, null),
		new LuaField("kDefaultRaycastLayers", get_kDefaultRaycastLayers, null),
		new LuaField("kAllLayers", get_kAllLayers, null),
		new LuaField("IgnoreRaycastLayer", get_IgnoreRaycastLayer, null),
		new LuaField("DefaultRaycastLayers", get_DefaultRaycastLayers, null),
		new LuaField("AllLayers", get_AllLayers, null),
		new LuaField("gravity", get_gravity, set_gravity),
		new LuaField("minPenetrationForPenalty", get_minPenetrationForPenalty, set_minPenetrationForPenalty),
		new LuaField("bounceThreshold", get_bounceThreshold, set_bounceThreshold),
		new LuaField("sleepVelocity", get_sleepVelocity, set_sleepVelocity),
		new LuaField("sleepAngularVelocity", get_sleepAngularVelocity, set_sleepAngularVelocity),
		new LuaField("maxAngularVelocity", get_maxAngularVelocity, set_maxAngularVelocity),
		new LuaField("solverIterationCount", get_solverIterationCount, set_solverIterationCount),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreatePhysics(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Physics obj = new Physics();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Physics));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Physics", typeof(Physics), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_kIgnoreRaycastLayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics.kIgnoreRaycastLayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_kDefaultRaycastLayers(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics.kDefaultRaycastLayers);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_kAllLayers(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics.kAllLayers);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IgnoreRaycastLayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics.IgnoreRaycastLayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DefaultRaycastLayers(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics.DefaultRaycastLayers);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AllLayers(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics.AllLayers);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gravity(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Physics.gravity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_minPenetrationForPenalty(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics.minPenetrationForPenalty);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bounceThreshold(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics.bounceThreshold);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sleepVelocity(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics.sleepVelocity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sleepAngularVelocity(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics.sleepAngularVelocity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxAngularVelocity(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics.maxAngularVelocity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_solverIterationCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics.solverIterationCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_gravity(IntPtr L)
	{
		Physics.gravity = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_minPenetrationForPenalty(IntPtr L)
	{
		Physics.minPenetrationForPenalty = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bounceThreshold(IntPtr L)
	{
		Physics.bounceThreshold = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sleepVelocity(IntPtr L)
	{
		Physics.sleepVelocity = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sleepAngularVelocity(IntPtr L)
	{
		Physics.sleepAngularVelocity = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxAngularVelocity(IntPtr L)
	{
		Physics.maxAngularVelocity = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_solverIterationCount(IntPtr L)
	{
		Physics.solverIterationCount = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Raycast(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(Ray), typeof(float)};
		Type[] types2 = {typeof(Ray), typeof(RaycastHit)};
		Type[] types3 = {typeof(Vector3), typeof(Vector3)};
		Type[] types4 = {typeof(Ray), typeof(float), typeof(int)};
		Type[] types5 = {typeof(Vector3), typeof(Vector3), typeof(float)};
		Type[] types6 = {typeof(Ray), typeof(RaycastHit), typeof(float)};
		Type[] types7 = {typeof(Vector3), typeof(Vector3), typeof(RaycastHit)};
		Type[] types8 = {typeof(Vector3), typeof(Vector3), typeof(float), typeof(int)};
		Type[] types9 = {typeof(Vector3), typeof(Vector3), typeof(RaycastHit), typeof(float)};
		Type[] types10 = {typeof(Ray), typeof(RaycastHit), typeof(float), typeof(int)};

		if (count == 1)
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			bool o = Physics.Raycast(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			bool o = Physics.Raycast(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			RaycastHit arg1 = LuaScriptMgr.GetNetObject<RaycastHit>(L, 2);
			bool o = Physics.Raycast(arg0,out arg1);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg1);
			return 2;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types3, 1))
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			bool o = Physics.Raycast(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types4, 1))
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			bool o = Physics.Raycast(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types5, 1))
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			bool o = Physics.Raycast(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types6, 1))
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			RaycastHit arg1 = LuaScriptMgr.GetNetObject<RaycastHit>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			bool o = Physics.Raycast(arg0,out arg1,arg2);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg1);
			return 2;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types7, 1))
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			RaycastHit arg2 = LuaScriptMgr.GetNetObject<RaycastHit>(L, 3);
			bool o = Physics.Raycast(arg0,arg1,out arg2);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg2);
			return 2;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, types8, 1))
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			bool o = Physics.Raycast(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, types9, 1))
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			RaycastHit arg2 = LuaScriptMgr.GetNetObject<RaycastHit>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			bool o = Physics.Raycast(arg0,arg1,out arg2,arg3);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg2);
			return 2;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, types10, 1))
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			RaycastHit arg1 = LuaScriptMgr.GetNetObject<RaycastHit>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			bool o = Physics.Raycast(arg0,out arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg1);
			return 2;
		}
		else if (count == 5)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			RaycastHit arg2 = LuaScriptMgr.GetNetObject<RaycastHit>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 5);
			bool o = Physics.Raycast(arg0,arg1,out arg2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg2);
			return 2;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics.Raycast");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RaycastAll(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(Vector3), typeof(Vector3)};
		Type[] types2 = {typeof(Ray), typeof(float)};
		Type[] types3 = {typeof(Vector3), typeof(Vector3), typeof(float)};
		Type[] types4 = {typeof(Ray), typeof(float), typeof(int)};

		if (count == 1)
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			RaycastHit[] o = Physics.RaycastAll(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			RaycastHit[] o = Physics.RaycastAll(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			RaycastHit[] o = Physics.RaycastAll(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types3, 1))
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			RaycastHit[] o = Physics.RaycastAll(arg0,arg1,arg2);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types4, 1))
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			RaycastHit[] o = Physics.RaycastAll(arg0,arg1,arg2);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			RaycastHit[] o = Physics.RaycastAll(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics.RaycastAll");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Linecast(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(Vector3), typeof(Vector3), typeof(RaycastHit)};
		Type[] types2 = {typeof(Vector3), typeof(Vector3), typeof(int)};

		if (count == 2)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			bool o = Physics.Linecast(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			RaycastHit arg2 = LuaScriptMgr.GetNetObject<RaycastHit>(L, 3);
			bool o = Physics.Linecast(arg0,arg1,out arg2);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg2);
			return 2;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			bool o = Physics.Linecast(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			RaycastHit arg2 = LuaScriptMgr.GetNetObject<RaycastHit>(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			bool o = Physics.Linecast(arg0,arg1,out arg2,arg3);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg2);
			return 2;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics.Linecast");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OverlapSphere(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Collider[] o = Physics.OverlapSphere(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			Collider[] o = Physics.OverlapSphere(arg0,arg1,arg2);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics.OverlapSphere");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CapsuleCast(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3), typeof(RaycastHit)};
		Type[] types2 = {typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3), typeof(float)};
		Type[] types3 = {typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3), typeof(RaycastHit), typeof(float)};
		Type[] types4 = {typeof(Vector3), typeof(Vector3), typeof(float), typeof(Vector3), typeof(float), typeof(int)};

		if (count == 4)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector3 arg3 = LuaScriptMgr.GetNetObject<Vector3>(L, 4);
			bool o = Physics.CapsuleCast(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector3 arg3 = LuaScriptMgr.GetNetObject<Vector3>(L, 4);
			RaycastHit arg4 = LuaScriptMgr.GetNetObject<RaycastHit>(L, 5);
			bool o = Physics.CapsuleCast(arg0,arg1,arg2,arg3,out arg4);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg4);
			return 2;
		}
		else if (count == 5 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector3 arg3 = LuaScriptMgr.GetNetObject<Vector3>(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			bool o = Physics.CapsuleCast(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 6 && LuaScriptMgr.CheckTypes(L, types3, 1))
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector3 arg3 = LuaScriptMgr.GetNetObject<Vector3>(L, 4);
			RaycastHit arg4 = LuaScriptMgr.GetNetObject<RaycastHit>(L, 5);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 6);
			bool o = Physics.CapsuleCast(arg0,arg1,arg2,arg3,out arg4,arg5);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg4);
			return 2;
		}
		else if (count == 6 && LuaScriptMgr.CheckTypes(L, types4, 1))
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector3 arg3 = LuaScriptMgr.GetNetObject<Vector3>(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			int arg5 = (int)LuaScriptMgr.GetNumber(L, 6);
			bool o = Physics.CapsuleCast(arg0,arg1,arg2,arg3,arg4,arg5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 7)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector3 arg3 = LuaScriptMgr.GetNetObject<Vector3>(L, 4);
			RaycastHit arg4 = LuaScriptMgr.GetNetObject<RaycastHit>(L, 5);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 6);
			int arg6 = (int)LuaScriptMgr.GetNumber(L, 7);
			bool o = Physics.CapsuleCast(arg0,arg1,arg2,arg3,out arg4,arg5,arg6);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg4);
			return 2;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics.CapsuleCast");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SphereCast(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(Ray), typeof(float), typeof(float)};
		Type[] types2 = {typeof(Ray), typeof(float), typeof(RaycastHit)};
		Type[] types3 = {typeof(Ray), typeof(float), typeof(float), typeof(int)};
		Type[] types4 = {typeof(Ray), typeof(float), typeof(RaycastHit), typeof(float)};
		Type[] types5 = {typeof(Vector3), typeof(float), typeof(Vector3), typeof(RaycastHit)};
		Type[] types6 = {typeof(Ray), typeof(float), typeof(RaycastHit), typeof(float), typeof(int)};
		Type[] types7 = {typeof(Vector3), typeof(float), typeof(Vector3), typeof(RaycastHit), typeof(float)};

		if (count == 2)
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			bool o = Physics.SphereCast(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			bool o = Physics.SphereCast(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			RaycastHit arg2 = LuaScriptMgr.GetNetObject<RaycastHit>(L, 3);
			bool o = Physics.SphereCast(arg0,arg1,out arg2);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg2);
			return 2;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, types3, 1))
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			bool o = Physics.SphereCast(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, types4, 1))
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			RaycastHit arg2 = LuaScriptMgr.GetNetObject<RaycastHit>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			bool o = Physics.SphereCast(arg0,arg1,out arg2,arg3);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg2);
			return 2;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, types5, 1))
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector3 arg2 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
			RaycastHit arg3 = LuaScriptMgr.GetNetObject<RaycastHit>(L, 4);
			bool o = Physics.SphereCast(arg0,arg1,arg2,out arg3);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg3);
			return 2;
		}
		else if (count == 5 && LuaScriptMgr.CheckTypes(L, types6, 1))
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			RaycastHit arg2 = LuaScriptMgr.GetNetObject<RaycastHit>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 5);
			bool o = Physics.SphereCast(arg0,arg1,out arg2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg2);
			return 2;
		}
		else if (count == 5 && LuaScriptMgr.CheckTypes(L, types7, 1))
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector3 arg2 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
			RaycastHit arg3 = LuaScriptMgr.GetNetObject<RaycastHit>(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			bool o = Physics.SphereCast(arg0,arg1,arg2,out arg3,arg4);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg3);
			return 2;
		}
		else if (count == 6)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector3 arg2 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
			RaycastHit arg3 = LuaScriptMgr.GetNetObject<RaycastHit>(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			int arg5 = (int)LuaScriptMgr.GetNumber(L, 6);
			bool o = Physics.SphereCast(arg0,arg1,arg2,out arg3,arg4,arg5);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg3);
			return 2;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics.SphereCast");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CapsuleCastAll(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector3 arg3 = LuaScriptMgr.GetNetObject<Vector3>(L, 4);
			RaycastHit[] o = Physics.CapsuleCastAll(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector3 arg3 = LuaScriptMgr.GetNetObject<Vector3>(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			RaycastHit[] o = Physics.CapsuleCastAll(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector3 arg3 = LuaScriptMgr.GetNetObject<Vector3>(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			int arg5 = (int)LuaScriptMgr.GetNumber(L, 6);
			RaycastHit[] o = Physics.CapsuleCastAll(arg0,arg1,arg2,arg3,arg4,arg5);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics.CapsuleCastAll");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SphereCastAll(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(Ray), typeof(float), typeof(float)};
		Type[] types2 = {typeof(Vector3), typeof(float), typeof(Vector3)};
		Type[] types3 = {typeof(Vector3), typeof(float), typeof(Vector3), typeof(float)};
		Type[] types4 = {typeof(Ray), typeof(float), typeof(float), typeof(int)};

		if (count == 2)
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			RaycastHit[] o = Physics.SphereCastAll(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			RaycastHit[] o = Physics.SphereCastAll(arg0,arg1,arg2);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector3 arg2 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
			RaycastHit[] o = Physics.SphereCastAll(arg0,arg1,arg2);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, types3, 1))
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector3 arg2 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			RaycastHit[] o = Physics.SphereCastAll(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, types4, 1))
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			RaycastHit[] o = Physics.SphereCastAll(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector3 arg2 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 5);
			RaycastHit[] o = Physics.SphereCastAll(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics.SphereCastAll");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CheckSphere(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			bool o = Physics.CheckSphere(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			bool o = Physics.CheckSphere(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics.CheckSphere");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CheckCapsule(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			bool o = Physics.CheckCapsule(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			bool o = Physics.CheckCapsule(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics.CheckCapsule");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IgnoreCollision(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Collider arg0 = LuaScriptMgr.GetNetObject<Collider>(L, 1);
			Collider arg1 = LuaScriptMgr.GetNetObject<Collider>(L, 2);
			Physics.IgnoreCollision(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			Collider arg0 = LuaScriptMgr.GetNetObject<Collider>(L, 1);
			Collider arg1 = LuaScriptMgr.GetNetObject<Collider>(L, 2);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 3);
			Physics.IgnoreCollision(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics.IgnoreCollision");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IgnoreLayerCollision(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			Physics.IgnoreLayerCollision(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 3);
			Physics.IgnoreLayerCollision(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics.IgnoreLayerCollision");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetIgnoreLayerCollision(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		bool o = Physics.GetIgnoreLayerCollision(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

