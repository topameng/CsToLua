using System;
using LuaInterface;

public class MsgPacketWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("PushLuaString", PushLuaString),
		new LuaMethod("New", _CreateMsgPacket),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("id", get_id, set_id),
		new LuaField("seq", get_seq, set_seq),
		new LuaField("errno", get_errno, set_errno),
		new LuaField("data", get_data, set_data),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMsgPacket(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			MsgPacket obj = new MsgPacket();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MsgPacket.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(MsgPacket));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "MsgPacket", typeof(MsgPacket), regs, fields, typeof(System.Object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_id(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MsgPacket obj = (MsgPacket)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name id");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index id on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.id);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_seq(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MsgPacket obj = (MsgPacket)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name seq");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index seq on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.seq);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_errno(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MsgPacket obj = (MsgPacket)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name errno");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index errno on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.errno);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_data(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MsgPacket obj = (MsgPacket)o;

		if (obj == null)
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

		LuaScriptMgr.PushArray(L, obj.data);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_id(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MsgPacket obj = (MsgPacket)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name id");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index id on a nil value");
			}
		}

		obj.id = (ushort)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_seq(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MsgPacket obj = (MsgPacket)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name seq");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index seq on a nil value");
			}
		}

		obj.seq = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_errno(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MsgPacket obj = (MsgPacket)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name errno");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index errno on a nil value");
			}
		}

		obj.errno = (ushort)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_data(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MsgPacket obj = (MsgPacket)o;

		if (obj == null)
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

		obj.data = LuaScriptMgr.GetNetObject<Byte[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PushLuaString(IntPtr L)
	{
	        MsgPacket obj = LuaScriptMgr.GetNetObject<MsgPacket>(L, 1);
        	obj.PushLuaString(L);
		return 1;
	}
}

