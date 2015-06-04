using System;
using UnityEngine;
using LuaInterface;

public class CameraClearFlagsWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("Skybox", GetSkybox),
		new LuaMethod("Color", GetColor),
		new LuaMethod("SolidColor", GetSolidColor),
		new LuaMethod("Depth", GetDepth),
		new LuaMethod("Nothing", GetNothing),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.CameraClearFlags", typeof(UnityEngine.CameraClearFlags), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSkybox(IntPtr L)
	{
		LuaScriptMgr.Push(L, CameraClearFlags.Skybox);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetColor(IntPtr L)
	{
		LuaScriptMgr.Push(L, CameraClearFlags.Color);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSolidColor(IntPtr L)
	{
		LuaScriptMgr.Push(L, CameraClearFlags.SolidColor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDepth(IntPtr L)
	{
		LuaScriptMgr.Push(L, CameraClearFlags.Depth);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetNothing(IntPtr L)
	{
		LuaScriptMgr.Push(L, CameraClearFlags.Nothing);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		CameraClearFlags o = (CameraClearFlags)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

