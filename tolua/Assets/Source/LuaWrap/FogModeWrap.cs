using UnityEngine;
using System;
using LuaInterface;

public class FogModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Linear", FogMode.Linear),
		new LuaEnum("Exponential", FogMode.Exponential),
		new LuaEnum("ExponentialSquared", FogMode.ExponentialSquared),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.FogMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.FogMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		FogMode o = (FogMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

