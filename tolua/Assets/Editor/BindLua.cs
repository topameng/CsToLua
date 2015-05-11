using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

using Object = UnityEngine.Object;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;
using UnityEngine.Rendering;

public static class LuaBinding
{
    public class BindType
    {
        public string name;
        public Type type;
        public bool IsStatic;
        public string baseName = null;
        public string wrapName = "";
        public string libName = "";

        string GetTypeStr(string str)
        {
            if (str.Contains("`"))
            {
                string regStr = @"^(?<s0>.*?)\.?(?<s1>\w*)`[1-9]\[(?<s2>.*?)\]$";
                Regex r = new Regex(regStr, RegexOptions.None);
                Match mc = r.Match(str);
                bool beMember = false;

                if (!mc.Success)
                {
                    regStr = @"^(?<s0>.*?)\.?(?<s1>\w*)`[1-9]\+(?<s3>.*?)\[(?<s2>.*?)\]$";
                    r = new Regex(regStr, RegexOptions.None);
                    mc = r.Match(str);
                    beMember = true;
                }

                string s0 = mc.Groups["s0"].Value;
                string s1 = mc.Groups["s1"].Value;
                string s2 = mc.Groups["s2"].Value;
                string[] ss = s2.Split(new char[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
                s2 = string.Empty;

                for (int i = 0; i < ss.Length; i++)
                {
                    ss[i] = ToLua._TC(ss[i]);
                }

                for (int i = 0; i < ss.Length - 1; i++)
                {
                    s2 += ss[i];
                    s2 += ",";
                }

                s2 += ss[ss.Length - 1];

                string s4 = string.Format("{0}<{1}>", s1, s2);

                if (beMember)
                {
                    s4 += ".";
                    s4 += mc.Groups["s3"].Value;
                }

                str = s0 + "." + s4;
            }
            else if (str.Contains("+"))
            {
                str = str.Replace('+', '.');
            }

            return str;
        }

		private static string[] getGenericName(Type[] _types)
		{
			string[] results = new string[_types.Length];
			for (int i = 0; i < _types.Length; i++)
			{
				if (_types[i].IsGenericType)
					results[i] = getGenericName(_types[i]);
				else
					results[i] = _types[i].ToString();

			}

			return results;
		}

		private static string getGenericName(Type _type)
		{
			if (_type.GetGenericArguments().Length == 0)
				return _type.Name;

			var gArgs = _type.GetGenericArguments();
			var typeName = _type.Name;
			var pureTypeName = typeName.Substring(0, typeName.IndexOf('`'));
			return pureTypeName + "<" + string.Join(",", getGenericName(gArgs)) + ">";
		}
        public BindType(Type t)
        {
            string str = t.ToString();
            //str = GetTypeStr(str);            
            libName = GetTypeStr(str);
            type = t;

            if (t.IsGenericType) str = libName;

            if (t.BaseType != null)
            {
				if (t.BaseType.IsGenericType)
				{
					baseName = getGenericName(t.BaseType);
				}
				else
					baseName = t.BaseType.ToString();

                if (baseName == "System.ValueType")
                {
                    baseName = null;
                }
            }

            if (t.GetConstructor(Type.EmptyTypes) == null && t.IsAbstract && t.IsSealed)
            {
                baseName = null;
                IsStatic = true;
            }

            int index = str.LastIndexOf('.');

            if (index > 0)
            {
                name = str.Substring(index + 1);
                name = name.Replace('+', '.');
                wrapName = name.Replace(".", "");
            }
            else
            {
                name = str.Replace('+', '.');
                wrapName = name.Replace(".", "");
            }
        }

        public BindType SetBaseName(string str)
        {
            baseName = str;
            return this;
        }

        public BindType SetClassName(string str)
        {
            name = str;
            wrapName = GetWrapName();
            return this;
        }

        public BindType SetWrapName(string str)
        {
            wrapName = str;
            return this;
        }

        public BindType SetLibName(string str)
        {
            libName = str;
            return this;
        }

        string GetWrapName()
        {
            string[] ss = name.Split(new char[] { '.' });
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < ss.Length; i++)
            {
                sb.Append(ss[i]);
            }

            return sb.ToString();
        }
    }

