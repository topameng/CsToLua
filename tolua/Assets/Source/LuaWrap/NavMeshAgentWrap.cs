using UnityEngine;
using System;
using LuaInterface;

public class NavMeshAgentWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("SetDestination", SetDestination),
		new LuaMethod("ActivateCurrentOffMeshLink", ActivateCurrentOffMeshLink),
		new LuaMethod("CompleteOffMeshLink", CompleteOffMeshLink),
		new LuaMethod("Warp", Warp),
		new LuaMethod("Move", Move),
		new LuaMethod("Stop", Stop),
		new LuaMethod("Resume", Resume),
		new LuaMethod("ResetPath", ResetPath),
		new LuaMethod("SetPath", SetPath),
		new LuaMethod("FindClosestEdge", FindClosestEdge),
		new LuaMethod("Raycast", Raycast),
		new LuaMethod("CalculatePath", CalculatePath),
		new LuaMethod("SamplePathPosition", SamplePathPosition),
		new LuaMethod("SetLayerCost", SetLayerCost),
		new LuaMethod("GetLayerCost", GetLayerCost),
		new LuaMethod("New", _CreateNavMeshAgent),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("destination", get_destination, set_destination),
		new LuaField("stoppingDistance", get_stoppingDistance, set_stoppingDistance),
		new LuaField("velocity", get_velocity, set_velocity),
		new LuaField("nextPosition", get_nextPosition, set_nextPosition),
		new LuaField("steeringTarget", get_steeringTarget, null),
		new LuaField("desiredVelocity", get_desiredVelocity, null),
		new LuaField("remainingDistance", get_remainingDistance, null),
		new LuaField("baseOffset", get_baseOffset, set_baseOffset),
		new LuaField("isOnOffMeshLink", get_isOnOffMeshLink, null),
		new LuaField("currentOffMeshLinkData", get_currentOffMeshLinkData, null),
		new LuaField("nextOffMeshLinkData", get_nextOffMeshLinkData, null),
		new LuaField("autoTraverseOffMeshLink", get_autoTraverseOffMeshLink, set_autoTraverseOffMeshLink),
		new LuaField("autoBraking", get_autoBraking, set_autoBraking),
		new LuaField("autoRepath", get_autoRepath, set_autoRepath),
		new LuaField("hasPath", get_hasPath, null),
		new LuaField("pathPending", get_pathPending, null),
		new LuaField("isPathStale", get_isPathStale, null),
		new LuaField("pathStatus", get_pathStatus, null),
		new LuaField("pathEndPosition", get_pathEndPosition, null),
		new LuaField("path", get_path, set_path),
		new LuaField("walkableMask", get_walkableMask, set_walkableMask),
		new LuaField("speed", get_speed, set_speed),
		new LuaField("angularSpeed", get_angularSpeed, set_angularSpeed),
		new LuaField("acceleration", get_acceleration, set_acceleration),
		new LuaField("updatePosition", get_updatePosition, set_updatePosition),
		new LuaField("updateRotation", get_updateRotation, set_updateRotation),
		new LuaField("radius", get_radius, set_radius),
		new LuaField("height", get_height, set_height),
		new LuaField("obstacleAvoidanceType", get_obstacleAvoidanceType, set_obstacleAvoidanceType),
		new LuaField("avoidancePriority", get_avoidancePriority, set_avoidancePriority),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateNavMeshAgent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			NavMeshAgent obj = new NavMeshAgent();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: NavMeshAgent.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(NavMeshAgent));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.NavMeshAgent", typeof(NavMeshAgent), regs, fields, "UnityEngine.Behaviour");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_destination(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name destination");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index destination on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.PushValue(L, obj.destination);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stoppingDistance(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stoppingDistance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stoppingDistance on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.Push(L, obj.stoppingDistance);
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

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.PushValue(L, obj.velocity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_nextPosition(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name nextPosition");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index nextPosition on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.PushValue(L, obj.nextPosition);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_steeringTarget(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name steeringTarget");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index steeringTarget on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.PushValue(L, obj.steeringTarget);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_desiredVelocity(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name desiredVelocity");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index desiredVelocity on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.PushValue(L, obj.desiredVelocity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_remainingDistance(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name remainingDistance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index remainingDistance on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.Push(L, obj.remainingDistance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_baseOffset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name baseOffset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index baseOffset on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.Push(L, obj.baseOffset);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isOnOffMeshLink(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isOnOffMeshLink");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isOnOffMeshLink on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.Push(L, obj.isOnOffMeshLink);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_currentOffMeshLinkData(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name currentOffMeshLinkData");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index currentOffMeshLinkData on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.PushValue(L, obj.currentOffMeshLinkData);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_nextOffMeshLinkData(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name nextOffMeshLinkData");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index nextOffMeshLinkData on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.PushValue(L, obj.nextOffMeshLinkData);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_autoTraverseOffMeshLink(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name autoTraverseOffMeshLink");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index autoTraverseOffMeshLink on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.Push(L, obj.autoTraverseOffMeshLink);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_autoBraking(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name autoBraking");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index autoBraking on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.Push(L, obj.autoBraking);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_autoRepath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name autoRepath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index autoRepath on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.Push(L, obj.autoRepath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hasPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hasPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hasPath on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.Push(L, obj.hasPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pathPending(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pathPending");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pathPending on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.Push(L, obj.pathPending);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPathStale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isPathStale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isPathStale on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.Push(L, obj.isPathStale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pathStatus(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pathStatus");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pathStatus on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.PushEnum(L, obj.pathStatus);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pathEndPosition(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pathEndPosition");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pathEndPosition on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.PushValue(L, obj.pathEndPosition);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_path(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name path");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index path on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.PushObject(L, obj.path);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_walkableMask(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name walkableMask");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index walkableMask on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.Push(L, obj.walkableMask);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_speed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name speed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index speed on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.Push(L, obj.speed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_angularSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularSpeed on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.Push(L, obj.angularSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_acceleration(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name acceleration");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index acceleration on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.Push(L, obj.acceleration);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_updatePosition(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name updatePosition");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index updatePosition on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.Push(L, obj.updatePosition);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_updateRotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name updateRotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index updateRotation on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.Push(L, obj.updateRotation);
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

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.Push(L, obj.radius);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_height(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name height");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index height on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.Push(L, obj.height);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_obstacleAvoidanceType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name obstacleAvoidanceType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index obstacleAvoidanceType on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.PushEnum(L, obj.obstacleAvoidanceType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_avoidancePriority(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name avoidancePriority");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index avoidancePriority on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		LuaScriptMgr.Push(L, obj.avoidancePriority);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_destination(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name destination");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index destination on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		obj.destination = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stoppingDistance(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stoppingDistance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stoppingDistance on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		obj.stoppingDistance = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
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

		NavMeshAgent obj = (NavMeshAgent)o;
		obj.velocity = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_nextPosition(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name nextPosition");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index nextPosition on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		obj.nextPosition = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_baseOffset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name baseOffset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index baseOffset on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		obj.baseOffset = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_autoTraverseOffMeshLink(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name autoTraverseOffMeshLink");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index autoTraverseOffMeshLink on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		obj.autoTraverseOffMeshLink = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_autoBraking(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name autoBraking");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index autoBraking on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		obj.autoBraking = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_autoRepath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name autoRepath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index autoRepath on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		obj.autoRepath = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_path(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name path");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index path on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		obj.path = LuaScriptMgr.GetNetObject<NavMeshPath>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_walkableMask(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name walkableMask");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index walkableMask on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		obj.walkableMask = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_speed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name speed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index speed on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		obj.speed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_angularSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name angularSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index angularSpeed on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		obj.angularSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_acceleration(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name acceleration");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index acceleration on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		obj.acceleration = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_updatePosition(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name updatePosition");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index updatePosition on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		obj.updatePosition = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_updateRotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name updateRotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index updateRotation on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		obj.updateRotation = LuaScriptMgr.GetBoolean(L, 3);
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

		NavMeshAgent obj = (NavMeshAgent)o;
		obj.radius = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_height(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name height");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index height on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		obj.height = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_obstacleAvoidanceType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name obstacleAvoidanceType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index obstacleAvoidanceType on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		obj.obstacleAvoidanceType = LuaScriptMgr.GetNetObject<ObstacleAvoidanceType>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_avoidancePriority(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name avoidancePriority");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index avoidancePriority on a nil value");
			}
		}

		NavMeshAgent obj = (NavMeshAgent)o;
		obj.avoidancePriority = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetDestination(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		NavMeshAgent obj = LuaScriptMgr.GetNetObject<NavMeshAgent>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		bool o = obj.SetDestination(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ActivateCurrentOffMeshLink(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		NavMeshAgent obj = LuaScriptMgr.GetNetObject<NavMeshAgent>(L, 1);
		bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
		obj.ActivateCurrentOffMeshLink(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CompleteOffMeshLink(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		NavMeshAgent obj = LuaScriptMgr.GetNetObject<NavMeshAgent>(L, 1);
		obj.CompleteOffMeshLink();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Warp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		NavMeshAgent obj = LuaScriptMgr.GetNetObject<NavMeshAgent>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		bool o = obj.Warp(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Move(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		NavMeshAgent obj = LuaScriptMgr.GetNetObject<NavMeshAgent>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		obj.Move(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Stop(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			NavMeshAgent obj = LuaScriptMgr.GetNetObject<NavMeshAgent>(L, 1);
			obj.Stop();
			return 0;
		}
		else if (count == 2)
		{
			NavMeshAgent obj = LuaScriptMgr.GetNetObject<NavMeshAgent>(L, 1);
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			obj.Stop(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: NavMeshAgent.Stop");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Resume(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		NavMeshAgent obj = LuaScriptMgr.GetNetObject<NavMeshAgent>(L, 1);
		obj.Resume();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResetPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		NavMeshAgent obj = LuaScriptMgr.GetNetObject<NavMeshAgent>(L, 1);
		obj.ResetPath();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		NavMeshAgent obj = LuaScriptMgr.GetNetObject<NavMeshAgent>(L, 1);
		NavMeshPath arg0 = LuaScriptMgr.GetNetObject<NavMeshPath>(L, 2);
		bool o = obj.SetPath(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindClosestEdge(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		NavMeshAgent obj = LuaScriptMgr.GetNetObject<NavMeshAgent>(L, 1);
		NavMeshHit arg0 = LuaScriptMgr.GetNetObject<NavMeshHit>(L, 2);
		bool o = obj.FindClosestEdge(out arg0);
		LuaScriptMgr.Push(L, o);
		LuaScriptMgr.PushValue(L, arg0);
		return 2;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Raycast(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		NavMeshAgent obj = LuaScriptMgr.GetNetObject<NavMeshAgent>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		NavMeshHit arg1 = LuaScriptMgr.GetNetObject<NavMeshHit>(L, 3);
		bool o = obj.Raycast(arg0,out arg1);
		LuaScriptMgr.Push(L, o);
		LuaScriptMgr.PushValue(L, arg1);
		return 2;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CalculatePath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		NavMeshAgent obj = LuaScriptMgr.GetNetObject<NavMeshAgent>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		NavMeshPath arg1 = LuaScriptMgr.GetNetObject<NavMeshPath>(L, 3);
		bool o = obj.CalculatePath(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SamplePathPosition(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		NavMeshAgent obj = LuaScriptMgr.GetNetObject<NavMeshAgent>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		NavMeshHit arg2 = LuaScriptMgr.GetNetObject<NavMeshHit>(L, 4);
		bool o = obj.SamplePathPosition(arg0,arg1,out arg2);
		LuaScriptMgr.Push(L, o);
		LuaScriptMgr.PushValue(L, arg2);
		return 2;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetLayerCost(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		NavMeshAgent obj = LuaScriptMgr.GetNetObject<NavMeshAgent>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		obj.SetLayerCost(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLayerCost(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		NavMeshAgent obj = LuaScriptMgr.GetNetObject<NavMeshAgent>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		float o = obj.GetLayerCost(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

