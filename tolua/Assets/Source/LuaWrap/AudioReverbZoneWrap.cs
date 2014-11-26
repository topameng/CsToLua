using UnityEngine;
using System;
using LuaInterface;

public class AudioReverbZoneWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateAudioReverbZone),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("minDistance", get_minDistance, set_minDistance),
		new LuaField("maxDistance", get_maxDistance, set_maxDistance),
		new LuaField("reverbPreset", get_reverbPreset, set_reverbPreset),
		new LuaField("room", get_room, set_room),
		new LuaField("roomHF", get_roomHF, set_roomHF),
		new LuaField("roomLF", get_roomLF, set_roomLF),
		new LuaField("decayTime", get_decayTime, set_decayTime),
		new LuaField("decayHFRatio", get_decayHFRatio, set_decayHFRatio),
		new LuaField("reflections", get_reflections, set_reflections),
		new LuaField("reflectionsDelay", get_reflectionsDelay, set_reflectionsDelay),
		new LuaField("reverb", get_reverb, set_reverb),
		new LuaField("reverbDelay", get_reverbDelay, set_reverbDelay),
		new LuaField("HFReference", get_HFReference, set_HFReference),
		new LuaField("LFReference", get_LFReference, set_LFReference),
		new LuaField("roomRolloffFactor", get_roomRolloffFactor, set_roomRolloffFactor),
		new LuaField("diffusion", get_diffusion, set_diffusion),
		new LuaField("density", get_density, set_density),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAudioReverbZone(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AudioReverbZone obj = new AudioReverbZone();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AudioReverbZone.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AudioReverbZone));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AudioReverbZone", typeof(AudioReverbZone), regs, fields, "UnityEngine.Behaviour");
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

		AudioReverbZone obj = (AudioReverbZone)o;
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

		AudioReverbZone obj = (AudioReverbZone)o;
		LuaScriptMgr.Push(L, obj.maxDistance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_reverbPreset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name reverbPreset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index reverbPreset on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		LuaScriptMgr.PushEnum(L, obj.reverbPreset);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_room(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name room");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index room on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		LuaScriptMgr.Push(L, obj.room);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_roomHF(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roomHF");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roomHF on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		LuaScriptMgr.Push(L, obj.roomHF);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_roomLF(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roomLF");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roomLF on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		LuaScriptMgr.Push(L, obj.roomLF);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_decayTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name decayTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index decayTime on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		LuaScriptMgr.Push(L, obj.decayTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_decayHFRatio(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name decayHFRatio");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index decayHFRatio on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		LuaScriptMgr.Push(L, obj.decayHFRatio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_reflections(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name reflections");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index reflections on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		LuaScriptMgr.Push(L, obj.reflections);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_reflectionsDelay(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name reflectionsDelay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index reflectionsDelay on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		LuaScriptMgr.Push(L, obj.reflectionsDelay);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_reverb(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name reverb");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index reverb on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		LuaScriptMgr.Push(L, obj.reverb);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_reverbDelay(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name reverbDelay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index reverbDelay on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		LuaScriptMgr.Push(L, obj.reverbDelay);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_HFReference(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name HFReference");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index HFReference on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		LuaScriptMgr.Push(L, obj.HFReference);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LFReference(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name LFReference");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index LFReference on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		LuaScriptMgr.Push(L, obj.LFReference);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_roomRolloffFactor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roomRolloffFactor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roomRolloffFactor on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		LuaScriptMgr.Push(L, obj.roomRolloffFactor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_diffusion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name diffusion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index diffusion on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		LuaScriptMgr.Push(L, obj.diffusion);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_density(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name density");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index density on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		LuaScriptMgr.Push(L, obj.density);
		return 1;
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

		AudioReverbZone obj = (AudioReverbZone)o;
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

		AudioReverbZone obj = (AudioReverbZone)o;
		obj.maxDistance = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_reverbPreset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name reverbPreset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index reverbPreset on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		obj.reverbPreset = LuaScriptMgr.GetNetObject<AudioReverbPreset>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_room(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name room");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index room on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		obj.room = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_roomHF(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roomHF");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roomHF on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		obj.roomHF = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_roomLF(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roomLF");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roomLF on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		obj.roomLF = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_decayTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name decayTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index decayTime on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		obj.decayTime = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_decayHFRatio(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name decayHFRatio");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index decayHFRatio on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		obj.decayHFRatio = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_reflections(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name reflections");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index reflections on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		obj.reflections = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_reflectionsDelay(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name reflectionsDelay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index reflectionsDelay on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		obj.reflectionsDelay = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_reverb(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name reverb");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index reverb on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		obj.reverb = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_reverbDelay(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name reverbDelay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index reverbDelay on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		obj.reverbDelay = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_HFReference(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name HFReference");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index HFReference on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		obj.HFReference = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_LFReference(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name LFReference");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index LFReference on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		obj.LFReference = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_roomRolloffFactor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roomRolloffFactor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roomRolloffFactor on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		obj.roomRolloffFactor = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_diffusion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name diffusion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index diffusion on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		obj.diffusion = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_density(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name density");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index density on a nil value");
			}
		}

		AudioReverbZone obj = (AudioReverbZone)o;
		obj.density = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}