    static BindType _GT(Type t)
    {
        return new BindType(t);
    }

    static BindType[] binds = new BindType[]
    {
        //object 由于跟 Object 文件重名就不加入了                     
        //测试模板
        ////_GT(typeof(Dictionary<int,string>)).SetWrapName("DictInt2Str").SetLibName("DictInt2Str"),
        
        //custom    
        _GT(typeof(Debugger)),
        //_GT(typeof(SocketClient)),        
        //_GT(typeof(UIBase)),        
        //_GT(typeof(LuaHelper)),                           
        //_GT(typeof(UnGfx)),                                                            
        //_GT(typeof(UIProxy)),
        //_GT(typeof(SkinnedMeshBaker)),       
        //_GT(typeof(AssetFileMgr.AssetFile)).SetWrapName("AssetFile"),      
                 
        //_GT(typeof(Pathfinding.Path)),
        //_GT(typeof(Pathfinding.ABPath)),
        //_GT(typeof(Seeker)),        
                                                                              
        
        //unity                        
        _GT(typeof(Component)),
        _GT(typeof(Behaviour)),
        _GT(typeof(MonoBehaviour)),        
        _GT(typeof(GameObject)),
        _GT(typeof(Transform)),
        _GT(typeof(Space)),

        _GT(typeof(Camera)),   
        _GT(typeof(CameraClearFlags)),           
        _GT(typeof(Material)),
        _GT(typeof(Renderer)),        
        _GT(typeof(MeshRenderer)),
        _GT(typeof(SkinnedMeshRenderer)),
        _GT(typeof(Light)),
        _GT(typeof(LightType)),     
        _GT(typeof(ParticleEmitter)),
        _GT(typeof(ParticleRenderer)),
        _GT(typeof(ParticleAnimator)),        
                
        _GT(typeof(Physics)),
        _GT(typeof(Collider)),
        _GT(typeof(BoxCollider)),
        _GT(typeof(MeshCollider)),
        _GT(typeof(SphereCollider)),
        
        _GT(typeof(CharacterController)),

        _GT(typeof(Animation)),             
        _GT(typeof(AnimationClip)),
        _GT(typeof(TrackedReference)),
        _GT(typeof(AnimationState)),  
        _GT(typeof(QueueMode)),  
        _GT(typeof(PlayMode)),                  
        
        _GT(typeof(AudioClip)),
        _GT(typeof(AudioSource)),                
        
        _GT(typeof(Application)),
        _GT(typeof(Input)),    
        _GT(typeof(TouchPhase)),            
        _GT(typeof(KeyCode)),             
        _GT(typeof(Screen)),
        _GT(typeof(Time)),
        _GT(typeof(RenderSettings)),
        _GT(typeof(SleepTimeout)),        

        _GT(typeof(AsyncOperation)),
        _GT(typeof(AssetBundle)),   
        _GT(typeof(BlendWeights)),   
        _GT(typeof(QualitySettings)),  
        _GT(typeof(Plane)), 
        _GT(typeof(AnimationBlendMode)),    
        _GT(typeof(RenderTexture)),
        

        //ngui
        /*_GT(typeof(UICamera)),
        _GT(typeof(Localization)),
        _GT(typeof(NGUITools)),

        _GT(typeof(UIRect)),
        _GT(typeof(UIWidget)),        
        _GT(typeof(UIWidgetContainer)),     
        _GT(typeof(UILabel)),        
        _GT(typeof(UIToggle)),
        _GT(typeof(UIBasicSprite)),        
        _GT(typeof(UITexture)),
        _GT(typeof(UISprite)),           
        _GT(typeof(UIProgressBar)),
        _GT(typeof(UISlider)),
        _GT(typeof(UIGrid)),
        _GT(typeof(UIInput)),
        _GT(typeof(UIScrollView)),
        
        _GT(typeof(UITweener)),
        _GT(typeof(TweenWidth)),
        _GT(typeof(TweenRotation)),
        _GT(typeof(TweenPosition)),
        _GT(typeof(TweenScale)),
        _GT(typeof(UICenterOnChild)),    
        _GT(typeof(UIAtlas)),*/ 
   
        //_GT(typeof(LeanTween)),
        //_GT(typeof(LTDescr)),
        
    };


