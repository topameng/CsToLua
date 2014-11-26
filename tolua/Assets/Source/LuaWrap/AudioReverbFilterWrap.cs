using UnityEngine;
using System;
using LuaInterface;

public class AudioReverbFilterWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateAudioReverbFilter),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("reverbPreset", get_reverbPreset, set_reverbPreset),
		new LuaField("dryLevel", get_dryLevel, set_dryLevel),
		new LuaField("room", get_room, set_room),
		new LuaField("roomHF", get_roomHF, set_roomHF),
		new LuaField("roomRolloff", get_roomRolloff, set_roomRolloff),
		new LuaField("decayTime", get_decayTime, set_decayTime),
		new LuaField("decayHFRatio", get_decayHFRatio, set_decayHFRatio),
		new LuaField("reflectionsLevel", get_reflectionsLevel, set_reflectionsLevel),
		new LuaField("reflectionsDelay", get_reflectionsDelay, set_reflectionsDelay),
		new LuaField("reverbLevel", get_reverbLevel, set_reverbLevel),
		new LuaField("reverbDelay", get_reverbDelay, set_reverbDelay),
		new LuaField("diffusion", get_diffusion, set_diffusion),
		new LuaField("density", get_density, set_density),
		new LuaField("hfReference", get_hfReference, set_hfReference),
		new LuaField("roomLF", get_roomLF, set_roomLF),
		new LuaField("lFReference", get_lFReference, set_lFReference),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAudioReverbFilter(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AudioReverbFilter obj = new AudioReverbFilter();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AudioReverbFilter.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AudioReverbFilter));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AudioReverbFilter", typeof(AudioReverbFilter), regs, fields, "UnityEngine.Behaviour");
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
		LuaScriptMgr.PushEnum(L, obj.reverbPreset);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dryLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dryLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dryLevel on a nil value");
			}
		}

		AudioReverbFilter obj = (AudioReverbFilter)o;
		LuaScriptMgr.Push(L, obj.dryLevel);
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
		LuaScriptMgr.Push(L, obj.roomHF);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_roomRolloff(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roomRolloff");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roomRolloff on a nil value");
			}
		}

		AudioReverbFilter obj = (AudioReverbFilter)o;
		LuaScriptMgr.Push(L, obj.roomRolloff);
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
		LuaScriptMgr.Push(L, obj.decayHFRatio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_reflectionsLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name reflectionsLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index reflectionsLevel on a nil value");
			}
		}

		AudioReverbFilter obj = (AudioReverbFilter)o;
		LuaScriptMgr.Push(L, obj.reflectionsLevel);
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
		LuaScriptMgr.Push(L, obj.reflectionsDelay);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_reverbLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name reverbLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index reverbLevel on a nil value");
			}
		}

		AudioReverbFilter obj = (AudioReverbFilter)o;
		LuaScriptMgr.Push(L, obj.reverbLevel);
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
		LuaScriptMgr.Push(L, obj.reverbDelay);
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
		LuaScriptMgr.Push(L, obj.density);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hfReference(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hfReference");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hfReference on a nil value");
			}
		}

		AudioReverbFilter obj = (AudioReverbFilter)o;
		LuaScriptMgr.Push(L, obj.hfReference);
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
		LuaScriptMgr.Push(L, obj.roomLF);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lFReference(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lFReference");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lFReference on a nil value");
			}
		}

		AudioReverbFilter obj = (AudioReverbFilter)o;
		LuaScriptMgr.Push(L, obj.lFReference);
		return 1;
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
		obj.reverbPreset = LuaScriptMgr.GetNetObject<AudioReverbPreset>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_dryLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dryLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dryLevel on a nil value");
			}
		}

		AudioReverbFilter obj = (AudioReverbFilter)o;
		obj.dryLevel = (float)LuaScriptMgr.GetNumber(L, 3);
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
		obj.room = (float)LuaScriptMgr.GetNumber(L, 3);
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
		obj.roomHF = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_roomRolloff(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name roomRolloff");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index roomRolloff on a nil value");
			}
		}

		AudioReverbFilter obj = (AudioReverbFilter)o;
		obj.roomRolloff = (float)LuaScriptMgr.GetNumber(L, 3);
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
		obj.decayHFRatio = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_reflectionsLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name reflectionsLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index reflectionsLevel on a nil value");
			}
		}

		AudioReverbFilter obj = (AudioReverbFilter)o;
		obj.reflectionsLevel = (float)LuaScriptMgr.GetNumber(L, 3);
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
		obj.reflectionsDelay = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_reverbLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name reverbLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index reverbLevel on a nil value");
			}
		}

		AudioReverbFilter obj = (AudioReverbFilter)o;
		obj.reverbLevel = (float)LuaScriptMgr.GetNumber(L, 3);
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
		obj.reverbDelay = (float)LuaScriptMgr.GetNumber(L, 3);
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
		obj.density = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_hfReference(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hfReference");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hfReference on a nil value");
			}
		}

		AudioReverbFilter obj = (AudioReverbFilter)o;
		obj.hfReference = (float)LuaScriptMgr.GetNumber(L, 3);
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

		AudioReverbFilter obj = (AudioReverbFilter)o;
		obj.roomLF = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lFReference(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lFReference");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lFReference on a nil value");
			}
		}

		AudioReverbFilter obj = (AudioReverbFilter)o;
		obj.lFReference = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}

