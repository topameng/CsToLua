using UnityEngine;
using System;
using LuaInterface;

public class Vector2Wrap : ILuaWrap
{
	public static LuaScriptMgr luaMgr = null;
	public static int reference = -1;

	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Set", Set),
		new LuaMethod("Lerp", Lerp),
		new LuaMethod("MoveTowards", MoveTowards),
		new LuaMethod("Scale", Scale),
		new LuaMethod("Normalize", Normalize),
		new LuaMethod("ToString", ToString),
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("Equals", Equals),
		new LuaMethod("Dot", Dot),
		new LuaMethod("Angle", Angle),
		new LuaMethod("Distance", Distance),
		new LuaMethod("ClampMagnitude", ClampMagnitude),
		new LuaMethod("SqrMagnitude", SqrMagnitude),
		new LuaMethod("Min", Min),
		new LuaMethod("Max", Max),
		new LuaMethod("New", Create),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("kEpsilon", get_kEpsilon, null),
		new LuaField("x", get_x, set_x),
		new LuaField("y", get_y, set_y),
		new LuaField("normalized", get_normalized, null),
		new LuaField("magnitude", get_magnitude, null),
		new LuaField("sqrMagnitude", get_sqrMagnitude, null),
		new LuaField("zero", get_zero, null),
		new LuaField("one", get_one, null),
		new LuaField("up", get_up, null),
		new LuaField("right", get_right, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);
		object obj = null;

		if (count == 2)
		{
			float arg0 = (float)luaMgr.GetNumber(1);
			float arg1 = (float)luaMgr.GetNumber(2);
			obj = new Vector2(arg0,arg1);
			luaMgr.PushResult(obj);
			return 1;
		}
		else if (count == 0)
		{
			obj = new Vector2();
			luaMgr.PushResult(obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Vector2.New' has some invalid arguments");
		}

		return 0;
	}

	public void Register()
	{
		LuaMethod[] metas = new LuaMethod[]
		{
			new LuaMethod("__index", Lua_Index),
			new LuaMethod("__newindex", Lua_NewIndex),
			new LuaMethod("__tostring", Lua_ToString),
			new LuaMethod("__add", Lua_Add),
			new LuaMethod("__sub", Lua_Sub),
			new LuaMethod("__mul", Lua_Mul),
			new LuaMethod("__div", Lua_Div),
			new LuaMethod("__eq", Lua_Eq),
			new LuaMethod("__unm", Lua_Neg),
		};

		luaMgr = LuaScriptMgr.Instance;
		reference = luaMgr.RegisterLib("Vector2", regs);
		luaMgr.CreateMetaTable("Vector2", metas, typeof(Vector2));
		luaMgr.RegisterField(typeof(Vector2), fields);
	}

	static bool get_kEpsilon(IntPtr l)
	{
		luaMgr.PushResult(Vector2.kEpsilon);
		return true;
	}

	static bool get_x(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Vector2 obj = (Vector2)o;
		luaMgr.PushResult(obj.x);
		return true;
	}

	static bool get_y(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Vector2 obj = (Vector2)o;
		luaMgr.PushResult(obj.y);
		return true;
	}

	static bool get_normalized(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Vector2 obj = (Vector2)o;
		luaMgr.PushResult(obj.normalized);
		return true;
	}

	static bool get_magnitude(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Vector2 obj = (Vector2)o;
		luaMgr.PushResult(obj.magnitude);
		return true;
	}

	static bool get_sqrMagnitude(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Vector2 obj = (Vector2)o;
		luaMgr.PushResult(obj.sqrMagnitude);
		return true;
	}

	static bool get_zero(IntPtr l)
	{
		luaMgr.PushResult(Vector2.zero);
		return true;
	}

	static bool get_one(IntPtr l)
	{
		luaMgr.PushResult(Vector2.one);
		return true;
	}

	static bool get_up(IntPtr l)
	{
		luaMgr.PushResult(Vector2.up);
		return true;
	}

