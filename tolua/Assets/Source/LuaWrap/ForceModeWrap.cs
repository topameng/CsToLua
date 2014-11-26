using UnityEngine;
using System;
using LuaInterface;

public class ForceModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Force", ForceMode.Force),
		new LuaEnum("Acceleration", ForceMode.Acceleration),
		new LuaEnum("Impulse", ForceMode.Impulse),
		new LuaEnum("VelocityChange", ForceMode.VelocityChange),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ForceMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.ForceMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ForceMode o = (ForceMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

