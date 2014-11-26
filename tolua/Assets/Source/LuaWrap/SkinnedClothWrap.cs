using UnityEngine;
using System;
using LuaInterface;

public class SkinnedClothWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("SetEnabledFading", SetEnabledFading),
		new LuaMethod("New", _CreateSkinnedCloth),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("coefficients", get_coefficients, set_coefficients),
		new LuaField("worldVelocityScale", get_worldVelocityScale, set_worldVelocityScale),
		new LuaField("worldAccelerationScale", get_worldAccelerationScale, set_worldAccelerationScale),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSkinnedCloth(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			SkinnedCloth obj = new SkinnedCloth();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SkinnedCloth.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(SkinnedCloth));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.SkinnedCloth", typeof(SkinnedCloth), regs, fields, "UnityEngine.Cloth");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_coefficients(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name coefficients");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index coefficients on a nil value");
			}
		}

		SkinnedCloth obj = (SkinnedCloth)o;
		LuaScriptMgr.PushArray(L, obj.coefficients);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_worldVelocityScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name worldVelocityScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index worldVelocityScale on a nil value");
			}
		}

		SkinnedCloth obj = (SkinnedCloth)o;
		LuaScriptMgr.Push(L, obj.worldVelocityScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_worldAccelerationScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name worldAccelerationScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index worldAccelerationScale on a nil value");
			}
		}

		SkinnedCloth obj = (SkinnedCloth)o;
		LuaScriptMgr.Push(L, obj.worldAccelerationScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_coefficients(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name coefficients");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index coefficients on a nil value");
			}
		}

		SkinnedCloth obj = (SkinnedCloth)o;
		obj.coefficients = LuaScriptMgr.GetNetObject<ClothSkinningCoefficient[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_worldVelocityScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name worldVelocityScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index worldVelocityScale on a nil value");
			}
		}

		SkinnedCloth obj = (SkinnedCloth)o;
		obj.worldVelocityScale = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_worldAccelerationScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name worldAccelerationScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index worldAccelerationScale on a nil value");
			}
		}

		SkinnedCloth obj = (SkinnedCloth)o;
		obj.worldAccelerationScale = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetEnabledFading(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			SkinnedCloth obj = LuaScriptMgr.GetNetObject<SkinnedCloth>(L, 1);
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			obj.SetEnabledFading(arg0);
			return 0;
		}
		else if (count == 3)
		{
			SkinnedCloth obj = LuaScriptMgr.GetNetObject<SkinnedCloth>(L, 1);
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			obj.SetEnabledFading(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SkinnedCloth.SetEnabledFading");
		}

		return 0;
	}
}

