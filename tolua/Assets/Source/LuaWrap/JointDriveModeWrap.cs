using UnityEngine;
using System;
using LuaInterface;

public class JointDriveModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("None", JointDriveMode.None),
		new LuaEnum("Position", JointDriveMode.Position),
		new LuaEnum("Velocity", JointDriveMode.Velocity),
		new LuaEnum("PositionAndVelocity", JointDriveMode.PositionAndVelocity),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.JointDriveMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.JointDriveMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		JointDriveMode o = (JointDriveMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

