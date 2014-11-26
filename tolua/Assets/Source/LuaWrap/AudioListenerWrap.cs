using UnityEngine;
using System;
using LuaInterface;

public class AudioListenerWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetOutputData", GetOutputData),
		new LuaMethod("GetSpectrumData", GetSpectrumData),
		new LuaMethod("New", _CreateAudioListener),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("volume", get_volume, set_volume),
		new LuaField("pause", get_pause, set_pause),
		new LuaField("velocityUpdateMode", get_velocityUpdateMode, set_velocityUpdateMode),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAudioListener(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AudioListener obj = new AudioListener();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AudioListener.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AudioListener));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AudioListener", typeof(AudioListener), regs, fields, "UnityEngine.Behaviour");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_volume(IntPtr L)
	{
		LuaScriptMgr.Push(L, AudioListener.volume);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pause(IntPtr L)
	{
		LuaScriptMgr.Push(L, AudioListener.pause);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_velocityUpdateMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name velocityUpdateMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index velocityUpdateMode on a nil value");
			}
		}

		AudioListener obj = (AudioListener)o;
		LuaScriptMgr.PushEnum(L, obj.velocityUpdateMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_volume(IntPtr L)
	{
		AudioListener.volume = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pause(IntPtr L)
	{
		AudioListener.pause = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_velocityUpdateMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name velocityUpdateMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index velocityUpdateMode on a nil value");
			}
		}

		AudioListener obj = (AudioListener)o;
		obj.velocityUpdateMode = LuaScriptMgr.GetNetObject<AudioVelocityUpdateMode>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetOutputData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		float[] objs0 = LuaScriptMgr.GetArrayNumber<float>(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		AudioListener.GetOutputData(objs0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSpectrumData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		float[] objs0 = LuaScriptMgr.GetArrayNumber<float>(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		FFTWindow arg2 = LuaScriptMgr.GetNetObject<FFTWindow>(L, 3);
		AudioListener.GetSpectrumData(objs0,arg1,arg2);
		return 0;
	}
}

