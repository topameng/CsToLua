using UnityEngine;
using System;
using System.Text;
using LuaInterface;

public class WWWFormWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("AddField", AddField),
		new LuaMethod("AddBinaryData", AddBinaryData),
		new LuaMethod("New", _CreateWWWForm),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("headers", get_headers, null),
		new LuaField("data", get_data, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateWWWForm(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			WWWForm obj = new WWWForm();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: WWWForm.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(WWWForm));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.WWWForm", typeof(WWWForm), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_headers(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name headers");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index headers on a nil value");
			}
		}

		WWWForm obj = (WWWForm)o;
		LuaScriptMgr.PushObject(L, obj.headers);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_data(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name data");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index data on a nil value");
			}
		}

		WWWForm obj = (WWWForm)o;
		LuaScriptMgr.PushArray(L, obj.data);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddField(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(WWWForm), typeof(string), typeof(int)};
		Type[] types1 = {typeof(WWWForm), typeof(string), typeof(string)};

		if (count == 3 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			WWWForm obj = LuaScriptMgr.GetNetObject<WWWForm>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
			obj.AddField(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			WWWForm obj = LuaScriptMgr.GetNetObject<WWWForm>(L, 1);
			string arg0 = LuaScriptMgr.GetString(L, 2);
			string arg1 = LuaScriptMgr.GetString(L, 3);
			obj.AddField(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			WWWForm obj = LuaScriptMgr.GetNetObject<WWWForm>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			string arg1 = LuaScriptMgr.GetLuaString(L, 3);
			Encoding arg2 = LuaScriptMgr.GetNetObject<Encoding>(L, 4);
			obj.AddField(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: WWWForm.AddField");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddBinaryData(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			WWWForm obj = LuaScriptMgr.GetNetObject<WWWForm>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			byte[] objs1 = LuaScriptMgr.GetArrayNumber<byte>(L, 3);
			obj.AddBinaryData(arg0,objs1);
			return 0;
		}
		else if (count == 4)
		{
			WWWForm obj = LuaScriptMgr.GetNetObject<WWWForm>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			byte[] objs1 = LuaScriptMgr.GetArrayNumber<byte>(L, 3);
			string arg2 = LuaScriptMgr.GetLuaString(L, 4);
			obj.AddBinaryData(arg0,objs1,arg2);
			return 0;
		}
		else if (count == 5)
		{
			WWWForm obj = LuaScriptMgr.GetNetObject<WWWForm>(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			byte[] objs1 = LuaScriptMgr.GetArrayNumber<byte>(L, 3);
			string arg2 = LuaScriptMgr.GetLuaString(L, 4);
			string arg3 = LuaScriptMgr.GetLuaString(L, 5);
			obj.AddBinaryData(arg0,objs1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: WWWForm.AddBinaryData");
		}

		return 0;
	}
}

