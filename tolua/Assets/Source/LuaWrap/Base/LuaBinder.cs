using System;
public static class LuaBinder
{
	public static void Bind(IntPtr L)
	{
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
	}
}
