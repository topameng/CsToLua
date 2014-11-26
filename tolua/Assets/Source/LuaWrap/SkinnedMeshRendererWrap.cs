using UnityEngine;
using System;
using LuaInterface;

public class SkinnedMeshRendererWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("BakeMesh", BakeMesh),
		new LuaMethod("GetBlendShapeWeight", GetBlendShapeWeight),
		new LuaMethod("SetBlendShapeWeight", SetBlendShapeWeight),
		new LuaMethod("New", _CreateSkinnedMeshRenderer),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("bones", get_bones, set_bones),
		new LuaField("rootBone", get_rootBone, set_rootBone),
		new LuaField("quality", get_quality, set_quality),
		new LuaField("sharedMesh", get_sharedMesh, set_sharedMesh),
		new LuaField("updateWhenOffscreen", get_updateWhenOffscreen, set_updateWhenOffscreen),
		new LuaField("localBounds", get_localBounds, set_localBounds),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSkinnedMeshRenderer(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			SkinnedMeshRenderer obj = new SkinnedMeshRenderer();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SkinnedMeshRenderer.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(SkinnedMeshRenderer));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.SkinnedMeshRenderer", typeof(SkinnedMeshRenderer), regs, fields, "UnityEngine.Renderer");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bones(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bones");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bones on a nil value");
			}
		}

		SkinnedMeshRenderer obj = (SkinnedMeshRenderer)o;
		LuaScriptMgr.PushArray(L, obj.bones);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rootBone(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rootBone");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rootBone on a nil value");
			}
		}

		SkinnedMeshRenderer obj = (SkinnedMeshRenderer)o;
		LuaScriptMgr.Push(L, obj.rootBone);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_quality(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name quality");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index quality on a nil value");
			}
		}

		SkinnedMeshRenderer obj = (SkinnedMeshRenderer)o;
		LuaScriptMgr.PushEnum(L, obj.quality);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sharedMesh(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sharedMesh");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sharedMesh on a nil value");
			}
		}

		SkinnedMeshRenderer obj = (SkinnedMeshRenderer)o;
		LuaScriptMgr.Push(L, obj.sharedMesh);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_updateWhenOffscreen(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name updateWhenOffscreen");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index updateWhenOffscreen on a nil value");
			}
		}

		SkinnedMeshRenderer obj = (SkinnedMeshRenderer)o;
		LuaScriptMgr.Push(L, obj.updateWhenOffscreen);
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

		SkinnedMeshRenderer obj = (SkinnedMeshRenderer)o;
		LuaScriptMgr.PushValue(L, obj.localBounds);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bones(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bones");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bones on a nil value");
			}
		}

		SkinnedMeshRenderer obj = (SkinnedMeshRenderer)o;
		obj.bones = LuaScriptMgr.GetNetObject<Transform[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rootBone(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rootBone");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rootBone on a nil value");
			}
		}

		SkinnedMeshRenderer obj = (SkinnedMeshRenderer)o;
		obj.rootBone = LuaScriptMgr.GetNetObject<Transform>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_quality(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name quality");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index quality on a nil value");
			}
		}

		SkinnedMeshRenderer obj = (SkinnedMeshRenderer)o;
		obj.quality = LuaScriptMgr.GetNetObject<SkinQuality>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sharedMesh(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sharedMesh");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sharedMesh on a nil value");
			}
		}

		SkinnedMeshRenderer obj = (SkinnedMeshRenderer)o;
		obj.sharedMesh = LuaScriptMgr.GetNetObject<Mesh>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_updateWhenOffscreen(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name updateWhenOffscreen");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index updateWhenOffscreen on a nil value");
			}
		}

		SkinnedMeshRenderer obj = (SkinnedMeshRenderer)o;
		obj.updateWhenOffscreen = LuaScriptMgr.GetBoolean(L, 3);
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

		SkinnedMeshRenderer obj = (SkinnedMeshRenderer)o;
		obj.localBounds = LuaScriptMgr.GetNetObject<Bounds>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BakeMesh(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SkinnedMeshRenderer obj = LuaScriptMgr.GetNetObject<SkinnedMeshRenderer>(L, 1);
		Mesh arg0 = LuaScriptMgr.GetNetObject<Mesh>(L, 2);
		obj.BakeMesh(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBlendShapeWeight(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SkinnedMeshRenderer obj = LuaScriptMgr.GetNetObject<SkinnedMeshRenderer>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		float o = obj.GetBlendShapeWeight(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetBlendShapeWeight(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		SkinnedMeshRenderer obj = LuaScriptMgr.GetNetObject<SkinnedMeshRenderer>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		obj.SetBlendShapeWeight(arg0,arg1);
		return 0;
	}
}

