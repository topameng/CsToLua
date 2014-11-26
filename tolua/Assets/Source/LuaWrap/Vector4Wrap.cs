using UnityEngine;
using System;
using LuaInterface;

public class Vector4Wrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("get_Item", get_Item),
		new LuaMethod("set_Item", set_Item),
		new LuaMethod("Set", Set),
		new LuaMethod("Lerp", Lerp),
		new LuaMethod("MoveTowards", MoveTowards),
		new LuaMethod("Scale", Scale),
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("Equals", Equals),
		new LuaMethod("Normalize", Normalize),
		new LuaMethod("ToString", ToString),
		new LuaMethod("Dot", Dot),
		new LuaMethod("Project", Project),
		new LuaMethod("Distance", Distance),
		new LuaMethod("Magnitude", Magnitude),
		new LuaMethod("SqrMagnitude", SqrMagnitude),
		new LuaMethod("Min", Min),
		new LuaMethod("Max", Max),
		new LuaMethod("New", _CreateVector4),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__tostring", Lua_ToString),
		new LuaMethod("__add", Lua_Add),
		new LuaMethod("__sub", Lua_Sub),
		new LuaMethod("__mul", Lua_Mul),
		new LuaMethod("__div", Lua_Div),
		new LuaMethod("__eq", Lua_Eq),
		new LuaMethod("__unm", Lua_Neg),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("kEpsilon", get_kEpsilon, null),
		new LuaField("x", get_x, set_x),
		new LuaField("y", get_y, set_y),
		new LuaField("z", get_z, set_z),
		new LuaField("w", get_w, set_w),
		new LuaField("normalized", get_normalized, null),
		new LuaField("magnitude", get_magnitude, null),
		new LuaField("sqrMagnitude", get_sqrMagnitude, null),
		new LuaField("zero", get_zero, null),
		new LuaField("one", get_one, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateVector4(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector4 obj = new Vector4(arg0,arg1);
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else if (count == 3)
		{
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Vector4 obj = new Vector4(arg0,arg1,arg2);
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else if (count == 4)
		{
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			Vector4 obj = new Vector4(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else if (count == 0)
		{
			Vector4 obj = new Vector4();
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Vector4.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Vector4));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Vector4", typeof(Vector4), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_kEpsilon(IntPtr L)
	{
		LuaScriptMgr.Push(L, Vector4.kEpsilon);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_x(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name x");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index x on a nil value");
			}
		}

		Vector4 obj = (Vector4)o;
		LuaScriptMgr.Push(L, obj.x);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_y(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name y");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index y on a nil value");
			}
		}

		Vector4 obj = (Vector4)o;
		LuaScriptMgr.Push(L, obj.y);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_z(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name z");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index z on a nil value");
			}
		}

		Vector4 obj = (Vector4)o;
		LuaScriptMgr.Push(L, obj.z);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_w(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name w");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index w on a nil value");
			}
		}

		Vector4 obj = (Vector4)o;
		LuaScriptMgr.Push(L, obj.w);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_normalized(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name normalized");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index normalized on a nil value");
			}
		}

		Vector4 obj = (Vector4)o;
		LuaScriptMgr.PushValue(L, obj.normalized);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_magnitude(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name magnitude");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index magnitude on a nil value");
			}
		}

		Vector4 obj = (Vector4)o;
		LuaScriptMgr.Push(L, obj.magnitude);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sqrMagnitude(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sqrMagnitude");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sqrMagnitude on a nil value");
			}
		}

		Vector4 obj = (Vector4)o;
		LuaScriptMgr.Push(L, obj.sqrMagnitude);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_zero(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Vector4.zero);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_one(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Vector4.one);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_x(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name x");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index x on a nil value");
			}
		}

		Vector4 obj = (Vector4)o;
		obj.x = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_y(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name y");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index y on a nil value");
			}
		}

		Vector4 obj = (Vector4)o;
		obj.y = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_z(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name z");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index z on a nil value");
			}
		}

		Vector4 obj = (Vector4)o;
		obj.z = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_w(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name w");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index w on a nil value");
			}
		}

		Vector4 obj = (Vector4)o;
		obj.w = (float)LuaScriptMgr.GetNumber(L, 3);
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
			LuaScriptMgr.Push(L, "Table: UnityEngine.Vector4");
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Item(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector4 obj = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		float o = obj[arg0];
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Item(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Vector4 obj = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		obj[arg0] = arg1;
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Set(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		Vector4 obj = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 5);
		obj.Set(arg0,arg1,arg2,arg3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lerp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Vector4 arg0 = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		Vector4 arg1 = LuaScriptMgr.GetNetObject<Vector4>(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		Vector4 o = Vector4.Lerp(arg0,arg1,arg2);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MoveTowards(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Vector4 arg0 = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		Vector4 arg1 = LuaScriptMgr.GetNetObject<Vector4>(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		Vector4 o = Vector4.MoveTowards(arg0,arg1,arg2);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Scale(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector4 obj = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		Vector4 arg0 = LuaScriptMgr.GetNetObject<Vector4>(L, 2);
		obj.Scale(arg0);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Vector4 obj = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector4 obj = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Normalize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Vector4 obj = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		obj.Normalize();
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Vector4 obj = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
			string o = obj.ToString();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Vector4 obj = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			string o = obj.ToString(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Vector4.ToString");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Dot(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector4 arg0 = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		Vector4 arg1 = LuaScriptMgr.GetNetObject<Vector4>(L, 2);
		float o = Vector4.Dot(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Project(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector4 arg0 = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		Vector4 arg1 = LuaScriptMgr.GetNetObject<Vector4>(L, 2);
		Vector4 o = Vector4.Project(arg0,arg1);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Distance(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector4 arg0 = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		Vector4 arg1 = LuaScriptMgr.GetNetObject<Vector4>(L, 2);
		float o = Vector4.Distance(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Magnitude(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Vector4 arg0 = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		float o = Vector4.Magnitude(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SqrMagnitude(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Vector4 obj = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		float o = obj.SqrMagnitude();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Min(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector4 arg0 = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		Vector4 arg1 = LuaScriptMgr.GetNetObject<Vector4>(L, 2);
		Vector4 o = Vector4.Min(arg0,arg1);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Max(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector4 arg0 = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		Vector4 arg1 = LuaScriptMgr.GetNetObject<Vector4>(L, 2);
		Vector4 o = Vector4.Max(arg0,arg1);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Add(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector4 arg0 = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		Vector4 arg1 = LuaScriptMgr.GetNetObject<Vector4>(L, 2);
		Vector4 o = arg0 + arg1;
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Sub(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector4 arg0 = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		Vector4 arg1 = LuaScriptMgr.GetNetObject<Vector4>(L, 2);
		Vector4 o = arg0 - arg1;
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Neg(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Vector4 arg0 = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		Vector4 o = -arg0;
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Mul(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(float), typeof(Vector4)};
		Type[] types1 = {typeof(Vector4), typeof(float)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
			Vector4 arg1 = LuaScriptMgr.GetNetObject<Vector4>(L, 2);
			Vector4 o = arg0 * arg1;
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Vector4 arg0 = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector4 o = arg0 * arg1;
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Vector4.op_Multiply");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Div(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector4 arg0 = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
		Vector4 o = arg0 / arg1;
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector4 arg0 = LuaScriptMgr.GetNetObject<Vector4>(L, 1);
		Vector4 arg1 = LuaScriptMgr.GetNetObject<Vector4>(L, 2);
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

