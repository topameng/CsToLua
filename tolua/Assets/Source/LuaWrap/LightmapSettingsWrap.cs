using UnityEngine;
using System;
using LuaInterface;

public class LightmapSettingsWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateLightmapSettings),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("lightmaps", get_lightmaps, set_lightmaps),
		new LuaField("lightmapsMode", get_lightmapsMode, set_lightmapsMode),
		new LuaField("bakedColorSpace", get_bakedColorSpace, set_bakedColorSpace),
		new LuaField("lightProbes", get_lightProbes, set_lightProbes),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLightmapSettings(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			LightmapSettings obj = new LightmapSettings();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: LightmapSettings.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(LightmapSettings));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.LightmapSettings", typeof(LightmapSettings), regs, fields, "UnityEngine.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lightmaps(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, LightmapSettings.lightmaps);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lightmapsMode(IntPtr L)
	{
		LuaScriptMgr.PushEnum(L, LightmapSettings.lightmapsMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bakedColorSpace(IntPtr L)
	{
		LuaScriptMgr.PushEnum(L, LightmapSettings.bakedColorSpace);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lightProbes(IntPtr L)
	{
		LuaScriptMgr.Push(L, LightmapSettings.lightProbes);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lightmaps(IntPtr L)
	{
		LightmapSettings.lightmaps = LuaScriptMgr.GetNetObject<LightmapData[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lightmapsMode(IntPtr L)
	{
		LightmapSettings.lightmapsMode = LuaScriptMgr.GetNetObject<LightmapsMode>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_bakedColorSpace(IntPtr L)
	{
		LightmapSettings.bakedColorSpace = LuaScriptMgr.GetNetObject<ColorSpace>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lightProbes(IntPtr L)
	{
		LightmapSettings.lightProbes = LuaScriptMgr.GetNetObject<LightProbes>(L, 3);
		return 0;
	}
}

