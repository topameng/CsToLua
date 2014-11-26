using UnityEngine;
using System;
using LuaInterface;

public class JointProjectionModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("None", JointProjectionMode.None),
		new LuaEnum("PositionAndRotation", JointProjectionMode.PositionAndRotation),
		new LuaEnum("PositionOnly", JointProjectionMode.PositionOnly),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.JointProjectionMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.JointProjectionMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		JointProjectionMode o = (JointProjectionMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

