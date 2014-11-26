using UnityEngine;
using System;
using LuaInterface;

public class DeviceTypeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Unknown", DeviceType.Unknown),
		new LuaEnum("Handheld", DeviceType.Handheld),
		new LuaEnum("Console", DeviceType.Console),
		new LuaEnum("Desktop", DeviceType.Desktop),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.DeviceType", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.DeviceType", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		DeviceType o = (DeviceType)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

