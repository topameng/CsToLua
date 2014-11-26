using UnityEngine;
using System;
using LuaInterface;

public class NavMeshWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Raycast", Raycast),
		new LuaMethod("CalculatePath", CalculatePath),
		new LuaMethod("FindClosestEdge", FindClosestEdge),
		new LuaMethod("SamplePosition", SamplePosition),
		new LuaMethod("SetLayerCost", SetLayerCost),
		new LuaMethod("GetLayerCost", GetLayerCost),
		new LuaMethod("GetNavMeshLayerFromName", GetNavMeshLayerFromName),
		new LuaMethod("CalculateTriangulation", CalculateTriangulation),
		new LuaMethod("AddOffMeshLinks", AddOffMeshLinks),
		new LuaMethod("RestoreNavMesh", RestoreNavMesh),
		new LuaMethod("New", _CreateNavMesh),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateNavMesh(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			NavMesh obj = new NavMesh();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: NavMesh.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(NavMesh));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.NavMesh", typeof(NavMesh), regs, fields, "UnityEngine.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Raycast(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
		Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		NavMeshHit arg2 = LuaScriptMgr.GetNetObject<NavMeshHit>(L, 3);
		int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
		bool o = NavMesh.Raycast(arg0,arg1,out arg2,arg3);
		LuaScriptMgr.Push(L, o);
		LuaScriptMgr.PushValue(L, arg2);
		return 2;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CalculatePath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
		Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
		NavMeshPath arg3 = LuaScriptMgr.GetNetObject<NavMeshPath>(L, 4);
		bool o = NavMesh.CalculatePath(arg0,arg1,arg2,arg3);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindClosestEdge(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
		NavMeshHit arg1 = LuaScriptMgr.GetNetObject<NavMeshHit>(L, 2);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
		bool o = NavMesh.FindClosestEdge(arg0,out arg1,arg2);
		LuaScriptMgr.Push(L, o);
		LuaScriptMgr.PushValue(L, arg1);
		return 2;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SamplePosition(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
		NavMeshHit arg1 = LuaScriptMgr.GetNetObject<NavMeshHit>(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
		bool o = NavMesh.SamplePosition(arg0,out arg1,arg2,arg3);
		LuaScriptMgr.Push(L, o);
		LuaScriptMgr.PushValue(L, arg1);
		return 2;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetLayerCost(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
		NavMesh.SetLayerCost(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLayerCost(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		float o = NavMesh.GetLayerCost(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetNavMeshLayerFromName(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		int o = NavMesh.GetNavMeshLayerFromName(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CalculateTriangulation(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		NavMeshTriangulation o = NavMesh.CalculateTriangulation();
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddOffMeshLinks(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		NavMesh.AddOffMeshLinks();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RestoreNavMesh(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		NavMesh.RestoreNavMesh();
		return 0;
	}
}

