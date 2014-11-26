using UnityEngine;
using System;
using LuaInterface;

public class LightTypeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Spot", LightType.Spot),
		new LuaEnum("Directional", LightType.Directional),
		new LuaEnum("Point", LightType.Point),
		new LuaEnum("Area", LightType.Area),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.LightType", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.LightType", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		LightType o = (LightType)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

