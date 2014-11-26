using UnityEngine;
using System;
using LuaInterface;

public class Texture2DWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("CreateExternalTexture", CreateExternalTexture),
		new LuaMethod("UpdateExternalTexture", UpdateExternalTexture),
		new LuaMethod("SetPixel", SetPixel),
		new LuaMethod("GetPixel", GetPixel),
		new LuaMethod("GetPixelBilinear", GetPixelBilinear),
		new LuaMethod("SetPixels", SetPixels),
		new LuaMethod("SetPixels32", SetPixels32),
		new LuaMethod("LoadImage", LoadImage),
		new LuaMethod("LoadRawTextureData", LoadRawTextureData),
		new LuaMethod("GetPixels", GetPixels),
		new LuaMethod("GetPixels32", GetPixels32),
		new LuaMethod("Apply", Apply),
		new LuaMethod("Resize", Resize),
		new LuaMethod("Compress", Compress),
		new LuaMethod("PackTextures", PackTextures),
		new LuaMethod("ReadPixels", ReadPixels),
		new LuaMethod("EncodeToPNG", EncodeToPNG),
		new LuaMethod("EncodeToJPG", EncodeToJPG),
		new LuaMethod("New", _CreateTexture2D),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("mipmapCount", get_mipmapCount, null),
		new LuaField("format", get_format, null),		
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateTexture2D(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			Texture2D obj = new Texture2D(arg0,arg1);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else if (count == 4)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			TextureFormat arg2 = LuaScriptMgr.GetNetObject<TextureFormat>(L, 3);
			bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
			Texture2D obj = new Texture2D(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else if (count == 5)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			TextureFormat arg2 = LuaScriptMgr.GetNetObject<TextureFormat>(L, 3);
			bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
			bool arg4 = LuaScriptMgr.GetBoolean(L, 5);
			Texture2D obj = new Texture2D(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Texture2D.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Texture2D));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Texture2D", typeof(Texture2D), regs, fields, "UnityEngine.Texture");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mipmapCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mipmapCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mipmapCount on a nil value");
			}
		}

		Texture2D obj = (Texture2D)o;
		LuaScriptMgr.Push(L, obj.mipmapCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_format(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name format");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index format on a nil value");
			}
		}

		Texture2D obj = (Texture2D)o;
		LuaScriptMgr.PushEnum(L, obj.format);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateExternalTexture(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 6);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		TextureFormat arg2 = LuaScriptMgr.GetNetObject<TextureFormat>(L, 3);
		bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
		bool arg4 = LuaScriptMgr.GetBoolean(L, 5);
		IntPtr arg5 = (IntPtr)LuaScriptMgr.GetNumber(L, 6);
		Texture2D o = Texture2D.CreateExternalTexture(arg0,arg1,arg2,arg3,arg4,arg5);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UpdateExternalTexture(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
		IntPtr arg0 = (IntPtr)LuaScriptMgr.GetNumber(L, 2);
		obj.UpdateExternalTexture(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetPixel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		Color arg2 = LuaScriptMgr.GetNetObject<Color>(L, 4);
		obj.SetPixel(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPixel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		Color o = obj.GetPixel(arg0,arg1);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPixelBilinear(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		Color o = obj.GetPixelBilinear(arg0,arg1);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetPixels(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			Color[] objs0 = LuaScriptMgr.GetArrayObject<Color>(L, 2);
			obj.SetPixels(objs0);
			return 0;
		}
		else if (count == 3)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			Color[] objs0 = LuaScriptMgr.GetArrayObject<Color>(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			obj.SetPixels(objs0,arg1);
			return 0;
		}
		else if (count == 6)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 5);
			Color[] objs4 = LuaScriptMgr.GetArrayObject<Color>(L, 6);
			obj.SetPixels(arg0,arg1,arg2,arg3,objs4);
			return 0;
		}
		else if (count == 7)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 5);
			Color[] objs4 = LuaScriptMgr.GetArrayObject<Color>(L, 6);
			int arg5 = (int)LuaScriptMgr.GetNumber(L, 7);
			obj.SetPixels(arg0,arg1,arg2,arg3,objs4,arg5);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Texture2D.SetPixels");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetPixels32(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			Color32[] objs0 = LuaScriptMgr.GetArrayObject<Color32>(L, 2);
			obj.SetPixels32(objs0);
			return 0;
		}
		else if (count == 3)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			Color32[] objs0 = LuaScriptMgr.GetArrayObject<Color32>(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			obj.SetPixels32(objs0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Texture2D.SetPixels32");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadImage(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
		byte[] objs0 = LuaScriptMgr.GetArrayNumber<byte>(L, 2);
		bool o = obj.LoadImage(objs0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadRawTextureData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
		byte[] objs0 = LuaScriptMgr.GetArrayNumber<byte>(L, 2);
		obj.LoadRawTextureData(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPixels(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			Color[] o = obj.GetPixels();
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Color[] o = obj.GetPixels(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 5);
			Color[] o = obj.GetPixels(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			int arg3 = (int)LuaScriptMgr.GetNumber(L, 5);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 6);
			Color[] o = obj.GetPixels(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Texture2D.GetPixels");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPixels32(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			Color32[] o = obj.GetPixels32();
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Color32[] o = obj.GetPixels32(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Texture2D.GetPixels32");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Apply(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			obj.Apply();
			return 0;
		}
		else if (count == 2)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			obj.Apply(arg0);
			return 0;
		}
		else if (count == 3)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			obj.Apply(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Texture2D.Apply");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Resize(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			bool o = obj.Resize(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			TextureFormat arg2 = LuaScriptMgr.GetNetObject<TextureFormat>(L, 4);
			bool arg3 = LuaScriptMgr.GetBoolean(L, 5);
			bool o = obj.Resize(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Texture2D.Resize");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Compress(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
		bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
		obj.Compress(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PackTextures(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			Texture2D[] objs0 = LuaScriptMgr.GetArrayObject<Texture2D>(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			Rect[] o = obj.PackTextures(objs0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			Texture2D[] objs0 = LuaScriptMgr.GetArrayObject<Texture2D>(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			Rect[] o = obj.PackTextures(objs0,arg1,arg2);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			Texture2D[] objs0 = LuaScriptMgr.GetArrayObject<Texture2D>(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			bool arg3 = LuaScriptMgr.GetBoolean(L, 5);
			Rect[] o = obj.PackTextures(objs0,arg1,arg2,arg3);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Texture2D.PackTextures");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReadPixels(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			Rect arg0 = LuaScriptMgr.GetNetObject<Rect>(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			obj.ReadPixels(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 5)
		{
			Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			Rect arg0 = LuaScriptMgr.GetNetObject<Rect>(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			bool arg3 = LuaScriptMgr.GetBoolean(L, 5);
			obj.ReadPixels(arg0,arg1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Texture2D.ReadPixels");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EncodeToPNG(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
		byte[] o = obj.EncodeToPNG();
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EncodeToJPG(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Texture2D obj = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
		byte[] o = obj.EncodeToJPG();
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}
}

