using UnityEngine;
using System;
using LuaInterface;

public class AudioChorusFilterWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateAudioChorusFilter),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("dryMix", get_dryMix, set_dryMix),
		new LuaField("wetMix1", get_wetMix1, set_wetMix1),
		new LuaField("wetMix2", get_wetMix2, set_wetMix2),
		new LuaField("wetMix3", get_wetMix3, set_wetMix3),
		new LuaField("delay", get_delay, set_delay),
		new LuaField("rate", get_rate, set_rate),
		new LuaField("depth", get_depth, set_depth),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAudioChorusFilter(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AudioChorusFilter obj = new AudioChorusFilter();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AudioChorusFilter.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AudioChorusFilter));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AudioChorusFilter", typeof(AudioChorusFilter), regs, fields, "UnityEngine.Behaviour");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dryMix(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dryMix");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dryMix on a nil value");
			}
		}

		AudioChorusFilter obj = (AudioChorusFilter)o;
		LuaScriptMgr.Push(L, obj.dryMix);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_wetMix1(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name wetMix1");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index wetMix1 on a nil value");
			}
		}

		AudioChorusFilter obj = (AudioChorusFilter)o;
		LuaScriptMgr.Push(L, obj.wetMix1);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_wetMix2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name wetMix2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index wetMix2 on a nil value");
			}
		}

		AudioChorusFilter obj = (AudioChorusFilter)o;
		LuaScriptMgr.Push(L, obj.wetMix2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_wetMix3(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name wetMix3");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index wetMix3 on a nil value");
			}
		}

		AudioChorusFilter obj = (AudioChorusFilter)o;
		LuaScriptMgr.Push(L, obj.wetMix3);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_delay(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name delay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index delay on a nil value");
			}
		}

		AudioChorusFilter obj = (AudioChorusFilter)o;
		LuaScriptMgr.Push(L, obj.delay);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rate on a nil value");
			}
		}

		AudioChorusFilter obj = (AudioChorusFilter)o;
		LuaScriptMgr.Push(L, obj.rate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_depth(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depth on a nil value");
			}
		}

		AudioChorusFilter obj = (AudioChorusFilter)o;
		LuaScriptMgr.Push(L, obj.depth);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_dryMix(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dryMix");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dryMix on a nil value");
			}
		}

		AudioChorusFilter obj = (AudioChorusFilter)o;
		obj.dryMix = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_wetMix1(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name wetMix1");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index wetMix1 on a nil value");
			}
		}

		AudioChorusFilter obj = (AudioChorusFilter)o;
		obj.wetMix1 = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_wetMix2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name wetMix2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index wetMix2 on a nil value");
			}
		}

		AudioChorusFilter obj = (AudioChorusFilter)o;
		obj.wetMix2 = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_wetMix3(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name wetMix3");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index wetMix3 on a nil value");
			}
		}

		AudioChorusFilter obj = (AudioChorusFilter)o;
		obj.wetMix3 = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_delay(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name delay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index delay on a nil value");
			}
		}

		AudioChorusFilter obj = (AudioChorusFilter)o;
		obj.delay = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rate on a nil value");
			}
		}

		AudioChorusFilter obj = (AudioChorusFilter)o;
		obj.rate = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_depth(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depth on a nil value");
			}
		}

		AudioChorusFilter obj = (AudioChorusFilter)o;
		obj.depth = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}

