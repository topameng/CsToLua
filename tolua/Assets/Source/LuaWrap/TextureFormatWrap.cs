using UnityEngine;
using System;
using LuaInterface;

public class TextureFormatWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Alpha8", TextureFormat.Alpha8),
		new LuaEnum("ARGB4444", TextureFormat.ARGB4444),
		new LuaEnum("RGB24", TextureFormat.RGB24),
		new LuaEnum("RGBA32", TextureFormat.RGBA32),
		new LuaEnum("ARGB32", TextureFormat.ARGB32),
		new LuaEnum("RGB565", TextureFormat.RGB565),
		new LuaEnum("DXT1", TextureFormat.DXT1),
		new LuaEnum("DXT5", TextureFormat.DXT5),
		new LuaEnum("RGBA4444", TextureFormat.RGBA4444),
		new LuaEnum("BGRA32", TextureFormat.BGRA32),
		new LuaEnum("PVRTC_RGB2", TextureFormat.PVRTC_RGB2),
		new LuaEnum("PVRTC_RGBA2", TextureFormat.PVRTC_RGBA2),
		new LuaEnum("PVRTC_RGB4", TextureFormat.PVRTC_RGB4),
		new LuaEnum("PVRTC_RGBA4", TextureFormat.PVRTC_RGBA4),
		new LuaEnum("ETC_RGB4", TextureFormat.ETC_RGB4),
		new LuaEnum("ATC_RGB4", TextureFormat.ATC_RGB4),
		new LuaEnum("ATC_RGBA8", TextureFormat.ATC_RGBA8),
		new LuaEnum("ATF_RGB_DXT1", TextureFormat.ATF_RGB_DXT1),
		new LuaEnum("ATF_RGBA_JPG", TextureFormat.ATF_RGBA_JPG),
		new LuaEnum("ATF_RGB_JPG", TextureFormat.ATF_RGB_JPG),
		new LuaEnum("EAC_R", TextureFormat.EAC_R),
		new LuaEnum("EAC_R_SIGNED", TextureFormat.EAC_R_SIGNED),
		new LuaEnum("EAC_RG", TextureFormat.EAC_RG),
		new LuaEnum("EAC_RG_SIGNED", TextureFormat.EAC_RG_SIGNED),
		new LuaEnum("ETC2_RGB", TextureFormat.ETC2_RGB),
		new LuaEnum("ETC2_RGBA1", TextureFormat.ETC2_RGBA1),
		new LuaEnum("ETC2_RGBA8", TextureFormat.ETC2_RGBA8),
		new LuaEnum("ASTC_RGB_4x4", TextureFormat.ASTC_RGB_4x4),
		new LuaEnum("ASTC_RGB_5x5", TextureFormat.ASTC_RGB_5x5),
		new LuaEnum("ASTC_RGB_6x6", TextureFormat.ASTC_RGB_6x6),
		new LuaEnum("ASTC_RGB_8x8", TextureFormat.ASTC_RGB_8x8),
		new LuaEnum("ASTC_RGB_10x10", TextureFormat.ASTC_RGB_10x10),
		new LuaEnum("ASTC_RGB_12x12", TextureFormat.ASTC_RGB_12x12),
		new LuaEnum("ASTC_RGBA_4x4", TextureFormat.ASTC_RGBA_4x4),
		new LuaEnum("ASTC_RGBA_5x5", TextureFormat.ASTC_RGBA_5x5),
		new LuaEnum("ASTC_RGBA_6x6", TextureFormat.ASTC_RGBA_6x6),
		new LuaEnum("ASTC_RGBA_8x8", TextureFormat.ASTC_RGBA_8x8),
		new LuaEnum("ASTC_RGBA_10x10", TextureFormat.ASTC_RGBA_10x10),
		new LuaEnum("ASTC_RGBA_12x12", TextureFormat.ASTC_RGBA_12x12),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.TextureFormat", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.TextureFormat", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		TextureFormat o = (TextureFormat)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

