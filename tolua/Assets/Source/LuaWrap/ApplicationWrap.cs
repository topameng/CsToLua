using UnityEngine;
using System;
using LuaInterface;

public class ApplicationWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Quit", Quit),
		new LuaMethod("CancelQuit", CancelQuit),
		new LuaMethod("LoadLevel", LoadLevel),
		new LuaMethod("LoadLevelAsync", LoadLevelAsync),
		new LuaMethod("LoadLevelAdditiveAsync", LoadLevelAdditiveAsync),
		new LuaMethod("LoadLevelAdditive", LoadLevelAdditive),
		new LuaMethod("GetStreamProgressForLevel", GetStreamProgressForLevel),
		new LuaMethod("CanStreamedLevelBeLoaded", CanStreamedLevelBeLoaded),
		new LuaMethod("CaptureScreenshot", CaptureScreenshot),
		new LuaMethod("HasProLicense", HasProLicense),
		new LuaMethod("ExternalCall", ExternalCall),
		new LuaMethod("ExternalEval", ExternalEval),
		new LuaMethod("OpenURL", OpenURL),
		new LuaMethod("RegisterLogCallback", RegisterLogCallback),
		new LuaMethod("RegisterLogCallbackThreaded", RegisterLogCallbackThreaded),
		new LuaMethod("RequestUserAuthorization", RequestUserAuthorization),
		new LuaMethod("HasUserAuthorization", HasUserAuthorization),
		new LuaMethod("New", _CreateApplication),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("loadedLevel", get_loadedLevel, null),
		new LuaField("loadedLevelName", get_loadedLevelName, null),
		new LuaField("isLoadingLevel", get_isLoadingLevel, null),
		new LuaField("levelCount", get_levelCount, null),
		new LuaField("streamedBytes", get_streamedBytes, null),
		new LuaField("isPlaying", get_isPlaying, null),
		new LuaField("isEditor", get_isEditor, null),
		new LuaField("isWebPlayer", get_isWebPlayer, null),
		new LuaField("platform", get_platform, null),
		new LuaField("runInBackground", get_runInBackground, set_runInBackground),
		new LuaField("dataPath", get_dataPath, null),
		new LuaField("streamingAssetsPath", get_streamingAssetsPath, null),
		new LuaField("persistentDataPath", get_persistentDataPath, null),
		new LuaField("temporaryCachePath", get_temporaryCachePath, null),
		new LuaField("srcValue", get_srcValue, null),
		new LuaField("absoluteURL", get_absoluteURL, null),
		new LuaField("unityVersion", get_unityVersion, null),
		new LuaField("webSecurityEnabled", get_webSecurityEnabled, null),
		new LuaField("webSecurityHostUrl", get_webSecurityHostUrl, null),
		new LuaField("targetFrameRate", get_targetFrameRate, set_targetFrameRate),
		new LuaField("systemLanguage", get_systemLanguage, null),
		new LuaField("backgroundLoadingPriority", get_backgroundLoadingPriority, set_backgroundLoadingPriority),
		new LuaField("internetReachability", get_internetReachability, null),
		new LuaField("genuine", get_genuine, null),
		new LuaField("genuineCheckAvailable", get_genuineCheckAvailable, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateApplication(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Application obj = new Application();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Application.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Application));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Application", typeof(Application), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_loadedLevel(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.loadedLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_loadedLevelName(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.loadedLevelName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isLoadingLevel(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.isLoadingLevel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_levelCount(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.levelCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_streamedBytes(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.streamedBytes);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPlaying(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.isPlaying);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isEditor(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.isEditor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isWebPlayer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.isWebPlayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_platform(IntPtr L)
	{
		LuaScriptMgr.PushEnum(L, Application.platform);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_runInBackground(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.runInBackground);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dataPath(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.dataPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_streamingAssetsPath(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.streamingAssetsPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_persistentDataPath(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.persistentDataPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_temporaryCachePath(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.temporaryCachePath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_srcValue(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.srcValue);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_absoluteURL(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.absoluteURL);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_unityVersion(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.unityVersion);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_webSecurityEnabled(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.webSecurityEnabled);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_webSecurityHostUrl(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.webSecurityHostUrl);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_targetFrameRate(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.targetFrameRate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_systemLanguage(IntPtr L)
	{
		LuaScriptMgr.PushEnum(L, Application.systemLanguage);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_backgroundLoadingPriority(IntPtr L)
	{
		LuaScriptMgr.PushEnum(L, Application.backgroundLoadingPriority);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_internetReachability(IntPtr L)
	{
		LuaScriptMgr.PushEnum(L, Application.internetReachability);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_genuine(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.genuine);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_genuineCheckAvailable(IntPtr L)
	{
		LuaScriptMgr.Push(L, Application.genuineCheckAvailable);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_runInBackground(IntPtr L)
	{
		Application.runInBackground = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_targetFrameRate(IntPtr L)
	{
		Application.targetFrameRate = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_backgroundLoadingPriority(IntPtr L)
	{
		Application.backgroundLoadingPriority = LuaScriptMgr.GetNetObject<ThreadPriority>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Quit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Application.Quit();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CancelQuit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Application.CancelQuit();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadLevel(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(string)};
		Type[] types1 = {typeof(int)};

		if (count == 1 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			Application.LoadLevel(arg0);
			return 0;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			Application.LoadLevel(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Application.LoadLevel");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadLevelAsync(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(string)};
		Type[] types1 = {typeof(int)};

		if (count == 1 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			AsyncOperation o = Application.LoadLevelAsync(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			AsyncOperation o = Application.LoadLevelAsync(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Application.LoadLevelAsync");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadLevelAdditiveAsync(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(string)};
		Type[] types1 = {typeof(int)};

		if (count == 1 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			AsyncOperation o = Application.LoadLevelAdditiveAsync(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			AsyncOperation o = Application.LoadLevelAdditiveAsync(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Application.LoadLevelAdditiveAsync");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadLevelAdditive(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(string)};
		Type[] types1 = {typeof(int)};

		if (count == 1 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			Application.LoadLevelAdditive(arg0);
			return 0;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			Application.LoadLevelAdditive(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Application.LoadLevelAdditive");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetStreamProgressForLevel(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(string)};
		Type[] types1 = {typeof(int)};

		if (count == 1 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			float o = Application.GetStreamProgressForLevel(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			float o = Application.GetStreamProgressForLevel(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Application.GetStreamProgressForLevel");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CanStreamedLevelBeLoaded(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(string)};
		Type[] types1 = {typeof(int)};

		if (count == 1 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			bool o = Application.CanStreamedLevelBeLoaded(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			bool o = Application.CanStreamedLevelBeLoaded(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Application.CanStreamedLevelBeLoaded");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CaptureScreenshot(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			Application.CaptureScreenshot(arg0);
			return 0;
		}
		else if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			Application.CaptureScreenshot(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Application.CaptureScreenshot");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HasProLicense(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		bool o = Application.HasProLicense();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ExternalCall(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		object[] objs1 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
		Application.ExternalCall(arg0,objs1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ExternalEval(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Application.ExternalEval(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OpenURL(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Application.OpenURL(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RegisterLogCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UnityEngine.Application.LogCallback arg0 = LuaScriptMgr.GetNetObject<UnityEngine.Application.LogCallback>(L, 1);
		Application.RegisterLogCallback(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RegisterLogCallbackThreaded(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UnityEngine.Application.LogCallback arg0 = LuaScriptMgr.GetNetObject<UnityEngine.Application.LogCallback>(L, 1);
		Application.RegisterLogCallbackThreaded(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RequestUserAuthorization(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UserAuthorization arg0 = LuaScriptMgr.GetNetObject<UserAuthorization>(L, 1);
		AsyncOperation o = Application.RequestUserAuthorization(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HasUserAuthorization(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UserAuthorization arg0 = LuaScriptMgr.GetNetObject<UserAuthorization>(L, 1);
		bool o = Application.HasUserAuthorization(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

