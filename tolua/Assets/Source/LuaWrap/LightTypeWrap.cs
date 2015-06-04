using System;
using UnityEngine;
using LuaInterface;

public class LightTypeWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("Spot", GetSpot),
		new LuaMethod("Directional", GetDirectional),
		new LuaMethod("Point", GetPoint),
		new LuaMethod("Area", GetArea),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.LightType", typeof(UnityEngine.LightType), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSpot(IntPtr L)
	{
		LuaScriptMgr.Push(L, LightType.Spot);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDirectional(IntPtr L)
	{
		LuaScriptMgr.Push(L, LightType.Directional);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPoint(IntPtr L)
	{
		LuaScriptMgr.Push(L, LightType.Point);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetArea(IntPtr L)
	{
		LuaScriptMgr.Push(L, LightType.Area);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		LightType o = (LightType)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

