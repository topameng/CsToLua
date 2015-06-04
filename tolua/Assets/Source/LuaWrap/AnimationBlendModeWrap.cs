using System;
using UnityEngine;
using LuaInterface;

public class AnimationBlendModeWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("Blend", GetBlend),
		new LuaMethod("Additive", GetAdditive),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AnimationBlendMode", typeof(UnityEngine.AnimationBlendMode), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBlend(IntPtr L)
	{
		LuaScriptMgr.Push(L, AnimationBlendMode.Blend);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAdditive(IntPtr L)
	{
		LuaScriptMgr.Push(L, AnimationBlendMode.Additive);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		AnimationBlendMode o = (AnimationBlendMode)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

