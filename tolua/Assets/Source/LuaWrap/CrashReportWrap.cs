using UnityEngine;
using System;
using LuaInterface;

public class CrashReportWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("RemoveAll", RemoveAll),
		new LuaMethod("Remove", Remove),
		new LuaMethod("New", _CreateCrashReport),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("time", get_time, null),
		new LuaField("text", get_text, null),
		new LuaField("reports", get_reports, null),
		new LuaField("lastReport", get_lastReport, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCrashReport(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CrashReport class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(CrashReport));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.CrashReport", typeof(CrashReport), regs, fields, "System.Object");
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

		CrashReport obj = (CrashReport)o;
		LuaScriptMgr.PushValue(L, obj.time);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_text(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name text");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index text on a nil value");
			}
		}

		CrashReport obj = (CrashReport)o;
		LuaScriptMgr.Push(L, obj.text);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_reports(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, CrashReport.reports);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lastReport(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, CrashReport.lastReport);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveAll(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		CrashReport.RemoveAll();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Remove(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CrashReport obj = LuaScriptMgr.GetNetObject<CrashReport>(L, 1);
		obj.Remove();
		return 0;
	}
}

