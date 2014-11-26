using UnityEngine;
using System;
using LuaInterface;

public class TransparencySortModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Default", TransparencySortMode.Default),
		new LuaEnum("Perspective", TransparencySortMode.Perspective),
		new LuaEnum("Orthographic", TransparencySortMode.Orthographic),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.TransparencySortMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.TransparencySortMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		TransparencySortMode o = (TransparencySortMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

