using UnityEngine;
using System;
using LuaInterface;

public class Joint2DWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateJoint2D),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("connectedBody", get_connectedBody, set_connectedBody),
		new LuaField("collideConnected", get_collideConnected, set_collideConnected),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateJoint2D(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Joint2D obj = new Joint2D();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Joint2D.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Joint2D));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Joint2D", typeof(Joint2D), regs, fields, "UnityEngine.Behaviour");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_connectedBody(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name connectedBody");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index connectedBody on a nil value");
			}
		}

		Joint2D obj = (Joint2D)o;
		LuaScriptMgr.Push(L, obj.connectedBody);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_collideConnected(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name collideConnected");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index collideConnected on a nil value");
			}
		}

		Joint2D obj = (Joint2D)o;
		LuaScriptMgr.Push(L, obj.collideConnected);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_connectedBody(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name connectedBody");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index connectedBody on a nil value");
			}
		}

		Joint2D obj = (Joint2D)o;
		obj.connectedBody = LuaScriptMgr.GetNetObject<Rigidbody2D>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_collideConnected(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name collideConnected");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index collideConnected on a nil value");
			}
		}

		Joint2D obj = (Joint2D)o;
		obj.collideConnected = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}
}

