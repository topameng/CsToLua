using UnityEngine;
using System;
using LuaInterface;

public class PhysicMaterialWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreatePhysicMaterial),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("dynamicFriction", get_dynamicFriction, set_dynamicFriction),
		new LuaField("staticFriction", get_staticFriction, set_staticFriction),
		new LuaField("bounciness", get_bounciness, set_bounciness),
		new LuaField("frictionDirection2", get_frictionDirection2, set_frictionDirection2),
		new LuaField("dynamicFriction2", get_dynamicFriction2, set_dynamicFriction2),
		new LuaField("staticFriction2", get_staticFriction2, set_staticFriction2),
		new LuaField("frictionCombine", get_frictionCombine, set_frictionCombine),
		new LuaField("bounceCombine", get_bounceCombine, set_bounceCombine),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreatePhysicMaterial(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			PhysicMaterial obj = new PhysicMaterial();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else if (count == 1)
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			PhysicMaterial obj = new PhysicMaterial(arg0);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: PhysicMaterial.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(PhysicMaterial));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.PhysicMaterial", typeof(PhysicMaterial), regs, fields, "UnityEngine.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dynamicFriction(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dynamicFriction");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dynamicFriction on a nil value");
			}
		}

		PhysicMaterial obj = (PhysicMaterial)o;
		LuaScriptMgr.Push(L, obj.dynamicFriction);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_staticFriction(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name staticFriction");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index staticFriction on a nil value");
			}
		}

		PhysicMaterial obj = (PhysicMaterial)o;
		LuaScriptMgr.Push(L, obj.staticFriction);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bounciness(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bounciness");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bounciness on a nil value");
			}
		}

		PhysicMaterial obj = (PhysicMaterial)o;
		LuaScriptMgr.Push(L, obj.bounciness);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_frictionDirection2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name frictionDirection2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index frictionDirection2 on a nil value");
			}
		}

		PhysicMaterial obj = (PhysicMaterial)o;
		LuaScriptMgr.PushValue(L, obj.frictionDirection2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dynamicFriction2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dynamicFriction2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dynamicFriction2 on a nil value");
			}
		}

		PhysicMaterial obj = (PhysicMaterial)o;
		LuaScriptMgr.Push(L, obj.dynamicFriction2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_staticFriction2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name staticFriction2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index staticFriction2 on a nil value");
			}
		}

		PhysicMaterial obj = (PhysicMaterial)o;
		LuaScriptMgr.Push(L, obj.staticFriction2);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_frictionCombine(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name frictionCombine");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index frictionCombine on a nil value");
			}
		}

		PhysicMaterial obj = (PhysicMaterial)o;
		LuaScriptMgr.PushEnum(L, obj.frictionCombine);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bounceCombine(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bounceCombine");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bounceCombine on a nil value");
			}
		}

		PhysicMaterial obj = (PhysicMaterial)o;
		LuaScriptMgr.PushEnum(L, obj.bounceCombine);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_dynamicFriction(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dynamicFriction");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dynamicFriction on a nil value");
			}
		}

		PhysicMaterial obj = (PhysicMaterial)o;
		obj.dynamicFriction = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_staticFriction(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name staticFriction");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index staticFriction on a nil value");
			}
		}

		PhysicMaterial obj = (PhysicMaterial)o;
		obj.staticFriction = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bounciness(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bounciness");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bounciness on a nil value");
			}
		}

		PhysicMaterial obj = (PhysicMaterial)o;
		obj.bounciness = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_frictionDirection2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name frictionDirection2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index frictionDirection2 on a nil value");
			}
		}

		PhysicMaterial obj = (PhysicMaterial)o;
		obj.frictionDirection2 = LuaScriptMgr.GetNetObject<Vector3>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_dynamicFriction2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dynamicFriction2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dynamicFriction2 on a nil value");
			}
		}

		PhysicMaterial obj = (PhysicMaterial)o;
		obj.dynamicFriction2 = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_staticFriction2(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name staticFriction2");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index staticFriction2 on a nil value");
			}
		}

		PhysicMaterial obj = (PhysicMaterial)o;
		obj.staticFriction2 = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_frictionCombine(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name frictionCombine");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index frictionCombine on a nil value");
			}
		}

		PhysicMaterial obj = (PhysicMaterial)o;
		obj.frictionCombine = LuaScriptMgr.GetNetObject<PhysicMaterialCombine>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bounceCombine(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bounceCombine");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bounceCombine on a nil value");
			}
		}

		PhysicMaterial obj = (PhysicMaterial)o;
		obj.bounceCombine = LuaScriptMgr.GetNetObject<PhysicMaterialCombine>(L, 3);
		return 0;
	}
}

