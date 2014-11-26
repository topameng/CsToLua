using UnityEngine;
using System;
using LuaInterface;
using Object = UnityEngine.Object;

public class AnimationEventWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateAnimationEvent),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("stringParameter", get_stringParameter, set_stringParameter),
		new LuaField("floatParameter", get_floatParameter, set_floatParameter),
		new LuaField("intParameter", get_intParameter, set_intParameter),
		new LuaField("objectReferenceParameter", get_objectReferenceParameter, set_objectReferenceParameter),
		new LuaField("functionName", get_functionName, set_functionName),
		new LuaField("time", get_time, set_time),
		new LuaField("messageOptions", get_messageOptions, set_messageOptions),
		new LuaField("animationState", get_animationState, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAnimationEvent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AnimationEvent obj = new AnimationEvent();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AnimationEvent.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AnimationEvent));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AnimationEvent", typeof(AnimationEvent), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stringParameter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stringParameter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stringParameter on a nil value");
			}
		}

		AnimationEvent obj = (AnimationEvent)o;
		LuaScriptMgr.Push(L, obj.stringParameter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_floatParameter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name floatParameter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index floatParameter on a nil value");
			}
		}

		AnimationEvent obj = (AnimationEvent)o;
		LuaScriptMgr.Push(L, obj.floatParameter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_intParameter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name intParameter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index intParameter on a nil value");
			}
		}

		AnimationEvent obj = (AnimationEvent)o;
		LuaScriptMgr.Push(L, obj.intParameter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_objectReferenceParameter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name objectReferenceParameter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index objectReferenceParameter on a nil value");
			}
		}

		AnimationEvent obj = (AnimationEvent)o;
		LuaScriptMgr.Push(L, obj.objectReferenceParameter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_functionName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name functionName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index functionName on a nil value");
			}
		}

		AnimationEvent obj = (AnimationEvent)o;
		LuaScriptMgr.Push(L, obj.functionName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_time(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name time");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index time on a nil value");
			}
		}

		AnimationEvent obj = (AnimationEvent)o;
		LuaScriptMgr.Push(L, obj.time);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_messageOptions(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name messageOptions");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index messageOptions on a nil value");
			}
		}

		AnimationEvent obj = (AnimationEvent)o;
		LuaScriptMgr.PushEnum(L, obj.messageOptions);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_animationState(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name animationState");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index animationState on a nil value");
			}
		}

		AnimationEvent obj = (AnimationEvent)o;
		LuaScriptMgr.PushObject(L, obj.animationState);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_stringParameter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stringParameter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stringParameter on a nil value");
			}
		}

		AnimationEvent obj = (AnimationEvent)o;
		obj.stringParameter = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_floatParameter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name floatParameter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index floatParameter on a nil value");
			}
		}

		AnimationEvent obj = (AnimationEvent)o;
		obj.floatParameter = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_intParameter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name intParameter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index intParameter on a nil value");
			}
		}

		AnimationEvent obj = (AnimationEvent)o;
		obj.intParameter = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_objectReferenceParameter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name objectReferenceParameter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index objectReferenceParameter on a nil value");
			}
		}

		AnimationEvent obj = (AnimationEvent)o;
		obj.objectReferenceParameter = LuaScriptMgr.GetNetObject<Object>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_functionName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name functionName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index functionName on a nil value");
			}
		}

		AnimationEvent obj = (AnimationEvent)o;
		obj.functionName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_time(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name time");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index time on a nil value");
			}
		}

		AnimationEvent obj = (AnimationEvent)o;
		obj.time = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_messageOptions(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name messageOptions");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index messageOptions on a nil value");
			}
		}

		AnimationEvent obj = (AnimationEvent)o;
		obj.messageOptions = LuaScriptMgr.GetNetObject<SendMessageOptions>(L, 3);
		return 0;
	}
}

