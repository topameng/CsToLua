using UnityEngine;
using System;
using LuaInterface;

public class LightmapsModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Single", LightmapsMode.Single),
		new LuaEnum("Dual", LightmapsMode.Dual),
		new LuaEnum("Directional", LightmapsMode.Directional),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.LightmapsMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.LightmapsMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		LightmapsMode o = (LightmapsMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

