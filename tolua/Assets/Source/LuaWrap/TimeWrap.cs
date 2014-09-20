using UnityEngine;
using System;
using LuaInterface;

public class TimeWrap : ILuaWrap
{
	public static LuaScriptMgr luaMgr = null;
	public static int reference = -1;

	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", Create),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("time", get_time, null),
		new LuaField("timeSinceLevelLoad", get_timeSinceLevelLoad, null),
		new LuaField("deltaTime", get_deltaTime, null),
		new LuaField("fixedTime", get_fixedTime, null),
		new LuaField("unscaledTime", get_unscaledTime, null),
		new LuaField("unscaledDeltaTime", get_unscaledDeltaTime, null),
		new LuaField("fixedDeltaTime", get_fixedDeltaTime, set_fixedDeltaTime),
		new LuaField("maximumDeltaTime", get_maximumDeltaTime, set_maximumDeltaTime),
		new LuaField("smoothDeltaTime", get_smoothDeltaTime, null),
		new LuaField("timeScale", get_timeScale, set_timeScale),
		new LuaField("frameCount", get_frameCount, null),
		new LuaField("renderedFrameCount", get_renderedFrameCount, null),
		new LuaField("realtimeSinceStartup", get_realtimeSinceStartup, null),
		new LuaField("captureFramerate", get_captureFramerate, set_captureFramerate),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);
		object obj = null;

		if (count == 0)
		{
			obj = new Time();
			luaMgr.PushResult(obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Time.New' has some invalid arguments");
		}

		return 0;
	}

	public void Register()
	{
		LuaMethod[] metas = new LuaMethod[]
		{
			new LuaMethod("__index", Lua_Index),
			new LuaMethod("__newindex", Lua_NewIndex),
		};

		luaMgr = LuaScriptMgr.Instance;
		reference = luaMgr.RegisterLib("Time", regs);
		luaMgr.CreateMetaTable("Time", metas, typeof(Time));
		luaMgr.RegisterField(typeof(Time), fields);
	}

	static bool get_time(IntPtr l)
	{
		luaMgr.PushResult(Time.time);
		return true;
	}

	static bool get_timeSinceLevelLoad(IntPtr l)
	{
		luaMgr.PushResult(Time.timeSinceLevelLoad);
		return true;
	}

	static bool get_deltaTime(IntPtr l)
	{
		luaMgr.PushResult(Time.deltaTime);
		return true;
	}

	static bool get_fixedTime(IntPtr l)
	{
		luaMgr.PushResult(Time.fixedTime);
		return true;
	}

	static bool get_unscaledTime(IntPtr l)
	{
		luaMgr.PushResult(Time.unscaledTime);
		return true;
	}

	static bool get_unscaledDeltaTime(IntPtr l)
	{
		luaMgr.PushResult(Time.unscaledDeltaTime);
		return true;
	}

	static bool get_fixedDeltaTime(IntPtr l)
	{
		luaMgr.PushResult(Time.fixedDeltaTime);
		return true;
	}

	static bool get_maximumDeltaTime(IntPtr l)
	{
		luaMgr.PushResult(Time.maximumDeltaTime);
		return true;
	}

	static bool get_smoothDeltaTime(IntPtr l)
	{
		luaMgr.PushResult(Time.smoothDeltaTime);
		return true;
	}

	static bool get_timeScale(IntPtr l)
	{
		luaMgr.PushResult(Time.timeScale);
		return true;
	}

	static bool get_frameCount(IntPtr l)
	{
		luaMgr.PushResult(Time.frameCount);
		return true;
	}

	static bool get_renderedFrameCount(IntPtr l)
	{
		luaMgr.PushResult(Time.renderedFrameCount);
		return true;
	}

	static bool get_realtimeSinceStartup(IntPtr l)
	{
		luaMgr.PushResult(Time.realtimeSinceStartup);
		return true;
	}

	static bool get_captureFramerate(IntPtr l)
	{
		luaMgr.PushResult(Time.captureFramerate);
		return true;
	}

	public static bool TryLuaIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.Index(reference, str, fields))
		{
			return true;
		}

		return objectWrap.TryLuaIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Index(IntPtr l)
	{
		if (TryLuaIndex(l))
		{
			return 1;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'Time' does not contain a definition for '{0}'", str));
		return 0;
	}

	static bool set_fixedDeltaTime(IntPtr l)
	{
		Time.fixedDeltaTime = (float)luaMgr.GetNumber(3);
		return true;
	}

	static bool set_maximumDeltaTime(IntPtr l)
	{
		Time.maximumDeltaTime = (float)luaMgr.GetNumber(3);
		return true;
	}

	static bool set_timeScale(IntPtr l)
	{
		Time.timeScale = (float)luaMgr.GetNumber(3);
		return true;
	}

	static bool set_captureFramerate(IntPtr l)
	{
		Time.captureFramerate = (int)luaMgr.GetNumber(3);
		return true;
	}

	public static bool TryLuaNewIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.NewIndex(reference, str, fields))
		{
			return true;
		}

		return objectWrap.TryLuaNewIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_NewIndex(IntPtr l)
	{
		if (TryLuaNewIndex(l))
		{
			return 0;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'Time' does not contain a definition for '{0}'", str));
		return 0;
	}
}

