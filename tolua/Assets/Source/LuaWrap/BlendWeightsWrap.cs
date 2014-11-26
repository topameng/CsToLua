using UnityEngine;
using System;
using LuaInterface;

public class BlendWeightsWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("OneBone", BlendWeights.OneBone),
		new LuaEnum("TwoBones", BlendWeights.TwoBones),
		new LuaEnum("FourBones", BlendWeights.FourBones),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.BlendWeights", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.BlendWeights", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		BlendWeights o = (BlendWeights)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

