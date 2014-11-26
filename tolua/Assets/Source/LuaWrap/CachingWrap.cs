using UnityEngine;
using System;
using LuaInterface;

public class CachingWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Authorize", Authorize),
		new LuaMethod("CleanCache", CleanCache),
		new LuaMethod("IsVersionCached", IsVersionCached),
		new LuaMethod("MarkAsUsed", MarkAsUsed),
		new LuaMethod("New", _CreateCaching),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("spaceFree", get_spaceFree, null),
		new LuaField("maximumAvailableDiskSpace", get_maximumAvailableDiskSpace, set_maximumAvailableDiskSpace),
		new LuaField("spaceOccupied", get_spaceOccupied, null),
		new LuaField("expirationDelay", get_expirationDelay, set_expirationDelay),
		new LuaField("enabled", get_enabled, set_enabled),
		new LuaField("ready", get_ready, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCaching(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Caching obj = new Caching();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Caching.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Caching));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Caching", typeof(Caching), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spaceFree(IntPtr L)
	{
		LuaScriptMgr.Push(L, Caching.spaceFree);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maximumAvailableDiskSpace(IntPtr L)
	{
		LuaScriptMgr.Push(L, Caching.maximumAvailableDiskSpace);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spaceOccupied(IntPtr L)
	{
		LuaScriptMgr.Push(L, Caching.spaceOccupied);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_expirationDelay(IntPtr L)
	{
		LuaScriptMgr.Push(L, Caching.expirationDelay);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enabled(IntPtr L)
	{
		LuaScriptMgr.Push(L, Caching.enabled);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ready(IntPtr L)
	{
		LuaScriptMgr.Push(L, Caching.ready);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maximumAvailableDiskSpace(IntPtr L)
	{
		Caching.maximumAvailableDiskSpace = (long)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_expirationDelay(IntPtr L)
	{
		Caching.expirationDelay = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enabled(IntPtr L)
	{
		Caching.enabled = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Authorize(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			long arg2 = (long)LuaScriptMgr.GetNumber(L, 3);
			string arg3 = LuaScriptMgr.GetLuaString(L, 4);
			bool o = Caching.Authorize(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			long arg2 = (long)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			string arg4 = LuaScriptMgr.GetLuaString(L, 5);
			bool o = Caching.Authorize(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Caching.Authorize");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CleanCache(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		bool o = Caching.CleanCache();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsVersionCached(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		bool o = Caching.IsVersionCached(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MarkAsUsed(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		bool o = Caching.MarkAsUsed(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

