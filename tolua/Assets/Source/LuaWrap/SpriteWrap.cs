using UnityEngine;
using System;
using LuaInterface;

public class SpriteWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Create", Create),
		new LuaMethod("New", _CreateSprite),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("bounds", get_bounds, null),
		new LuaField("rect", get_rect, null),
		new LuaField("texture", get_texture, null),
		new LuaField("textureRect", get_textureRect, null),
		new LuaField("textureRectOffset", get_textureRectOffset, null),
		new LuaField("packed", get_packed, null),
		new LuaField("packingMode", get_packingMode, null),
		new LuaField("packingRotation", get_packingRotation, null),
		new LuaField("border", get_border, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSprite(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Sprite obj = new Sprite();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Sprite.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Sprite));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Sprite", typeof(Sprite), regs, fields, "UnityEngine.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_bounds(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name bounds");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index bounds on a nil value");
			}
		}

		Sprite obj = (Sprite)o;
		LuaScriptMgr.PushValue(L, obj.bounds);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rect on a nil value");
			}
		}

		Sprite obj = (Sprite)o;
		LuaScriptMgr.PushValue(L, obj.rect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_texture(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name texture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index texture on a nil value");
			}
		}

		Sprite obj = (Sprite)o;
		LuaScriptMgr.Push(L, obj.texture);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_textureRect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name textureRect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index textureRect on a nil value");
			}
		}

		Sprite obj = (Sprite)o;
		LuaScriptMgr.PushValue(L, obj.textureRect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_textureRectOffset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name textureRectOffset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index textureRectOffset on a nil value");
			}
		}

		Sprite obj = (Sprite)o;
		LuaScriptMgr.PushValue(L, obj.textureRectOffset);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_packed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name packed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index packed on a nil value");
			}
		}

		Sprite obj = (Sprite)o;
		LuaScriptMgr.Push(L, obj.packed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_packingMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name packingMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index packingMode on a nil value");
			}
		}

		Sprite obj = (Sprite)o;
		LuaScriptMgr.PushEnum(L, obj.packingMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_packingRotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name packingRotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index packingRotation on a nil value");
			}
		}

		Sprite obj = (Sprite)o;
		LuaScriptMgr.PushEnum(L, obj.packingRotation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_border(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name border");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index border on a nil value");
			}
		}

		Sprite obj = (Sprite)o;
		LuaScriptMgr.PushValue(L, obj.border);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			Texture2D arg0 = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			Rect arg1 = LuaScriptMgr.GetNetObject<Rect>(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			Sprite o = Sprite.Create(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Texture2D arg0 = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			Rect arg1 = LuaScriptMgr.GetNetObject<Rect>(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			Sprite o = Sprite.Create(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			Texture2D arg0 = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			Rect arg1 = LuaScriptMgr.GetNetObject<Rect>(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			uint arg4 = (uint)LuaScriptMgr.GetNumber(L, 5);
			Sprite o = Sprite.Create(arg0,arg1,arg2,arg3,arg4);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 6)
		{
			Texture2D arg0 = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			Rect arg1 = LuaScriptMgr.GetNetObject<Rect>(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			uint arg4 = (uint)LuaScriptMgr.GetNumber(L, 5);
			SpriteMeshType arg5 = LuaScriptMgr.GetNetObject<SpriteMeshType>(L, 6);
			Sprite o = Sprite.Create(arg0,arg1,arg2,arg3,arg4,arg5);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 7)
		{
			Texture2D arg0 = LuaScriptMgr.GetNetObject<Texture2D>(L, 1);
			Rect arg1 = LuaScriptMgr.GetNetObject<Rect>(L, 2);
			Vector2 arg2 = LuaScriptMgr.GetNetObject<Vector2>(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			uint arg4 = (uint)LuaScriptMgr.GetNumber(L, 5);
			SpriteMeshType arg5 = LuaScriptMgr.GetNetObject<SpriteMeshType>(L, 6);
			Vector4 arg6 = LuaScriptMgr.GetNetObject<Vector4>(L, 7);
			Sprite o = Sprite.Create(arg0,arg1,arg2,arg3,arg4,arg5,arg6);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Sprite.Create");
		}

		return 0;
	}
}

