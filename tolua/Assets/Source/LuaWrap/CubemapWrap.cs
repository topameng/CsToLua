using UnityEngine;
using System;
using LuaInterface;

public class CubemapWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("SetPixel", SetPixel),
		new LuaMethod("GetPixel", GetPixel),
		new LuaMethod("GetPixels", GetPixels),
		new LuaMethod("SetPixels", SetPixels),
		new LuaMethod("Apply", Apply),
		new LuaMethod("SmoothEdges", SmoothEdges),
		new LuaMethod("New", _CreateCubemap),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("format", get_format, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCubemap(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			TextureFormat arg1 = LuaScriptMgr.GetNetObject<TextureFormat>(L, 2);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 3);
			Cubemap obj = new Cubemap(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Cubemap.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Cubemap));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Cubemap", typeof(Cubemap), regs, fields, "UnityEngine.Texture");
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

		Cubemap obj = (Cubemap)o;
		LuaScriptMgr.PushEnum(L, obj.format);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetPixel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		Cubemap obj = LuaScriptMgr.GetNetObject<Cubemap>(L, 1);
		CubemapFace arg0 = LuaScriptMgr.GetNetObject<CubemapFace>(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
		Color arg3 = LuaScriptMgr.GetNetObject<Color>(L, 5);
		obj.SetPixel(arg0,arg1,arg2,arg3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPixel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Cubemap obj = LuaScriptMgr.GetNetObject<Cubemap>(L, 1);
		CubemapFace arg0 = LuaScriptMgr.GetNetObject<CubemapFace>(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
		Color o = obj.GetPixel(arg0,arg1,arg2);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPixels(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Cubemap obj = LuaScriptMgr.GetNetObject<Cubemap>(L, 1);
			CubemapFace arg0 = LuaScriptMgr.GetNetObject<CubemapFace>(L, 2);
			Color[] o = obj.GetPixels(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Cubemap obj = LuaScriptMgr.GetNetObject<Cubemap>(L, 1);
			CubemapFace arg0 = LuaScriptMgr.GetNetObject<CubemapFace>(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			Color[] o = obj.GetPixels(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Cubemap.GetPixels");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetPixels(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Cubemap obj = LuaScriptMgr.GetNetObject<Cubemap>(L, 1);
			Color[] objs0 = LuaScriptMgr.GetArrayObject<Color>(L, 2);
			CubemapFace arg1 = LuaScriptMgr.GetNetObject<CubemapFace>(L, 3);
			obj.SetPixels(objs0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Cubemap obj = LuaScriptMgr.GetNetObject<Cubemap>(L, 1);
			Color[] objs0 = LuaScriptMgr.GetArrayObject<Color>(L, 2);
			CubemapFace arg1 = LuaScriptMgr.GetNetObject<CubemapFace>(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			obj.SetPixels(objs0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Cubemap.SetPixels");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Apply(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Cubemap obj = LuaScriptMgr.GetNetObject<Cubemap>(L, 1);
			obj.Apply();
			return 0;
		}
		else if (count == 2)
		{
			Cubemap obj = LuaScriptMgr.GetNetObject<Cubemap>(L, 1);
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			obj.Apply(arg0);
			return 0;
		}
		else if (count == 3)
		{
			Cubemap obj = LuaScriptMgr.GetNetObject<Cubemap>(L, 1);
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			obj.Apply(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Cubemap.Apply");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SmoothEdges(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Cubemap obj = LuaScriptMgr.GetNetObject<Cubemap>(L, 1);
			obj.SmoothEdges();
			return 0;
		}
		else if (count == 2)
		{
			Cubemap obj = LuaScriptMgr.GetNetObject<Cubemap>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			obj.SmoothEdges(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Cubemap.SmoothEdges");
		}

		return 0;
	}
}

