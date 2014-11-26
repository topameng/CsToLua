using UnityEngine;
using System;
using LuaInterface;

public class Texture3DWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetPixels", GetPixels),
		new LuaMethod("SetPixels", SetPixels),
		new LuaMethod("Apply", Apply),
		new LuaMethod("New", _CreateTexture3D),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("depth", get_depth, null),
		new LuaField("format", get_format, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateTexture3D(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 5)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			TextureFormat arg3 = LuaScriptMgr.GetNetObject<TextureFormat>(L, 4);
			bool arg4 = LuaScriptMgr.GetBoolean(L, 5);
			Texture3D obj = new Texture3D(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Texture3D.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Texture3D));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Texture3D", typeof(Texture3D), regs, fields, "UnityEngine.Texture");
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

		Texture3D obj = (Texture3D)o;
		LuaScriptMgr.Push(L, obj.depth);
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

		Texture3D obj = (Texture3D)o;
		LuaScriptMgr.PushEnum(L, obj.format);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPixels(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Texture3D obj = LuaScriptMgr.GetNetObject<Texture3D>(L, 1);
			Color[] o = obj.GetPixels();
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Texture3D obj = LuaScriptMgr.GetNetObject<Texture3D>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Color[] o = obj.GetPixels(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Texture3D.GetPixels");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetPixels(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Texture3D obj = LuaScriptMgr.GetNetObject<Texture3D>(L, 1);
			Color[] objs0 = LuaScriptMgr.GetArrayObject<Color>(L, 2);
			obj.SetPixels(objs0);
			return 0;
		}
		else if (count == 3)
		{
			Texture3D obj = LuaScriptMgr.GetNetObject<Texture3D>(L, 1);
			Color[] objs0 = LuaScriptMgr.GetArrayObject<Color>(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			obj.SetPixels(objs0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Texture3D.SetPixels");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Apply(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Texture3D obj = LuaScriptMgr.GetNetObject<Texture3D>(L, 1);
			obj.Apply();
			return 0;
		}
		else if (count == 2)
		{
			Texture3D obj = LuaScriptMgr.GetNetObject<Texture3D>(L, 1);
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			obj.Apply(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Texture3D.Apply");
		}

		return 0;
	}
}

