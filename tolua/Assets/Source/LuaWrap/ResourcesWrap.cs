using UnityEngine;
using System;
using LuaInterface;
using Object = UnityEngine.Object;

public class ResourcesWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("FindObjectsOfTypeAll", FindObjectsOfTypeAll),
		new LuaMethod("Load", Load),
		new LuaMethod("LoadAll", LoadAll),
		new LuaMethod("GetBuiltinResource", GetBuiltinResource),
		new LuaMethod("LoadAssetAtPath", LoadAssetAtPath),
		new LuaMethod("UnloadAsset", UnloadAsset),
		new LuaMethod("UnloadUnusedAssets", UnloadUnusedAssets),
		new LuaMethod("New", _CreateResources),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateResources(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Resources obj = new Resources();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Resources.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Resources));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Resources", typeof(Resources), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindObjectsOfTypeAll(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
		Object[] o = Resources.FindObjectsOfTypeAll(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Load(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			Object o = Resources.Load(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			Type arg1 = LuaScriptMgr.GetTypeObject(L, 2);
			Object o = Resources.Load(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Resources.Load");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAll(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			Object[] o = Resources.LoadAll(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			Type arg1 = LuaScriptMgr.GetTypeObject(L, 2);
			Object[] o = Resources.LoadAll(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Resources.LoadAll");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetBuiltinResource(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Type arg0 = LuaScriptMgr.GetTypeObject(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Object o = Resources.GetBuiltinResource(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAssetAtPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Type arg1 = LuaScriptMgr.GetTypeObject(L, 2);
		Object o = Resources.LoadAssetAtPath(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnloadAsset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Object arg0 = LuaScriptMgr.GetNetObject<Object>(L, 1);
		Resources.UnloadAsset(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnloadUnusedAssets(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		AsyncOperation o = Resources.UnloadUnusedAssets();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}
}

