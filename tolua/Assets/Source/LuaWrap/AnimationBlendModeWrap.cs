using UnityEngine;
using System;
using LuaInterface;

public class AnimationBlendModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Blend", AnimationBlendMode.Blend),
		new LuaEnum("Additive", AnimationBlendMode.Additive),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AnimationBlendMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.AnimationBlendMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		AnimationBlendMode o = (AnimationBlendMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

