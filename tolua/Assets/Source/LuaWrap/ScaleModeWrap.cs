using UnityEngine;
using System;
using LuaInterface;

public class ScaleModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("StretchToFill", ScaleMode.StretchToFill),
		new LuaEnum("ScaleAndCrop", ScaleMode.ScaleAndCrop),
		new LuaEnum("ScaleToFit", ScaleMode.ScaleToFit),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ScaleMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.ScaleMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ScaleMode o = (ScaleMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

