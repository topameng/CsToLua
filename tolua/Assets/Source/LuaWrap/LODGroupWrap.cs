using UnityEngine;
using System;
using LuaInterface;

public class LODGroupWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("RecalculateBounds", RecalculateBounds),
		new LuaMethod("SetLODS", SetLODS),
		new LuaMethod("ForceLOD", ForceLOD),
		new LuaMethod("New", _CreateLODGroup),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("localReferencePoint", get_localReferencePoint, set_localReferencePoint),
		new LuaField("size", get_size, set_size),
		new LuaField("lodCount", get_lodCount, null),
		new LuaField("enabled", get_enabled, set_enabled),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLODGroup(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			LODGroup obj = new LODGroup();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: LODGroup.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(LODGroup));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.LODGroup", typeof(LODGroup), regs, fields, "UnityEngine.Component");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localReferencePoint(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name localReferencePoint");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index localReferencePoint on a nil value");
			}
		}

		LODGroup obj = (LODGroup)o;
		LuaScriptMgr.PushValue(L, obj.localReferencePoint);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_size(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name size");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index size on a nil value");
			}
		}

		LODGroup obj = (LODGroup)o;
		LuaScriptMgr.Push(L, obj.size);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lodCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lodCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lodCount on a nil value");
			}
		}

		LODGroup obj = (LODGroup)o;
		LuaScriptMgr.Push(L, obj.lodCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enabled on a nil value");
			}
		}

		LODGroup obj = (LODGroup)o;
		LuaScriptMgr.Push(L, obj.enabled);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localReferencePoint(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name localReferencePoint");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index localReferencePoint on a nil value");
			}
		}

		LODGroup obj = (LODGroup)o;
		obj.localReferencePoint = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_size(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name size");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index size on a nil value");
			}
		}

		LODGroup obj = (LODGroup)o;
		obj.size = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enabled on a nil value");
			}
		}

		LODGroup obj = (LODGroup)o;
		obj.enabled = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RecalculateBounds(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LODGroup obj = LuaScriptMgr.GetNetObject<LODGroup>(L, 1);
		obj.RecalculateBounds();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetLODS(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LODGroup obj = LuaScriptMgr.GetNetObject<LODGroup>(L, 1);
		LOD[] objs0 = LuaScriptMgr.GetArrayObject<LOD>(L, 2);
		obj.SetLODS(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ForceLOD(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LODGroup obj = LuaScriptMgr.GetNetObject<LODGroup>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.ForceLOD(arg0);
		return 0;
	}
}

