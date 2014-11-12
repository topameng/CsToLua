using System;
public static class LuaBinder
{
	public static void Bind(IntPtr L)
	{
		objectWrap.Register(L);
		ObjectWrap.Register(L);
		coroutineWrap.Register(L);
		TypeWrap.Register(L);
		TimeWrap.Register(L);
		Vector2Wrap.Register(L);
		Vector3Wrap.Register(L);
		GameObjectWrap.Register(L);
		ComponentWrap.Register(L);
		BehaviourWrap.Register(L);
		TransformWrap.Register(L);
		MonoBehaviourWrap.Register(L);
		ApplicationWrap.Register(L);
		KeyframeWrap.Register(L);
		AnimationCurveWrap.Register(L);
		TestToLuaWrap.Register(L);
		TestEnumWrap.Register(L);
		SpaceWrap.Register(L);
		LightWrap.Register(L);
		LightTypeWrap.Register(L);
		MotionWrap.Register(L);
		AnimationClipWrap.Register(L);
	}
}
