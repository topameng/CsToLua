using System;
using UnityEngine;

public static class LuaBinder
{
	public static void Bind(IntPtr L)
	{
        objectWrap.Register(L);
        ObjectWrap.Register(L);
        TypeWrap.Register(L);
        DelegateWrap.Register(L);
        IEnumeratorWrap.Register(L);
        EnumWrap.Register(L);
        StringWrap.Register(L);
        MsgPacketWrap.Register(L);

        DebuggerWrap.Register(L);

        float time = Time.realtimeSinceStartup;
        //u3d				
        ComponentWrap.Register(L);
        BehaviourWrap.Register(L);
        MonoBehaviourWrap.Register(L);
        GameObjectWrap.Register(L);
        TransformWrap.Register(L);
        SpaceWrap.Register(L);

        CameraWrap.Register(L);
        CameraClearFlagsWrap.Register(L);
        MaterialWrap.Register(L);
        RendererWrap.Register(L);
        MeshRendererWrap.Register(L);
        SkinnedMeshRendererWrap.Register(L);
        LightTypeWrap.Register(L);
        LightWrap.Register(L);
        ParticleAnimatorWrap.Register(L);
        ParticleEmitterWrap.Register(L);
        ParticleRendererWrap.Register(L);

        PhysicsWrap.Register(L);
        ColliderWrap.Register(L);
        BoxColliderWrap.Register(L);
        MeshColliderWrap.Register(L);
        SphereColliderWrap.Register(L);
        CharacterControllerWrap.Register(L);

        AnimationWrap.Register(L);
        AnimationClipWrap.Register(L);
        TrackedReferenceWrap.Register(L);
        AnimationStateWrap.Register(L);
        QueueModeWrap.Register(L);				    //for animation		
        PlayModeWrap.Register(L);
        AnimationBlendModeWrap.Register(L);

        AudioSourceWrap.Register(L);
        AudioClipWrap.Register(L);

        ApplicationWrap.Register(L);
        InputWrap.Register(L);
        KeyCodeWrap.Register(L);
        TouchPhaseWrap.Register(L);
        TimeWrap.Register(L);
        ScreenWrap.Register(L);
        RenderSettingsWrap.Register(L);
        SleepTimeoutWrap.Register(L);

        AsyncOperationWrap.Register(L);
        AssetBundleWrap.Register(L);

        QualitySettingsWrap.Register(L);
        BlendWeightsWrap.Register(L);
        RenderTextureWrap.Register(L);

        Debugger.Log("bind u3d to lua cost:" + (Time.realtimeSinceStartup - time).ToString());
	}
}
