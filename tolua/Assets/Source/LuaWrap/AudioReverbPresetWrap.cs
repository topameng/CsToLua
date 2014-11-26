using UnityEngine;
using System;
using LuaInterface;

public class AudioReverbPresetWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Off", AudioReverbPreset.Off),
		new LuaEnum("Generic", AudioReverbPreset.Generic),
		new LuaEnum("PaddedCell", AudioReverbPreset.PaddedCell),
		new LuaEnum("Room", AudioReverbPreset.Room),
		new LuaEnum("Bathroom", AudioReverbPreset.Bathroom),
		new LuaEnum("Livingroom", AudioReverbPreset.Livingroom),
		new LuaEnum("Stoneroom", AudioReverbPreset.Stoneroom),
		new LuaEnum("Auditorium", AudioReverbPreset.Auditorium),
		new LuaEnum("Concerthall", AudioReverbPreset.Concerthall),
		new LuaEnum("Cave", AudioReverbPreset.Cave),
		new LuaEnum("Arena", AudioReverbPreset.Arena),
		new LuaEnum("Hangar", AudioReverbPreset.Hangar),
		new LuaEnum("CarpetedHallway", AudioReverbPreset.CarpetedHallway),
		new LuaEnum("Hallway", AudioReverbPreset.Hallway),
		new LuaEnum("StoneCorridor", AudioReverbPreset.StoneCorridor),
		new LuaEnum("Alley", AudioReverbPreset.Alley),
		new LuaEnum("Forest", AudioReverbPreset.Forest),
		new LuaEnum("City", AudioReverbPreset.City),
		new LuaEnum("Mountains", AudioReverbPreset.Mountains),
		new LuaEnum("Quarry", AudioReverbPreset.Quarry),
		new LuaEnum("Plain", AudioReverbPreset.Plain),
		new LuaEnum("ParkingLot", AudioReverbPreset.ParkingLot),
		new LuaEnum("SewerPipe", AudioReverbPreset.SewerPipe),
		new LuaEnum("Underwater", AudioReverbPreset.Underwater),
		new LuaEnum("Drugged", AudioReverbPreset.Drugged),
		new LuaEnum("Dizzy", AudioReverbPreset.Dizzy),
		new LuaEnum("Psychotic", AudioReverbPreset.Psychotic),
		new LuaEnum("User", AudioReverbPreset.User),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.AudioReverbPreset", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.AudioReverbPreset", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		AudioReverbPreset o = (AudioReverbPreset)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

