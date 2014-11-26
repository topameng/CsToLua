using UnityEngine;
using System;
using LuaInterface;

public class TouchWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateTouch),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("fingerId", get_fingerId, null),
		new LuaField("position", get_position, null),
		new LuaField("rawPosition", get_rawPosition, null),
		new LuaField("deltaPosition", get_deltaPosition, null),
		new LuaField("deltaTime", get_deltaTime, null),
		new LuaField("tapCount", get_tapCount, null),
		new LuaField("phase", get_phase, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateTouch(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Touch obj = new Touch();
		LuaScriptMgr.PushValue(L, obj);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Touch));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Touch", typeof(Touch), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fingerId(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fingerId");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fingerId on a nil value");
			}
		}

		Touch obj = (Touch)o;
		LuaScriptMgr.Push(L, obj.fingerId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_position(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name position");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index position on a nil value");
			}
		}

		Touch obj = (Touch)o;
		LuaScriptMgr.PushValue(L, obj.position);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rawPosition(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rawPosition");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rawPosition on a nil value");
			}
		}

		Touch obj = (Touch)o;
		LuaScriptMgr.PushValue(L, obj.rawPosition);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_deltaPosition(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name deltaPosition");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index deltaPosition on a nil value");
			}
		}

		Touch obj = (Touch)o;
		LuaScriptMgr.PushValue(L, obj.deltaPosition);
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

		Touch obj = (Touch)o;
		LuaScriptMgr.Push(L, obj.deltaTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tapCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tapCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tapCount on a nil value");
			}
		}

		Touch obj = (Touch)o;
		LuaScriptMgr.Push(L, obj.tapCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_phase(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name phase");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index phase on a nil value");
			}
		}

		Touch obj = (Touch)o;
		LuaScriptMgr.PushEnum(L, obj.phase);
		return 1;
	}
}

