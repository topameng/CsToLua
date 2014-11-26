using UnityEngine;
using System;
using LuaInterface;

public class Color32Wrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("ToString", ToString),
		new LuaMethod("Lerp", Lerp),
		new LuaMethod("New", _CreateColor32),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__tostring", Lua_ToString),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("r", get_r, set_r),
		new LuaField("g", get_g, set_g),
		new LuaField("b", get_b, set_b),
		new LuaField("a", get_a, set_a),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateColor32(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4)
		{
			byte arg0 = (byte)LuaScriptMgr.GetNumber(L, 1);
			byte arg1 = (byte)LuaScriptMgr.GetNumber(L, 2);
			byte arg2 = (byte)LuaScriptMgr.GetNumber(L, 3);
			byte arg3 = (byte)LuaScriptMgr.GetNumber(L, 4);
			Color32 obj = new Color32(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else if (count == 0)
		{
			Color32 obj = new Color32();
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Color32.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Color32));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Color32", typeof(Color32), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_r(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name r");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index r on a nil value");
			}
		}

		Color32 obj = (Color32)o;
		LuaScriptMgr.Push(L, obj.r);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_g(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name g");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index g on a nil value");
			}
		}

		Color32 obj = (Color32)o;
		LuaScriptMgr.Push(L, obj.g);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_b(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name b");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index b on a nil value");
			}
		}

		Color32 obj = (Color32)o;
		LuaScriptMgr.Push(L, obj.b);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_a(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name a");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index a on a nil value");
			}
		}

		Color32 obj = (Color32)o;
		LuaScriptMgr.Push(L, obj.a);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_r(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name r");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index r on a nil value");
			}
		}

		Color32 obj = (Color32)o;
		obj.r = (byte)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_g(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name g");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index g on a nil value");
			}
		}

		Color32 obj = (Color32)o;
		obj.g = (byte)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_b(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name b");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index b on a nil value");
			}
		}

		Color32 obj = (Color32)o;
		obj.b = (byte)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_a(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name a");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index a on a nil value");
			}
		}

		Color32 obj = (Color32)o;
		obj.a = (byte)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
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
			LuaScriptMgr.Push(L, "Table: UnityEngine.Color32");
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Color32 obj = LuaScriptMgr.GetNetObject<Color32>(L, 1);
			string o = obj.ToString();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Color32 obj = LuaScriptMgr.GetNetObject<Color32>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			string o = obj.ToString(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Color32.ToString");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lerp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Color32 arg0 = LuaScriptMgr.GetNetObject<Color32>(L, 1);
		Color32 arg1 = LuaScriptMgr.GetNetObject<Color32>(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		Color32 o = Color32.Lerp(arg0,arg1,arg2);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}
}

