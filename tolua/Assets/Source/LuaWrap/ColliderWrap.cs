using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class ColliderWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("ClosestPointOnBounds", ClosestPointOnBounds),
		new LuaMethod("Raycast", Raycast),
		new LuaMethod("New", _CreateCollider),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__eq", Lua_Eq),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("enabled", get_enabled, set_enabled),
		new LuaField("attachedRigidbody", get_attachedRigidbody, null),
		new LuaField("isTrigger", get_isTrigger, set_isTrigger),
		new LuaField("material", get_material, set_material),
		new LuaField("sharedMaterial", get_sharedMaterial, set_sharedMaterial),
		new LuaField("bounds", get_bounds, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCollider(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Collider obj = new Collider();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Collider.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Collider));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Collider", typeof(Collider), regs, fields, typeof(UnityEngine.Component));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Collider obj = (Collider)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enabled on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.enabled);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_attachedRigidbody(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Collider obj = (Collider)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name attachedRigidbody");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index attachedRigidbody on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.attachedRigidbody);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isTrigger(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Collider obj = (Collider)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isTrigger");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isTrigger on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isTrigger);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_material(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Collider obj = (Collider)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name material");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index material on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.material);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sharedMaterial(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Collider obj = (Collider)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sharedMaterial");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sharedMaterial on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.sharedMaterial);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bounds(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Collider obj = (Collider)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bounds");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bounds on a nil value");
			}
		}

		LuaScriptMgr.PushValue(L, obj.bounds);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enabled(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Collider obj = (Collider)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enabled");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enabled on a nil value");
			}
		}

		obj.enabled = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isTrigger(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Collider obj = (Collider)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isTrigger");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isTrigger on a nil value");
			}
		}

		obj.isTrigger = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_material(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Collider obj = (Collider)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name material");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index material on a nil value");
			}
		}

		obj.material = LuaScriptMgr.GetUnityObject<PhysicMaterial>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sharedMaterial(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Collider obj = (Collider)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sharedMaterial");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sharedMaterial on a nil value");
			}
		}

		obj.sharedMaterial = LuaScriptMgr.GetUnityObject<PhysicMaterial>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClosestPointOnBounds(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Collider obj = LuaScriptMgr.GetUnityObject<Collider>(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetVector3(L, 2);
		Vector3 o = obj.ClosestPointOnBounds(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Raycast(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Collider obj = LuaScriptMgr.GetUnityObject<Collider>(L, 1);
		Ray arg0 = LuaScriptMgr.GetRay(L, 2);
		RaycastHit arg1;
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		bool o = obj.Raycast(arg0,out arg1,arg2);
		LuaScriptMgr.Push(L, o);
		LuaScriptMgr.Push(L, arg1);
		return 2;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetVarObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetVarObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

