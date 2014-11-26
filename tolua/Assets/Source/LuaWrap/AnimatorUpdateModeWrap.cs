using UnityEngine;
using System;
using LuaInterface;

public class AnimatorUpdateModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Normal", AnimatorUpdateMode.Normal),
		new LuaEnum("AnimatePhysics", AnimatorUpdateMode.AnimatePhysics),
		new LuaEnum("UnscaledTime", AnimatorUpdateMode.UnscaledTime),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AnimatorUpdateMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.AnimatorUpdateMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		AnimatorUpdateMode o = (AnimatorUpdateMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