	static bool get_right(IntPtr l)
	{
		luaMgr.PushResult(Vector2.right);
		return true;
	}

	public static bool TryLuaIndex(IntPtr l)
	{
		LuaTypes luaType = LuaDLL.lua_type(l, 2);

		if (luaType == LuaTypes.LUA_TNUMBER)
		{
			object o = luaMgr.GetLuaObject(1);
			if (o == null) return false;
			int pos = (int)luaMgr.GetNumber(2);
			Vector2 obj = (Vector2)o;
			luaMgr.PushResult(obj[pos]);
			return true;
		}

		string str = luaMgr.GetString(2);

		if (luaMgr.Index(reference, str, fields))
		{
			return true;
		}

		return objectWrap.TryLuaIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Index(IntPtr l)
	{
		if (TryLuaIndex(l))
		{
			return 1;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'Vector2' does not contain a definition for '{0}'", str));
		return 0;
	}

	static bool set_x(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Vector2 obj = (Vector2)o;
		obj.x = (float)luaMgr.GetNumber(3);
		luaMgr.SetValueObject(1, obj);
		return true;
	}

	static bool set_y(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		Vector2 obj = (Vector2)o;
		obj.y = (float)luaMgr.GetNumber(3);
		luaMgr.SetValueObject(1, obj);
		return true;
	}

	public static bool TryLuaNewIndex(IntPtr l)
	{
		LuaTypes luaType = LuaDLL.lua_type(l, 2);

		if (luaType == LuaTypes.LUA_TNUMBER)
		{
			object o = luaMgr.GetLuaObject(1);
			if (o == null) return false;
			int pos = (int)luaMgr.GetNumber(2);
			float val = (float)luaMgr.GetNumber(3);
			Vector2 obj = (Vector2)o;
			obj[pos] = val;
			luaMgr.SetValueObject(1, obj);
			return true;
		}

		string str = luaMgr.GetString(2);

		if (luaMgr.NewIndex(reference, str, fields))
		{
			return true;
		}

		return objectWrap.TryLuaNewIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_NewIndex(IntPtr l)
	{
		if (TryLuaNewIndex(l))
		{
			return 0;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'Vector2' does not contain a definition for '{0}'", str));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr l)
	{
		Vector2 obj = (Vector2)luaMgr.GetNetObject(1);
		luaMgr.PushResult(obj.ToString());
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Set(IntPtr l)
	{
		luaMgr.CheckArgsCount(3);
		Vector2 obj = (Vector2)luaMgr.GetNetObject(1);
		float arg0 = (float)luaMgr.GetNumber(2);
		float arg1 = (float)luaMgr.GetNumber(3);
		obj.Set(arg0,arg1);
		luaMgr.SetValueObject(1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lerp(IntPtr l)
	{
		luaMgr.CheckArgsCount(3);
		Vector2 arg0 = (Vector2)luaMgr.GetNetObject(1);
		Vector2 arg1 = (Vector2)luaMgr.GetNetObject(2);
		float arg2 = (float)luaMgr.GetNumber(3);
		Vector2 o = Vector2.Lerp(arg0,arg1,arg2);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MoveTowards(IntPtr l)
	{
		luaMgr.CheckArgsCount(3);
		Vector2 arg0 = (Vector2)luaMgr.GetNetObject(1);
		Vector2 arg1 = (Vector2)luaMgr.GetNetObject(2);
		float arg2 = (float)luaMgr.GetNumber(3);
		Vector2 o = Vector2.MoveTowards(arg0,arg1,arg2);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Scale(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Vector2 obj = (Vector2)luaMgr.GetNetObject(1);
		Vector2 arg0 = (Vector2)luaMgr.GetNetObject(2);
		obj.Scale(arg0);
		luaMgr.SetValueObject(1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Normalize(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Vector2 obj = (Vector2)luaMgr.GetNetObject(1);
		obj.Normalize();
		luaMgr.SetValueObject(1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		if (count == 1)
		{
			Vector2 obj = (Vector2)luaMgr.GetNetObject(1);
			string o = obj.ToString();
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2)
		{
			Vector2 obj = (Vector2)luaMgr.GetNetObject(1);
			string arg0 = luaMgr.GetString(2);
			string o = obj.ToString(arg0);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Vector2.ToString' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Vector2 obj = (Vector2)luaMgr.GetNetObject(1);
		int o = obj.GetHashCode();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Vector2 obj = (Vector2)luaMgr.GetNetObject(1);
		object arg0 = (object)luaMgr.GetNetObject(2);
		bool o = obj.Equals(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Dot(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Vector2 arg0 = (Vector2)luaMgr.GetNetObject(1);
		Vector2 arg1 = (Vector2)luaMgr.GetNetObject(2);
		float o = Vector2.Dot(arg0,arg1);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Angle(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Vector2 arg0 = (Vector2)luaMgr.GetNetObject(1);
		Vector2 arg1 = (Vector2)luaMgr.GetNetObject(2);
		float o = Vector2.Angle(arg0,arg1);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Distance(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Vector2 arg0 = (Vector2)luaMgr.GetNetObject(1);
		Vector2 arg1 = (Vector2)luaMgr.GetNetObject(2);
		float o = Vector2.Distance(arg0,arg1);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClampMagnitude(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Vector2 arg0 = (Vector2)luaMgr.GetNetObject(1);
		float arg1 = (float)luaMgr.GetNumber(2);
		Vector2 o = Vector2.ClampMagnitude(arg0,arg1);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SqrMagnitude(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Vector2 obj = (Vector2)luaMgr.GetNetObject(1);
		float o = obj.SqrMagnitude();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Min(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Vector2 arg0 = (Vector2)luaMgr.GetNetObject(1);
		Vector2 arg1 = (Vector2)luaMgr.GetNetObject(2);
		Vector2 o = Vector2.Min(arg0,arg1);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Max(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Vector2 arg0 = (Vector2)luaMgr.GetNetObject(1);
		Vector2 arg1 = (Vector2)luaMgr.GetNetObject(2);
		Vector2 o = Vector2.Max(arg0,arg1);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Add(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Vector2 arg0 = (Vector2)luaMgr.GetNetObject(1);
		Vector2 arg1 = (Vector2)luaMgr.GetNetObject(2);
		Vector2 o = arg0 + arg1;
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Sub(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Vector2 arg0 = (Vector2)luaMgr.GetNetObject(1);
		Vector2 arg1 = (Vector2)luaMgr.GetNetObject(2);
		Vector2 o = arg0 - arg1;
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Neg(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Vector2 arg0 = (Vector2)luaMgr.GetNetObject(1);
		Vector2 o = -arg0;
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Mul(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		Type[] types0 = {typeof(float), typeof(Vector2)};
		Type[] types1 = {typeof(Vector2), typeof(float)};

		if (count == 2 && luaMgr.CheckTypes(types0, 1))
		{
			float arg0 = (float)luaMgr.GetNumber(1);
			Vector2 arg1 = (Vector2)luaMgr.GetNetObject(2);
			Vector2 o = arg0 * arg1;
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2 && luaMgr.CheckTypes(types1, 1))
		{
			Vector2 arg0 = (Vector2)luaMgr.GetNetObject(1);
			float arg1 = (float)luaMgr.GetNumber(2);
			Vector2 o = arg0 * arg1;
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Vector2.op_Multiply' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Div(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Vector2 arg0 = (Vector2)luaMgr.GetNetObject(1);
		float arg1 = (float)luaMgr.GetNumber(2);
		Vector2 o = arg0 / arg1;
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		Vector2 arg0 = (Vector2)luaMgr.GetNetObject(1);
		Vector2 arg1 = (Vector2)luaMgr.GetNetObject(2);
		bool o = arg0 == arg1;
		luaMgr.PushResult(o);
		return 1;
	}
}

