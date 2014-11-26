using UnityEngine;
using System;
using LuaInterface;

public class PolygonCollider2DWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetPath", GetPath),
		new LuaMethod("SetPath", SetPath),
		new LuaMethod("GetTotalPointCount", GetTotalPointCount),
		new LuaMethod("CreatePrimitive", CreatePrimitive),
		new LuaMethod("New", _CreatePolygonCollider2D),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("points", get_points, set_points),
		new LuaField("pathCount", get_pathCount, set_pathCount),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreatePolygonCollider2D(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			PolygonCollider2D obj = new PolygonCollider2D();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: PolygonCollider2D.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(PolygonCollider2D));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.PolygonCollider2D", typeof(PolygonCollider2D), regs, fields, "UnityEngine.Collider2D");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_points(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name points");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index points on a nil value");
			}
		}

		PolygonCollider2D obj = (PolygonCollider2D)o;
		LuaScriptMgr.PushArray(L, obj.points);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pathCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pathCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pathCount on a nil value");
			}
		}

		PolygonCollider2D obj = (PolygonCollider2D)o;
		LuaScriptMgr.Push(L, obj.pathCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_points(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name points");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index points on a nil value");
			}
		}

		PolygonCollider2D obj = (PolygonCollider2D)o;
		obj.points = LuaScriptMgr.GetNetObject<Vector2[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pathCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pathCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pathCount on a nil value");
			}
		}

		PolygonCollider2D obj = (PolygonCollider2D)o;
		obj.pathCount = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		PolygonCollider2D obj = LuaScriptMgr.GetNetObject<PolygonCollider2D>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Vector2[] o = obj.GetPath(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		PolygonCollider2D obj = LuaScriptMgr.GetNetObject<PolygonCollider2D>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Vector2[] objs1 = LuaScriptMgr.GetArrayObject<Vector2>(L, 3);
		obj.SetPath(arg0,objs1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTotalPointCount(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		PolygonCollider2D obj = LuaScriptMgr.GetNetObject<PolygonCollider2D>(L, 1);
		int o = obj.GetTotalPointCount();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreatePrimitive(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			PolygonCollider2D obj = LuaScriptMgr.GetNetObject<PolygonCollider2D>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			obj.CreatePrimitive(arg0);
			return 0;
		}
		else if (count == 3)
		{
			PolygonCollider2D obj = LuaScriptMgr.GetNetObject<PolygonCollider2D>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			obj.CreatePrimitive(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			PolygonCollider2D obj = LuaScriptMgr.GetNetObject<PolygonCollider2D>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Vector2 arg1 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 4);
			obj.CreatePrimitive(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: PolygonCollider2D.CreatePrimitive");
		}

		return 0;
	}
}

