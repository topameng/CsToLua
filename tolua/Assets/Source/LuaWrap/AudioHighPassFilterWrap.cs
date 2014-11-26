using UnityEngine;
using System;
using LuaInterface;

public class AudioHighPassFilterWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateAudioHighPassFilter),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("cutoffFrequency", get_cutoffFrequency, set_cutoffFrequency),
		new LuaField("highpassResonaceQ", get_highpassResonaceQ, set_highpassResonaceQ),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAudioHighPassFilter(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AudioHighPassFilter obj = new AudioHighPassFilter();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AudioHighPassFilter.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AudioHighPassFilter));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AudioHighPassFilter", typeof(AudioHighPassFilter), regs, fields, "UnityEngine.Behaviour");
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

		AudioHighPassFilter obj = (AudioHighPassFilter)o;
		LuaScriptMgr.Push(L, obj.cutoffFrequency);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_highpassResonaceQ(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name highpassResonaceQ");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index highpassResonaceQ on a nil value");
			}
		}

		AudioHighPassFilter obj = (AudioHighPassFilter)o;
		LuaScriptMgr.Push(L, obj.highpassResonaceQ);
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

		AudioHighPassFilter obj = (AudioHighPassFilter)o;
		obj.cutoffFrequency = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_highpassResonaceQ(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name highpassResonaceQ");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index highpassResonaceQ on a nil value");
			}
		}

		AudioHighPassFilter obj = (AudioHighPassFilter)o;
		obj.highpassResonaceQ = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}

