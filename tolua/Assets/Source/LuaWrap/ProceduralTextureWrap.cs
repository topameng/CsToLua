using UnityEngine;
using System;
using LuaInterface;

public class ProceduralTextureWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetProceduralOutputType", GetProceduralOutputType),
		new LuaMethod("GetPixels32", GetPixels32),
		new LuaMethod("New", _CreateProceduralTexture),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("hasAlpha", get_hasAlpha, null),
		new LuaField("format", get_format, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateProceduralTexture(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			ProceduralTexture obj = new ProceduralTexture();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ProceduralTexture.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ProceduralTexture));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ProceduralTexture", typeof(ProceduralTexture), regs, fields, "UnityEngine.Texture");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hasAlpha(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hasAlpha");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hasAlpha on a nil value");
			}
		}

		ProceduralTexture obj = (ProceduralTexture)o;
		LuaScriptMgr.Push(L, obj.hasAlpha);
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

		ProceduralTexture obj = (ProceduralTexture)o;
		LuaScriptMgr.PushEnum(L, obj.format);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetProceduralOutputType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ProceduralTexture obj = LuaScriptMgr.GetNetObject<ProceduralTexture>(L, 1);
		ProceduralOutputType o = obj.GetProceduralOutputType();
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPixels32(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		ProceduralTexture obj = LuaScriptMgr.GetNetObject<ProceduralTexture>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
		int arg3 = (int)LuaScriptMgr.GetNumber(L, 5);
		Color32[] o = obj.GetPixels32(arg0,arg1,arg2,arg3);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}
}

