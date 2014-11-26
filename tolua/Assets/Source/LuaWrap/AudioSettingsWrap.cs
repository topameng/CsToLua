using UnityEngine;
using System;
using LuaInterface;

public class AudioSettingsWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("SetDSPBufferSize", SetDSPBufferSize),
		new LuaMethod("GetDSPBufferSize", GetDSPBufferSize),
		new LuaMethod("New", _CreateAudioSettings),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("driverCaps", get_driverCaps, null),
		new LuaField("speakerMode", get_speakerMode, set_speakerMode),
		new LuaField("dspTime", get_dspTime, null),
		new LuaField("outputSampleRate", get_outputSampleRate, set_outputSampleRate),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAudioSettings(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AudioSettings obj = new AudioSettings();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AudioSettings.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AudioSettings));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AudioSettings", typeof(AudioSettings), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_driverCaps(IntPtr L)
	{
		LuaScriptMgr.PushEnum(L, AudioSettings.driverCaps);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_speakerMode(IntPtr L)
	{
		LuaScriptMgr.PushEnum(L, AudioSettings.speakerMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dspTime(IntPtr L)
	{
		LuaScriptMgr.Push(L, AudioSettings.dspTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_outputSampleRate(IntPtr L)
	{
		LuaScriptMgr.Push(L, AudioSettings.outputSampleRate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_speakerMode(IntPtr L)
	{
		AudioSettings.speakerMode = LuaScriptMgr.GetNetObject<AudioSpeakerMode>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_outputSampleRate(IntPtr L)
	{
		AudioSettings.outputSampleRate = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetDSPBufferSize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		AudioSettings.SetDSPBufferSize(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDSPBufferSize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int arg0 = LuaScriptMgr.GetNetObject<int>(L, 1);
		int arg1 = LuaScriptMgr.GetNetObject<int>(L, 2);
		AudioSettings.GetDSPBufferSize(out arg0,out arg1);
		LuaScriptMgr.Push(L, arg0);
		LuaScriptMgr.Push(L, arg1);
		return 2;
	}
}

