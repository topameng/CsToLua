using UnityEngine;
using System;
using LuaInterface;

public class PlayModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("StopSameLayer", PlayMode.StopSameLayer),
		new LuaEnum("StopAll", PlayMode.StopAll),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.PlayMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.PlayMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		PlayMode o = (PlayMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

