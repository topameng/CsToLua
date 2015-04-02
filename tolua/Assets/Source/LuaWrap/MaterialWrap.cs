using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class MaterialWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("SetColor", SetColor),
		new LuaMethod("GetColor", GetColor),
		new LuaMethod("SetVector", SetVector),
		new LuaMethod("GetVector", GetVector),
		new LuaMethod("SetTexture", SetTexture),
		new LuaMethod("GetTexture", GetTexture),
		new LuaMethod("SetTextureOffset", SetTextureOffset),
		new LuaMethod("GetTextureOffset", GetTextureOffset),
		new LuaMethod("SetTextureScale", SetTextureScale),
		new LuaMethod("GetTextureScale", GetTextureScale),
		new LuaMethod("SetMatrix", SetMatrix),
		new LuaMethod("GetMatrix", GetMatrix),
		new LuaMethod("SetFloat", SetFloat),
		new LuaMethod("GetFloat", GetFloat),
		new LuaMethod("SetInt", SetInt),
		new LuaMethod("GetInt", GetInt),
		new LuaMethod("SetBuffer", SetBuffer),
		new LuaMethod("HasProperty", HasProperty),
		new LuaMethod("GetTag", GetTag),
		new LuaMethod("Lerp", Lerp),
		new LuaMethod("SetPass", SetPass),
		new LuaMethod("CopyPropertiesFromMaterial", CopyPropertiesFromMaterial),
		new LuaMethod("EnableKeyword", EnableKeyword),
		new LuaMethod("DisableKeyword", DisableKeyword),
		new LuaMethod("New", _CreateMaterial),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__eq", Lua_Eq),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("shader", get_shader, set_shader),
		new LuaField("color", get_color, set_color),
		new LuaField("mainTexture", get_mainTexture, set_mainTexture),
		new LuaField("mainTextureOffset", get_mainTextureOffset, set_mainTextureOffset),
		new LuaField("mainTextureScale", get_mainTextureScale, set_mainTextureScale),
		new LuaField("passCount", get_passCount, null),
		new LuaField("renderQueue", get_renderQueue, set_renderQueue),
		new LuaField("shaderKeywords", get_shaderKeywords, set_shaderKeywords),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMaterial(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);


		if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material)))
		{
			Material arg0 = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			Material obj = new Material(arg0);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(Shader)))
		{
			Shader arg0 = LuaScriptMgr.GetUnityObject<Shader>(L, 1);
			Material obj = new Material(arg0);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(string)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			Material obj = new Material(arg0);
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Material));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Material", typeof(Material), regs, fields, typeof(UnityEngine.Object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shader(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shader");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shader on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.shader);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_color(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name color");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index color on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.color);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainTexture(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTexture on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mainTexture);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainTextureOffset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTextureOffset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTextureOffset on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mainTextureOffset);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainTextureScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTextureScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTextureScale on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mainTextureScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_passCount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name passCount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index passCount on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.passCount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_renderQueue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name renderQueue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index renderQueue on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.renderQueue);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shaderKeywords(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shaderKeywords");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shaderKeywords on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.shaderKeywords);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shader(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shader");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shader on a nil value");
			}
		}

		obj.shader = LuaScriptMgr.GetUnityObject<Shader>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_color(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name color");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index color on a nil value");
			}
		}

		obj.color = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mainTexture(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTexture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTexture on a nil value");
			}
		}

		obj.mainTexture = LuaScriptMgr.GetUnityObject<Texture>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mainTextureOffset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTextureOffset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTextureOffset on a nil value");
			}
		}

		obj.mainTextureOffset = LuaScriptMgr.GetVector2(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mainTextureScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainTextureScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainTextureScale on a nil value");
			}
		}

		obj.mainTextureScale = LuaScriptMgr.GetVector2(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_renderQueue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name renderQueue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index renderQueue on a nil value");
			}
		}

		obj.renderQueue = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shaderKeywords(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Material obj = (Material)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shaderKeywords");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shaderKeywords on a nil value");
			}
		}

		obj.shaderKeywords = LuaScriptMgr.GetNetObject<String[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetColor(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(LuaTable)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Color arg1 = LuaScriptMgr.GetColor(L, 3);
			obj.SetColor(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(LuaTable)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Color arg1 = LuaScriptMgr.GetColor(L, 3);
			obj.SetColor(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetColor");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetColor(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Color o = obj.GetColor(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Color o = obj.GetColor(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetColor");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetVector(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(LuaTable)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Vector4 arg1 = LuaScriptMgr.GetVector4(L, 3);
			obj.SetVector(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(LuaTable)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Vector4 arg1 = LuaScriptMgr.GetVector4(L, 3);
			obj.SetVector(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetVector");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetVector(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Vector4 o = obj.GetVector(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Vector4 o = obj.GetVector(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetVector");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTexture(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(Texture)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Texture arg1 = LuaScriptMgr.GetUnityObject<Texture>(L, 3);
			obj.SetTexture(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(Texture)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Texture arg1 = LuaScriptMgr.GetUnityObject<Texture>(L, 3);
			obj.SetTexture(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetTexture");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTexture(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Texture o = obj.GetTexture(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Texture o = obj.GetTexture(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetTexture");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTextureOffset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Vector2 arg1 = LuaScriptMgr.GetVector2(L, 3);
		obj.SetTextureOffset(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTextureOffset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Vector2 o = obj.GetTextureOffset(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTextureScale(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Vector2 arg1 = LuaScriptMgr.GetVector2(L, 3);
		obj.SetTextureScale(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTextureScale(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Vector2 o = obj.GetTextureScale(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetMatrix(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(Matrix4x4)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Matrix4x4 arg1 = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 3);
			obj.SetMatrix(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(Matrix4x4)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Matrix4x4 arg1 = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 3);
			obj.SetMatrix(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetMatrix");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMatrix(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Matrix4x4 o = obj.GetMatrix(arg0);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Matrix4x4 o = obj.GetMatrix(arg0);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetMatrix");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetFloat(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(float)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			obj.SetFloat(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(float)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			obj.SetFloat(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetFloat");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFloat(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			float o = obj.GetFloat(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			float o = obj.GetFloat(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetFloat");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetInt(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int), typeof(int)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			obj.SetInt(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string), typeof(int)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			obj.SetInt(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetInt");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInt(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			int o = obj.GetInt(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			int o = obj.GetInt(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetInt");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetBuffer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		ComputeBuffer arg1 = LuaScriptMgr.GetNetObject<ComputeBuffer>(L, 3);
		obj.SetBuffer(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HasProperty(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(int)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			bool o = obj.HasProperty(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Material), typeof(string)))
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			bool o = obj.HasProperty(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.HasProperty");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTag(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		if (count == 3)
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			string o = obj.GetTag(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			string arg2 = LuaScriptMgr.GetLuaString(L, 4);
			string o = obj.GetTag(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetTag");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lerp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
		Material arg0 = LuaScriptMgr.GetUnityObject<Material>(L, 2);
		Material arg1 = LuaScriptMgr.GetUnityObject<Material>(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		obj.Lerp(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetPass(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		bool o = obj.SetPass(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CopyPropertiesFromMaterial(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
		Material arg0 = LuaScriptMgr.GetUnityObject<Material>(L, 2);
		obj.CopyPropertiesFromMaterial(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EnableKeyword(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.EnableKeyword(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DisableKeyword(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Material obj = LuaScriptMgr.GetUnityObject<Material>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.DisableKeyword(arg0);
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

