using UnityEngine;
using System;
using LuaInterface;

public class WrapModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Once", WrapMode.Once),
		new LuaEnum("Loop", WrapMode.Loop),
		new LuaEnum("PingPong", WrapMode.PingPong),
		new LuaEnum("Default", WrapMode.Default),
		new LuaEnum("ClampForever", WrapMode.ClampForever),
		new LuaEnum("Clamp", WrapMode.Clamp),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.WrapMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.WrapMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		WrapMode o = (WrapMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

