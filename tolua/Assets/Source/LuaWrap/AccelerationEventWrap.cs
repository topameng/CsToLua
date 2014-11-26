using UnityEngine;
using System;
using LuaInterface;

public class AccelerationEventWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateAccelerationEvent),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("acceleration", get_acceleration, null),
		new LuaField("deltaTime", get_deltaTime, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAccelerationEvent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		AccelerationEvent obj = new AccelerationEvent();
		LuaScriptMgr.PushValue(L, obj);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AccelerationEvent));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AccelerationEvent", typeof(AccelerationEvent), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_acceleration(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name acceleration");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index acceleration on a nil value");
			}
		}

		AccelerationEvent obj = (AccelerationEvent)o;
		LuaScriptMgr.PushValue(L, obj.acceleration);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_deltaTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name deltaTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index deltaTime on a nil value");
			}
		}

		AccelerationEvent obj = (AccelerationEvent)o;
		LuaScriptMgr.Push(L, obj.deltaTime);
		return 1;
	}
}

