using UnityEngine;
using System;
using LuaInterface;

public class SpringJoint2DWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetReactionForce", GetReactionForce),
		new LuaMethod("GetReactionTorque", GetReactionTorque),
		new LuaMethod("New", _CreateSpringJoint2D),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("distance", get_distance, set_distance),
		new LuaField("dampingRatio", get_dampingRatio, set_dampingRatio),
		new LuaField("frequency", get_frequency, set_frequency),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSpringJoint2D(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			SpringJoint2D obj = new SpringJoint2D();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SpringJoint2D.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(SpringJoint2D));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.SpringJoint2D", typeof(SpringJoint2D), regs, fields, "UnityEngine.AnchoredJoint2D");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_distance(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name distance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index distance on a nil value");
			}
		}

		SpringJoint2D obj = (SpringJoint2D)o;
		LuaScriptMgr.Push(L, obj.distance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dampingRatio(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dampingRatio");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dampingRatio on a nil value");
			}
		}

		SpringJoint2D obj = (SpringJoint2D)o;
		LuaScriptMgr.Push(L, obj.dampingRatio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_frequency(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name frequency");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index frequency on a nil value");
			}
		}

		SpringJoint2D obj = (SpringJoint2D)o;
		LuaScriptMgr.Push(L, obj.frequency);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_distance(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name distance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index distance on a nil value");
			}
		}

		SpringJoint2D obj = (SpringJoint2D)o;
		obj.distance = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_dampingRatio(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dampingRatio");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dampingRatio on a nil value");
			}
		}

		SpringJoint2D obj = (SpringJoint2D)o;
		obj.dampingRatio = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_frequency(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name frequency");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index frequency on a nil value");
			}
		}

		SpringJoint2D obj = (SpringJoint2D)o;
		obj.frequency = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetReactionForce(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SpringJoint2D obj = LuaScriptMgr.GetNetObject<SpringJoint2D>(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		Vector2 o = obj.GetReactionForce(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetReactionTorque(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SpringJoint2D obj = LuaScriptMgr.GetNetObject<SpringJoint2D>(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		float o = obj.GetReactionTorque(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

