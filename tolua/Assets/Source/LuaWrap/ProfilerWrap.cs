using UnityEngine;
using System;
using LuaInterface;
using Object = UnityEngine.Object;

public class ProfilerWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("AddFramesFromFile", AddFramesFromFile),
		new LuaMethod("BeginSample", BeginSample),
		new LuaMethod("EndSample", EndSample),
		new LuaMethod("GetRuntimeMemorySize", GetRuntimeMemorySize),
		new LuaMethod("GetMonoHeapSize", GetMonoHeapSize),
		new LuaMethod("GetMonoUsedSize", GetMonoUsedSize),
		new LuaMethod("GetTotalAllocatedMemory", GetTotalAllocatedMemory),
		new LuaMethod("GetTotalUnusedReservedMemory", GetTotalUnusedReservedMemory),
		new LuaMethod("GetTotalReservedMemory", GetTotalReservedMemory),
		new LuaMethod("New", _CreateProfiler),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("supported", get_supported, null),
		new LuaField("logFile", get_logFile, set_logFile),
		new LuaField("enableBinaryLog", get_enableBinaryLog, set_enableBinaryLog),
		new LuaField("enabled", get_enabled, set_enabled),
		new LuaField("usedHeapSize", get_usedHeapSize, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateProfiler(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Profiler obj = new Profiler();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Profiler.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Profiler));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Profiler", typeof(Profiler), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supported(IntPtr L)
	{
		LuaScriptMgr.Push(L, Profiler.supported);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_logFile(IntPtr L)
	{
		LuaScriptMgr.Push(L, Profiler.logFile);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enableBinaryLog(IntPtr L)
	{
		LuaScriptMgr.Push(L, Profiler.enableBinaryLog);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enabled(IntPtr L)
	{
		LuaScriptMgr.Push(L, Profiler.enabled);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_usedHeapSize(IntPtr L)
	{
		LuaScriptMgr.Push(L, Profiler.usedHeapSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_logFile(IntPtr L)
	{
		Profiler.logFile = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enableBinaryLog(IntPtr L)
	{
		Profiler.enableBinaryLog = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enabled(IntPtr L)
	{
		Profiler.enabled = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddFramesFromFile(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Profiler.AddFramesFromFile(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BeginSample(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			Profiler.BeginSample(arg0);
			return 0;
		}
		else if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			Object arg1 = LuaScriptMgr.GetNetObject<Object>(L, 2);
			Profiler.BeginSample(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Profiler.BeginSample");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EndSample(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Profiler.EndSample();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRuntimeMemorySize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Object arg0 = LuaScriptMgr.GetNetObject<Object>(L, 1);
		int o = Profiler.GetRuntimeMemorySize(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMonoHeapSize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		uint o = Profiler.GetMonoHeapSize();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMonoUsedSize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		uint o = Profiler.GetMonoUsedSize();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTotalAllocatedMemory(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		uint o = Profiler.GetTotalAllocatedMemory();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTotalUnusedReservedMemory(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		uint o = Profiler.GetTotalUnusedReservedMemory();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTotalReservedMemory(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		uint o = Profiler.GetTotalReservedMemory();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

