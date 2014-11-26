using UnityEngine;
using System;
using LuaInterface;

public class FontWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("HasCharacter", HasCharacter),
		new LuaMethod("RequestCharactersInTexture", RequestCharactersInTexture),
		new LuaMethod("GetMaxVertsForString", GetMaxVertsForString),
		new LuaMethod("GetCharacterInfo", GetCharacterInfo),
		new LuaMethod("New", _CreateFont),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("material", get_material, set_material),
		new LuaField("fontNames", get_fontNames, set_fontNames),
		new LuaField("characterInfo", get_characterInfo, set_characterInfo),
		new LuaField("textureRebuildCallback", get_textureRebuildCallback, set_textureRebuildCallback),
		new LuaField("dynamic", get_dynamic, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateFont(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Font obj = new Font();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else if (count == 1)
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			Font obj = new Font(arg0);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Font.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Font));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Font", typeof(Font), regs, fields, "UnityEngine.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_material(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name material");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index material on a nil value");
			}
		}

		Font obj = (Font)o;
		LuaScriptMgr.Push(L, obj.material);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fontNames(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fontNames");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fontNames on a nil value");
			}
		}

		Font obj = (Font)o;
		LuaScriptMgr.PushArray(L, obj.fontNames);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_characterInfo(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name characterInfo");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index characterInfo on a nil value");
			}
		}

		Font obj = (Font)o;
		LuaScriptMgr.PushArray(L, obj.characterInfo);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_textureRebuildCallback(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name textureRebuildCallback");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index textureRebuildCallback on a nil value");
			}
		}

		Font obj = (Font)o;
		LuaScriptMgr.PushObject(L, obj.textureRebuildCallback);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dynamic(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dynamic");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dynamic on a nil value");
			}
		}

		Font obj = (Font)o;
		LuaScriptMgr.Push(L, obj.dynamic);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_material(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name material");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index material on a nil value");
			}
		}

		Font obj = (Font)o;
		obj.material = LuaScriptMgr.GetNetObject<Material>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fontNames(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fontNames");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fontNames on a nil value");
			}
		}

		Font obj = (Font)o;
		obj.fontNames = LuaScriptMgr.GetNetObject<String[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_characterInfo(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name characterInfo");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index characterInfo on a nil value");
			}
		}

		Font obj = (Font)o;
		obj.characterInfo = LuaScriptMgr.GetNetObject<CharacterInfo[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_textureRebuildCallback(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name textureRebuildCallback");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index textureRebuildCallback on a nil value");
			}
		}

		Font obj = (Font)o;
		obj.textureRebuildCallback = LuaScriptMgr.GetNetObject<UnityEngine.Font.FontTextureRebuildCallback>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HasCharacter(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Font obj = LuaScriptMgr.GetNetObject<Font>(L, 1);
		char arg0 = (char)LuaScriptMgr.GetNumber(L, 2);
		bool o = obj.HasCharacter(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RequestCharactersInTexture(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Font obj = LuaScriptMgr.GetNetObject<Font>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.RequestCharactersInTexture(arg0);
			return 0;
		}
		else if (count == 3)
		{
			Font obj = LuaScriptMgr.GetNetObject<Font>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			obj.RequestCharactersInTexture(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			Font obj = LuaScriptMgr.GetNetObject<Font>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			FontStyle arg2 = LuaScriptMgr.GetNetObject<FontStyle>(L, 4);
			obj.RequestCharactersInTexture(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Font.RequestCharactersInTexture");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMaxVertsForString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		int o = Font.GetMaxVertsForString(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetCharacterInfo(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Font obj = LuaScriptMgr.GetNetObject<Font>(L, 1);
			char arg0 = (char)LuaScriptMgr.GetNumber(L, 2);
			CharacterInfo arg1 = LuaScriptMgr.GetNetObject<CharacterInfo>(L, 3);
			bool o = obj.GetCharacterInfo(arg0,out arg1);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg1);
			return 2;
		}
		else if (count == 4)
		{
			Font obj = LuaScriptMgr.GetNetObject<Font>(L, 1);
			char arg0 = (char)LuaScriptMgr.GetNumber(L, 2);
			CharacterInfo arg1 = LuaScriptMgr.GetNetObject<CharacterInfo>(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			bool o = obj.GetCharacterInfo(arg0,out arg1,arg2);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg1);
			return 2;
		}
		else if (count == 5)
		{
			Font obj = LuaScriptMgr.GetNetObject<Font>(L, 1);
			char arg0 = (char)LuaScriptMgr.GetNumber(L, 2);
			CharacterInfo arg1 = LuaScriptMgr.GetNetObject<CharacterInfo>(L, 3);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
			FontStyle arg3 = LuaScriptMgr.GetNetObject<FontStyle>(L, 5);
			bool o = obj.GetCharacterInfo(arg0,out arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			LuaScriptMgr.PushValue(L, arg1);
			return 2;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Font.GetCharacterInfo");
		}

		return 0;
	}
}

