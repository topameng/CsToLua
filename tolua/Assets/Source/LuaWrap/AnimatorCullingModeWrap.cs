using UnityEngine;
using System;
using LuaInterface;

public class AnimatorCullingModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("AlwaysAnimate", AnimatorCullingMode.AlwaysAnimate),
		new LuaEnum("BasedOnRenderers", AnimatorCullingMode.BasedOnRenderers),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AnimatorCullingMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.AnimatorCullingMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		AnimatorCullingMode o = (AnimatorCullingMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

