using UnityEngine;
using System;
using LuaInterface;

public class AudioSourceWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Play", Play),
		new LuaMethod("PlayDelayed", PlayDelayed),
		new LuaMethod("PlayScheduled", PlayScheduled),
		new LuaMethod("SetScheduledStartTime", SetScheduledStartTime),
		new LuaMethod("SetScheduledEndTime", SetScheduledEndTime),
		new LuaMethod("Stop", Stop),
		new LuaMethod("Pause", Pause),
		new LuaMethod("PlayOneShot", PlayOneShot),
		new LuaMethod("PlayClipAtPoint", PlayClipAtPoint),
		new LuaMethod("GetOutputData", GetOutputData),
		new LuaMethod("GetSpectrumData", GetSpectrumData),
		new LuaMethod("New", _CreateAudioSource),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("volume", get_volume, set_volume),
		new LuaField("pitch", get_pitch, set_pitch),
		new LuaField("time", get_time, set_time),
		new LuaField("timeSamples", get_timeSamples, set_timeSamples),
		new LuaField("clip", get_clip, set_clip),
		new LuaField("isPlaying", get_isPlaying, null),
		new LuaField("loop", get_loop, set_loop),
		new LuaField("ignoreListenerVolume", get_ignoreListenerVolume, set_ignoreListenerVolume),
		new LuaField("playOnAwake", get_playOnAwake, set_playOnAwake),
		new LuaField("ignoreListenerPause", get_ignoreListenerPause, set_ignoreListenerPause),
		new LuaField("velocityUpdateMode", get_velocityUpdateMode, set_velocityUpdateMode),
		new LuaField("panLevel", get_panLevel, set_panLevel),
		new LuaField("bypassEffects", get_bypassEffects, set_bypassEffects),
		new LuaField("bypassListenerEffects", get_bypassListenerEffects, set_bypassListenerEffects),
		new LuaField("bypassReverbZones", get_bypassReverbZones, set_bypassReverbZones),
		new LuaField("dopplerLevel", get_dopplerLevel, set_dopplerLevel),
		new LuaField("spread", get_spread, set_spread),
		new LuaField("priority", get_priority, set_priority),
		new LuaField("mute", get_mute, set_mute),
		new LuaField("minDistance", get_minDistance, set_minDistance),
		new LuaField("maxDistance", get_maxDistance, set_maxDistance),
		new LuaField("pan", get_pan, set_pan),
		new LuaField("rolloffMode", get_rolloffMode, set_rolloffMode),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAudioSource(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AudioSource obj = new AudioSource();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AudioSource.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AudioSource));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AudioSource", typeof(AudioSource), regs, fields, "UnityEngine.Behaviour");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_volume(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name volume");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index volume on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.volume);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pitch(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pitch");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pitch on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.pitch);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_time(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name time");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index time on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.time);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_timeSamples(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name timeSamples");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index timeSamples on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.timeSamples);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_clip(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name clip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index clip on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.clip);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPlaying(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isPlaying");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isPlaying on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.isPlaying);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_loop(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name loop");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index loop on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.loop);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ignoreListenerVolume(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ignoreListenerVolume");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ignoreListenerVolume on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.ignoreListenerVolume);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_playOnAwake(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name playOnAwake");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index playOnAwake on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.playOnAwake);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ignoreListenerPause(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ignoreListenerPause");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ignoreListenerPause on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.ignoreListenerPause);
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

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.PushEnum(L, obj.velocityUpdateMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_panLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name panLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index panLevel on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.panLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bypassEffects(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bypassEffects");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bypassEffects on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.bypassEffects);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bypassListenerEffects(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bypassListenerEffects");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bypassListenerEffects on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.bypassListenerEffects);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bypassReverbZones(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bypassReverbZones");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bypassReverbZones on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.bypassReverbZones);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dopplerLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dopplerLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dopplerLevel on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.dopplerLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spread(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spread");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spread on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.spread);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_priority(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name priority");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index priority on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.priority);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mute(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mute");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mute on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.mute);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_minDistance(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name minDistance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index minDistance on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.minDistance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxDistance(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxDistance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxDistance on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.maxDistance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pan(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pan");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pan on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.Push(L, obj.pan);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rolloffMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rolloffMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rolloffMode on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		LuaScriptMgr.PushEnum(L, obj.rolloffMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_volume(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name volume");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index volume on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.volume = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pitch(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pitch");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pitch on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.pitch = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_time(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name time");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index time on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.time = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_timeSamples(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name timeSamples");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index timeSamples on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.timeSamples = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_clip(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name clip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index clip on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.clip = LuaScriptMgr.GetNetObject<AudioClip>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_loop(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name loop");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index loop on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.loop = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ignoreListenerVolume(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ignoreListenerVolume");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ignoreListenerVolume on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.ignoreListenerVolume = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_playOnAwake(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name playOnAwake");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index playOnAwake on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.playOnAwake = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ignoreListenerPause(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name ignoreListenerPause");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index ignoreListenerPause on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.ignoreListenerPause = LuaScriptMgr.GetBoolean(L, 3);
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

		AudioSource obj = (AudioSource)o;
		obj.velocityUpdateMode = LuaScriptMgr.GetNetObject<AudioVelocityUpdateMode>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_panLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name panLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index panLevel on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.panLevel = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bypassEffects(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bypassEffects");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bypassEffects on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.bypassEffects = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bypassListenerEffects(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bypassListenerEffects");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bypassListenerEffects on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.bypassListenerEffects = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bypassReverbZones(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bypassReverbZones");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bypassReverbZones on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.bypassReverbZones = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_dopplerLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dopplerLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dopplerLevel on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.dopplerLevel = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_spread(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spread");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spread on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.spread = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_priority(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name priority");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index priority on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.priority = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mute(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mute");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mute on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.mute = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_minDistance(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name minDistance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index minDistance on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.minDistance = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxDistance(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxDistance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxDistance on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.maxDistance = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pan(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pan");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pan on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.pan = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rolloffMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rolloffMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rolloffMode on a nil value");
			}
		}

		AudioSource obj = (AudioSource)o;
		obj.rolloffMode = LuaScriptMgr.GetNetObject<AudioRolloffMode>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Play(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			AudioSource obj = LuaScriptMgr.GetNetObject<AudioSource>(L, 1);
			obj.Play();
			return 0;
		}
		else if (count == 2)
		{
			AudioSource obj = LuaScriptMgr.GetNetObject<AudioSource>(L, 1);
			ulong arg0 = (ulong)LuaScriptMgr.GetNumber(L, 2);
			obj.Play(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AudioSource.Play");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayDelayed(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		AudioSource obj = LuaScriptMgr.GetNetObject<AudioSource>(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		obj.PlayDelayed(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayScheduled(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		AudioSource obj = LuaScriptMgr.GetNetObject<AudioSource>(L, 1);
		double arg0 = (double)LuaScriptMgr.GetNumber(L, 2);
		obj.PlayScheduled(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetScheduledStartTime(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		AudioSource obj = LuaScriptMgr.GetNetObject<AudioSource>(L, 1);
		double arg0 = (double)LuaScriptMgr.GetNumber(L, 2);
		obj.SetScheduledStartTime(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetScheduledEndTime(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		AudioSource obj = LuaScriptMgr.GetNetObject<AudioSource>(L, 1);
		double arg0 = (double)LuaScriptMgr.GetNumber(L, 2);
		obj.SetScheduledEndTime(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Stop(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		AudioSource obj = LuaScriptMgr.GetNetObject<AudioSource>(L, 1);
		obj.Stop();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Pause(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		AudioSource obj = LuaScriptMgr.GetNetObject<AudioSource>(L, 1);
		obj.Pause();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayOneShot(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			AudioSource obj = LuaScriptMgr.GetNetObject<AudioSource>(L, 1);
			AudioClip arg0 = LuaScriptMgr.GetNetObject<AudioClip>(L, 2);
			obj.PlayOneShot(arg0);
			return 0;
		}
		else if (count == 3)
		{
			AudioSource obj = LuaScriptMgr.GetNetObject<AudioSource>(L, 1);
			AudioClip arg0 = LuaScriptMgr.GetNetObject<AudioClip>(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			obj.PlayOneShot(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AudioSource.PlayOneShot");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayClipAtPoint(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			AudioClip arg0 = LuaScriptMgr.GetNetObject<AudioClip>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			AudioSource.PlayClipAtPoint(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			AudioClip arg0 = LuaScriptMgr.GetNetObject<AudioClip>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			AudioSource.PlayClipAtPoint(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AudioSource.PlayClipAtPoint");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetOutputData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		AudioSource obj = LuaScriptMgr.GetNetObject<AudioSource>(L, 1);
		float[] objs0 = LuaScriptMgr.GetArrayNumber<float>(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.GetOutputData(objs0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSpectrumData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		AudioSource obj = LuaScriptMgr.GetNetObject<AudioSource>(L, 1);
		float[] objs0 = LuaScriptMgr.GetArrayNumber<float>(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		FFTWindow arg2 = LuaScriptMgr.GetNetObject<FFTWindow>(L, 4);
		obj.GetSpectrumData(objs0,arg1,arg2);
		return 0;
	}
}

