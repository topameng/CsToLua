using UnityEngine;
using System;
using LuaInterface;

public class WebCamTextureWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Play", Play),
		new LuaMethod("Pause", Pause),
		new LuaMethod("Stop", Stop),		
		new LuaMethod("GetPixel", GetPixel),
		new LuaMethod("GetPixels", GetPixels),
		new LuaMethod("GetPixels32", GetPixels32),
		new LuaMethod("New", _CreateWebCamTexture),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("isPlaying", get_isPlaying, null),
		new LuaField("deviceName", get_deviceName, set_deviceName),
		new LuaField("requestedFPS", get_requestedFPS, set_requestedFPS),
		new LuaField("requestedWidth", get_requestedWidth, set_requestedWidth),
		new LuaField("requestedHeight", get_requestedHeight, set_requestedHeight),		
		new LuaField("devices", get_devices, null),
		new LuaField("videoRotationAngle", get_videoRotationAngle, null),
		new LuaField("videoVerticallyMirrored", get_videoVerticallyMirrored, null),
		new LuaField("didUpdateThisFrame", get_didUpdateThisFrame, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateWebCamTexture(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types3 = {typeof(int), typeof(int), typeof(int)};
		Type[] types4 = {typeof(string), typeof(int), typeof(int)};

		if (count == 0)
		{
			WebCamTexture obj = new WebCamTexture();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else if (count == 1)
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			WebCamTexture obj = new WebCamTexture(arg0);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else if (count == 2)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			WebCamTexture obj = new WebCamTexture(arg0,arg1);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types3, 1))
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			WebCamTexture obj = new WebCamTexture(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types4, 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			WebCamTexture obj = new WebCamTexture(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else if (count == 4)
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			WebCamTexture obj = new WebCamTexture(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: WebCamTexture.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(WebCamTexture));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.WebCamTexture", typeof(WebCamTexture), regs, fields, "UnityEngine.Texture");
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

		WebCamTexture obj = (WebCamTexture)o;
		LuaScriptMgr.Push(L, obj.isPlaying);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_deviceName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name deviceName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index deviceName on a nil value");
			}
		}

		WebCamTexture obj = (WebCamTexture)o;
		LuaScriptMgr.Push(L, obj.deviceName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_requestedFPS(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name requestedFPS");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index requestedFPS on a nil value");
			}
		}

		WebCamTexture obj = (WebCamTexture)o;
		LuaScriptMgr.Push(L, obj.requestedFPS);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_requestedWidth(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name requestedWidth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index requestedWidth on a nil value");
			}
		}

		WebCamTexture obj = (WebCamTexture)o;
		LuaScriptMgr.Push(L, obj.requestedWidth);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_requestedHeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name requestedHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index requestedHeight on a nil value");
			}
		}

		WebCamTexture obj = (WebCamTexture)o;
		LuaScriptMgr.Push(L, obj.requestedHeight);
		return 1;
	}


	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_devices(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, WebCamTexture.devices);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_videoRotationAngle(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name videoRotationAngle");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index videoRotationAngle on a nil value");
			}
		}

		WebCamTexture obj = (WebCamTexture)o;
		LuaScriptMgr.Push(L, obj.videoRotationAngle);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_videoVerticallyMirrored(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name videoVerticallyMirrored");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index videoVerticallyMirrored on a nil value");
			}
		}

		WebCamTexture obj = (WebCamTexture)o;
		LuaScriptMgr.Push(L, obj.videoVerticallyMirrored);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_didUpdateThisFrame(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name didUpdateThisFrame");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index didUpdateThisFrame on a nil value");
			}
		}

		WebCamTexture obj = (WebCamTexture)o;
		LuaScriptMgr.Push(L, obj.didUpdateThisFrame);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_deviceName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name deviceName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index deviceName on a nil value");
			}
		}

		WebCamTexture obj = (WebCamTexture)o;
		obj.deviceName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_requestedFPS(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name requestedFPS");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index requestedFPS on a nil value");
			}
		}

		WebCamTexture obj = (WebCamTexture)o;
		obj.requestedFPS = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_requestedWidth(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name requestedWidth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index requestedWidth on a nil value");
			}
		}

		WebCamTexture obj = (WebCamTexture)o;
		obj.requestedWidth = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_requestedHeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name requestedHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index requestedHeight on a nil value");
			}
		}

		WebCamTexture obj = (WebCamTexture)o;
		obj.requestedHeight = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Play(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		WebCamTexture obj = LuaScriptMgr.GetNetObject<WebCamTexture>(L, 1);
		obj.Play();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Pause(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		WebCamTexture obj = LuaScriptMgr.GetNetObject<WebCamTexture>(L, 1);
		obj.Pause();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Stop(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		WebCamTexture obj = LuaScriptMgr.GetNetObject<WebCamTexture>(L, 1);
		obj.Stop();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPixel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		WebCamTexture obj = LuaScriptMgr.GetNetObject<WebCamTexture>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		Color o = obj.GetPixel(arg0,arg1);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPixels(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			WebCamTexture obj = LuaScriptMgr.GetNetObject<WebCamTexture>(L, 1);
			Color[] o = obj.GetPixels();
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 5)
		{
			WebCamTexture obj = LuaScriptMgr.GetNetObject<WebCamTexture>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 5);
			Color[] o = obj.GetPixels(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: WebCamTexture.GetPixels");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPixels32(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			WebCamTexture obj = LuaScriptMgr.GetNetObject<WebCamTexture>(L, 1);
			Color32[] o = obj.GetPixels32();
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2)
		{
			WebCamTexture obj = LuaScriptMgr.GetNetObject<WebCamTexture>(L, 1);
			Color32[] objs0 = LuaScriptMgr.GetArrayObject<Color32>(L, 2);
			Color32[] o = obj.GetPixels32(objs0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: WebCamTexture.GetPixels32");
		}

		return 0;
	}
}

