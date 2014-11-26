using UnityEngine;
using System;
using LuaInterface;

public class DeviceOrientationWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Unknown", DeviceOrientation.Unknown),
		new LuaEnum("Portrait", DeviceOrientation.Portrait),
		new LuaEnum("PortraitUpsideDown", DeviceOrientation.PortraitUpsideDown),
		new LuaEnum("LandscapeLeft", DeviceOrientation.LandscapeLeft),
		new LuaEnum("LandscapeRight", DeviceOrientation.LandscapeRight),
		new LuaEnum("FaceUp", DeviceOrientation.FaceUp),
		new LuaEnum("FaceDown", DeviceOrientation.FaceDown),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.DeviceOrientation", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.DeviceOrientation", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		DeviceOrientation o = (DeviceOrientation)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

