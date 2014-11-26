using UnityEngine;
using System;
using System.Collections;
using LuaInterface;

public class AnimationWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Stop", Stop),
		new LuaMethod("Rewind", Rewind),
		new LuaMethod("Sample", Sample),
		new LuaMethod("IsPlaying", IsPlaying),
		new LuaMethod("get_Item", get_Item),
		new LuaMethod("Play", Play),
		new LuaMethod("CrossFade", CrossFade),
		new LuaMethod("Blend", Blend),
		new LuaMethod("CrossFadeQueued", CrossFadeQueued),
		new LuaMethod("PlayQueued", PlayQueued),
		new LuaMethod("AddClip", AddClip),
		new LuaMethod("RemoveClip", RemoveClip),
		new LuaMethod("GetClipCount", GetClipCount),
		new LuaMethod("SyncLayer", SyncLayer),
		new LuaMethod("GetEnumerator", GetEnumerator),
		new LuaMethod("GetClip", GetClip),
		new LuaMethod("New", _CreateAnimation),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("clip", get_clip, set_clip),
		new LuaField("playAutomatically", get_playAutomatically, set_playAutomatically),
		new LuaField("wrapMode", get_wrapMode, set_wrapMode),
		new LuaField("isPlaying", get_isPlaying, null),
		new LuaField("animatePhysics", get_animatePhysics, set_animatePhysics),
		new LuaField("cullingType", get_cullingType, set_cullingType),
		new LuaField("localBounds", get_localBounds, set_localBounds),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAnimation(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Animation obj = new Animation();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Animation.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Animation));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Animation", typeof(Animation), regs, fields, "UnityEngine.Behaviour");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_clip(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name clip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index clip on a nil value");
			}
		}

		Animation obj = (Animation)o;
		LuaScriptMgr.Push(L, obj.clip);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_playAutomatically(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name playAutomatically");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index playAutomatically on a nil value");
			}
		}

		Animation obj = (Animation)o;
		LuaScriptMgr.Push(L, obj.playAutomatically);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_wrapMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name wrapMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index wrapMode on a nil value");
			}
		}

		Animation obj = (Animation)o;
		LuaScriptMgr.PushEnum(L, obj.wrapMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPlaying(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isPlaying");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isPlaying on a nil value");
			}
		}

		Animation obj = (Animation)o;
		LuaScriptMgr.Push(L, obj.isPlaying);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_animatePhysics(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name animatePhysics");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index animatePhysics on a nil value");
			}
		}

		Animation obj = (Animation)o;
		LuaScriptMgr.Push(L, obj.animatePhysics);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cullingType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cullingType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cullingType on a nil value");
			}
		}

		Animation obj = (Animation)o;
		LuaScriptMgr.PushEnum(L, obj.cullingType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localBounds(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name localBounds");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index localBounds on a nil value");
			}
		}

		Animation obj = (Animation)o;
		LuaScriptMgr.PushValue(L, obj.localBounds);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_clip(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name clip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index clip on a nil value");
			}
		}

		Animation obj = (Animation)o;
		obj.clip = LuaScriptMgr.GetNetObject<AnimationClip>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_playAutomatically(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name playAutomatically");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index playAutomatically on a nil value");
			}
		}

		Animation obj = (Animation)o;
		obj.playAutomatically = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_wrapMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name wrapMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index wrapMode on a nil value");
			}
		}

		Animation obj = (Animation)o;
		obj.wrapMode = LuaScriptMgr.GetNetObject<WrapMode>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_animatePhysics(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name animatePhysics");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index animatePhysics on a nil value");
			}
		}

		Animation obj = (Animation)o;
		obj.animatePhysics = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cullingType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cullingType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cullingType on a nil value");
			}
		}

		Animation obj = (Animation)o;
		obj.cullingType = LuaScriptMgr.GetNetObject<AnimationCullingType>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localBounds(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name localBounds");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index localBounds on a nil value");
			}
		}

		Animation obj = (Animation)o;
		obj.localBounds = LuaScriptMgr.GetNetObject<Bounds>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Stop(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			obj.Stop();
			return 0;
		}
		else if (count == 2)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.Stop(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Animation.Stop");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Rewind(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			obj.Rewind();
			return 0;
		}
		else if (count == 2)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.Rewind(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Animation.Rewind");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Sample(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
		obj.Sample();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsPlaying(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = obj.IsPlaying(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Item(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		AnimationState o = obj[arg0];
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Play(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(Animation), typeof(string)};
		Type[] types2 = {typeof(Animation), typeof(PlayMode)};

		if (count == 1)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			bool o = obj.Play();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			bool o = obj.Play(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			PlayMode arg0 = LuaScriptMgr.GetNetObject<PlayMode>(L, 2);
			bool o = obj.Play(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			PlayMode arg1 = LuaScriptMgr.GetNetObject<PlayMode>(L, 3);
			bool o = obj.Play(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Animation.Play");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CrossFade(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.CrossFade(arg0);
			return 0;
		}
		else if (count == 3)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			obj.CrossFade(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			PlayMode arg2 = LuaScriptMgr.GetNetObject<PlayMode>(L, 4);
			obj.CrossFade(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Animation.CrossFade");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Blend(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.Blend(arg0);
			return 0;
		}
		else if (count == 3)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			obj.Blend(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			obj.Blend(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Animation.Blend");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CrossFadeQueued(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			AnimationState o = obj.CrossFadeQueued(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			AnimationState o = obj.CrossFadeQueued(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			QueueMode arg2 = LuaScriptMgr.GetNetObject<QueueMode>(L, 4);
			AnimationState o = obj.CrossFadeQueued(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			QueueMode arg2 = LuaScriptMgr.GetNetObject<QueueMode>(L, 4);
			PlayMode arg3 = LuaScriptMgr.GetNetObject<PlayMode>(L, 5);
			AnimationState o = obj.CrossFadeQueued(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Animation.CrossFadeQueued");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlayQueued(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			AnimationState o = obj.PlayQueued(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			QueueMode arg1 = LuaScriptMgr.GetNetObject<QueueMode>(L, 3);
			AnimationState o = obj.PlayQueued(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			QueueMode arg1 = LuaScriptMgr.GetNetObject<QueueMode>(L, 3);
			PlayMode arg2 = LuaScriptMgr.GetNetObject<PlayMode>(L, 4);
			AnimationState o = obj.PlayQueued(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Animation.PlayQueued");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddClip(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			AnimationClip arg0 = LuaScriptMgr.GetNetObject<AnimationClip>(L, 2);
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			obj.AddClip(arg0,arg1);
			return 0;
		}
		else if (count == 5)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			AnimationClip arg0 = LuaScriptMgr.GetNetObject<AnimationClip>(L, 2);
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 5);
			obj.AddClip(arg0,arg1,arg2,arg3);
			return 0;
		}
		else if (count == 6)
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			AnimationClip arg0 = LuaScriptMgr.GetNetObject<AnimationClip>(L, 2);
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 5);
			bool arg4 = LuaScriptMgr.GetBoolean(L, 6);
			obj.AddClip(arg0,arg1,arg2,arg3,arg4);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Animation.AddClip");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveClip(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(Animation), typeof(string)};
		Type[] types1 = {typeof(Animation), typeof(AnimationClip)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			obj.RemoveClip(arg0);
			return 0;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
			AnimationClip arg0 = LuaScriptMgr.GetNetObject<AnimationClip>(L, 2);
			obj.RemoveClip(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Animation.RemoveClip");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClipCount(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
		int o = obj.GetClipCount();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SyncLayer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		obj.SyncLayer(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEnumerator(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
		IEnumerator o = obj.GetEnumerator();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClip(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Animation obj = LuaScriptMgr.GetNetObject<Animation>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		AnimationClip o = obj.GetClip(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

