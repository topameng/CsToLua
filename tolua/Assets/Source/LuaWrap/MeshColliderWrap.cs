using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class MeshColliderWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateMeshCollider),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__eq", Lua_Eq),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("sharedMesh", get_sharedMesh, set_sharedMesh),
		new LuaField("convex", get_convex, set_convex),
		new LuaField("smoothSphereCollisions", get_smoothSphereCollisions, set_smoothSphereCollisions),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMeshCollider(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			MeshCollider obj = new MeshCollider();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MeshCollider.New");
		}

		return 0;
	}

	static Type classType = typeof(MeshCollider);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);

		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.MeshCollider", typeof(MeshCollider), regs, fields, typeof(Collider));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sharedMesh(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MeshCollider obj = (MeshCollider)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sharedMesh");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sharedMesh on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.sharedMesh);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_convex(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MeshCollider obj = (MeshCollider)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name convex");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index convex on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.convex);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_smoothSphereCollisions(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MeshCollider obj = (MeshCollider)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name smoothSphereCollisions");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index smoothSphereCollisions on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.smoothSphereCollisions);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sharedMesh(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MeshCollider obj = (MeshCollider)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sharedMesh");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sharedMesh on a nil value");
			}
		}

		obj.sharedMesh = (Mesh)LuaScriptMgr.GetUnityObject(L, 3, typeof(Mesh));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_convex(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MeshCollider obj = (MeshCollider)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name convex");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index convex on a nil value");
			}
		}

		obj.convex = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_smoothSphereCollisions(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MeshCollider obj = (MeshCollider)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name smoothSphereCollisions");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index smoothSphereCollisions on a nil value");
			}
		}

		obj.smoothSphereCollisions = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetLuaObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetLuaObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

