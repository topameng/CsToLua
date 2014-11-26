using UnityEngine;
using System;
using LuaInterface;

public class ProceduralMaterialWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetProceduralPropertyDescriptions", GetProceduralPropertyDescriptions),
		new LuaMethod("HasProceduralProperty", HasProceduralProperty),
		new LuaMethod("GetProceduralBoolean", GetProceduralBoolean),
		new LuaMethod("SetProceduralBoolean", SetProceduralBoolean),
		new LuaMethod("GetProceduralFloat", GetProceduralFloat),
		new LuaMethod("SetProceduralFloat", SetProceduralFloat),
		new LuaMethod("GetProceduralVector", GetProceduralVector),
		new LuaMethod("SetProceduralVector", SetProceduralVector),
		new LuaMethod("GetProceduralColor", GetProceduralColor),
		new LuaMethod("SetProceduralColor", SetProceduralColor),
		new LuaMethod("GetProceduralEnum", GetProceduralEnum),
		new LuaMethod("SetProceduralEnum", SetProceduralEnum),
		new LuaMethod("GetProceduralTexture", GetProceduralTexture),
		new LuaMethod("SetProceduralTexture", SetProceduralTexture),
		new LuaMethod("IsProceduralPropertyCached", IsProceduralPropertyCached),
		new LuaMethod("CacheProceduralProperty", CacheProceduralProperty),
		new LuaMethod("ClearCache", ClearCache),
		new LuaMethod("RebuildTextures", RebuildTextures),
		new LuaMethod("RebuildTexturesImmediately", RebuildTexturesImmediately),
		new LuaMethod("StopRebuilds", StopRebuilds),
		new LuaMethod("GetGeneratedTextures", GetGeneratedTextures),
		new LuaMethod("GetGeneratedTexture", GetGeneratedTexture),
		new LuaMethod("New", _CreateProceduralMaterial),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("cacheSize", get_cacheSize, set_cacheSize),
		new LuaField("animationUpdateRate", get_animationUpdateRate, set_animationUpdateRate),
		new LuaField("isProcessing", get_isProcessing, null),
		new LuaField("isCachedDataAvailable", get_isCachedDataAvailable, null),
		new LuaField("isLoadTimeGenerated", get_isLoadTimeGenerated, set_isLoadTimeGenerated),
		new LuaField("loadingBehavior", get_loadingBehavior, null),
		new LuaField("isSupported", get_isSupported, null),
		new LuaField("substanceProcessorUsage", get_substanceProcessorUsage, set_substanceProcessorUsage),
		new LuaField("preset", get_preset, set_preset),
		new LuaField("isReadable", get_isReadable, set_isReadable),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateProceduralMaterial(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			ProceduralMaterial obj = new ProceduralMaterial();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ProceduralMaterial.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ProceduralMaterial));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ProceduralMaterial", typeof(ProceduralMaterial), regs, fields, "UnityEngine.Material");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cacheSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cacheSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cacheSize on a nil value");
			}
		}

		ProceduralMaterial obj = (ProceduralMaterial)o;
		LuaScriptMgr.PushEnum(L, obj.cacheSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_animationUpdateRate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name animationUpdateRate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index animationUpdateRate on a nil value");
			}
		}

		ProceduralMaterial obj = (ProceduralMaterial)o;
		LuaScriptMgr.Push(L, obj.animationUpdateRate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isProcessing(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isProcessing");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isProcessing on a nil value");
			}
		}

		ProceduralMaterial obj = (ProceduralMaterial)o;
		LuaScriptMgr.Push(L, obj.isProcessing);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isCachedDataAvailable(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isCachedDataAvailable");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isCachedDataAvailable on a nil value");
			}
		}

		ProceduralMaterial obj = (ProceduralMaterial)o;
		LuaScriptMgr.Push(L, obj.isCachedDataAvailable);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isLoadTimeGenerated(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isLoadTimeGenerated");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isLoadTimeGenerated on a nil value");
			}
		}

		ProceduralMaterial obj = (ProceduralMaterial)o;
		LuaScriptMgr.Push(L, obj.isLoadTimeGenerated);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_loadingBehavior(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name loadingBehavior");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index loadingBehavior on a nil value");
			}
		}

		ProceduralMaterial obj = (ProceduralMaterial)o;
		LuaScriptMgr.PushEnum(L, obj.loadingBehavior);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isSupported(IntPtr L)
	{
		LuaScriptMgr.Push(L, ProceduralMaterial.isSupported);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_substanceProcessorUsage(IntPtr L)
	{
		LuaScriptMgr.PushEnum(L, ProceduralMaterial.substanceProcessorUsage);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_preset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name preset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index preset on a nil value");
			}
		}

		ProceduralMaterial obj = (ProceduralMaterial)o;
		LuaScriptMgr.Push(L, obj.preset);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isReadable(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isReadable");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isReadable on a nil value");
			}
		}

		ProceduralMaterial obj = (ProceduralMaterial)o;
		LuaScriptMgr.Push(L, obj.isReadable);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cacheSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cacheSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cacheSize on a nil value");
			}
		}

		ProceduralMaterial obj = (ProceduralMaterial)o;
		obj.cacheSize = LuaScriptMgr.GetNetObject<ProceduralCacheSize>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_animationUpdateRate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name animationUpdateRate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index animationUpdateRate on a nil value");
			}
		}

		ProceduralMaterial obj = (ProceduralMaterial)o;
		obj.animationUpdateRate = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isLoadTimeGenerated(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isLoadTimeGenerated");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isLoadTimeGenerated on a nil value");
			}
		}

		ProceduralMaterial obj = (ProceduralMaterial)o;
		obj.isLoadTimeGenerated = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_substanceProcessorUsage(IntPtr L)
	{
		ProceduralMaterial.substanceProcessorUsage = LuaScriptMgr.GetNetObject<ProceduralProcessorUsage>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_preset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name preset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index preset on a nil value");
			}
		}

		ProceduralMaterial obj = (ProceduralMaterial)o;
		obj.preset = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isReadable(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isReadable");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isReadable on a nil value");
			}
		}

		ProceduralMaterial obj = (ProceduralMaterial)o;
		obj.isReadable = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetProceduralPropertyDescriptions(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		ProceduralPropertyDescription[] o = obj.GetProceduralPropertyDescriptions();
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HasProceduralProperty(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = obj.HasProceduralProperty(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetProceduralBoolean(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = obj.GetProceduralBoolean(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetProceduralBoolean(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
		obj.SetProceduralBoolean(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetProceduralFloat(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		float o = obj.GetProceduralFloat(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetProceduralFloat(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		obj.SetProceduralFloat(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetProceduralVector(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Vector4 o = obj.GetProceduralVector(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetProceduralVector(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Vector4 arg1 = LuaScriptMgr.GetNetObject<Vector4>(L, 3);
		obj.SetProceduralVector(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetProceduralColor(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Color o = obj.GetProceduralColor(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetProceduralColor(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Color arg1 = LuaScriptMgr.GetNetObject<Color>(L, 3);
		obj.SetProceduralColor(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetProceduralEnum(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int o = obj.GetProceduralEnum(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetProceduralEnum(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.SetProceduralEnum(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetProceduralTexture(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Texture2D o = obj.GetProceduralTexture(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetProceduralTexture(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Texture2D arg1 = LuaScriptMgr.GetNetObject<Texture2D>(L, 3);
		obj.SetProceduralTexture(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsProceduralPropertyCached(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = obj.IsProceduralPropertyCached(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CacheProceduralProperty(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
		obj.CacheProceduralProperty(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearCache(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		obj.ClearCache();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RebuildTextures(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		obj.RebuildTextures();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RebuildTexturesImmediately(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		obj.RebuildTexturesImmediately();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StopRebuilds(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		ProceduralMaterial.StopRebuilds();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetGeneratedTextures(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		Texture[] o = obj.GetGeneratedTextures();
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetGeneratedTexture(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ProceduralMaterial obj = LuaScriptMgr.GetNetObject<ProceduralMaterial>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		ProceduralTexture o = obj.GetGeneratedTexture(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

