using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class TextureWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("SetGlobalAnisotropicFilteringLimits", SetGlobalAnisotropicFilteringLimits),
			new LuaMethod("GetNativeTexturePtr", GetNativeTexturePtr),
			new LuaMethod("GetNativeTextureID", GetNativeTextureID),
			new LuaMethod("New", _CreateTexture),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("masterTextureLimit", get_masterTextureLimit, set_masterTextureLimit),
			new LuaField("anisotropicFiltering", get_anisotropicFiltering, set_anisotropicFiltering),
			new LuaField("width", get_width, set_width),
			new LuaField("height", get_height, set_height),
			new LuaField("filterMode", get_filterMode, set_filterMode),
			new LuaField("anisoLevel", get_anisoLevel, set_anisoLevel),
			new LuaField("wrapMode", get_wrapMode, set_wrapMode),
			new LuaField("mipMapBias", get_mipMapBias, set_mipMapBias),
			new LuaField("texelSize", get_texelSize, null),
		};

		LuaScriptMgr.RegisterLib(L, "UnityEngine.Texture", typeof(UnityEngine.Texture), regs, fields, typeof(Object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateTexture(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Texture obj = new Texture();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Texture.New");
		}

		return 0;
	}

	static Type classType = typeof(Texture);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_masterTextureLimit(IntPtr L)
	{
		LuaScriptMgr.Push(L, Texture.masterTextureLimit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_anisotropicFiltering(IntPtr L)
	{
		LuaScriptMgr.Push(L, Texture.anisotropicFiltering);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_width(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Texture obj = (Texture)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name width");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index width on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.width);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_height(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Texture obj = (Texture)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name height");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index height on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.height);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_filterMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Texture obj = (Texture)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name filterMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index filterMode on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.filterMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_anisoLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Texture obj = (Texture)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name anisoLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index anisoLevel on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.anisoLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_wrapMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Texture obj = (Texture)o;

		if (obj == null)
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

		LuaScriptMgr.Push(L, obj.wrapMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mipMapBias(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Texture obj = (Texture)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mipMapBias");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mipMapBias on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mipMapBias);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_texelSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Texture obj = (Texture)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name texelSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index texelSize on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.texelSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_masterTextureLimit(IntPtr L)
	{
		Texture.masterTextureLimit = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_anisotropicFiltering(IntPtr L)
	{
		Texture.anisotropicFiltering = (AnisotropicFiltering)LuaScriptMgr.GetNetObject(L, 3, typeof(AnisotropicFiltering));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_width(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Texture obj = (Texture)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name width");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index width on a nil value");
			}
		}

		obj.width = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_height(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Texture obj = (Texture)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name height");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index height on a nil value");
			}
		}

		obj.height = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_filterMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Texture obj = (Texture)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name filterMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index filterMode on a nil value");
			}
		}

		obj.filterMode = (FilterMode)LuaScriptMgr.GetNetObject(L, 3, typeof(FilterMode));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_anisoLevel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Texture obj = (Texture)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name anisoLevel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index anisoLevel on a nil value");
			}
		}

		obj.anisoLevel = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_wrapMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Texture obj = (Texture)o;

		if (obj == null)
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

		obj.wrapMode = (TextureWrapMode)LuaScriptMgr.GetNetObject(L, 3, typeof(TextureWrapMode));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mipMapBias(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Texture obj = (Texture)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mipMapBias");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mipMapBias on a nil value");
			}
		}

		obj.mipMapBias = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetGlobalAnisotropicFilteringLimits(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		Texture.SetGlobalAnisotropicFilteringLimits(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetNativeTexturePtr(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Texture obj = (Texture)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Texture");
		IntPtr o = obj.GetNativeTexturePtr();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetNativeTextureID(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Texture obj = (Texture)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Texture");
		int o = obj.GetNativeTextureID();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetLuaObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetLuaObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

