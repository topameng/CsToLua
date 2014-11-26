using UnityEngine;
using System;
using LuaInterface;

public class AudioRolloffModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Logarithmic", AudioRolloffMode.Logarithmic),
		new LuaEnum("Linear", AudioRolloffMode.Linear),
		new LuaEnum("Custom", AudioRolloffMode.Custom),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AudioRolloffMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.AudioRolloffMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		AudioRolloffMode o = (AudioRolloffMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

