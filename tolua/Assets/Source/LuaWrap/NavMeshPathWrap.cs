using UnityEngine;
using System;
using LuaInterface;

public class NavMeshPathWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("ClearCorners", ClearCorners),
		new LuaMethod("New", _CreateNavMeshPath),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("corners", get_corners, null),
		new LuaField("status", get_status, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateNavMeshPath(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			NavMeshPath obj = new NavMeshPath();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: NavMeshPath.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(NavMeshPath));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.NavMeshPath", typeof(NavMeshPath), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_corners(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name corners");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index corners on a nil value");
			}
		}

		NavMeshPath obj = (NavMeshPath)o;
		LuaScriptMgr.PushArray(L, obj.corners);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_status(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name status");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index status on a nil value");
			}
		}

		NavMeshPath obj = (NavMeshPath)o;
		LuaScriptMgr.PushEnum(L, obj.status);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearCorners(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		NavMeshPath obj = LuaScriptMgr.GetNetObject<NavMeshPath>(L, 1);
		obj.ClearCorners();
		return 0;
	}
}

