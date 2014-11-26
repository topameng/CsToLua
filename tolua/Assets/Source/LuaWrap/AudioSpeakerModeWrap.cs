using UnityEngine;
using System;
using LuaInterface;

public class AudioSpeakerModeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Raw", AudioSpeakerMode.Raw),
		new LuaEnum("Mono", AudioSpeakerMode.Mono),
		new LuaEnum("Stereo", AudioSpeakerMode.Stereo),
		new LuaEnum("Quad", AudioSpeakerMode.Quad),
		new LuaEnum("Surround", AudioSpeakerMode.Surround),
		new LuaEnum("Mode5point1", AudioSpeakerMode.Mode5point1),
		new LuaEnum("Mode7point1", AudioSpeakerMode.Mode7point1),
		new LuaEnum("Prologic", AudioSpeakerMode.Prologic),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AudioSpeakerMode", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.AudioSpeakerMode", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		AudioSpeakerMode o = (AudioSpeakerMode)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

