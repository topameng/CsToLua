using UnityEngine;
using System;
using LuaInterface;

public class ComputeBufferWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Dispose", Dispose),
		new LuaMethod("Release", Release),
		new LuaMethod("SetData", SetData),
		new LuaMethod("GetData", GetData),
		new LuaMethod("CopyCount", CopyCount),
		new LuaMethod("New", _CreateComputeBuffer),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("count", get_count, null),
		new LuaField("stride", get_stride, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateComputeBuffer(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			ComputeBuffer obj = new ComputeBuffer(arg0,arg1);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 3)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			ComputeBufferType arg2 = LuaScriptMgr.GetNetObject<ComputeBufferType>(L, 3);
			ComputeBuffer obj = new ComputeBuffer(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: ComputeBuffer.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ComputeBuffer));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ComputeBuffer", typeof(ComputeBuffer), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_count(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name count");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index count on a nil value");
			}
		}

		ComputeBuffer obj = (ComputeBuffer)o;
		LuaScriptMgr.Push(L, obj.count);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_stride(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name stride");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index stride on a nil value");
			}
		}

		ComputeBuffer obj = (ComputeBuffer)o;
		LuaScriptMgr.Push(L, obj.stride);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Dispose(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ComputeBuffer obj = LuaScriptMgr.GetNetObject<ComputeBuffer>(L, 1);
		obj.Dispose();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Release(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ComputeBuffer obj = LuaScriptMgr.GetNetObject<ComputeBuffer>(L, 1);
		obj.Release();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ComputeBuffer obj = LuaScriptMgr.GetNetObject<ComputeBuffer>(L, 1);
		Array arg0 = LuaScriptMgr.GetNetObject<Array>(L, 2);
		obj.SetData(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ComputeBuffer obj = LuaScriptMgr.GetNetObject<ComputeBuffer>(L, 1);
		Array arg0 = LuaScriptMgr.GetNetObject<Array>(L, 2);
		obj.GetData(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CopyCount(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		ComputeBuffer arg0 = LuaScriptMgr.GetNetObject<ComputeBuffer>(L, 1);
		ComputeBuffer arg1 = LuaScriptMgr.GetNetObject<ComputeBuffer>(L, 2);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
		ComputeBuffer.CopyCount(arg0,arg1,arg2);
		return 0;
	}
}