    [MenuItem("Thinky/Gen Lua Wrap Files", false, 11)]
    public static void Binding()
    {
        if (!Application.isPlaying)
        {
            EditorApplication.isPlaying = true;
        }

        BindType[] list = binds;

        for (int i = 0; i < list.Length; i++)
        {
            ToLua.Clear();
            ToLua.className = list[i].name;
            ToLua.type = list[i].type;
            ToLua.isStaticClass = list[i].IsStatic;
            ToLua.baseClassName = list[i].baseName;
            ToLua.wrapClassName = list[i].wrapName;
            ToLua.libClassName = list[i].libName;
            ToLua.Generate(null);
        }

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < list.Length; i++)
        {
            sb.AppendFormat("\t\t{0}Wrap.Register();\r\n", list[i].wrapName);
        }

        EditorApplication.isPlaying = false;
        //StringBuilder sb1 = new StringBuilder();

        //for (int i = 0; i < binds.Length; i++)
        //{
        //    sb1.AppendFormat("\t\t{0}Wrap.Register(L);\r\n", binds[i].wrapName);
        //}

        //GenLuaBinder();
        Debug.Log("Generate lua binding files over");
        AssetDatabase.Refresh();        
    }

    [MenuItem("Thinky/Gen LuaBinder File", false, 12)]
    static void GenLuaBinder()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("using System;");
        sb.AppendLine();
        sb.AppendLine("public static class LuaBinder");
        sb.AppendLine("{");
        sb.AppendLine("\tpublic static void Bind(IntPtr L)");
        sb.AppendLine("\t{");
        sb.AppendLine("\t\tobjectWrap.Register(L);");
        sb.AppendLine("\t\tObjectWrap.Register(L);");
        sb.AppendLine("\t\tTypeWrap.Register(L);");
        sb.AppendLine("\t\tDelegateWrap.Register(L);");
        sb.AppendLine("\t\tIEnumeratorWrap.Register(L);");
        sb.AppendLine("\t\tEnumWrap.Register(L);");
        sb.AppendLine("\t\tStringWrap.Register(L);");
        sb.AppendLine("\t\tMsgPacketWrap.Register(L);");
        

        string[] files = Directory.GetFiles("Assets/Source/LuaWrap/", "*.cs", SearchOption.TopDirectoryOnly);

        for (int i = 0; i < files.Length; i++)
        {
            string wrapName = Path.GetFileName(files[i]);
            int pos = wrapName.LastIndexOf(".");
            wrapName = wrapName.Substring(0, pos);
            sb.AppendFormat("\t\t{0}.Register(L);\r\n", wrapName);
        }

        sb.AppendLine("\t}");
        sb.AppendLine("}");

        string file = Application.dataPath + "/Source/LuaWrap/Base/LuaBinder.cs";

