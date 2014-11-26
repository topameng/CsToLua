using UnityEngine;
using System;
using LuaInterface;

public class RigidbodySleepMode2DWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("NeverSleep", RigidbodySleepMode2D.NeverSleep),
		new LuaEnum("StartAwake", RigidbodySleepMode2D.StartAwake),
		new LuaEnum("StartAsleep", RigidbodySleepMode2D.StartAsleep),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.RigidbodySleepMode2D", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.RigidbodySleepMode2D", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		RigidbodySleepMode2D o = (RigidbodySleepMode2D)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

