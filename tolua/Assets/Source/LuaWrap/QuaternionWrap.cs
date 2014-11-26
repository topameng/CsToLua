using UnityEngine;
using System;
using LuaInterface;

public class QuaternionWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("get_Item", get_Item),
		new LuaMethod("set_Item", set_Item),
		new LuaMethod("Set", Set),
		new LuaMethod("Dot", Dot),
		new LuaMethod("AngleAxis", AngleAxis),
		new LuaMethod("ToAngleAxis", ToAngleAxis),
		new LuaMethod("FromToRotation", FromToRotation),
		new LuaMethod("SetFromToRotation", SetFromToRotation),
		new LuaMethod("LookRotation", LookRotation),
		new LuaMethod("SetLookRotation", SetLookRotation),
		new LuaMethod("Slerp", Slerp),
		new LuaMethod("Lerp", Lerp),
		new LuaMethod("RotateTowards", RotateTowards),
		new LuaMethod("Inverse", Inverse),
		new LuaMethod("ToString", ToString),
		new LuaMethod("Angle", Angle),
		new LuaMethod("Euler", Euler),
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("Equals", Equals),
		new LuaMethod("New", _CreateQuaternion),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__tostring", Lua_ToString),
		new LuaMethod("__mul", Lua_Mul),
		new LuaMethod("__eq", Lua_Eq),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("kEpsilon", get_kEpsilon, null),
		new LuaField("x", get_x, set_x),
		new LuaField("y", get_y, set_y),
		new LuaField("z", get_z, set_z),
		new LuaField("w", get_w, set_w),
		new LuaField("identity", get_identity, null),
		new LuaField("eulerAngles", get_eulerAngles, set_eulerAngles),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateQuaternion(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4)
		{
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			Quaternion obj = new Quaternion(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else if (count == 0)
		{
			Quaternion obj = new Quaternion();
			LuaScriptMgr.PushValue(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Quaternion.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Quaternion));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Quaternion", typeof(Quaternion), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_kEpsilon(IntPtr L)
	{
		LuaScriptMgr.Push(L, Quaternion.kEpsilon);
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

		Quaternion obj = (Quaternion)o;
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

		Quaternion obj = (Quaternion)o;
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

		Quaternion obj = (Quaternion)o;
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

		Quaternion obj = (Quaternion)o;
		LuaScriptMgr.Push(L, obj.w);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_identity(IntPtr L)
	{
		LuaScriptMgr.PushValue(L, Quaternion.identity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_eulerAngles(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name eulerAngles");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index eulerAngles on a nil value");
			}
		}

		Quaternion obj = (Quaternion)o;
		LuaScriptMgr.PushValue(L, obj.eulerAngles);
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

		Quaternion obj = (Quaternion)o;
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

		Quaternion obj = (Quaternion)o;
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

		Quaternion obj = (Quaternion)o;
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

		Quaternion obj = (Quaternion)o;
		obj.w = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_eulerAngles(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name eulerAngles");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index eulerAngles on a nil value");
			}
		}

		Quaternion obj = (Quaternion)o;
		obj.eulerAngles = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
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
			LuaScriptMgr.Push(L, "Table: UnityEngine.Quaternion");
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Item(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Quaternion obj = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		float o = obj[arg0];
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Item(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Quaternion obj = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
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
		Quaternion obj = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 5);
		obj.Set(arg0,arg1,arg2,arg3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Dot(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Quaternion arg0 = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
		Quaternion arg1 = LuaScriptMgr.GetNetObject<Quaternion>(L, 2);
		float o = Quaternion.Dot(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AngleAxis(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
		Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Quaternion o = Quaternion.AngleAxis(arg0,arg1);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToAngleAxis(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Quaternion obj = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
		float arg0 = LuaScriptMgr.GetNetObject<float>(L, 2);
		Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		obj.ToAngleAxis(out arg0,out arg1);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		LuaScriptMgr.Push(L, arg0);
		LuaScriptMgr.PushValue(L, arg1);
		return 2;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FromToRotation(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
		Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Quaternion o = Quaternion.FromToRotation(arg0,arg1);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetFromToRotation(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Quaternion obj = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
		Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		obj.SetFromToRotation(arg0,arg1);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LookRotation(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Quaternion o = Quaternion.LookRotation(arg0);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			Quaternion o = Quaternion.LookRotation(arg0,arg1);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Quaternion.LookRotation");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetLookRotation(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Quaternion obj = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			obj.SetLookRotation(arg0);
			LuaScriptMgr.SetValueObject(L, 1, obj);
			return 0;
		}
		else if (count == 3)
		{
			Quaternion obj = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
			obj.SetLookRotation(arg0,arg1);
			LuaScriptMgr.SetValueObject(L, 1, obj);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Quaternion.SetLookRotation");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Slerp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Quaternion arg0 = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
		Quaternion arg1 = LuaScriptMgr.GetNetObject<Quaternion>(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		Quaternion o = Quaternion.Slerp(arg0,arg1,arg2);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lerp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Quaternion arg0 = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
		Quaternion arg1 = LuaScriptMgr.GetNetObject<Quaternion>(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		Quaternion o = Quaternion.Lerp(arg0,arg1,arg2);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RotateTowards(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Quaternion arg0 = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
		Quaternion arg1 = LuaScriptMgr.GetNetObject<Quaternion>(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		Quaternion o = Quaternion.RotateTowards(arg0,arg1,arg2);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Inverse(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Quaternion arg0 = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
		Quaternion o = Quaternion.Inverse(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Quaternion obj = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
			string o = obj.ToString();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Quaternion obj = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			string o = obj.ToString(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Quaternion.ToString");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Angle(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Quaternion arg0 = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
		Quaternion arg1 = LuaScriptMgr.GetNetObject<Quaternion>(L, 2);
		float o = Quaternion.Angle(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Euler(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Vector3 arg0 = LuaScriptMgr.GetNetObject<Vector3>(L, 1);
			Quaternion o = Quaternion.Euler(arg0);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 3)
		{
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			Quaternion o = Quaternion.Euler(arg0,arg1,arg2);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Quaternion.Euler");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Quaternion obj = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Quaternion obj = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Mul(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(Quaternion), typeof(Vector3)};
		Type[] types1 = {typeof(Quaternion), typeof(Quaternion)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			Quaternion arg0 = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetNetObject<Vector3>(L, 2);
			Vector3 o = arg0 * arg1;
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Quaternion arg0 = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
			Quaternion arg1 = LuaScriptMgr.GetNetObject<Quaternion>(L, 2);
			Quaternion o = arg0 * arg1;
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Quaternion.op_Multiply");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Quaternion arg0 = LuaScriptMgr.GetNetObject<Quaternion>(L, 1);
		Quaternion arg1 = LuaScriptMgr.GetNetObject<Quaternion>(L, 2);
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

