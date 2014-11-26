using UnityEngine;
using System;
using UnityEngine.Rendering;
using LuaInterface;

public class BlendOpWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Add", BlendOp.Add),
		new LuaEnum("Subtract", BlendOp.Subtract),
		new LuaEnum("ReverseSubtract", BlendOp.ReverseSubtract),
		new LuaEnum("Min", BlendOp.Min),
		new LuaEnum("Max", BlendOp.Max),
		new LuaEnum("LogicalClear", BlendOp.LogicalClear),
		new LuaEnum("LogicalSet", BlendOp.LogicalSet),
		new LuaEnum("LogicalCopy", BlendOp.LogicalCopy),
		new LuaEnum("LogicalCopyInverted", BlendOp.LogicalCopyInverted),
		new LuaEnum("LogicalNoop", BlendOp.LogicalNoop),
		new LuaEnum("LogicalInvert", BlendOp.LogicalInvert),
		new LuaEnum("LogicalAnd", BlendOp.LogicalAnd),
		new LuaEnum("LogicalNand", BlendOp.LogicalNand),
		new LuaEnum("LogicalOr", BlendOp.LogicalOr),
		new LuaEnum("LogicalNor", BlendOp.LogicalNor),
		new LuaEnum("LogicalXor", BlendOp.LogicalXor),
		new LuaEnum("LogicalEquivalence", BlendOp.LogicalEquivalence),
		new LuaEnum("LogicalAndReverse", BlendOp.LogicalAndReverse),
		new LuaEnum("LogicalAndInverted", BlendOp.LogicalAndInverted),
		new LuaEnum("LogicalOrReverse", BlendOp.LogicalOrReverse),
		new LuaEnum("LogicalOrInverted", BlendOp.LogicalOrInverted),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.Rendering.BlendOp", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.Rendering.BlendOp", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		BlendOp o = (BlendOp)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

