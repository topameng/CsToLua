using UnityEngine;
using System;
using LuaInterface;

public class ThreadPriorityWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Low", ThreadPriority.Low),
		new LuaEnum("BelowNormal", ThreadPriority.BelowNormal),
		new LuaEnum("Normal", ThreadPriority.Normal),
		new LuaEnum("High", ThreadPriority.High),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ThreadPriority", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.ThreadPriority", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ThreadPriority o = (ThreadPriority)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

