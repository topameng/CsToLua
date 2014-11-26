using UnityEngine;
using System;
using LuaInterface;

public class Physics2DWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("IgnoreCollision", IgnoreCollision),
		new LuaMethod("GetIgnoreCollision", GetIgnoreCollision),
		new LuaMethod("IgnoreLayerCollision", IgnoreLayerCollision),
		new LuaMethod("GetIgnoreLayerCollision", GetIgnoreLayerCollision),
		new LuaMethod("Linecast", Linecast),
		new LuaMethod("LinecastAll", LinecastAll),
		new LuaMethod("LinecastNonAlloc", LinecastNonAlloc),
		new LuaMethod("Raycast", Raycast),
		new LuaMethod("RaycastAll", RaycastAll),
		new LuaMethod("RaycastNonAlloc", RaycastNonAlloc),
		new LuaMethod("CircleCast", CircleCast),
		new LuaMethod("CircleCastAll", CircleCastAll),
		new LuaMethod("CircleCastNonAlloc", CircleCastNonAlloc),
		new LuaMethod("BoxCast", BoxCast),
		new LuaMethod("BoxCastAll", BoxCastAll),
		new LuaMethod("BoxCastNonAlloc", BoxCastNonAlloc),
		new LuaMethod("GetRayIntersection", GetRayIntersection),
		new LuaMethod("GetRayIntersectionAll", GetRayIntersectionAll),
		new LuaMethod("GetRayIntersectionNonAlloc", GetRayIntersectionNonAlloc),
		new LuaMethod("OverlapPoint", OverlapPoint),
		new LuaMethod("OverlapPointAll", OverlapPointAll),
		new LuaMethod("OverlapPointNonAlloc", OverlapPointNonAlloc),
		new LuaMethod("OverlapCircle", OverlapCircle),
		new LuaMethod("OverlapCircleAll", OverlapCircleAll),
		new LuaMethod("OverlapCircleNonAlloc", OverlapCircleNonAlloc),
		new LuaMethod("OverlapArea", OverlapArea),
		new LuaMethod("OverlapAreaAll", OverlapAreaAll),
		new LuaMethod("OverlapAreaNonAlloc", OverlapAreaNonAlloc),
		new LuaMethod("New", _CreatePhysics2D),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("IgnoreRaycastLayer", get_IgnoreRaycastLayer, null),
		new LuaField("DefaultRaycastLayers", get_DefaultRaycastLayers, null),
		new LuaField("AllLayers", get_AllLayers, null),
		new LuaField("velocityIterations", get_velocityIterations, set_velocityIterations),
		new LuaField("positionIterations", get_positionIterations, set_positionIterations),
		new LuaField("gravity", get_gravity, set_gravity),
		new LuaField("raycastsHitTriggers", get_raycastsHitTriggers, set_raycastsHitTriggers),
		new LuaField("velocityThreshold", get_velocityThreshold, set_velocityThreshold),
		new LuaField("maxLinearCorrection", get_maxLinearCorrection, set_maxLinearCorrection),
		new LuaField("maxAngularCorrection", get_maxAngularCorrection, set_maxAngularCorrection),
		new LuaField("maxTranslationSpeed", get_maxTranslationSpeed, set_maxTranslationSpeed),
		new LuaField("maxRotationSpeed", get_maxRotationSpeed, set_maxRotationSpeed),
		new LuaField("baumgarteScale", get_baumgarteScale, set_baumgarteScale),
		new LuaField("baumgarteTOIScale", get_baumgarteTOIScale, set_baumgarteTOIScale),
		new LuaField("timeToSleep", get_timeToSleep, set_timeToSleep),
		new LuaField("linearSleepTolerance", get_linearSleepTolerance, set_linearSleepTolerance),
		new LuaField("angularSleepTolerance", get_angularSleepTolerance, set_angularSleepTolerance),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreatePhysics2D(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Physics2D obj = new Physics2D();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Physics2D));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Physics2D", typeof(Physics2D), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IgnoreRaycastLayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics2D.IgnoreRaycastLayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DefaultRaycastLayers(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics2D.DefaultRaycastLayers);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AllLayers(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics2D.AllLayers);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_velocityIterations(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics2D.velocityIterations);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_positionIterations(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics2D.positionIterations);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gravity(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Physics2D.gravity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_raycastsHitTriggers(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics2D.raycastsHitTriggers);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_velocityThreshold(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics2D.velocityThreshold);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxLinearCorrection(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics2D.maxLinearCorrection);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxAngularCorrection(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics2D.maxAngularCorrection);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxTranslationSpeed(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics2D.maxTranslationSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxRotationSpeed(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics2D.maxRotationSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_baumgarteScale(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics2D.baumgarteScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_baumgarteTOIScale(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics2D.baumgarteTOIScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_timeToSleep(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics2D.timeToSleep);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_linearSleepTolerance(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics2D.linearSleepTolerance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_angularSleepTolerance(IntPtr L)
	{
		LuaScriptMgr.Push(L, Physics2D.angularSleepTolerance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_velocityIterations(IntPtr L)
	{
		Physics2D.velocityIterations = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_positionIterations(IntPtr L)
	{
		Physics2D.positionIterations = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_gravity(IntPtr L)
	{
		Physics2D.gravity = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_raycastsHitTriggers(IntPtr L)
	{
		Physics2D.raycastsHitTriggers = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_velocityThreshold(IntPtr L)
	{
		Physics2D.velocityThreshold = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxLinearCorrection(IntPtr L)
	{
		Physics2D.maxLinearCorrection = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxAngularCorrection(IntPtr L)
	{
		Physics2D.maxAngularCorrection = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxTranslationSpeed(IntPtr L)
	{
		Physics2D.maxTranslationSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxRotationSpeed(IntPtr L)
	{
		Physics2D.maxRotationSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_baumgarteScale(IntPtr L)
	{
		Physics2D.baumgarteScale = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_baumgarteTOIScale(IntPtr L)
	{
		Physics2D.baumgarteTOIScale = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_timeToSleep(IntPtr L)
	{
		Physics2D.timeToSleep = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_linearSleepTolerance(IntPtr L)
	{
		Physics2D.linearSleepTolerance = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_angularSleepTolerance(IntPtr L)
	{
		Physics2D.angularSleepTolerance = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IgnoreCollision(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Collider2D arg0 = LuaScriptMgr.GetNetObject<Collider2D>(L, 1);
			Collider2D arg1 = LuaScriptMgr.GetNetObject<Collider2D>(L, 2);
			Physics2D.IgnoreCollision(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			Collider2D arg0 = LuaScriptMgr.GetNetObject<Collider2D>(L, 1);
			Collider2D arg1 = LuaScriptMgr.GetNetObject<Collider2D>(L, 2);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 3);
			Physics2D.IgnoreCollision(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.IgnoreCollision");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetIgnoreCollision(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Collider2D arg0 = LuaScriptMgr.GetNetObject<Collider2D>(L, 1);
		Collider2D arg1 = LuaScriptMgr.GetNetObject<Collider2D>(L, 2);
		bool o = Physics2D.GetIgnoreCollision(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IgnoreLayerCollision(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			Physics2D.IgnoreLayerCollision(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 3);
			Physics2D.IgnoreLayerCollision(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.IgnoreLayerCollision");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetIgnoreLayerCollision(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		bool o = Physics2D.GetIgnoreLayerCollision(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Linecast(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			RaycastHit2D o = Physics2D.Linecast(arg0,arg1);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			RaycastHit2D o = Physics2D.Linecast(arg0,arg1,arg2);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			RaycastHit2D o = Physics2D.Linecast(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			RaycastHit2D o = Physics2D.Linecast(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.Linecast");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LinecastAll(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			RaycastHit2D[] o = Physics2D.LinecastAll(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			RaycastHit2D[] o = Physics2D.LinecastAll(arg0,arg1,arg2);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			RaycastHit2D[] o = Physics2D.LinecastAll(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			RaycastHit2D[] o = Physics2D.LinecastAll(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.LinecastAll");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LinecastNonAlloc(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			RaycastHit2D[] objs2 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 3);
			int o = Physics2D.LinecastNonAlloc(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			RaycastHit2D[] objs2 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			int o = Physics2D.LinecastNonAlloc(arg0,arg1,objs2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			RaycastHit2D[] objs2 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			int o = Physics2D.LinecastNonAlloc(arg0,arg1,objs2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			RaycastHit2D[] objs2 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 6);
			int o = Physics2D.LinecastNonAlloc(arg0,arg1,objs2,arg3,arg4,arg5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.LinecastNonAlloc");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Raycast(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			RaycastHit2D o = Physics2D.Raycast(arg0,arg1);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			RaycastHit2D o = Physics2D.Raycast(arg0,arg1,arg2);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			RaycastHit2D o = Physics2D.Raycast(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			RaycastHit2D o = Physics2D.Raycast(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 6);
			RaycastHit2D o = Physics2D.Raycast(arg0,arg1,arg2,arg3,arg4,arg5);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.Raycast");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RaycastAll(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			RaycastHit2D[] o = Physics2D.RaycastAll(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			RaycastHit2D[] o = Physics2D.RaycastAll(arg0,arg1,arg2);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			RaycastHit2D[] o = Physics2D.RaycastAll(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			RaycastHit2D[] o = Physics2D.RaycastAll(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 6);
			RaycastHit2D[] o = Physics2D.RaycastAll(arg0,arg1,arg2,arg3,arg4,arg5);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.RaycastAll");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RaycastNonAlloc(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			RaycastHit2D[] objs2 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 3);
			int o = Physics2D.RaycastNonAlloc(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			RaycastHit2D[] objs2 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			int o = Physics2D.RaycastNonAlloc(arg0,arg1,objs2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			RaycastHit2D[] objs2 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 5);
			int o = Physics2D.RaycastNonAlloc(arg0,arg1,objs2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			RaycastHit2D[] objs2 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 5);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 6);
			int o = Physics2D.RaycastNonAlloc(arg0,arg1,objs2,arg3,arg4,arg5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 7)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			RaycastHit2D[] objs2 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 5);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 6);
			float arg6 = (float)LuaScriptMgr.GetNumber(L, 7);
			int o = Physics2D.RaycastNonAlloc(arg0,arg1,objs2,arg3,arg4,arg5,arg6);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.RaycastNonAlloc");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CircleCast(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			RaycastHit2D o = Physics2D.CircleCast(arg0,arg1,arg2);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			RaycastHit2D o = Physics2D.CircleCast(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 5);
			RaycastHit2D o = Physics2D.CircleCast(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 5);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 6);
			RaycastHit2D o = Physics2D.CircleCast(arg0,arg1,arg2,arg3,arg4,arg5);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 7)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 5);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 6);
			float arg6 = (float)LuaScriptMgr.GetNumber(L, 7);
			RaycastHit2D o = Physics2D.CircleCast(arg0,arg1,arg2,arg3,arg4,arg5,arg6);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.CircleCast");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CircleCastAll(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			RaycastHit2D[] o = Physics2D.CircleCastAll(arg0,arg1,arg2);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			RaycastHit2D[] o = Physics2D.CircleCastAll(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 5);
			RaycastHit2D[] o = Physics2D.CircleCastAll(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 5);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 6);
			RaycastHit2D[] o = Physics2D.CircleCastAll(arg0,arg1,arg2,arg3,arg4,arg5);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 7)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 5);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 6);
			float arg6 = (float)LuaScriptMgr.GetNumber(L, 7);
			RaycastHit2D[] o = Physics2D.CircleCastAll(arg0,arg1,arg2,arg3,arg4,arg5,arg6);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.CircleCastAll");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CircleCastNonAlloc(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			RaycastHit2D[] objs3 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 4);
			int o = Physics2D.CircleCastNonAlloc(arg0,arg1,arg2,objs3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			RaycastHit2D[] objs3 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			int o = Physics2D.CircleCastNonAlloc(arg0,arg1,arg2,objs3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			RaycastHit2D[] objs3 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			int arg5 = (int)LuaScriptMgr.GetNumber(L, 6);
			int o = Physics2D.CircleCastNonAlloc(arg0,arg1,arg2,objs3,arg4,arg5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 7)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			RaycastHit2D[] objs3 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			int arg5 = (int)LuaScriptMgr.GetNumber(L, 6);
			float arg6 = (float)LuaScriptMgr.GetNumber(L, 7);
			int o = Physics2D.CircleCastNonAlloc(arg0,arg1,arg2,objs3,arg4,arg5,arg6);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 8)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			RaycastHit2D[] objs3 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			int arg5 = (int)LuaScriptMgr.GetNumber(L, 6);
			float arg6 = (float)LuaScriptMgr.GetNumber(L, 7);
			float arg7 = (float)LuaScriptMgr.GetNumber(L, 8);
			int o = Physics2D.CircleCastNonAlloc(arg0,arg1,arg2,objs3,arg4,arg5,arg6,arg7);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.CircleCastNonAlloc");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BoxCast(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector2 arg3 = LuaScriptMgr.GetNetObject<Vector2>(L, 4);
			RaycastHit2D o = Physics2D.BoxCast(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector2 arg3 = LuaScriptMgr.GetNetObject<Vector2>(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			RaycastHit2D o = Physics2D.BoxCast(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector2 arg3 = LuaScriptMgr.GetNetObject<Vector2>(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			int arg5 = (int)LuaScriptMgr.GetNumber(L, 6);
			RaycastHit2D o = Physics2D.BoxCast(arg0,arg1,arg2,arg3,arg4,arg5);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 7)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector2 arg3 = LuaScriptMgr.GetNetObject<Vector2>(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			int arg5 = (int)LuaScriptMgr.GetNumber(L, 6);
			float arg6 = (float)LuaScriptMgr.GetNumber(L, 7);
			RaycastHit2D o = Physics2D.BoxCast(arg0,arg1,arg2,arg3,arg4,arg5,arg6);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 8)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector2 arg3 = LuaScriptMgr.GetNetObject<Vector2>(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			int arg5 = (int)LuaScriptMgr.GetNumber(L, 6);
			float arg6 = (float)LuaScriptMgr.GetNumber(L, 7);
			float arg7 = (float)LuaScriptMgr.GetNumber(L, 8);
			RaycastHit2D o = Physics2D.BoxCast(arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.BoxCast");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BoxCastAll(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector2 arg3 = LuaScriptMgr.GetNetObject<Vector2>(L, 4);
			RaycastHit2D[] o = Physics2D.BoxCastAll(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector2 arg3 = LuaScriptMgr.GetNetObject<Vector2>(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			RaycastHit2D[] o = Physics2D.BoxCastAll(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector2 arg3 = LuaScriptMgr.GetNetObject<Vector2>(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			int arg5 = (int)LuaScriptMgr.GetNumber(L, 6);
			RaycastHit2D[] o = Physics2D.BoxCastAll(arg0,arg1,arg2,arg3,arg4,arg5);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 7)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector2 arg3 = LuaScriptMgr.GetNetObject<Vector2>(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			int arg5 = (int)LuaScriptMgr.GetNumber(L, 6);
			float arg6 = (float)LuaScriptMgr.GetNumber(L, 7);
			RaycastHit2D[] o = Physics2D.BoxCastAll(arg0,arg1,arg2,arg3,arg4,arg5,arg6);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 8)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector2 arg3 = LuaScriptMgr.GetNetObject<Vector2>(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			int arg5 = (int)LuaScriptMgr.GetNumber(L, 6);
			float arg6 = (float)LuaScriptMgr.GetNumber(L, 7);
			float arg7 = (float)LuaScriptMgr.GetNumber(L, 8);
			RaycastHit2D[] o = Physics2D.BoxCastAll(arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.BoxCastAll");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BoxCastNonAlloc(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 5)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector2 arg3 = LuaScriptMgr.GetNetObject<Vector2>(L, 4);
			RaycastHit2D[] objs4 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 5);
			int o = Physics2D.BoxCastNonAlloc(arg0,arg1,arg2,arg3,objs4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector2 arg3 = LuaScriptMgr.GetNetObject<Vector2>(L, 4);
			RaycastHit2D[] objs4 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 5);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 6);
			int o = Physics2D.BoxCastNonAlloc(arg0,arg1,arg2,arg3,objs4,arg5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 7)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector2 arg3 = LuaScriptMgr.GetNetObject<Vector2>(L, 4);
			RaycastHit2D[] objs4 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 5);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 6);
			int arg6 = (int)LuaScriptMgr.GetNumber(L, 7);
			int o = Physics2D.BoxCastNonAlloc(arg0,arg1,arg2,arg3,objs4,arg5,arg6);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 8)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector2 arg3 = LuaScriptMgr.GetNetObject<Vector2>(L, 4);
			RaycastHit2D[] objs4 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 5);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 6);
			int arg6 = (int)LuaScriptMgr.GetNumber(L, 7);
			float arg7 = (float)LuaScriptMgr.GetNumber(L, 8);
			int o = Physics2D.BoxCastNonAlloc(arg0,arg1,arg2,arg3,objs4,arg5,arg6,arg7);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 9)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector2 arg3 = LuaScriptMgr.GetNetObject<Vector2>(L, 4);
			RaycastHit2D[] objs4 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 5);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 6);
			int arg6 = (int)LuaScriptMgr.GetNumber(L, 7);
			float arg7 = (float)LuaScriptMgr.GetNumber(L, 8);
			float arg8 = (float)LuaScriptMgr.GetNumber(L, 9);
			int o = Physics2D.BoxCastNonAlloc(arg0,arg1,arg2,arg3,objs4,arg5,arg6,arg7,arg8);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.BoxCastNonAlloc");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRayIntersection(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			RaycastHit2D o = Physics2D.GetRayIntersection(arg0);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			RaycastHit2D o = Physics2D.GetRayIntersection(arg0,arg1);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			RaycastHit2D o = Physics2D.GetRayIntersection(arg0,arg1,arg2);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.GetRayIntersection");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRayIntersectionAll(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			RaycastHit2D[] o = Physics2D.GetRayIntersectionAll(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			RaycastHit2D[] o = Physics2D.GetRayIntersectionAll(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			RaycastHit2D[] o = Physics2D.GetRayIntersectionAll(arg0,arg1,arg2);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.GetRayIntersectionAll");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRayIntersectionNonAlloc(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			RaycastHit2D[] objs1 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 2);
			int o = Physics2D.GetRayIntersectionNonAlloc(arg0,objs1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			RaycastHit2D[] objs1 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			int o = Physics2D.GetRayIntersectionNonAlloc(arg0,objs1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 1);
			RaycastHit2D[] objs1 = LuaScriptMgr.GetArrayObject<RaycastHit2D>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			int o = Physics2D.GetRayIntersectionNonAlloc(arg0,objs1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.GetRayIntersectionNonAlloc");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OverlapPoint(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Collider2D o = Physics2D.OverlapPoint(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			Collider2D o = Physics2D.OverlapPoint(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Collider2D o = Physics2D.OverlapPoint(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			Collider2D o = Physics2D.OverlapPoint(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.OverlapPoint");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OverlapPointAll(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Collider2D[] o = Physics2D.OverlapPointAll(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			Collider2D[] o = Physics2D.OverlapPointAll(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Collider2D[] o = Physics2D.OverlapPointAll(arg0,arg1,arg2);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			Collider2D[] o = Physics2D.OverlapPointAll(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.OverlapPointAll");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OverlapPointNonAlloc(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Collider2D[] objs1 = LuaScriptMgr.GetArrayObject<Collider2D>(L, 2);
			int o = Physics2D.OverlapPointNonAlloc(arg0,objs1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Collider2D[] objs1 = LuaScriptMgr.GetArrayObject<Collider2D>(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			int o = Physics2D.OverlapPointNonAlloc(arg0,objs1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Collider2D[] objs1 = LuaScriptMgr.GetArrayObject<Collider2D>(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			int o = Physics2D.OverlapPointNonAlloc(arg0,objs1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Collider2D[] objs1 = LuaScriptMgr.GetArrayObject<Collider2D>(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			int o = Physics2D.OverlapPointNonAlloc(arg0,objs1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.OverlapPointNonAlloc");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OverlapCircle(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Collider2D o = Physics2D.OverlapCircle(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			Collider2D o = Physics2D.OverlapCircle(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			Collider2D o = Physics2D.OverlapCircle(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			Collider2D o = Physics2D.OverlapCircle(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.OverlapCircle");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OverlapCircleAll(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Collider2D[] o = Physics2D.OverlapCircleAll(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			Collider2D[] o = Physics2D.OverlapCircleAll(arg0,arg1,arg2);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			Collider2D[] o = Physics2D.OverlapCircleAll(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			Collider2D[] o = Physics2D.OverlapCircleAll(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.OverlapCircleAll");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OverlapCircleNonAlloc(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Collider2D[] objs2 = LuaScriptMgr.GetArrayObject<Collider2D>(L, 3);
			int o = Physics2D.OverlapCircleNonAlloc(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Collider2D[] objs2 = LuaScriptMgr.GetArrayObject<Collider2D>(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			int o = Physics2D.OverlapCircleNonAlloc(arg0,arg1,objs2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Collider2D[] objs2 = LuaScriptMgr.GetArrayObject<Collider2D>(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			int o = Physics2D.OverlapCircleNonAlloc(arg0,arg1,objs2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Collider2D[] objs2 = LuaScriptMgr.GetArrayObject<Collider2D>(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 6);
			int o = Physics2D.OverlapCircleNonAlloc(arg0,arg1,objs2,arg3,arg4,arg5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.OverlapCircleNonAlloc");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OverlapArea(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			Collider2D o = Physics2D.OverlapArea(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			Collider2D o = Physics2D.OverlapArea(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			Collider2D o = Physics2D.OverlapArea(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			Collider2D o = Physics2D.OverlapArea(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.OverlapArea");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OverlapAreaAll(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			Collider2D[] o = Physics2D.OverlapAreaAll(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			Collider2D[] o = Physics2D.OverlapAreaAll(arg0,arg1,arg2);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			Collider2D[] o = Physics2D.OverlapAreaAll(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			Collider2D[] o = Physics2D.OverlapAreaAll(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.OverlapAreaAll");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OverlapAreaNonAlloc(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			Collider2D[] objs2 = LuaScriptMgr.GetArrayObject<Collider2D>(L, 3);
			int o = Physics2D.OverlapAreaNonAlloc(arg0,arg1,objs2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			Collider2D[] objs2 = LuaScriptMgr.GetArrayObject<Collider2D>(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			int o = Physics2D.OverlapAreaNonAlloc(arg0,arg1,objs2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			Collider2D[] objs2 = LuaScriptMgr.GetArrayObject<Collider2D>(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			int o = Physics2D.OverlapAreaNonAlloc(arg0,arg1,objs2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Vector2 arg0 = LuaScriptMgr.GetNetObject<Vector2>(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 2);
			Collider2D[] objs2 = LuaScriptMgr.GetArrayObject<Collider2D>(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 6);
			int o = Physics2D.OverlapAreaNonAlloc(arg0,arg1,objs2,arg3,arg4,arg5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Physics2D.OverlapAreaNonAlloc");
		}

		return 0;
	}
}

