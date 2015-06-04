using System;
using UnityEngine;
using LuaInterface;

public class BlendWeightsWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("OneBone", GetOneBone),
		new LuaMethod("TwoBones", GetTwoBones),
		new LuaMethod("FourBones", GetFourBones),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.BlendWeights", typeof(UnityEngine.BlendWeights), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetOneBone(IntPtr L)
	{
		LuaScriptMgr.Push(L, BlendWeights.OneBone);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTwoBones(IntPtr L)
	{
		LuaScriptMgr.Push(L, BlendWeights.TwoBones);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFourBones(IntPtr L)
	{
		LuaScriptMgr.Push(L, BlendWeights.FourBones);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		BlendWeights o = (BlendWeights)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

