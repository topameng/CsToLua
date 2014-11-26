using UnityEngine;
using System;
using LuaInterface;

public class MaterialPropertyBlockWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("AddFloat", AddFloat),
		new LuaMethod("AddVector", AddVector),
		new LuaMethod("AddColor", AddColor),
		new LuaMethod("AddMatrix", AddMatrix),
		new LuaMethod("AddTexture", AddTexture),
		new LuaMethod("GetFloat", GetFloat),
		new LuaMethod("GetVector", GetVector),
		new LuaMethod("GetMatrix", GetMatrix),
		new LuaMethod("GetTexture", GetTexture),
		new LuaMethod("Clear", Clear),
		new LuaMethod("New", _CreateMaterialPropertyBlock),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMaterialPropertyBlock(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			MaterialPropertyBlock obj = new MaterialPropertyBlock();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MaterialPropertyBlock.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(MaterialPropertyBlock));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.MaterialPropertyBlock", typeof(MaterialPropertyBlock), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddFloat(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(MaterialPropertyBlock), typeof(int), typeof(float)};
		Type[] types1 = {typeof(MaterialPropertyBlock), typeof(string), typeof(float)};

		if (count == 3 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			MaterialPropertyBlock obj = LuaScriptMgr.GetNetObject<MaterialPropertyBlock>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			obj.AddFloat(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			MaterialPropertyBlock obj = LuaScriptMgr.GetNetObject<MaterialPropertyBlock>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			obj.AddFloat(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MaterialPropertyBlock.AddFloat");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddVector(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(MaterialPropertyBlock), typeof(int), typeof(Vector4)};
		Type[] types1 = {typeof(MaterialPropertyBlock), typeof(string), typeof(Vector4)};

		if (count == 3 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			MaterialPropertyBlock obj = LuaScriptMgr.GetNetObject<MaterialPropertyBlock>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Vector4 arg1 = LuaScriptMgr.GetNetObject<Vector4>(L, 3);
			obj.AddVector(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			MaterialPropertyBlock obj = LuaScriptMgr.GetNetObject<MaterialPropertyBlock>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Vector4 arg1 = LuaScriptMgr.GetNetObject<Vector4>(L, 3);
			obj.AddVector(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MaterialPropertyBlock.AddVector");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddColor(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(MaterialPropertyBlock), typeof(int), typeof(Color)};
		Type[] types1 = {typeof(MaterialPropertyBlock), typeof(string), typeof(Color)};

		if (count == 3 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			MaterialPropertyBlock obj = LuaScriptMgr.GetNetObject<MaterialPropertyBlock>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Color arg1 = LuaScriptMgr.GetNetObject<Color>(L, 3);
			obj.AddColor(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			MaterialPropertyBlock obj = LuaScriptMgr.GetNetObject<MaterialPropertyBlock>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Color arg1 = LuaScriptMgr.GetNetObject<Color>(L, 3);
			obj.AddColor(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MaterialPropertyBlock.AddColor");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddMatrix(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(MaterialPropertyBlock), typeof(int), typeof(Matrix4x4)};
		Type[] types1 = {typeof(MaterialPropertyBlock), typeof(string), typeof(Matrix4x4)};

		if (count == 3 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			MaterialPropertyBlock obj = LuaScriptMgr.GetNetObject<MaterialPropertyBlock>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Matrix4x4 arg1 = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 3);
			obj.AddMatrix(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			MaterialPropertyBlock obj = LuaScriptMgr.GetNetObject<MaterialPropertyBlock>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Matrix4x4 arg1 = LuaScriptMgr.GetNetObject<Matrix4x4>(L, 3);
			obj.AddMatrix(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MaterialPropertyBlock.AddMatrix");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddTexture(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(MaterialPropertyBlock), typeof(int), typeof(Texture)};
		Type[] types1 = {typeof(MaterialPropertyBlock), typeof(string), typeof(Texture)};

		if (count == 3 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			MaterialPropertyBlock obj = LuaScriptMgr.GetNetObject<MaterialPropertyBlock>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Texture arg1 = LuaScriptMgr.GetNetObject<Texture>(L, 3);
			obj.AddTexture(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			MaterialPropertyBlock obj = LuaScriptMgr.GetNetObject<MaterialPropertyBlock>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Texture arg1 = LuaScriptMgr.GetNetObject<Texture>(L, 3);
			obj.AddTexture(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MaterialPropertyBlock.AddTexture");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFloat(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(MaterialPropertyBlock), typeof(int)};
		Type[] types1 = {typeof(MaterialPropertyBlock), typeof(string)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			MaterialPropertyBlock obj = LuaScriptMgr.GetNetObject<MaterialPropertyBlock>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			float o = obj.GetFloat(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			MaterialPropertyBlock obj = LuaScriptMgr.GetNetObject<MaterialPropertyBlock>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			float o = obj.GetFloat(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MaterialPropertyBlock.GetFloat");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetVector(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(MaterialPropertyBlock), typeof(int)};
		Type[] types1 = {typeof(MaterialPropertyBlock), typeof(string)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			MaterialPropertyBlock obj = LuaScriptMgr.GetNetObject<MaterialPropertyBlock>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Vector4 o = obj.GetVector(arg0);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			MaterialPropertyBlock obj = LuaScriptMgr.GetNetObject<MaterialPropertyBlock>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Vector4 o = obj.GetVector(arg0);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MaterialPropertyBlock.GetVector");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMatrix(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(MaterialPropertyBlock), typeof(int)};
		Type[] types1 = {typeof(MaterialPropertyBlock), typeof(string)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			MaterialPropertyBlock obj = LuaScriptMgr.GetNetObject<MaterialPropertyBlock>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Matrix4x4 o = obj.GetMatrix(arg0);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			MaterialPropertyBlock obj = LuaScriptMgr.GetNetObject<MaterialPropertyBlock>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Matrix4x4 o = obj.GetMatrix(arg0);
			LuaScriptMgr.PushValue(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MaterialPropertyBlock.GetMatrix");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTexture(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(MaterialPropertyBlock), typeof(int)};
		Type[] types1 = {typeof(MaterialPropertyBlock), typeof(string)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			MaterialPropertyBlock obj = LuaScriptMgr.GetNetObject<MaterialPropertyBlock>(L, 1);
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
			Texture o = obj.GetTexture(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			MaterialPropertyBlock obj = LuaScriptMgr.GetNetObject<MaterialPropertyBlock>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Texture o = obj.GetTexture(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MaterialPropertyBlock.GetTexture");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clear(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		MaterialPropertyBlock obj = LuaScriptMgr.GetNetObject<MaterialPropertyBlock>(L, 1);
		obj.Clear();
		return 0;
	}
}

