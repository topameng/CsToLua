using System;
using UnityEngine;
using LuaInterface;

public class PlayModeWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("StopSameLayer", GetStopSameLayer),
		new LuaMethod("StopAll", GetStopAll),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.PlayMode", typeof(UnityEngine.PlayMode), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetStopSameLayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, PlayMode.StopSameLayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetStopAll(IntPtr L)
	{
		LuaScriptMgr.Push(L, PlayMode.StopAll);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		PlayMode o = (PlayMode)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

