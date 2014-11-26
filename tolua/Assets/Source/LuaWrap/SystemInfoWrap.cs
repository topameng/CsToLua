using UnityEngine;
using System;
using LuaInterface;

public class SystemInfoWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("SupportsRenderTextureFormat", SupportsRenderTextureFormat),
		new LuaMethod("New", _CreateSystemInfo),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("operatingSystem", get_operatingSystem, null),
		new LuaField("processorType", get_processorType, null),
		new LuaField("processorCount", get_processorCount, null),
		new LuaField("systemMemorySize", get_systemMemorySize, null),
		new LuaField("graphicsMemorySize", get_graphicsMemorySize, null),
		new LuaField("graphicsDeviceName", get_graphicsDeviceName, null),
		new LuaField("graphicsDeviceVendor", get_graphicsDeviceVendor, null),
		new LuaField("graphicsDeviceID", get_graphicsDeviceID, null),
		new LuaField("graphicsDeviceVendorID", get_graphicsDeviceVendorID, null),
		new LuaField("graphicsDeviceVersion", get_graphicsDeviceVersion, null),
		new LuaField("graphicsShaderLevel", get_graphicsShaderLevel, null),
		new LuaField("graphicsPixelFillrate", get_graphicsPixelFillrate, null),
		new LuaField("supportsShadows", get_supportsShadows, null),
		new LuaField("supportsRenderTextures", get_supportsRenderTextures, null),
		new LuaField("supportsRenderToCubemap", get_supportsRenderToCubemap, null),
		new LuaField("supportsImageEffects", get_supportsImageEffects, null),
		new LuaField("supports3DTextures", get_supports3DTextures, null),
		new LuaField("supportsComputeShaders", get_supportsComputeShaders, null),
		new LuaField("supportsInstancing", get_supportsInstancing, null),
		new LuaField("supportsSparseTextures", get_supportsSparseTextures, null),
		new LuaField("supportedRenderTargetCount", get_supportedRenderTargetCount, null),
		new LuaField("supportsStencil", get_supportsStencil, null),
		new LuaField("supportsVertexPrograms", get_supportsVertexPrograms, null),
		new LuaField("npotSupport", get_npotSupport, null),
		new LuaField("deviceUniqueIdentifier", get_deviceUniqueIdentifier, null),
		new LuaField("deviceName", get_deviceName, null),
		new LuaField("deviceModel", get_deviceModel, null),
		new LuaField("supportsAccelerometer", get_supportsAccelerometer, null),
		new LuaField("supportsGyroscope", get_supportsGyroscope, null),
		new LuaField("supportsLocationService", get_supportsLocationService, null),
		new LuaField("supportsVibration", get_supportsVibration, null),
		new LuaField("deviceType", get_deviceType, null),
		new LuaField("maxTextureSize", get_maxTextureSize, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSystemInfo(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			SystemInfo obj = new SystemInfo();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SystemInfo.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(SystemInfo));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.SystemInfo", typeof(SystemInfo), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_operatingSystem(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.operatingSystem);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_processorType(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.processorType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_processorCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.processorCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_systemMemorySize(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.systemMemorySize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphicsMemorySize(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.graphicsMemorySize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphicsDeviceName(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.graphicsDeviceName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphicsDeviceVendor(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.graphicsDeviceVendor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphicsDeviceID(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.graphicsDeviceID);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphicsDeviceVendorID(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.graphicsDeviceVendorID);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphicsDeviceVersion(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.graphicsDeviceVersion);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphicsShaderLevel(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.graphicsShaderLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_graphicsPixelFillrate(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.graphicsPixelFillrate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsShadows(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsShadows);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsRenderTextures(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsRenderTextures);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsRenderToCubemap(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsRenderToCubemap);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsImageEffects(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsImageEffects);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supports3DTextures(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supports3DTextures);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsComputeShaders(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsComputeShaders);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsInstancing(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsInstancing);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsSparseTextures(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsSparseTextures);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportedRenderTargetCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportedRenderTargetCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsStencil(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsStencil);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsVertexPrograms(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsVertexPrograms);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_npotSupport(IntPtr L)
	{
		LuaScriptMgr.PushEnum(L, SystemInfo.npotSupport);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_deviceUniqueIdentifier(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.deviceUniqueIdentifier);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_deviceName(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.deviceName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_deviceModel(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.deviceModel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsAccelerometer(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsAccelerometer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsGyroscope(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsGyroscope);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsLocationService(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsLocationService);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_supportsVibration(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.supportsVibration);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_deviceType(IntPtr L)
	{
		LuaScriptMgr.PushEnum(L, SystemInfo.deviceType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxTextureSize(IntPtr L)
	{
		LuaScriptMgr.Push(L, SystemInfo.maxTextureSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SupportsRenderTextureFormat(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		RenderTextureFormat arg0 = LuaScriptMgr.GetNetObject<RenderTextureFormat>(L, 1);
		bool o = SystemInfo.SupportsRenderTextureFormat(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

