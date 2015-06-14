using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class TestEventListenerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateTestEventListener),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("OnClick", get_OnClick, set_OnClick),
		};

		LuaScriptMgr.RegisterLib(L, "TestEventListener", typeof(TestEventListener), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateTestEventListener(IntPtr L)
	{
		LuaDLL.luaL_error(L, "TestEventListener class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(TestEventListener);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OnClick(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TestEventListener obj = (TestEventListener)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name OnClick");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index OnClick on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.OnClick);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OnClick(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		TestEventListener obj = (TestEventListener)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name OnClick");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index OnClick on a nil value");
			}
		}

		LuaTypes type = LuaDLL.lua_type(L, 3);

		if (type != LuaTypes.LUA_TFUNCTION)
		{
			obj.OnClick = (Action<GameObject>)LuaScriptMgr.GetNetObject(L, 3, typeof(Action<GameObject>));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 3);
			obj.OnClick = (arg0) =>
			{
				int top = func.BeginPCall();
				LuaScriptMgr.Push(L, arg0);
				func.PCall(top, 1);
				func.EndPCall(top);
			};
		}
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetLuaObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetLuaObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

