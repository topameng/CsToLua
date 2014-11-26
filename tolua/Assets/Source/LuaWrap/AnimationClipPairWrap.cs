using UnityEngine;
using System;
using LuaInterface;

public class AnimationClipPairWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateAnimationClipPair),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("originalClip", get_originalClip, set_originalClip),
		new LuaField("overrideClip", get_overrideClip, set_overrideClip),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAnimationClipPair(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AnimationClipPair obj = new AnimationClipPair();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnimationClipPair.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AnimationClipPair));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AnimationClipPair", typeof(AnimationClipPair), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_originalClip(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name originalClip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index originalClip on a nil value");
			}
		}

		AnimationClipPair obj = (AnimationClipPair)o;
		LuaScriptMgr.Push(L, obj.originalClip);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_overrideClip(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name overrideClip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index overrideClip on a nil value");
			}
		}

		AnimationClipPair obj = (AnimationClipPair)o;
		LuaScriptMgr.Push(L, obj.overrideClip);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_originalClip(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name originalClip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index originalClip on a nil value");
			}
		}

		AnimationClipPair obj = (AnimationClipPair)o;
		obj.originalClip = LuaScriptMgr.GetNetObject<AnimationClip>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_overrideClip(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name overrideClip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index overrideClip on a nil value");
			}
		}

		AnimationClipPair obj = (AnimationClipPair)o;
		obj.overrideClip = LuaScriptMgr.GetNetObject<AnimationClip>(L, 3);
		return 0;
	}
}

