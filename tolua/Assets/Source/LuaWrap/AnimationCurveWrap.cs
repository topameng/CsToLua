using UnityEngine;
using System;
using LuaInterface;

public class AnimationCurveWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Evaluate", Evaluate),
		new LuaMethod("AddKey", AddKey),
		new LuaMethod("MoveKey", MoveKey),
		new LuaMethod("RemoveKey", RemoveKey),
		new LuaMethod("get_Item", get_Item),
		new LuaMethod("SmoothTangents", SmoothTangents),
		new LuaMethod("Linear", Linear),
		new LuaMethod("EaseInOut", EaseInOut),
		new LuaMethod("New", _CreateAnimationCurve),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("keys", get_keys, set_keys),
		new LuaField("length", get_length, null),
		new LuaField("preWrapMode", get_preWrapMode, set_preWrapMode),
		new LuaField("postWrapMode", get_postWrapMode, set_postWrapMode),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAnimationCurve(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AnimationCurve obj = new AnimationCurve();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (LuaScriptMgr.CheckParamsType(L, typeof(Keyframe), 1, count))
		{
			Keyframe[] objs0 = LuaScriptMgr.GetParamsObject<Keyframe>(L, 1, count);
			AnimationCurve obj = new AnimationCurve(objs0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnimationCurve.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AnimationCurve));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AnimationCurve", typeof(AnimationCurve), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_keys(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name keys");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index keys on a nil value");
			}
		}

		AnimationCurve obj = (AnimationCurve)o;
		LuaScriptMgr.PushArray(L, obj.keys);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_length(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name length");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index length on a nil value");
			}
		}

		AnimationCurve obj = (AnimationCurve)o;
		LuaScriptMgr.Push(L, obj.length);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_preWrapMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name preWrapMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index preWrapMode on a nil value");
			}
		}

		AnimationCurve obj = (AnimationCurve)o;
		LuaScriptMgr.PushEnum(L, obj.preWrapMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_postWrapMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name postWrapMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index postWrapMode on a nil value");
			}
		}

		AnimationCurve obj = (AnimationCurve)o;
		LuaScriptMgr.PushEnum(L, obj.postWrapMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_keys(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name keys");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index keys on a nil value");
			}
		}

		AnimationCurve obj = (AnimationCurve)o;
		obj.keys = LuaScriptMgr.GetNetObject<Keyframe[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_preWrapMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name preWrapMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index preWrapMode on a nil value");
			}
		}

		AnimationCurve obj = (AnimationCurve)o;
		obj.preWrapMode = LuaScriptMgr.GetNetObject<WrapMode>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_postWrapMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name postWrapMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index postWrapMode on a nil value");
			}
		}

		AnimationCurve obj = (AnimationCurve)o;
		obj.postWrapMode = LuaScriptMgr.GetNetObject<WrapMode>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Evaluate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		AnimationCurve obj = LuaScriptMgr.GetNetObject<AnimationCurve>(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		float o = obj.Evaluate(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddKey(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			AnimationCurve obj = LuaScriptMgr.GetNetObject<AnimationCurve>(L, 1);
			Keyframe arg0 = LuaScriptMgr.GetNetObject<Keyframe>(L, 2);
			int o = obj.AddKey(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			AnimationCurve obj = LuaScriptMgr.GetNetObject<AnimationCurve>(L, 1);
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			int o = obj.AddKey(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnimationCurve.AddKey");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MoveKey(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		AnimationCurve obj = LuaScriptMgr.GetNetObject<AnimationCurve>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Keyframe arg1 = LuaScriptMgr.GetNetObject<Keyframe>(L, 3);
		int o = obj.MoveKey(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveKey(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		AnimationCurve obj = LuaScriptMgr.GetNetObject<AnimationCurve>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.RemoveKey(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Item(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		AnimationCurve obj = LuaScriptMgr.GetNetObject<AnimationCurve>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Keyframe o = obj[arg0];
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SmoothTangents(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		AnimationCurve obj = LuaScriptMgr.GetNetObject<AnimationCurve>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		obj.SmoothTangents(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Linear(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
		AnimationCurve o = AnimationCurve.Linear(arg0,arg1,arg2,arg3);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EaseInOut(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
		AnimationCurve o = AnimationCurve.EaseInOut(arg0,arg1,arg2,arg3);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}
}

