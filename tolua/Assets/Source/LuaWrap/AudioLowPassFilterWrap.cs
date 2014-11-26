using UnityEngine;
using System;
using LuaInterface;

public class AudioLowPassFilterWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateAudioLowPassFilter),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("cutoffFrequency", get_cutoffFrequency, set_cutoffFrequency),
		new LuaField("lowpassResonaceQ", get_lowpassResonaceQ, set_lowpassResonaceQ),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAudioLowPassFilter(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AudioLowPassFilter obj = new AudioLowPassFilter();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AudioLowPassFilter.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AudioLowPassFilter));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AudioLowPassFilter", typeof(AudioLowPassFilter), regs, fields, "UnityEngine.Behaviour");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cutoffFrequency(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cutoffFrequency");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cutoffFrequency on a nil value");
			}
		}

		AudioLowPassFilter obj = (AudioLowPassFilter)o;
		LuaScriptMgr.Push(L, obj.cutoffFrequency);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lowpassResonaceQ(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lowpassResonaceQ");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lowpassResonaceQ on a nil value");
			}
		}

		AudioLowPassFilter obj = (AudioLowPassFilter)o;
		LuaScriptMgr.Push(L, obj.lowpassResonaceQ);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cutoffFrequency(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cutoffFrequency");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cutoffFrequency on a nil value");
			}
		}

		AudioLowPassFilter obj = (AudioLowPassFilter)o;
		obj.cutoffFrequency = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lowpassResonaceQ(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lowpassResonaceQ");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lowpassResonaceQ on a nil value");
			}
		}

		AudioLowPassFilter obj = (AudioLowPassFilter)o;
		obj.lowpassResonaceQ = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}

