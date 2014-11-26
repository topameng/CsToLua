using UnityEngine;
using System;
using LuaInterface;

public class OffMeshLinkTypeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("LinkTypeManual", OffMeshLinkType.LinkTypeManual),
		new LuaEnum("LinkTypeDropDown", OffMeshLinkType.LinkTypeDropDown),
		new LuaEnum("LinkTypeJumpAcross", OffMeshLinkType.LinkTypeJumpAcross),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.OffMeshLinkType", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.OffMeshLinkType", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		OffMeshLinkType o = (OffMeshLinkType)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

