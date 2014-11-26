using UnityEngine;
using System;
using LuaInterface;

public class MeshTopologyWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Triangles", MeshTopology.Triangles),
		new LuaEnum("Quads", MeshTopology.Quads),
		new LuaEnum("Lines", MeshTopology.Lines),
		new LuaEnum("LineStrip", MeshTopology.LineStrip),
		new LuaEnum("Points", MeshTopology.Points),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.MeshTopology", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.MeshTopology", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		MeshTopology o = (MeshTopology)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

