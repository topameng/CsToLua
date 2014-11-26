using UnityEngine;
using System;
using LuaInterface;

public class LightRenderModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Auto", LightRenderMode.Auto),
		new LuaEnum("ForcePixel", LightRenderMode.ForcePixel),
		new LuaEnum("ForceVertex", LightRenderMode.ForceVertex),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.LightRenderMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.LightRenderMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		LightRenderMode o = (LightRenderMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

