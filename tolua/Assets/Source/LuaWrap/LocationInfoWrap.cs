using UnityEngine;
using System;
using LuaInterface;

public class LocationInfoWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateLocationInfo),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("latitude", get_latitude, null),
		new LuaField("longitude", get_longitude, null),
		new LuaField("altitude", get_altitude, null),
		new LuaField("horizontalAccuracy", get_horizontalAccuracy, null),
		new LuaField("verticalAccuracy", get_verticalAccuracy, null),
		new LuaField("timestamp", get_timestamp, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLocationInfo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		LocationInfo obj = new LocationInfo();
		LuaScriptMgr.PushValue(L, obj);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(LocationInfo));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.LocationInfo", typeof(LocationInfo), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_latitude(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name latitude");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index latitude on a nil value");
			}
		}

		LocationInfo obj = (LocationInfo)o;
		LuaScriptMgr.Push(L, obj.latitude);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_longitude(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name longitude");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index longitude on a nil value");
			}
		}

		LocationInfo obj = (LocationInfo)o;
		LuaScriptMgr.Push(L, obj.longitude);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_altitude(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name altitude");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index altitude on a nil value");
			}
		}

		LocationInfo obj = (LocationInfo)o;
		LuaScriptMgr.Push(L, obj.altitude);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_horizontalAccuracy(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name horizontalAccuracy");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index horizontalAccuracy on a nil value");
			}
		}

		LocationInfo obj = (LocationInfo)o;
		LuaScriptMgr.Push(L, obj.horizontalAccuracy);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_verticalAccuracy(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name verticalAccuracy");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index verticalAccuracy on a nil value");
			}
		}

		LocationInfo obj = (LocationInfo)o;
		LuaScriptMgr.Push(L, obj.verticalAccuracy);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_timestamp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name timestamp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index timestamp on a nil value");
			}
		}

		LocationInfo obj = (LocationInfo)o;
		LuaScriptMgr.Push(L, obj.timestamp);
		return 1;
	}
}

