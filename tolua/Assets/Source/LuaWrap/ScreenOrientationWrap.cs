using UnityEngine;
using System;
using LuaInterface;

public class ScreenOrientationWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Unknown", ScreenOrientation.Unknown),
		new LuaEnum("Portrait", ScreenOrientation.Portrait),
		new LuaEnum("PortraitUpsideDown", ScreenOrientation.PortraitUpsideDown),
		new LuaEnum("LandscapeLeft", ScreenOrientation.LandscapeLeft),
		new LuaEnum("LandscapeRight", ScreenOrientation.LandscapeRight),
		new LuaEnum("AutoRotation", ScreenOrientation.AutoRotation),
		new LuaEnum("Landscape", ScreenOrientation.Landscape),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ScreenOrientation", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.ScreenOrientation", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ScreenOrientation o = (ScreenOrientation)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

