using UnityEngine;
using System;
using LuaInterface;

public class AudioDistortionFilterWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateAudioDistortionFilter),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("distortionLevel", get_distortionLevel, set_distortionLevel),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAudioDistortionFilter(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AudioDistortionFilter obj = new AudioDistortionFilter();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AudioDistortionFilter.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AudioDistortionFilter));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AudioDistortionFilter", typeof(AudioDistortionFilter), regs, fields, "UnityEngine.Behaviour");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_distortionLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name distortionLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index distortionLevel on a nil value");
			}
		}

		AudioDistortionFilter obj = (AudioDistortionFilter)o;
		LuaScriptMgr.Push(L, obj.distortionLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_distortionLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name distortionLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index distortionLevel on a nil value");
			}
		}

		AudioDistortionFilter obj = (AudioDistortionFilter)o;
		obj.distortionLevel = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}

