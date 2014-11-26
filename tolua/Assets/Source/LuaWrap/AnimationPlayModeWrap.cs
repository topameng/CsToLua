using UnityEngine;
using System;
using LuaInterface;

public class AnimationPlayModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Stop", AnimationPlayMode.Stop),
		new LuaEnum("Queue", AnimationPlayMode.Queue),
		new LuaEnum("Mix", AnimationPlayMode.Mix),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AnimationPlayMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.AnimationPlayMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		AnimationPlayMode o = (AnimationPlayMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

