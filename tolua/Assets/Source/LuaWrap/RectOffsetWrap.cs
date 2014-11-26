using UnityEngine;
using System;
using LuaInterface;

public class RectOffsetWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Add", Add),
		new LuaMethod("Remove", Remove),
		new LuaMethod("ToString", ToString),
		new LuaMethod("New", _CreateRectOffset),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__tostring", Lua_ToString),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("left", get_left, set_left),
		new LuaField("right", get_right, set_right),
		new LuaField("top", get_top, set_top),
		new LuaField("bottom", get_bottom, set_bottom),
		new LuaField("horizontal", get_horizontal, null),
		new LuaField("vertical", get_vertical, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateRectOffset(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			RectOffset obj = new RectOffset();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 4)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			RectOffset obj = new RectOffset(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: RectOffset.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(RectOffset));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.RectOffset", typeof(RectOffset), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_left(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name left");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index left on a nil value");
			}
		}

		RectOffset obj = (RectOffset)o;
		LuaScriptMgr.Push(L, obj.left);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_right(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name right");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index right on a nil value");
			}
		}

		RectOffset obj = (RectOffset)o;
		LuaScriptMgr.Push(L, obj.right);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_top(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name top");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index top on a nil value");
			}
		}

		RectOffset obj = (RectOffset)o;
		LuaScriptMgr.Push(L, obj.top);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bottom(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bottom");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bottom on a nil value");
			}
		}

		RectOffset obj = (RectOffset)o;
		LuaScriptMgr.Push(L, obj.bottom);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_horizontal(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name horizontal");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index horizontal on a nil value");
			}
		}

		RectOffset obj = (RectOffset)o;
		LuaScriptMgr.Push(L, obj.horizontal);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_vertical(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name vertical");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index vertical on a nil value");
			}
		}

		RectOffset obj = (RectOffset)o;
		LuaScriptMgr.Push(L, obj.vertical);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_left(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name left");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index left on a nil value");
			}
		}

		RectOffset obj = (RectOffset)o;
		obj.left = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_right(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name right");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index right on a nil value");
			}
		}

		RectOffset obj = (RectOffset)o;
		obj.right = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_top(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name top");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index top on a nil value");
			}
		}

		RectOffset obj = (RectOffset)o;
		obj.top = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bottom(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bottom");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bottom on a nil value");
			}
		}

		RectOffset obj = (RectOffset)o;
		obj.bottom = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		object obj = LuaScriptMgr.GetLuaObject(L, 1);
		if (obj != null)
		{
			LuaScriptMgr.Push(L, obj.ToString());
		}
		else
		{
			LuaScriptMgr.Push(L, "Table: UnityEngine.RectOffset");
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Add(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		RectOffset obj = LuaScriptMgr.GetNetObject<RectOffset>(L, 1);
		Rect arg0 = LuaScriptMgr.GetNetObject<Rect>(L, 2);
		Rect o = obj.Add(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Remove(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		RectOffset obj = LuaScriptMgr.GetNetObject<RectOffset>(L, 1);
		Rect arg0 = LuaScriptMgr.GetNetObject<Rect>(L, 2);
		Rect o = obj.Remove(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		RectOffset obj = LuaScriptMgr.GetNetObject<RectOffset>(L, 1);
		string o = obj.ToString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

