using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class RenderSettingsWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateRenderSettings),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__eq", Lua_Eq),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("fog", get_fog, set_fog),
		new LuaField("fogMode", get_fogMode, set_fogMode),
		new LuaField("fogColor", get_fogColor, set_fogColor),
		new LuaField("fogDensity", get_fogDensity, set_fogDensity),
		new LuaField("fogStartDistance", get_fogStartDistance, set_fogStartDistance),
		new LuaField("fogEndDistance", get_fogEndDistance, set_fogEndDistance),
		new LuaField("ambientLight", get_ambientLight, set_ambientLight),
		new LuaField("haloStrength", get_haloStrength, set_haloStrength),
		new LuaField("flareStrength", get_flareStrength, set_flareStrength),
		new LuaField("flareFadeSpeed", get_flareFadeSpeed, set_flareFadeSpeed),
		new LuaField("skybox", get_skybox, set_skybox),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateRenderSettings(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			RenderSettings obj = new RenderSettings();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: RenderSettings.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(RenderSettings));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.RenderSettings", typeof(RenderSettings), regs, fields, typeof(UnityEngine.Object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fog(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.fog);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fogMode(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.fogMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fogColor(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.fogColor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fogDensity(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.fogDensity);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fogStartDistance(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.fogStartDistance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fogEndDistance(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.fogEndDistance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ambientLight(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.ambientLight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_haloStrength(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.haloStrength);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flareStrength(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.flareStrength);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flareFadeSpeed(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.flareFadeSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_skybox(IntPtr L)
	{
		LuaScriptMgr.Push(L, RenderSettings.skybox);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fog(IntPtr L)
	{
		RenderSettings.fog = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fogMode(IntPtr L)
	{
		RenderSettings.fogMode = LuaScriptMgr.GetNetObject<FogMode>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fogColor(IntPtr L)
	{
		RenderSettings.fogColor = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fogDensity(IntPtr L)
	{
		RenderSettings.fogDensity = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fogStartDistance(IntPtr L)
	{
		RenderSettings.fogStartDistance = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fogEndDistance(IntPtr L)
	{
		RenderSettings.fogEndDistance = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_ambientLight(IntPtr L)
	{
		RenderSettings.ambientLight = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_haloStrength(IntPtr L)
	{
		RenderSettings.haloStrength = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flareStrength(IntPtr L)
	{
		RenderSettings.flareStrength = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flareFadeSpeed(IntPtr L)
	{
		RenderSettings.flareFadeSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_skybox(IntPtr L)
	{
		RenderSettings.skybox = LuaScriptMgr.GetUnityObject<Material>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetVarObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetVarObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

