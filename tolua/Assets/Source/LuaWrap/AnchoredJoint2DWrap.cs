using UnityEngine;
using System;
using LuaInterface;

public class AnchoredJoint2DWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateAnchoredJoint2D),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("anchor", get_anchor, set_anchor),
		new LuaField("connectedAnchor", get_connectedAnchor, set_connectedAnchor),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAnchoredJoint2D(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AnchoredJoint2D obj = new AnchoredJoint2D();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnchoredJoint2D.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AnchoredJoint2D));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AnchoredJoint2D", typeof(AnchoredJoint2D), regs, fields, "UnityEngine.Joint2D");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_anchor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name anchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index anchor on a nil value");
			}
		}

		AnchoredJoint2D obj = (AnchoredJoint2D)o;
		LuaScriptMgr.PushValue(L, obj.anchor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_connectedAnchor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name connectedAnchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index connectedAnchor on a nil value");
			}
		}

		AnchoredJoint2D obj = (AnchoredJoint2D)o;
		LuaScriptMgr.PushValue(L, obj.connectedAnchor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_anchor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name anchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index anchor on a nil value");
			}
		}

		AnchoredJoint2D obj = (AnchoredJoint2D)o;
		obj.anchor = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_connectedAnchor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name connectedAnchor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index connectedAnchor on a nil value");
			}
		}

		AnchoredJoint2D obj = (AnchoredJoint2D)o;
		obj.connectedAnchor = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
		return 0;
	}
}

