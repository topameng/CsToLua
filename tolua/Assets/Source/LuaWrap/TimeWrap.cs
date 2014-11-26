using UnityEngine;
using System;
using LuaInterface;

public class TimeWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateTime),
		new LuaMethod("GetClassType", GetClassType),
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
	static int _CreateTime(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Time obj = new Time();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Time.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Time));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Time", typeof(Time), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_time(IntPtr L)
	{
		LuaScriptMgr.Push(L, Time.time);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_timeSinceLevelLoad(IntPtr L)
	{
		LuaScriptMgr.Push(L, Time.timeSinceLevelLoad);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_deltaTime(IntPtr L)
	{
		LuaScriptMgr.Push(L, Time.deltaTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fixedTime(IntPtr L)
	{
		LuaScriptMgr.Push(L, Time.fixedTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_unscaledTime(IntPtr L)
	{
		LuaScriptMgr.Push(L, Time.unscaledTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_unscaledDeltaTime(IntPtr L)
	{
		LuaScriptMgr.Push(L, Time.unscaledDeltaTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fixedDeltaTime(IntPtr L)
	{
		LuaScriptMgr.Push(L, Time.fixedDeltaTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maximumDeltaTime(IntPtr L)
	{
		LuaScriptMgr.Push(L, Time.maximumDeltaTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_smoothDeltaTime(IntPtr L)
	{
		LuaScriptMgr.Push(L, Time.smoothDeltaTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_timeScale(IntPtr L)
	{
		LuaScriptMgr.Push(L, Time.timeScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_frameCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, Time.frameCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_renderedFrameCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, Time.renderedFrameCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_realtimeSinceStartup(IntPtr L)
	{
		LuaScriptMgr.Push(L, Time.realtimeSinceStartup);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_captureFramerate(IntPtr L)
	{
		LuaScriptMgr.Push(L, Time.captureFramerate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fixedDeltaTime(IntPtr L)
	{
		Time.fixedDeltaTime = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maximumDeltaTime(IntPtr L)
	{
		Time.maximumDeltaTime = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_timeScale(IntPtr L)
	{
		Time.timeScale = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_captureFramerate(IntPtr L)
	{
		Time.captureFramerate = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}

