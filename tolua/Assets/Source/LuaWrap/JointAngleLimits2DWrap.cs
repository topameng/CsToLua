using UnityEngine;
using System;
using LuaInterface;

public class JointAngleLimits2DWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateJointAngleLimits2D),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("min", get_min, set_min),
		new LuaField("max", get_max, set_max),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateJointAngleLimits2D(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		JointAngleLimits2D obj = new JointAngleLimits2D();
		LuaScriptMgr.PushValue(L, obj);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(JointAngleLimits2D));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.JointAngleLimits2D", typeof(JointAngleLimits2D), regs, fields, null);
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

		JointAngleLimits2D obj = (JointAngleLimits2D)o;
		LuaScriptMgr.Push(L, obj.min);
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

		JointAngleLimits2D obj = (JointAngleLimits2D)o;
		LuaScriptMgr.Push(L, obj.max);
		return 1;
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

		JointAngleLimits2D obj = (JointAngleLimits2D)o;
		obj.min = (float)LuaScriptMgr.GetNumber(L, 3);
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

		JointAngleLimits2D obj = (JointAngleLimits2D)o;
		obj.max = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}
}

