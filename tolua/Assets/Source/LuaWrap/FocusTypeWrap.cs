using UnityEngine;
using System;
using LuaInterface;

public class FocusTypeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Native", FocusType.Native),
		new LuaEnum("Keyboard", FocusType.Keyboard),
		new LuaEnum("Passive", FocusType.Passive),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.FocusType", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.FocusType", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		FocusType o = (FocusType)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

