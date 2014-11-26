using UnityEngine;
using System;
using LuaInterface;

public class FilterModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Point", FilterMode.Point),
		new LuaEnum("Bilinear", FilterMode.Bilinear),
		new LuaEnum("Trilinear", FilterMode.Trilinear),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.FilterMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.FilterMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		FilterMode o = (FilterMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

