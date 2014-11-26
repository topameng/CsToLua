using UnityEngine;
using System;
using LuaInterface;

public class QualitySettingsWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetQualityLevel", GetQualityLevel),
		new LuaMethod("SetQualityLevel", SetQualityLevel),
		new LuaMethod("IncreaseLevel", IncreaseLevel),
		new LuaMethod("DecreaseLevel", DecreaseLevel),
		new LuaMethod("New", _CreateQualitySettings),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("names", get_names, null),
		new LuaField("pixelLightCount", get_pixelLightCount, set_pixelLightCount),
		new LuaField("shadowProjection", get_shadowProjection, set_shadowProjection),
		new LuaField("shadowCascades", get_shadowCascades, set_shadowCascades),
		new LuaField("shadowDistance", get_shadowDistance, set_shadowDistance),
		new LuaField("masterTextureLimit", get_masterTextureLimit, set_masterTextureLimit),
		new LuaField("anisotropicFiltering", get_anisotropicFiltering, set_anisotropicFiltering),
		new LuaField("lodBias", get_lodBias, set_lodBias),
		new LuaField("maximumLODLevel", get_maximumLODLevel, set_maximumLODLevel),
		new LuaField("particleRaycastBudget", get_particleRaycastBudget, set_particleRaycastBudget),
		new LuaField("softVegetation", get_softVegetation, set_softVegetation),
		new LuaField("maxQueuedFrames", get_maxQueuedFrames, set_maxQueuedFrames),
		new LuaField("vSyncCount", get_vSyncCount, set_vSyncCount),
		new LuaField("antiAliasing", get_antiAliasing, set_antiAliasing),
		new LuaField("desiredColorSpace", get_desiredColorSpace, null),
		new LuaField("activeColorSpace", get_activeColorSpace, null),
		new LuaField("blendWeights", get_blendWeights, set_blendWeights),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateQualitySettings(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			QualitySettings obj = new QualitySettings();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: QualitySettings.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(QualitySettings));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.QualitySettings", typeof(QualitySettings), regs, fields, "UnityEngine.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_names(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, QualitySettings.names);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pixelLightCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, QualitySettings.pixelLightCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowProjection(IntPtr L)
	{
		LuaScriptMgr.PushEnum(L, QualitySettings.shadowProjection);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowCascades(IntPtr L)
	{
		LuaScriptMgr.Push(L, QualitySettings.shadowCascades);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowDistance(IntPtr L)
	{
		LuaScriptMgr.Push(L, QualitySettings.shadowDistance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_masterTextureLimit(IntPtr L)
	{
		LuaScriptMgr.Push(L, QualitySettings.masterTextureLimit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_anisotropicFiltering(IntPtr L)
	{
		LuaScriptMgr.PushEnum(L, QualitySettings.anisotropicFiltering);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lodBias(IntPtr L)
	{
		LuaScriptMgr.Push(L, QualitySettings.lodBias);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maximumLODLevel(IntPtr L)
	{
		LuaScriptMgr.Push(L, QualitySettings.maximumLODLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_particleRaycastBudget(IntPtr L)
	{
		LuaScriptMgr.Push(L, QualitySettings.particleRaycastBudget);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_softVegetation(IntPtr L)
	{
		LuaScriptMgr.Push(L, QualitySettings.softVegetation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxQueuedFrames(IntPtr L)
	{
		LuaScriptMgr.Push(L, QualitySettings.maxQueuedFrames);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_vSyncCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, QualitySettings.vSyncCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_antiAliasing(IntPtr L)
	{
		LuaScriptMgr.Push(L, QualitySettings.antiAliasing);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_desiredColorSpace(IntPtr L)
	{
		LuaScriptMgr.PushEnum(L, QualitySettings.desiredColorSpace);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_activeColorSpace(IntPtr L)
	{
		LuaScriptMgr.PushEnum(L, QualitySettings.activeColorSpace);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_blendWeights(IntPtr L)
	{
		LuaScriptMgr.PushEnum(L, QualitySettings.blendWeights);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pixelLightCount(IntPtr L)
	{
		QualitySettings.pixelLightCount = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowProjection(IntPtr L)
	{
		QualitySettings.shadowProjection = LuaScriptMgr.GetNetObject<ShadowProjection>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowCascades(IntPtr L)
	{
		QualitySettings.shadowCascades = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowDistance(IntPtr L)
	{
		QualitySettings.shadowDistance = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_masterTextureLimit(IntPtr L)
	{
		QualitySettings.masterTextureLimit = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_anisotropicFiltering(IntPtr L)
	{
		QualitySettings.anisotropicFiltering = LuaScriptMgr.GetNetObject<AnisotropicFiltering>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lodBias(IntPtr L)
	{
		QualitySettings.lodBias = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maximumLODLevel(IntPtr L)
	{
		QualitySettings.maximumLODLevel = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_particleRaycastBudget(IntPtr L)
	{
		QualitySettings.particleRaycastBudget = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_softVegetation(IntPtr L)
	{
		QualitySettings.softVegetation = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxQueuedFrames(IntPtr L)
	{
		QualitySettings.maxQueuedFrames = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_vSyncCount(IntPtr L)
	{
		QualitySettings.vSyncCount = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_antiAliasing(IntPtr L)
	{
		QualitySettings.antiAliasing = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_blendWeights(IntPtr L)
	{
		QualitySettings.blendWeights = LuaScriptMgr.GetNetObject<BlendWeights>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetQualityLevel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		int o = QualitySettings.GetQualityLevel();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetQualityLevel(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			QualitySettings.SetQualityLevel(arg0);
			return 0;
		}
		else if (count == 2)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
			QualitySettings.SetQualityLevel(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: QualitySettings.SetQualityLevel");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IncreaseLevel(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			QualitySettings.IncreaseLevel();
			return 0;
		}
		else if (count == 1)
		{
			bool arg0 = LuaScriptMgr.GetBoolean(L, 1);
			QualitySettings.IncreaseLevel(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: QualitySettings.IncreaseLevel");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DecreaseLevel(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			QualitySettings.DecreaseLevel();
			return 0;
		}
		else if (count == 1)
		{
			bool arg0 = LuaScriptMgr.GetBoolean(L, 1);
			QualitySettings.DecreaseLevel(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: QualitySettings.DecreaseLevel");
		}

		return 0;
	}
}

