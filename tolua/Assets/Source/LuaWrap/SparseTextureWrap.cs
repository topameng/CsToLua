using UnityEngine;
using System;
using LuaInterface;

public class SparseTextureWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("UpdateTile", UpdateTile),
		new LuaMethod("UpdateTileRaw", UpdateTileRaw),
		new LuaMethod("UnloadTile", UnloadTile),
		new LuaMethod("New", _CreateSparseTexture),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("tileWidth", get_tileWidth, null),
		new LuaField("tileHeight", get_tileHeight, null),
		new LuaField("isCreated", get_isCreated, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSparseTexture(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			TextureFormat arg2 = LuaScriptMgr.GetNetObject<TextureFormat>(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			SparseTexture obj = new SparseTexture(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else if (count == 5)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			TextureFormat arg2 = LuaScriptMgr.GetNetObject<TextureFormat>(L, 3);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
			bool arg4 = LuaScriptMgr.GetBoolean(L, 5);
			SparseTexture obj = new SparseTexture(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SparseTexture.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(SparseTexture));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.SparseTexture", typeof(SparseTexture), regs, fields, "UnityEngine.Texture");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tileWidth(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tileWidth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tileWidth on a nil value");
			}
		}

		SparseTexture obj = (SparseTexture)o;
		LuaScriptMgr.Push(L, obj.tileWidth);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tileHeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tileHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tileHeight on a nil value");
			}
		}

		SparseTexture obj = (SparseTexture)o;
		LuaScriptMgr.Push(L, obj.tileHeight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isCreated(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isCreated");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isCreated on a nil value");
			}
		}

		SparseTexture obj = (SparseTexture)o;
		LuaScriptMgr.Push(L, obj.isCreated);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UpdateTile(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		SparseTexture obj = LuaScriptMgr.GetNetObject<SparseTexture>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
		Color32[] objs3 = LuaScriptMgr.GetArrayObject<Color32>(L, 5);
		obj.UpdateTile(arg0,arg1,arg2,objs3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UpdateTileRaw(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		SparseTexture obj = LuaScriptMgr.GetNetObject<SparseTexture>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
		byte[] objs3 = LuaScriptMgr.GetArrayNumber<byte>(L, 5);
		obj.UpdateTileRaw(arg0,arg1,arg2,objs3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnloadTile(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		SparseTexture obj = LuaScriptMgr.GetNetObject<SparseTexture>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
		obj.UnloadTile(arg0,arg1,arg2);
		return 0;
	}
}

