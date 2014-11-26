using UnityEngine;
using System;
using LuaInterface;

public class AudioVelocityUpdateModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Auto", AudioVelocityUpdateMode.Auto),
		new LuaEnum("Fixed", AudioVelocityUpdateMode.Fixed),
		new LuaEnum("Dynamic", AudioVelocityUpdateMode.Dynamic),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AudioVelocityUpdateMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.AudioVelocityUpdateMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		AudioVelocityUpdateMode o = (AudioVelocityUpdateMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

