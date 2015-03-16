using System;
using UnityEngine;
using LuaInterface;

public class AsyncOperationWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateAsyncOperation),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("isDone", get_isDone, null),
		new LuaField("progress", get_progress, null),
		new LuaField("priority", get_priority, set_priority),
		new LuaField("allowSceneActivation", get_allowSceneActivation, set_allowSceneActivation),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAsyncOperation(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AsyncOperation obj = new AsyncOperation();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AsyncOperation.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AsyncOperation));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AsyncOperation", typeof(AsyncOperation), regs, fields, typeof(UnityEngine.YieldInstruction));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isDone(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		AsyncOperation obj = (AsyncOperation)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isDone");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isDone on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isDone);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_progress(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		AsyncOperation obj = (AsyncOperation)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name progress");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index progress on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.progress);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_priority(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		AsyncOperation obj = (AsyncOperation)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name priority");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index priority on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.priority);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_allowSceneActivation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		AsyncOperation obj = (AsyncOperation)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name allowSceneActivation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index allowSceneActivation on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.allowSceneActivation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_priority(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		AsyncOperation obj = (AsyncOperation)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name priority");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index priority on a nil value");
			}
		}

		obj.priority = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_allowSceneActivation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		AsyncOperation obj = (AsyncOperation)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name allowSceneActivation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index allowSceneActivation on a nil value");
			}
		}

		obj.allowSceneActivation = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}
}

