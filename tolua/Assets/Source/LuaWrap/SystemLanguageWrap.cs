using UnityEngine;
using System;
using LuaInterface;

public class SystemLanguageWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Afrikaans", SystemLanguage.Afrikaans),
		new LuaEnum("Arabic", SystemLanguage.Arabic),
		new LuaEnum("Basque", SystemLanguage.Basque),
		new LuaEnum("Belarusian", SystemLanguage.Belarusian),
		new LuaEnum("Bulgarian", SystemLanguage.Bulgarian),
		new LuaEnum("Catalan", SystemLanguage.Catalan),
		new LuaEnum("Chinese", SystemLanguage.Chinese),
		new LuaEnum("Czech", SystemLanguage.Czech),
		new LuaEnum("Danish", SystemLanguage.Danish),
		new LuaEnum("Dutch", SystemLanguage.Dutch),
		new LuaEnum("English", SystemLanguage.English),
		new LuaEnum("Estonian", SystemLanguage.Estonian),
		new LuaEnum("Faroese", SystemLanguage.Faroese),
		new LuaEnum("Finnish", SystemLanguage.Finnish),
		new LuaEnum("French", SystemLanguage.French),
		new LuaEnum("German", SystemLanguage.German),
		new LuaEnum("Greek", SystemLanguage.Greek),
		new LuaEnum("Hebrew", SystemLanguage.Hebrew),
		new LuaEnum("Hugarian", SystemLanguage.Hugarian),
		new LuaEnum("Icelandic", SystemLanguage.Icelandic),
		new LuaEnum("Indonesian", SystemLanguage.Indonesian),
		new LuaEnum("Italian", SystemLanguage.Italian),
		new LuaEnum("Japanese", SystemLanguage.Japanese),
		new LuaEnum("Korean", SystemLanguage.Korean),
		new LuaEnum("Latvian", SystemLanguage.Latvian),
		new LuaEnum("Lithuanian", SystemLanguage.Lithuanian),
		new LuaEnum("Norwegian", SystemLanguage.Norwegian),
		new LuaEnum("Polish", SystemLanguage.Polish),
		new LuaEnum("Portuguese", SystemLanguage.Portuguese),
		new LuaEnum("Romanian", SystemLanguage.Romanian),
		new LuaEnum("Russian", SystemLanguage.Russian),
		new LuaEnum("SerboCroatian", SystemLanguage.SerboCroatian),
		new LuaEnum("Slovak", SystemLanguage.Slovak),
		new LuaEnum("Slovenian", SystemLanguage.Slovenian),
		new LuaEnum("Spanish", SystemLanguage.Spanish),
		new LuaEnum("Swedish", SystemLanguage.Swedish),
		new LuaEnum("Thai", SystemLanguage.Thai),
		new LuaEnum("Turkish", SystemLanguage.Turkish),
		new LuaEnum("Ukrainian", SystemLanguage.Ukrainian),
		new LuaEnum("Vietnamese", SystemLanguage.Vietnamese),
		new LuaEnum("Unknown", SystemLanguage.Unknown),
		new LuaEnum("Hungarian", SystemLanguage.Hungarian),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.SystemLanguage", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.SystemLanguage", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		SystemLanguage o = (SystemLanguage)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

