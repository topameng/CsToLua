using UnityEngine;
using System;
using LuaInterface;

public class AvatarTargetWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Root", AvatarTarget.Root),
		new LuaEnum("Body", AvatarTarget.Body),
		new LuaEnum("LeftFoot", AvatarTarget.LeftFoot),
		new LuaEnum("RightFoot", AvatarTarget.RightFoot),
		new LuaEnum("LeftHand", AvatarTarget.LeftHand),
		new LuaEnum("RightHand", AvatarTarget.RightHand),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AvatarTarget", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.AvatarTarget", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		AvatarTarget o = (AvatarTarget)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

