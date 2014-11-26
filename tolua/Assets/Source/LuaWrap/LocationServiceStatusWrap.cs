using UnityEngine;
using System;
using LuaInterface;

public class LocationServiceStatusWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Stopped", LocationServiceStatus.Stopped),
		new LuaEnum("Initializing", LocationServiceStatus.Initializing),
		new LuaEnum("Running", LocationServiceStatus.Running),
		new LuaEnum("Failed", LocationServiceStatus.Failed),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.LocationServiceStatus", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.LocationServiceStatus", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		LocationServiceStatus o = (LocationServiceStatus)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

