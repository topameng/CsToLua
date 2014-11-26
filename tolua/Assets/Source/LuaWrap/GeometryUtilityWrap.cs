using UnityEngine;
using System;
using LuaInterface;

public class GeometryUtilityWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("CalculateFrustumPlanes", CalculateFrustumPlanes),
		new LuaMethod("TestPlanesAABB", TestPlanesAABB),
		new LuaMethod("New", _CreateGeometryUtility),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGeometryUtility(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			GeometryUtility obj = new GeometryUtility();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GeometryUtility.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(GeometryUtility));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.GeometryUtility", typeof(GeometryUtility), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CalculateFrustumPlanes(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(Matrix4x4)};
		Type[] types1 = {typeof(Camera)};

		if (count == 1 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			Matrix4x4 arg0 = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 1);
			Plane[] o = GeometryUtility.CalculateFrustumPlanes(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Camera arg0 = LuaScriptMgr.GetNetObject<Camera>(L, 1);
			Plane[] o = GeometryUtility.CalculateFrustumPlanes(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: GeometryUtility.CalculateFrustumPlanes");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TestPlanesAABB(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Plane[] objs0 = LuaScriptMgr.GetArrayObject<Plane>(L, 1);
		Bounds arg1 = LuaScriptMgr.GetNetObject<Bounds>(L, 2);
		bool o = GeometryUtility.TestPlanesAABB(objs0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

