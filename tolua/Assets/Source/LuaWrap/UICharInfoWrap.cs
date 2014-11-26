using UnityEngine;
using System;
using LuaInterface;

public class UICharInfoWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateUICharInfo),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("cursorPos", get_cursorPos, set_cursorPos),
		new LuaField("charWidth", get_charWidth, set_charWidth),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUICharInfo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		UICharInfo obj = new UICharInfo();
		LuaScriptMgr.PushValue(L, obj);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(UICharInfo));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.UICharInfo", typeof(UICharInfo), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cursorPos(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cursorPos");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cursorPos on a nil value");
			}
		}

		UICharInfo obj = (UICharInfo)o;
		LuaScriptMgr.PushValue(L, obj.cursorPos);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_charWidth(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name charWidth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index charWidth on a nil value");
			}
		}

		UICharInfo obj = (UICharInfo)o;
		LuaScriptMgr.Push(L, obj.charWidth);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cursorPos(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cursorPos");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cursorPos on a nil value");
			}
		}

		UICharInfo obj = (UICharInfo)o;
		obj.cursorPos = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_charWidth(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name charWidth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index charWidth on a nil value");
			}
		}

		UICharInfo obj = (UICharInfo)o;
		obj.charWidth = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}
}

