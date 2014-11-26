using UnityEngine;
using System;
using LuaInterface;

public class ShadowProjectionWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("CloseFit", ShadowProjection.CloseFit),
		new LuaEnum("StableFit", ShadowProjection.StableFit),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ShadowProjection", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.ShadowProjection", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ShadowProjection o = (ShadowProjection)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

