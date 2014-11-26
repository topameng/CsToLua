using UnityEngine;
using System;
using LuaInterface;

public class RenderTextureWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetTemporary", GetTemporary),
		new LuaMethod("ReleaseTemporary", ReleaseTemporary),
		new LuaMethod("Create", Create),
		new LuaMethod("Release", Release),
		new LuaMethod("IsCreated", IsCreated),
		new LuaMethod("DiscardContents", DiscardContents),
		new LuaMethod("MarkRestoreExpected", MarkRestoreExpected),
		new LuaMethod("SetGlobalShaderProperty", SetGlobalShaderProperty),
		new LuaMethod("GetTexelOffset", GetTexelOffset),
		new LuaMethod("SupportsStencil", SupportsStencil),
		new LuaMethod("New", _CreateRenderTexture),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("width", get_width, set_width),
		new LuaField("height", get_height, set_height),
		new LuaField("depth", get_depth, set_depth),
		new LuaField("isPowerOfTwo", get_isPowerOfTwo, set_isPowerOfTwo),
		new LuaField("sRGB", get_sRGB, null),
		new LuaField("format", get_format, set_format),
		new LuaField("useMipMap", get_useMipMap, set_useMipMap),
		new LuaField("generateMips", get_generateMips, set_generateMips),
		new LuaField("isCubemap", get_isCubemap, set_isCubemap),
		new LuaField("isVolume", get_isVolume, set_isVolume),
		new LuaField("volumeDepth", get_volumeDepth, set_volumeDepth),
		new LuaField("antiAliasing", get_antiAliasing, set_antiAliasing),
		new LuaField("enableRandomWrite", get_enableRandomWrite, set_enableRandomWrite),
		new LuaField("colorBuffer", get_colorBuffer, null),
		new LuaField("depthBuffer", get_depthBuffer, null),
		new LuaField("active", get_active, set_active),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateRenderTexture(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			RenderTexture obj = new RenderTexture(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else if (count == 4)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			RenderTextureFormat arg3 = LuaScriptMgr.GetNetObject<RenderTextureFormat>(L, 4);
			RenderTexture obj = new RenderTexture(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else if (count == 5)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			RenderTextureFormat arg3 = LuaScriptMgr.GetNetObject<RenderTextureFormat>(L, 4);
			RenderTextureReadWrite arg4 = LuaScriptMgr.GetNetObject<RenderTextureReadWrite>(L, 5);
			RenderTexture obj = new RenderTexture(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: RenderTexture.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(RenderTexture));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.RenderTexture", typeof(RenderTexture), regs, fields, "UnityEngine.Texture");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_width(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
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

		RenderTexture obj = (RenderTexture)o;
		LuaScriptMgr.Push(L, obj.width);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_height(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
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

		RenderTexture obj = (RenderTexture)o;
		LuaScriptMgr.Push(L, obj.height);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_depth(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depth on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		LuaScriptMgr.Push(L, obj.depth);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPowerOfTwo(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isPowerOfTwo");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isPowerOfTwo on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		LuaScriptMgr.Push(L, obj.isPowerOfTwo);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sRGB(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sRGB");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sRGB on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		LuaScriptMgr.Push(L, obj.sRGB);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_format(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name format");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index format on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		LuaScriptMgr.PushEnum(L, obj.format);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useMipMap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useMipMap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useMipMap on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		LuaScriptMgr.Push(L, obj.useMipMap);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_generateMips(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name generateMips");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index generateMips on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		LuaScriptMgr.Push(L, obj.generateMips);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isCubemap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isCubemap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isCubemap on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		LuaScriptMgr.Push(L, obj.isCubemap);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isVolume(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isVolume");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isVolume on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		LuaScriptMgr.Push(L, obj.isVolume);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_volumeDepth(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name volumeDepth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index volumeDepth on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		LuaScriptMgr.Push(L, obj.volumeDepth);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_antiAliasing(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name antiAliasing");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index antiAliasing on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		LuaScriptMgr.Push(L, obj.antiAliasing);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enableRandomWrite(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enableRandomWrite");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enableRandomWrite on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		LuaScriptMgr.Push(L, obj.enableRandomWrite);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_colorBuffer(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name colorBuffer");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index colorBuffer on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		LuaScriptMgr.PushValue(L, obj.colorBuffer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_depthBuffer(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depthBuffer");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depthBuffer on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		LuaScriptMgr.PushValue(L, obj.depthBuffer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_active(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderTexture.active);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_width(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
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

		RenderTexture obj = (RenderTexture)o;
		obj.width = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_height(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
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

		RenderTexture obj = (RenderTexture)o;
		obj.height = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_depth(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depth on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		obj.depth = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isPowerOfTwo(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isPowerOfTwo");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isPowerOfTwo on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		obj.isPowerOfTwo = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_format(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name format");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index format on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		obj.format = LuaScriptMgr.GetNetObject<RenderTextureFormat>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useMipMap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useMipMap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useMipMap on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		obj.useMipMap = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_generateMips(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name generateMips");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index generateMips on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		obj.generateMips = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isCubemap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isCubemap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isCubemap on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		obj.isCubemap = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isVolume(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isVolume");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isVolume on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		obj.isVolume = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_volumeDepth(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name volumeDepth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index volumeDepth on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		obj.volumeDepth = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_antiAliasing(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name antiAliasing");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index antiAliasing on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		obj.antiAliasing = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enableRandomWrite(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name enableRandomWrite");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index enableRandomWrite on a nil value");
			}
		}

		RenderTexture obj = (RenderTexture)o;
		obj.enableRandomWrite = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_active(IntPtr L)
	{
		RenderTexture.active = LuaScriptMgr.GetNetObject<RenderTexture>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTemporary(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			RenderTexture o = RenderTexture.GetTemporary(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			RenderTexture o = RenderTexture.GetTemporary(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			RenderTextureFormat arg3 = LuaScriptMgr.GetNetObject<RenderTextureFormat>(L, 4);
			RenderTexture o = RenderTexture.GetTemporary(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			RenderTextureFormat arg3 = LuaScriptMgr.GetNetObject<RenderTextureFormat>(L, 4);
			RenderTextureReadWrite arg4 = LuaScriptMgr.GetNetObject<RenderTextureReadWrite>(L, 5);
			RenderTexture o = RenderTexture.GetTemporary(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 6)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			RenderTextureFormat arg3 = LuaScriptMgr.GetNetObject<RenderTextureFormat>(L, 4);
			RenderTextureReadWrite arg4 = LuaScriptMgr.GetNetObject<RenderTextureReadWrite>(L, 5);
			int arg5 = (int)LuaScriptMgr.GetNumber(L, 6);
			RenderTexture o = RenderTexture.GetTemporary(arg0,arg1,arg2,arg3,arg4,arg5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: RenderTexture.GetTemporary");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReleaseTemporary(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		RenderTexture arg0 = LuaScriptMgr.GetNetObject<RenderTexture>(L, 1);
		RenderTexture.ReleaseTemporary(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		RenderTexture obj = LuaScriptMgr.GetNetObject<RenderTexture>(L, 1);
		bool o = obj.Create();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Release(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		RenderTexture obj = LuaScriptMgr.GetNetObject<RenderTexture>(L, 1);
		obj.Release();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsCreated(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		RenderTexture obj = LuaScriptMgr.GetNetObject<RenderTexture>(L, 1);
		bool o = obj.IsCreated();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DiscardContents(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			RenderTexture obj = LuaScriptMgr.GetNetObject<RenderTexture>(L, 1);
			obj.DiscardContents();
			return 0;
		}
		else if (count == 3)
		{
			RenderTexture obj = LuaScriptMgr.GetNetObject<RenderTexture>(L, 1);
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			obj.DiscardContents(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: RenderTexture.DiscardContents");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MarkRestoreExpected(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		RenderTexture obj = LuaScriptMgr.GetNetObject<RenderTexture>(L, 1);
		obj.MarkRestoreExpected();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetGlobalShaderProperty(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		RenderTexture obj = LuaScriptMgr.GetNetObject<RenderTexture>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.SetGlobalShaderProperty(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTexelOffset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		RenderTexture obj = LuaScriptMgr.GetNetObject<RenderTexture>(L, 1);
		Vector2 o = obj.GetTexelOffset();
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SupportsStencil(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		RenderTexture arg0 = LuaScriptMgr.GetNetObject<RenderTexture>(L, 1);
		bool o = RenderTexture.SupportsStencil(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

