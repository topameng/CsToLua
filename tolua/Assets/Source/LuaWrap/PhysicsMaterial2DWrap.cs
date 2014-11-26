using UnityEngine;
using System;
using LuaInterface;

public class PhysicsMaterial2DWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreatePhysicsMaterial2D),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("bounciness", get_bounciness, set_bounciness),
		new LuaField("friction", get_friction, set_friction),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreatePhysicsMaterial2D(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			PhysicsMaterial2D obj = new PhysicsMaterial2D();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else if (count == 1)
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			PhysicsMaterial2D obj = new PhysicsMaterial2D(arg0);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: PhysicsMaterial2D.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(PhysicsMaterial2D));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.PhysicsMaterial2D", typeof(PhysicsMaterial2D), regs, fields, "UnityEngine.Object");
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

		PhysicsMaterial2D obj = (PhysicsMaterial2D)o;
		LuaScriptMgr.Push(L, obj.bounciness);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_friction(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name friction");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index friction on a nil value");
			}
		}

		PhysicsMaterial2D obj = (PhysicsMaterial2D)o;
		LuaScriptMgr.Push(L, obj.friction);
		return 1;
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

		PhysicsMaterial2D obj = (PhysicsMaterial2D)o;
		obj.bounciness = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_friction(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name friction");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index friction on a nil value");
			}
		}

		PhysicsMaterial2D obj = (PhysicsMaterial2D)o;
		obj.friction = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}

