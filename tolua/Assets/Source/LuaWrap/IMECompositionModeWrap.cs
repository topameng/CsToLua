using UnityEngine;
using System;
using LuaInterface;

public class IMECompositionModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Auto", IMECompositionMode.Auto),
		new LuaEnum("On", IMECompositionMode.On),
		new LuaEnum("Off", IMECompositionMode.Off),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.IMECompositionMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.IMECompositionMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		IMECompositionMode o = (IMECompositionMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

