using UnityEngine;
using System;
using LuaInterface;

public class LightShadowsWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("None", LightShadows.None),
		new LuaEnum("Hard", LightShadows.Hard),
		new LuaEnum("Soft", LightShadows.Soft),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.LightShadows", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.LightShadows", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		LightShadows o = (LightShadows)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

