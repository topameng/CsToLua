using UnityEngine;
using System;
using LuaInterface;

public class RuntimePlatformWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("OSXEditor", RuntimePlatform.OSXEditor),
		new LuaEnum("OSXPlayer", RuntimePlatform.OSXPlayer),
		new LuaEnum("WindowsPlayer", RuntimePlatform.WindowsPlayer),
		new LuaEnum("OSXWebPlayer", RuntimePlatform.OSXWebPlayer),
		new LuaEnum("OSXDashboardPlayer", RuntimePlatform.OSXDashboardPlayer),
		new LuaEnum("WindowsWebPlayer", RuntimePlatform.WindowsWebPlayer),
		new LuaEnum("WindowsEditor", RuntimePlatform.WindowsEditor),
		new LuaEnum("IPhonePlayer", RuntimePlatform.IPhonePlayer),
		new LuaEnum("XBOX360", RuntimePlatform.XBOX360),
		new LuaEnum("PS3", RuntimePlatform.PS3),
		new LuaEnum("Android", RuntimePlatform.Android),
		new LuaEnum("NaCl", RuntimePlatform.NaCl),
		new LuaEnum("LinuxPlayer", RuntimePlatform.LinuxPlayer),
		new LuaEnum("FlashPlayer", RuntimePlatform.FlashPlayer),
		new LuaEnum("MetroPlayerX86", RuntimePlatform.MetroPlayerX86),
		new LuaEnum("MetroPlayerX64", RuntimePlatform.MetroPlayerX64),
		new LuaEnum("MetroPlayerARM", RuntimePlatform.MetroPlayerARM),
		new LuaEnum("WP8Player", RuntimePlatform.WP8Player),
		new LuaEnum("BlackBerryPlayer", RuntimePlatform.BlackBerryPlayer),
		new LuaEnum("TizenPlayer", RuntimePlatform.TizenPlayer),
		new LuaEnum("PSP2", RuntimePlatform.PSP2),
		new LuaEnum("PS4", RuntimePlatform.PS4),
		new LuaEnum("PSMPlayer", RuntimePlatform.PSMPlayer),
		new LuaEnum("XboxOne", RuntimePlatform.XboxOne),
		new LuaEnum("SamsungTVPlayer", RuntimePlatform.SamsungTVPlayer),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.RuntimePlatform", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.RuntimePlatform", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		RuntimePlatform o = (RuntimePlatform)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

