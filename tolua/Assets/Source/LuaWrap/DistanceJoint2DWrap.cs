using UnityEngine;
using System;
using LuaInterface;

public class DistanceJoint2DWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetReactionForce", GetReactionForce),
		new LuaMethod("GetReactionTorque", GetReactionTorque),
		new LuaMethod("New", _CreateDistanceJoint2D),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("distance", get_distance, set_distance),
		new LuaField("maxDistanceOnly", get_maxDistanceOnly, set_maxDistanceOnly),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateDistanceJoint2D(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			DistanceJoint2D obj = new DistanceJoint2D();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: DistanceJoint2D.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(DistanceJoint2D));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.DistanceJoint2D", typeof(DistanceJoint2D), regs, fields, "UnityEngine.AnchoredJoint2D");
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

		DistanceJoint2D obj = (DistanceJoint2D)o;
		LuaScriptMgr.Push(L, obj.distance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxDistanceOnly(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxDistanceOnly");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxDistanceOnly on a nil value");
			}
		}

		DistanceJoint2D obj = (DistanceJoint2D)o;
		LuaScriptMgr.Push(L, obj.maxDistanceOnly);
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

		DistanceJoint2D obj = (DistanceJoint2D)o;
		obj.distance = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxDistanceOnly(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name maxDistanceOnly");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index maxDistanceOnly on a nil value");
			}
		}

		DistanceJoint2D obj = (DistanceJoint2D)o;
		obj.maxDistanceOnly = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetReactionForce(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		DistanceJoint2D obj = LuaScriptMgr.GetNetObject<DistanceJoint2D>(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		Vector2 o = obj.GetReactionForce(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetReactionTorque(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		DistanceJoint2D obj = LuaScriptMgr.GetNetObject<DistanceJoint2D>(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		float o = obj.GetReactionTorque(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

