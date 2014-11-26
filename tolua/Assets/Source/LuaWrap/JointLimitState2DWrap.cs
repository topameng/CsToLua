using UnityEngine;
using System;
using LuaInterface;

public class JointLimitState2DWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Inactive", JointLimitState2D.Inactive),
		new LuaEnum("LowerLimit", JointLimitState2D.LowerLimit),
		new LuaEnum("UpperLimit", JointLimitState2D.UpperLimit),
		new LuaEnum("EqualLimits", JointLimitState2D.EqualLimits),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.JointLimitState2D", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.JointLimitState2D", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		JointLimitState2D o = (JointLimitState2D)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

