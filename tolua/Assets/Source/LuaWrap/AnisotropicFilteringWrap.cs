using UnityEngine;
using System;
using LuaInterface;

public class AnisotropicFilteringWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Disable", AnisotropicFiltering.Disable),
		new LuaEnum("Enable", AnisotropicFiltering.Enable),
		new LuaEnum("ForceEnable", AnisotropicFiltering.ForceEnable),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AnisotropicFiltering", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.AnisotropicFiltering", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		AnisotropicFiltering o = (AnisotropicFiltering)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

