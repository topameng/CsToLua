using System;
using UnityEngine;
using LuaInterface;

public class TouchPhaseWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("Began", GetBegan),
		new LuaMethod("Moved", GetMoved),
		new LuaMethod("Stationary", GetStationary),
		new LuaMethod("Ended", GetEnded),
		new LuaMethod("Canceled", GetCanceled),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.TouchPhase", typeof(UnityEngine.TouchPhase), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBegan(IntPtr L)
	{
		LuaScriptMgr.Push(L, TouchPhase.Began);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMoved(IntPtr L)
	{
		LuaScriptMgr.Push(L, TouchPhase.Moved);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetStationary(IntPtr L)
	{
		LuaScriptMgr.Push(L, TouchPhase.Stationary);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEnded(IntPtr L)
	{
		LuaScriptMgr.Push(L, TouchPhase.Ended);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetCanceled(IntPtr L)
	{
		LuaScriptMgr.Push(L, TouchPhase.Canceled);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		TouchPhase o = (TouchPhase)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

