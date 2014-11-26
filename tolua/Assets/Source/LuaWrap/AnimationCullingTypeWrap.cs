using UnityEngine;
using System;
using LuaInterface;

public class AnimationCullingTypeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("AlwaysAnimate", AnimationCullingType.AlwaysAnimate),
		new LuaEnum("BasedOnRenderers", AnimationCullingType.BasedOnRenderers),
		new LuaEnum("BasedOnClipBounds", AnimationCullingType.BasedOnClipBounds),
		new LuaEnum("BasedOnUserBounds", AnimationCullingType.BasedOnUserBounds),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AnimationCullingType", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.AnimationCullingType", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		AnimationCullingType o = (AnimationCullingType)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

