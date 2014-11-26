using UnityEngine;
using System;
using LuaInterface;

public class BoundsWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("Equals", Equals),
		new LuaMethod("SetMinMax", SetMinMax),
		new LuaMethod("Encapsulate", Encapsulate),
		new LuaMethod("Expand", Expand),
		new LuaMethod("Intersects", Intersects),
		new LuaMethod("Contains", Contains),
		new LuaMethod("SqrDistance", SqrDistance),
		new LuaMethod("IntersectRay", IntersectRay),
		new LuaMethod("ToString", ToString),
		new LuaMethod("New", _CreateBounds),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__tostring", Lua_ToString),
		new LuaMethod("__eq", Lua_Eq),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("center", get_center, set_center),
		new LuaField("size", get_size, set_size),
		new LuaField("extents", get_extents, set_extents),
		new LuaField("min", get_min, set_min),
		new LuaField("max", get_max, set_max),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateBounds(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			Bounds obj = new Bounds(arg0,arg1);
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else if (count == 0)
		{
			Bounds obj = new Bounds();
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Bounds.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Bounds));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Bounds", typeof(Bounds), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_center(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name center");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index center on a nil value");
			}
		}

		Bounds obj = (Bounds)o;
		LuaScriptMgr.PushValue(L, obj.center);
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

		Bounds obj = (Bounds)o;
		LuaScriptMgr.PushValue(L, obj.size);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_extents(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name extents");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index extents on a nil value");
			}
		}

		Bounds obj = (Bounds)o;
		LuaScriptMgr.PushValue(L, obj.extents);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_min(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name min");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index min on a nil value");
			}
		}

		Bounds obj = (Bounds)o;
		LuaScriptMgr.PushValue(L, obj.min);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_max(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name max");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index max on a nil value");
			}
		}

		Bounds obj = (Bounds)o;
		LuaScriptMgr.PushValue(L, obj.max);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_center(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name center");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index center on a nil value");
			}
		}

		Bounds obj = (Bounds)o;
		obj.center = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
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

		Bounds obj = (Bounds)o;
		obj.size = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_extents(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name extents");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index extents on a nil value");
			}
		}

		Bounds obj = (Bounds)o;
		obj.extents = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_min(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name min");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index min on a nil value");
			}
		}

		Bounds obj = (Bounds)o;
		obj.min = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_max(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name max");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index max on a nil value");
			}
		}

		Bounds obj = (Bounds)o;
		obj.max = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
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
			LuaScriptMgr.Push(L, "Table: UnityEngine.Bounds");
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Bounds obj = LuaScriptMgr.GetNetObject<Bounds>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Bounds obj = LuaScriptMgr.GetNetObject<Bounds>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetMinMax(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Bounds obj = LuaScriptMgr.GetNetObject<Bounds>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		obj.SetMinMax(arg0,arg1);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Encapsulate(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(Bounds), typeof(Bounds)};
		Type[] types1 = {typeof(Bounds), typeof(Vector3)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			Bounds obj = LuaScriptMgr.GetNetObject<Bounds>(L, 1);
			Bounds arg0 = LuaScriptMgr.GetNetObject<Bounds>(L, 2);
			obj.Encapsulate(arg0);
			LuaScriptMgr.SetValueObject(L, 1, obj);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Bounds obj = LuaScriptMgr.GetNetObject<Bounds>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			obj.Encapsulate(arg0);
			LuaScriptMgr.SetValueObject(L, 1, obj);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Bounds.Encapsulate");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Expand(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(Bounds), typeof(Vector3)};
		Type[] types1 = {typeof(Bounds), typeof(float)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			Bounds obj = LuaScriptMgr.GetNetObject<Bounds>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			obj.Expand(arg0);
			LuaScriptMgr.SetValueObject(L, 1, obj);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Bounds obj = LuaScriptMgr.GetNetObject<Bounds>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			obj.Expand(arg0);
			LuaScriptMgr.SetValueObject(L, 1, obj);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Bounds.Expand");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Intersects(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Bounds obj = LuaScriptMgr.GetNetObject<Bounds>(L, 1);
		Bounds arg0 = LuaScriptMgr.GetNetObject<Bounds>(L, 2);
		bool o = obj.Intersects(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Contains(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Bounds obj = LuaScriptMgr.GetNetObject<Bounds>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		bool o = obj.Contains(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SqrDistance(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Bounds obj = LuaScriptMgr.GetNetObject<Bounds>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		float o = obj.SqrDistance(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntersectRay(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Bounds obj = LuaScriptMgr.GetNetObject<Bounds>(L, 1);
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 2);
			bool o = obj.IntersectRay(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Bounds obj = LuaScriptMgr.GetNetObject<Bounds>(L, 1);
			Ray arg0 = LuaScriptMgr.GetNetObject<Ray>(L, 2);
			float arg1 = LuaScriptMgr.GetNetObject<float>(L, 3);
			bool o = obj.IntersectRay(arg0,out arg1);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.Push(L, arg1);
			return 2;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Bounds.IntersectRay");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Bounds obj = LuaScriptMgr.GetNetObject<Bounds>(L, 1);
			string o = obj.ToString();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Bounds obj = LuaScriptMgr.GetNetObject<Bounds>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			string o = obj.ToString(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Bounds.ToString");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Bounds arg0 = LuaScriptMgr.GetNetObject<Bounds>(L, 1);
		Bounds arg1 = LuaScriptMgr.GetNetObject<Bounds>(L, 2);
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

