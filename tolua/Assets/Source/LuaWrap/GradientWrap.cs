using UnityEngine;
using System;
using LuaInterface;

public class GradientWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Evaluate", Evaluate),
		new LuaMethod("SetKeys", SetKeys),
		new LuaMethod("New", _CreateGradient),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("colorKeys", get_colorKeys, set_colorKeys),
		new LuaField("alphaKeys", get_alphaKeys, set_alphaKeys),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateGradient(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Gradient obj = new Gradient();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Gradient.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Gradient));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Gradient", typeof(Gradient), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_colorKeys(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name colorKeys");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index colorKeys on a nil value");
			}
		}

		Gradient obj = (Gradient)o;
		LuaScriptMgr.PushArray(L, obj.colorKeys);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_alphaKeys(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name alphaKeys");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index alphaKeys on a nil value");
			}
		}

		Gradient obj = (Gradient)o;
		LuaScriptMgr.PushArray(L, obj.alphaKeys);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_colorKeys(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name colorKeys");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index colorKeys on a nil value");
			}
		}

		Gradient obj = (Gradient)o;
		obj.colorKeys = LuaScriptMgr.GetNetObject<GradientColorKey[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_alphaKeys(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name alphaKeys");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index alphaKeys on a nil value");
			}
		}

		Gradient obj = (Gradient)o;
		obj.alphaKeys = LuaScriptMgr.GetNetObject<GradientAlphaKey[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Evaluate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Gradient obj = LuaScriptMgr.GetNetObject<Gradient>(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		Color o = obj.Evaluate(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetKeys(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Gradient obj = LuaScriptMgr.GetNetObject<Gradient>(L, 1);
		GradientColorKey[] objs0 = LuaScriptMgr.GetArrayObject<GradientColorKey>(L, 2);
		GradientAlphaKey[] objs1 = LuaScriptMgr.GetArrayObject<GradientAlphaKey>(L, 3);
		obj.SetKeys(objs0,objs1);
		return 0;
	}
}

