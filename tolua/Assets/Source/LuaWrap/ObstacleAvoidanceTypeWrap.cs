using UnityEngine;
using System;
using LuaInterface;

public class ObstacleAvoidanceTypeWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("NoObstacleAvoidance", ObstacleAvoidanceType.NoObstacleAvoidance),
		new LuaEnum("LowQualityObstacleAvoidance", ObstacleAvoidanceType.LowQualityObstacleAvoidance),
		new LuaEnum("MedQualityObstacleAvoidance", ObstacleAvoidanceType.MedQualityObstacleAvoidance),
		new LuaEnum("GoodQualityObstacleAvoidance", ObstacleAvoidanceType.GoodQualityObstacleAvoidance),
		new LuaEnum("HighQualityObstacleAvoidance", ObstacleAvoidanceType.HighQualityObstacleAvoidance),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.ObstacleAvoidanceType", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.ObstacleAvoidanceType", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ObstacleAvoidanceType o = (ObstacleAvoidanceType)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

