using UnityEngine;
using System;
using LuaInterface;

public class NavMeshTriangulationWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateNavMeshTriangulation),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("vertices", get_vertices, set_vertices),
		new LuaField("indices", get_indices, set_indices),
		new LuaField("layers", get_layers, set_layers),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateNavMeshTriangulation(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		NavMeshTriangulation obj = new NavMeshTriangulation();
		LuaScriptMgr.PushValue(L, obj);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(NavMeshTriangulation));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.NavMeshTriangulation", typeof(NavMeshTriangulation), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_vertices(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name vertices");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index vertices on a nil value");
			}
		}

		NavMeshTriangulation obj = (NavMeshTriangulation)o;
		LuaScriptMgr.PushArray(L, obj.vertices);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_indices(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name indices");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index indices on a nil value");
			}
		}

		NavMeshTriangulation obj = (NavMeshTriangulation)o;
		LuaScriptMgr.PushArray(L, obj.indices);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_layers(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name layers");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index layers on a nil value");
			}
		}

		NavMeshTriangulation obj = (NavMeshTriangulation)o;
		LuaScriptMgr.PushArray(L, obj.layers);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_vertices(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name vertices");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index vertices on a nil value");
			}
		}

		NavMeshTriangulation obj = (NavMeshTriangulation)o;
		obj.vertices = LuaScriptMgr.GetNetObject<Vector3[]>(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_indices(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name indices");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index indices on a nil value");
			}
		}

		NavMeshTriangulation obj = (NavMeshTriangulation)o;
		obj.indices = LuaScriptMgr.GetNetObject<Int32[]>(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_layers(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name layers");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index layers on a nil value");
			}
		}

		NavMeshTriangulation obj = (NavMeshTriangulation)o;
		obj.layers = LuaScriptMgr.GetNetObject<Int32[]>(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}
}

