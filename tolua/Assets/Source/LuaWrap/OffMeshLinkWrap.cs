using UnityEngine;
using System;
using LuaInterface;

public class OffMeshLinkWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("UpdatePositions", UpdatePositions),
		new LuaMethod("New", _CreateOffMeshLink),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("activated", get_activated, set_activated),
		new LuaField("occupied", get_occupied, null),
		new LuaField("costOverride", get_costOverride, set_costOverride),
		new LuaField("biDirectional", get_biDirectional, set_biDirectional),
		new LuaField("navMeshLayer", get_navMeshLayer, set_navMeshLayer),
		new LuaField("autoUpdatePositions", get_autoUpdatePositions, set_autoUpdatePositions),
		new LuaField("startTransform", get_startTransform, set_startTransform),
		new LuaField("endTransform", get_endTransform, set_endTransform),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateOffMeshLink(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			OffMeshLink obj = new OffMeshLink();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: OffMeshLink.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(OffMeshLink));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.OffMeshLink", typeof(OffMeshLink), regs, fields, "UnityEngine.Component");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_activated(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name activated");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index activated on a nil value");
			}
		}

		OffMeshLink obj = (OffMeshLink)o;
		LuaScriptMgr.Push(L, obj.activated);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_occupied(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name occupied");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index occupied on a nil value");
			}
		}

		OffMeshLink obj = (OffMeshLink)o;
		LuaScriptMgr.Push(L, obj.occupied);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_costOverride(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name costOverride");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index costOverride on a nil value");
			}
		}

		OffMeshLink obj = (OffMeshLink)o;
		LuaScriptMgr.Push(L, obj.costOverride);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_biDirectional(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name biDirectional");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index biDirectional on a nil value");
			}
		}

		OffMeshLink obj = (OffMeshLink)o;
		LuaScriptMgr.Push(L, obj.biDirectional);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_navMeshLayer(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name navMeshLayer");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index navMeshLayer on a nil value");
			}
		}

		OffMeshLink obj = (OffMeshLink)o;
		LuaScriptMgr.Push(L, obj.navMeshLayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_autoUpdatePositions(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name autoUpdatePositions");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index autoUpdatePositions on a nil value");
			}
		}

		OffMeshLink obj = (OffMeshLink)o;
		LuaScriptMgr.Push(L, obj.autoUpdatePositions);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_startTransform(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startTransform");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startTransform on a nil value");
			}
		}

		OffMeshLink obj = (OffMeshLink)o;
		LuaScriptMgr.Push(L, obj.startTransform);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_endTransform(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name endTransform");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index endTransform on a nil value");
			}
		}

		OffMeshLink obj = (OffMeshLink)o;
		LuaScriptMgr.Push(L, obj.endTransform);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_activated(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name activated");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index activated on a nil value");
			}
		}

		OffMeshLink obj = (OffMeshLink)o;
		obj.activated = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_costOverride(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name costOverride");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index costOverride on a nil value");
			}
		}

		OffMeshLink obj = (OffMeshLink)o;
		obj.costOverride = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_biDirectional(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name biDirectional");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index biDirectional on a nil value");
			}
		}

		OffMeshLink obj = (OffMeshLink)o;
		obj.biDirectional = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_navMeshLayer(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name navMeshLayer");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index navMeshLayer on a nil value");
			}
		}

		OffMeshLink obj = (OffMeshLink)o;
		obj.navMeshLayer = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_autoUpdatePositions(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name autoUpdatePositions");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index autoUpdatePositions on a nil value");
			}
		}

		OffMeshLink obj = (OffMeshLink)o;
		obj.autoUpdatePositions = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_startTransform(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startTransform");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startTransform on a nil value");
			}
		}

		OffMeshLink obj = (OffMeshLink)o;
		obj.startTransform = LuaScriptMgr.GetNetObject<Transform>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_endTransform(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name endTransform");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index endTransform on a nil value");
			}
		}

		OffMeshLink obj = (OffMeshLink)o;
		obj.endTransform = LuaScriptMgr.GetNetObject<Transform>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UpdatePositions(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		OffMeshLink obj = LuaScriptMgr.GetNetObject<OffMeshLink>(L, 1);
		obj.UpdatePositions();
		return 0;
	}
}

