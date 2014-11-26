using UnityEngine;
using System;
using LuaInterface;

public class HumanBodyBonesWrap
{
	static LuaEnum[] enums = new LuaEnum[]
	{
		new LuaEnum("Hips", HumanBodyBones.Hips),
		new LuaEnum("LeftUpperLeg", HumanBodyBones.LeftUpperLeg),
		new LuaEnum("RightUpperLeg", HumanBodyBones.RightUpperLeg),
		new LuaEnum("LeftLowerLeg", HumanBodyBones.LeftLowerLeg),
		new LuaEnum("RightLowerLeg", HumanBodyBones.RightLowerLeg),
		new LuaEnum("LeftFoot", HumanBodyBones.LeftFoot),
		new LuaEnum("RightFoot", HumanBodyBones.RightFoot),
		new LuaEnum("Spine", HumanBodyBones.Spine),
		new LuaEnum("Chest", HumanBodyBones.Chest),
		new LuaEnum("Neck", HumanBodyBones.Neck),
		new LuaEnum("Head", HumanBodyBones.Head),
		new LuaEnum("LeftShoulder", HumanBodyBones.LeftShoulder),
		new LuaEnum("RightShoulder", HumanBodyBones.RightShoulder),
		new LuaEnum("LeftUpperArm", HumanBodyBones.LeftUpperArm),
		new LuaEnum("RightUpperArm", HumanBodyBones.RightUpperArm),
		new LuaEnum("LeftLowerArm", HumanBodyBones.LeftLowerArm),
		new LuaEnum("RightLowerArm", HumanBodyBones.RightLowerArm),
		new LuaEnum("LeftHand", HumanBodyBones.LeftHand),
		new LuaEnum("RightHand", HumanBodyBones.RightHand),
		new LuaEnum("LeftToes", HumanBodyBones.LeftToes),
		new LuaEnum("RightToes", HumanBodyBones.RightToes),
		new LuaEnum("LeftEye", HumanBodyBones.LeftEye),
		new LuaEnum("RightEye", HumanBodyBones.RightEye),
		new LuaEnum("Jaw", HumanBodyBones.Jaw),
		new LuaEnum("LeftThumbProximal", HumanBodyBones.LeftThumbProximal),
		new LuaEnum("LeftThumbIntermediate", HumanBodyBones.LeftThumbIntermediate),
		new LuaEnum("LeftThumbDistal", HumanBodyBones.LeftThumbDistal),
		new LuaEnum("LeftIndexProximal", HumanBodyBones.LeftIndexProximal),
		new LuaEnum("LeftIndexIntermediate", HumanBodyBones.LeftIndexIntermediate),
		new LuaEnum("LeftIndexDistal", HumanBodyBones.LeftIndexDistal),
		new LuaEnum("LeftMiddleProximal", HumanBodyBones.LeftMiddleProximal),
		new LuaEnum("LeftMiddleIntermediate", HumanBodyBones.LeftMiddleIntermediate),
		new LuaEnum("LeftMiddleDistal", HumanBodyBones.LeftMiddleDistal),
		new LuaEnum("LeftRingProximal", HumanBodyBones.LeftRingProximal),
		new LuaEnum("LeftRingIntermediate", HumanBodyBones.LeftRingIntermediate),
		new LuaEnum("LeftRingDistal", HumanBodyBones.LeftRingDistal),
		new LuaEnum("LeftLittleProximal", HumanBodyBones.LeftLittleProximal),
		new LuaEnum("LeftLittleIntermediate", HumanBodyBones.LeftLittleIntermediate),
		new LuaEnum("LeftLittleDistal", HumanBodyBones.LeftLittleDistal),
		new LuaEnum("RightThumbProximal", HumanBodyBones.RightThumbProximal),
		new LuaEnum("RightThumbIntermediate", HumanBodyBones.RightThumbIntermediate),
		new LuaEnum("RightThumbDistal", HumanBodyBones.RightThumbDistal),
		new LuaEnum("RightIndexProximal", HumanBodyBones.RightIndexProximal),
		new LuaEnum("RightIndexIntermediate", HumanBodyBones.RightIndexIntermediate),
		new LuaEnum("RightIndexDistal", HumanBodyBones.RightIndexDistal),
		new LuaEnum("RightMiddleProximal", HumanBodyBones.RightMiddleProximal),
		new LuaEnum("RightMiddleIntermediate", HumanBodyBones.RightMiddleIntermediate),
		new LuaEnum("RightMiddleDistal", HumanBodyBones.RightMiddleDistal),
		new LuaEnum("RightRingProximal", HumanBodyBones.RightRingProximal),
		new LuaEnum("RightRingIntermediate", HumanBodyBones.RightRingIntermediate),
		new LuaEnum("RightRingDistal", HumanBodyBones.RightRingDistal),
		new LuaEnum("RightLittleProximal", HumanBodyBones.RightLittleProximal),
		new LuaEnum("RightLittleIntermediate", HumanBodyBones.RightLittleIntermediate),
		new LuaEnum("RightLittleDistal", HumanBodyBones.RightLittleDistal),
		new LuaEnum("LastBone", HumanBodyBones.LastBone),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.HumanBodyBones", enums);
		LuaScriptMgr.RegisterFunc(L, "UnityEngine.HumanBodyBones", IntToEnum, "IntToEnum");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		HumanBodyBones o = (HumanBodyBones)arg0;
		LuaScriptMgr.PushEnum(L, o);
		return 1;
	}
}

