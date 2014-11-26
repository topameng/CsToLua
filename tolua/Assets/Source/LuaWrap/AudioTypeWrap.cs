using UnityEngine;
using System;
using LuaInterface;

public class AudioTypeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("UNKNOWN", AudioType.UNKNOWN),
		new LuaEnum("ACC", AudioType.ACC),
		new LuaEnum("AIFF", AudioType.AIFF),
		new LuaEnum("IT", AudioType.IT),
		new LuaEnum("MOD", AudioType.MOD),
		new LuaEnum("MPEG", AudioType.MPEG),
		new LuaEnum("OGGVORBIS", AudioType.OGGVORBIS),
		new LuaEnum("S3M", AudioType.S3M),
		new LuaEnum("WAV", AudioType.WAV),
		new LuaEnum("XM", AudioType.XM),
		new LuaEnum("XMA", AudioType.XMA),
		new LuaEnum("VAG", AudioType.VAG),
		new LuaEnum("AUDIOQUEUE", AudioType.AUDIOQUEUE),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AudioType", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.AudioType", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		AudioType o = (AudioType)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

