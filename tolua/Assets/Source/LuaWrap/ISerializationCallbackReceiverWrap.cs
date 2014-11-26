using UnityEngine;
using System;
using LuaInterface;

public class ISerializationCallbackReceiverWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("OnBeforeSerialize", OnBeforeSerialize),
		new LuaMethod("OnAfterDeserialize", OnAfterDeserialize),
		new LuaMethod("New", _CreateISerializationCallbackReceiver),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateISerializationCallbackReceiver(IntPtr L)
	{
		LuaDLL.luaL_error(L, "ISerializationCallbackReceiver class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ISerializationCallbackReceiver));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ISerializationCallbackReceiver", typeof(ISerializationCallbackReceiver), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnBeforeSerialize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ISerializationCallbackReceiver obj = LuaScriptMgr.GetNetObject<ISerializationCallbackReceiver>(L, 1);
		obj.OnBeforeSerialize();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnAfterDeserialize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ISerializationCallbackReceiver obj = LuaScriptMgr.GetNetObject<ISerializationCallbackReceiver>(L, 1);
		obj.OnAfterDeserialize();
		return 0;
	}
}