        using (StreamWriter textWriter = new StreamWriter(file, false, Encoding.UTF8))
        {
            textWriter.Write(sb.ToString());
            textWriter.Flush();
            textWriter.Close();
        }
    }

    [MenuItem("Thinky/Clear LuaBinder File", false, 13)]
    static void ClearLuaBinder()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("using System;");
        sb.AppendLine();
        sb.AppendLine("public static class LuaBinder");
        sb.AppendLine("{");
        sb.AppendLine("\tpublic static void Bind(IntPtr L)");
        sb.AppendLine("\t{");
        sb.AppendLine("\t}");
        sb.AppendLine("}");

        string file = Application.dataPath + "/Source/LuaWrap/Base/LuaBinder.cs";

        using (StreamWriter textWriter = new StreamWriter(file, false, Encoding.UTF8))
        {
            textWriter.Write(sb.ToString());
            textWriter.Flush();
            textWriter.Close();
        }

        AssetDatabase.Refresh();
    }

    [MenuItem("Thinky/Gen u3d Wrap Files", false, 11)]
    public static void U3dBinding()
    {
        List<string> dropList = new List<string>
        {      
            //特殊修改
            "UnityEngine.Object",

            //一般情况不需要的类, 编辑器相关的
            "HideInInspector",
            "ExecuteInEditMode",
            "AddComponentMenu",
            "ContextMenu",
            "RequireComponent",
            "DisallowMultipleComponent",
            "SerializeField",
            "AssemblyIsEditorAssembly",
            "Attribute",  //一些列文件，都是编辑器相关的     
            "FFTWindow",
  
            "Types",
            "UnitySurrogateSelector",            
            "TypeInferenceRules",            
            "ThreadPriority",
            "Debug",        //自定义debugger取代
            "GenericStack",

            //异常，lua无法catch
            "PlayerPrefsException",
            "UnassignedReferenceException",            
            "UnityException",
            "MissingComponentException",
            "MissingReferenceException",

            //RPC网络
            "RPC",
            "Network",
            "MasterServer",
            "BitStream",
            "HostData",
            "ConnectionTesterStatus",

            //unity 自带编辑器GUI
            "GUI",
            "EventType",
            "EventModifiers",
            //"Event",
            "FontStyle",
            "TextAlignment",
            "TextEditor",
            "TextEditorDblClickSnapping",
            "TextGenerator",
            "TextClipping",
            "TextGenerationSettings",
            "TextAnchor",
            "TextAsset",
            "TextWrapMode",
            "Gizmos",
            "ImagePosition",
            "FocusType",
            

            //地形相关
            "Terrain",                            
            "Tree",
            "SplatPrototype",
            "DetailPrototype",
            "DetailRenderMode",

            //其他
            "MeshSubsetCombineUtility",
            "AOT",
            "Random",
            "Mathf",
            "Social",
            "Enumerator",       
            "SendMouseEvents",               
            "Cursor",
            "Flash",
            "ActionScript",
            
    
            //非通用的类
            "ADBannerView",
            "ADInterstitialAd",            
            "Android",
            "jvalue",
            "iPhone",
            "iOS",
            "CalendarIdentifier",
            "CalendarUnit",
            "CalendarUnit",
            "FullScreenMovieControlMode",
            "FullScreenMovieScalingMode",
            "Handheld",
            "LocalNotification",
            "Motion",   //空类
            "NotificationServices",
            "RemoteNotificationType",      
            "RemoteNotification",
            "SamsungTV",
            "TextureCompressionQuality",
            "TouchScreenKeyboardType",
            "TouchScreenKeyboard",
            "MovieTexture",

            //我不需要的
            //2d 类
            "AccelerationEventWrap", //加速
            "AnimatorUtility",
            "AudioChorusFilter",		
		    "AudioDistortionFilter",
		    "AudioEchoFilter",
		    "AudioHighPassFilter",		    
		    "AudioLowPassFilter",
		    "AudioReverbFilter",
		    "AudioReverbPreset",
		    "AudioReverbZone",
		    "AudioRolloffMode",
		    "AudioSettings",		    
		    "AudioSpeakerMode",
		    "AudioType",
		    "AudioVelocityUpdateMode",
            
            "Ping",
            "Profiler",
            "StaticBatchingUtility",
            "Font",
            "Gyroscope",                        //不需要重力感应
            "ISerializationCallbackReceiver",   //u3d 继承的序列化接口，lua不需要
            "ImageEffectOpaque",                //后处理
            "ImageEffectTransformsToLDR",
            "PrimitiveType",                // 暂时不需要 GameObject.CreatePrimitive           
            "Skybox",                       //不会u3d自带的Skybox
            "SparseTexture",                // mega texture 不需要
            "Plane",
            "PlayerPrefs",

            //不用ugui
            "SpriteAlignment",
		    "SpriteMeshType",
		    "SpritePackingMode",
		    "SpritePackingRotation",
		    "SpriteRenderer",
		    "Sprite",
            "UIVertex",
            "CanvasGroup",
            "CanvasRenderer",
            "ICanvasRaycastFilter",
            "Canvas",
            "RectTransform",
            "DrivenRectTransformTracker",
            "DrivenTransformProperties",
            "RectTransformAxis",
		    "RectTransformEdge",
		    "RectTransformUtility",
		    "RectTransform",
            "UICharInfo",
		    "UILineInfo",

            //不需要轮子碰撞体
            "WheelCollider",
		    "WheelFrictionCurve",
		    "WheelHit",

            //手机不适用雾
            "FogMode",

            "UnityEventBase",
		    "UnityEventCallState",
		    "UnityEvent",

            "LightProbeGroup",
            "LightProbes",

            "NPOTSupport", //只是SystemInfo 的一个枚举值

            //没用到substance纹理
            "ProceduralCacheSize",
		    "ProceduralLoadingBehavior",
		    "ProceduralMaterial",
		    "ProceduralOutputType",
		    "ProceduralProcessorUsage",
		    "ProceduralPropertyDescription",
		    "ProceduralPropertyType",
		    "ProceduralTexture",

            //物理关节系统
		    "JointDriveMode",
		    "JointDrive",
		    "JointLimits",		
		    "JointMotor",
		    "JointProjectionMode",
		    "JointSpring",
            "SoftJointLimit",
            "SpringJoint",
            "HingeJoint",
            "FixedJoint",
            "ConfigurableJoint",
            "CharacterJoint",            
		    "Joint",

            "LODGroup",
		    "LOD",

            "DataUtility",          //给sprite使用的
            "CrashReport",
            "CombineInstance",
        };

        List<BindType> list = new List<BindType>();
        Assembly assembly = Assembly.Load("UnityEngine");
        Type[] types = assembly.GetExportedTypes();

        for (int i = 0; i < types.Length; i++)
        {
            //不导出： 模版类，event委托, c#协同相关, obsolete 类
            if (!types[i].IsGenericType && types[i].BaseType != typeof(System.MulticastDelegate) &&
                !typeof(YieldInstruction).IsAssignableFrom(types[i]) && !ToLua.IsObsolete(types[i]))
            {
                list.Add(_GT(types[i]));
            }
            else
            {
                Debug.Log("drop generic type " + types[i].ToString());
            }
        }

        for (int i = 0; i < dropList.Count; i++)
        {
            list.RemoveAll((p) => { return p.type.ToString().Contains(dropList[i]); });
        }

        //for (int i = 0; i < list.Count; i++)
        //{
        //    if (!typeof(UnityEngine.Object).IsAssignableFrom(list[i].type) && !list[i].type.IsEnum && !typeof(UnityEngine.TrackedReference).IsAssignableFrom(list[i].type)
        //        && !list[i].type.IsValueType && !list[i].type.IsSealed)            
        //    {
        //        Debug.Log(list[i].type.Name);
        //    }
        //}

        for (int i = 0; i < list.Count; i++)
        {
            try
            {
                ToLua.Clear();
                ToLua.className = list[i].name;
                ToLua.type = list[i].type;
                ToLua.isStaticClass = list[i].IsStatic;
                ToLua.baseClassName = list[i].baseName;
                ToLua.wrapClassName = list[i].wrapName;
                ToLua.libClassName = list[i].libName;
                ToLua.Generate(null);
            }
            catch (Exception e)
            {
                Debug.LogWarning("Generate wrap file error: " + e.ToString());
            }
        }

        GenLuaBinder();
        Debug.Log("Generate lua binding files over， Generate " + list.Count + " files");
        AssetDatabase.Refresh();
    }
}
