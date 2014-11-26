using UnityEngine;
using System;
using LuaInterface;

public class OffMeshLinkDataWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateOffMeshLinkData),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("valid", get_valid, null),
		new LuaField("activated", get_activated, null),
		new LuaField("linkType", get_linkType, null),
		new LuaField("startPos", get_startPos, null),
		new LuaField("endPos", get_endPos, null),
		new LuaField("offMeshLink", get_offMeshLink, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateOffMeshLinkData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		OffMeshLinkData obj = new OffMeshLinkData();
		LuaScriptMgr.PushValue(L, obj);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(OffMeshLinkData));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.OffMeshLinkData", typeof(OffMeshLinkData), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_valid(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name valid");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index valid on a nil value");
			}
		}

		OffMeshLinkData obj = (OffMeshLinkData)o;
		LuaScriptMgr.Push(L, obj.valid);
		return 1;
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

		OffMeshLinkData obj = (OffMeshLinkData)o;
		LuaScriptMgr.Push(L, obj.activated);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_linkType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name linkType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index linkType on a nil value");
			}
		}

		OffMeshLinkData obj = (OffMeshLinkData)o;
		LuaScriptMgr.PushEnum(L, obj.linkType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_startPos(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startPos");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startPos on a nil value");
			}
		}

		OffMeshLinkData obj = (OffMeshLinkData)o;
		LuaScriptMgr.PushValue(L, obj.startPos);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_endPos(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name endPos");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index endPos on a nil value");
			}
		}

		OffMeshLinkData obj = (OffMeshLinkData)o;
		LuaScriptMgr.PushValue(L, obj.endPos);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_offMeshLink(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name offMeshLink");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index offMeshLink on a nil value");
			}
		}

		OffMeshLinkData obj = (OffMeshLinkData)o;
		LuaScriptMgr.Push(L, obj.offMeshLink);
		return 1;
	}
}

