using UnityEngine;
using System;
using LuaInterface;
using Object = UnityEngine.Object;

public class AssetBundleWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("CreateFromMemory", CreateFromMemory),
		new LuaMethod("CreateFromMemoryImmediate", CreateFromMemoryImmediate),
		new LuaMethod("CreateFromFile", CreateFromFile),
		new LuaMethod("Contains", Contains),
		new LuaMethod("Load", Load),
		new LuaMethod("LoadAsync", LoadAsync),
		new LuaMethod("LoadAll", LoadAll),
		new LuaMethod("Unload", Unload),
		new LuaMethod("New", _CreateAssetBundle),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("mainAsset", get_mainAsset, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateAssetBundle(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			AssetBundle obj = new AssetBundle();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AssetBundle.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(AssetBundle));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AssetBundle", typeof(AssetBundle), regs, fields, "UnityEngine.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainAsset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainAsset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainAsset on a nil value");
			}
		}

		AssetBundle obj = (AssetBundle)o;
		LuaScriptMgr.Push(L, obj.mainAsset);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateFromMemory(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		byte[] objs0 = LuaScriptMgr.GetArrayNumber<byte>(L, 1);
		AssetBundleCreateRequest o = AssetBundle.CreateFromMemory(objs0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateFromMemoryImmediate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		byte[] objs0 = LuaScriptMgr.GetArrayNumber<byte>(L, 1);
		AssetBundle o = AssetBundle.CreateFromMemoryImmediate(objs0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateFromFile(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		AssetBundle o = AssetBundle.CreateFromFile(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Contains(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		AssetBundle obj = LuaScriptMgr.GetNetObject<AssetBundle>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = obj.Contains(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Load(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			AssetBundle obj = LuaScriptMgr.GetNetObject<AssetBundle>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			Object o = obj.Load(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			AssetBundle obj = LuaScriptMgr.GetNetObject<AssetBundle>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			Type arg1 = LuaScriptMgr.GetTypeObject(L, 3);
			Object o = obj.Load(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AssetBundle.Load");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAsync(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		AssetBundle obj = LuaScriptMgr.GetNetObject<AssetBundle>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Type arg1 = LuaScriptMgr.GetTypeObject(L, 3);
		AssetBundleRequest o = obj.LoadAsync(arg0,arg1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAll(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			AssetBundle obj = LuaScriptMgr.GetNetObject<AssetBundle>(L, 1);
			Object[] o = obj.LoadAll();
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2)
		{
			AssetBundle obj = LuaScriptMgr.GetNetObject<AssetBundle>(L, 1);
			Type arg0 = LuaScriptMgr.GetTypeObject(L, 2);
			Object[] o = obj.LoadAll(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: AssetBundle.LoadAll");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Unload(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		AssetBundle obj = LuaScriptMgr.GetNetObject<AssetBundle>(L, 1);
		bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
		obj.Unload(arg0);
		return 0;
	}
}

