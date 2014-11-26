using UnityEngine;
using System;
using LuaInterface;

public class TouchPhaseWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Began", TouchPhase.Began),
		new LuaEnum("Moved", TouchPhase.Moved),
		new LuaEnum("Stationary", TouchPhase.Stationary),
		new LuaEnum("Ended", TouchPhase.Ended),
		new LuaEnum("Canceled", TouchPhase.Canceled),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.TouchPhase", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.TouchPhase", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		TouchPhase o = (TouchPhase)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

