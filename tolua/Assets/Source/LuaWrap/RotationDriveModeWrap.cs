using UnityEngine;
using System;
using LuaInterface;

public class RotationDriveModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("XYAndZ", RotationDriveMode.XYAndZ),
		new LuaEnum("Slerp", RotationDriveMode.Slerp),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.RotationDriveMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.RotationDriveMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		RotationDriveMode o = (RotationDriveMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

