using UnityEngine;
using System;
using LuaInterface;

public class SkinQualityWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Auto", SkinQuality.Auto),
		new LuaEnum("Bone1", SkinQuality.Bone1),
		new LuaEnum("Bone2", SkinQuality.Bone2),
		new LuaEnum("Bone4", SkinQuality.Bone4),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.SkinQuality", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.SkinQuality", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		SkinQuality o = (SkinQuality)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

