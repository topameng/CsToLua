using UnityEngine;
using System;
using LuaInterface;

public class AvatarIKGoalWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("LeftFoot", AvatarIKGoal.LeftFoot),
		new LuaEnum("RightFoot", AvatarIKGoal.RightFoot),
		new LuaEnum("LeftHand", AvatarIKGoal.LeftHand),
		new LuaEnum("RightHand", AvatarIKGoal.RightHand),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AvatarIKGoal", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.AvatarIKGoal", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		AvatarIKGoal o = (AvatarIKGoal)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

