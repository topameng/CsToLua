using UnityEngine;
using System;
using LuaInterface;

public class LocationServiceWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Start", Start),
		new LuaMethod("Stop", Stop),
		new LuaMethod("New", _CreateLocationService),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("isEnabledByUser", get_isEnabledByUser, null),
		new LuaField("status", get_status, null),
		new LuaField("lastData", get_lastData, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLocationService(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			LocationService obj = new LocationService();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: LocationService.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(LocationService));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.LocationService", typeof(LocationService), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isEnabledByUser(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isEnabledByUser");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isEnabledByUser on a nil value");
			}
		}

		LocationService obj = (LocationService)o;
		LuaScriptMgr.Push(L, obj.isEnabledByUser);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_status(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name status");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index status on a nil value");
			}
		}

		LocationService obj = (LocationService)o;
		LuaScriptMgr.PushEnum(L, obj.status);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lastData(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lastData");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lastData on a nil value");
			}
		}

		LocationService obj = (LocationService)o;
		LuaScriptMgr.PushValue(L, obj.lastData);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Start(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			LocationService obj = LuaScriptMgr.GetNetObject<LocationService>(L, 1);
			obj.Start();
			return 0;
		}
		else if (count == 2)
		{
			LocationService obj = LuaScriptMgr.GetNetObject<LocationService>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			obj.Start(arg0);
			return 0;
		}
		else if (count == 3)
		{
			LocationService obj = LuaScriptMgr.GetNetObject<LocationService>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			obj.Start(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: LocationService.Start");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Stop(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LocationService obj = LuaScriptMgr.GetNetObject<LocationService>(L, 1);
		obj.Stop();
		return 0;
	}
}

