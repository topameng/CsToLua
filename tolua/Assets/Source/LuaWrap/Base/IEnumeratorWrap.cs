using System;
using System.Collections;
using LuaInterface;

public class IEnumeratorWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("MoveNext", MoveNext),
		new LuaMethod("Reset", Reset),
		new LuaMethod("New", _CreateIEnumerator),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("Current", get_Current, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateIEnumerator(IntPtr L)
	{
		LuaDLL.luaL_error(L, "IEnumerator class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(IEnumerator);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);

		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "System.Collections.IEnumerator", typeof(IEnumerator), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Current(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		IEnumerator obj = (IEnumerator)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Current");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Current on a nil value");
			}
		}

		LuaScriptMgr.PushVarObject(L, obj.Current);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MoveNext(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		IEnumerator obj = (IEnumerator)LuaScriptMgr.GetNetObject(L, 1, typeof(IEnumerator));
		bool o = obj.MoveNext();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Reset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		IEnumerator obj = (IEnumerator)LuaScriptMgr.GetNetObject(L, 1, typeof(IEnumerator));
		obj.Reset();
		return 0;
	}
}

