using UnityEngine;
using System;
using LuaInterface;

public class ColorWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("ToString", ToString),
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("Equals", Equals),
		new LuaMethod("Lerp", Lerp),
		new LuaMethod("get_Item", get_Item),
		new LuaMethod("set_Item", set_Item),
		new LuaMethod("New", _CreateColor),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__tostring", Lua_ToString),
		new LuaMethod("__add", Lua_Add),
		new LuaMethod("__sub", Lua_Sub),
		new LuaMethod("__mul", Lua_Mul),
		new LuaMethod("__div", Lua_Div),
		new LuaMethod("__eq", Lua_Eq),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("r", get_r, set_r),
		new LuaField("g", get_g, set_g),
		new LuaField("b", get_b, set_b),
		new LuaField("a", get_a, set_a),
		new LuaField("red", get_red, null),
		new LuaField("green", get_green, null),
		new LuaField("blue", get_blue, null),
		new LuaField("white", get_white, null),
		new LuaField("black", get_black, null),
		new LuaField("yellow", get_yellow, null),
		new LuaField("cyan", get_cyan, null),
		new LuaField("magenta", get_magenta, null),
		new LuaField("gray", get_gray, null),
		new LuaField("grey", get_grey, null),
		new LuaField("clear", get_clear, null),
		new LuaField("grayscale", get_grayscale, null),
		new LuaField("linear", get_linear, null),
		new LuaField("gamma", get_gamma, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateColor(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Color obj = new Color(arg0,arg1,arg2);
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else if (count == 4)
		{
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			Color obj = new Color(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else if (count == 0)
		{
			Color obj = new Color();
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Color.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Color));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Color", typeof(Color), regs, fields, null);
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

		Color obj = (Color)o;
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

		Color obj = (Color)o;
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

		Color obj = (Color)o;
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

		Color obj = (Color)o;
		LuaScriptMgr.Push(L, obj.a);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_red(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Color.red);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_green(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Color.green);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_blue(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Color.blue);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_white(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Color.white);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_black(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Color.black);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_yellow(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Color.yellow);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cyan(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Color.cyan);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_magenta(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Color.magenta);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gray(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Color.gray);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_grey(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Color.grey);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_clear(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Color.clear);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_grayscale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name grayscale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index grayscale on a nil value");
			}
		}

		Color obj = (Color)o;
		LuaScriptMgr.Push(L, obj.grayscale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_linear(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name linear");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index linear on a nil value");
			}
		}

		Color obj = (Color)o;
		LuaScriptMgr.PushValue(L, obj.linear);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gamma(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gamma");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gamma on a nil value");
			}
		}

		Color obj = (Color)o;
		LuaScriptMgr.PushValue(L, obj.gamma);
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

		Color obj = (Color)o;
		obj.r = (float)LuaScriptMgr.GetNumber(L, 3);
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

		Color obj = (Color)o;
		obj.g = (float)LuaScriptMgr.GetNumber(L, 3);
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

		Color obj = (Color)o;
		obj.b = (float)LuaScriptMgr.GetNumber(L, 3);
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

		Color obj = (Color)o;
		obj.a = (float)LuaScriptMgr.GetNumber(L, 3);
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
			LuaScriptMgr.Push(L, "Table: UnityEngine.Color");
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Color obj = LuaScriptMgr.GetNetObject<Color>(L, 1);
			string o = obj.ToString();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Color obj = LuaScriptMgr.GetNetObject<Color>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			string o = obj.ToString(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Color.ToString");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Color obj = LuaScriptMgr.GetNetObject<Color>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Color obj = LuaScriptMgr.GetNetObject<Color>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lerp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Color arg0 = LuaScriptMgr.GetNetObject<Color>(L, 1);
		Color arg1 = LuaScriptMgr.GetNetObject<Color>(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		Color o = Color.Lerp(arg0,arg1,arg2);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Item(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Color obj = LuaScriptMgr.GetNetObject<Color>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		float o = obj[arg0];
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Item(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Color obj = LuaScriptMgr.GetNetObject<Color>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		obj[arg0] = arg1;
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Add(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Color arg0 = LuaScriptMgr.GetNetObject<Color>(L, 1);
		Color arg1 = LuaScriptMgr.GetNetObject<Color>(L, 2);
		Color o = arg0 + arg1;
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Sub(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Color arg0 = LuaScriptMgr.GetNetObject<Color>(L, 1);
		Color arg1 = LuaScriptMgr.GetNetObject<Color>(L, 2);
		Color o = arg0 - arg1;
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Mul(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(float), typeof(Color)};
		Type[] types1 = {typeof(Color), typeof(float)};
		Type[] types2 = {typeof(Color), typeof(Color)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
			Color arg1 = LuaScriptMgr.GetNetObject<Color>(L, 2);
			Color o = arg0 * arg1;
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Color arg0 = LuaScriptMgr.GetNetObject<Color>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Color o = arg0 * arg1;
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Color arg0 = LuaScriptMgr.GetNetObject<Color>(L, 1);
			Color arg1 = LuaScriptMgr.GetNetObject<Color>(L, 2);
			Color o = arg0 * arg1;
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Color.op_Multiply");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Div(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Color arg0 = LuaScriptMgr.GetNetObject<Color>(L, 1);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
		Color o = arg0 / arg1;
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Color arg0 = LuaScriptMgr.GetNetObject<Color>(L, 1);
		Color arg1 = LuaScriptMgr.GetNetObject<Color>(L, 2);
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

