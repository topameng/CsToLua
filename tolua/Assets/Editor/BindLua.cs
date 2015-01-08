using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

using Object = UnityEngine.Object;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Reflection;


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

        public BindType(Type t)
        {
            string str = t.ToString();
            //str = GetTypeStr(str);
            libName = GetTypeStr(str);
            type = t;

            if (t.BaseType != null)
            {
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

    //注意必须保持基类在其派生类前面声明，否则自动生成的注册顺序是错误的
    static BindType[] binds = new BindType[]
    {	
        //object 由于跟 Object 文件重名就不加入了
        //_GT(typeof(Type)),
        
        ////u3d
        //_GT(typeof(Time)),
        //_GT(typeof(Vector2)),
        //_GT(typeof(Vector3)),        
        //_GT(typeof(GameObject)),
        //_GT(typeof(Component)),        
        
        //_GT(typeof(Behaviour)),
        //_GT(typeof(Transform)),
        //_GT(typeof(Resources)),
        //_GT(typeof(TextAsset)),    
        //_GT(typeof(Keyframe)),       
        //_GT(typeof(AnimationCurve)),
        //_GT(typeof(Motion)),
        //_GT(typeof(AnimationClip)),

        //_GT(typeof(MonoBehaviour)),

       ////内部
        //_GT(typeof(IAssetFile)),        
        //_GT(typeof(UIBase)),
        //_GT(typeof(UIEventListener)),
        //_GT(typeof(LuaHelper)),        
        //_GT(typeof(AssetFileMgr)),
        //_GT(typeof(Application)),            
        //_GT(typeof(UnGfx)),                               
        //_GT(typeof(TestToLua)),        
        //_GT(typeof(TestEnum)),        
        ////_GT(typeof(Dictionary<int,string>)).SetWrapName("DictInt2Str").SetLibName("DictInt2Str"),
        //_GT(typeof(Light)),
        //_GT(typeof(LightType)),

        ////ngui
        //_GT(typeof(UIRect)),
        //_GT(typeof(UIWidget)),
        //_GT(typeof(UILabel)),                 
        //_GT(typeof(UIEventListener)),                
        //_GT(typeof(UILabel.Effect)),       
        //_GT(typeof(Localization)),   
        //_GT(typeof(UICamera)),
    };

    [MenuItem("Lua/Gen Lua Wrap Files", false, 11)]
    public static void Binding()
    {
        if (!Application.isPlaying)
        {
            EditorApplication.isPlaying = true;
        }

        for (int i = 0; i < binds.Length; i++)
        {
            ToLua.Clear();
            ToLua.className = binds[i].name;
            ToLua.type = binds[i].type;
            ToLua.isStaticClass = binds[i].IsStatic;
            ToLua.baseClassName = binds[i].baseName;
            ToLua.wrapClassName = binds[i].wrapName;
            ToLua.libClassName = binds[i].libName;
            ToLua.Generate(null);
        }

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < binds.Length; i++)
        {
            sb.AppendFormat("\t\t{0}Wrap.Register();\r\n", binds[i].wrapName);
        }

        EditorApplication.isPlaying = false;
        //GenRegFile(binds);
        StringBuilder sb1 = new StringBuilder();

        for (int i = 0; i < binds.Length; i++)
        {
            sb1.AppendFormat("\t\t{0}Wrap.Register(L);\r\n", binds[i].wrapName);
        }

        Debug.Log("Generate lua binding files over");
        Debug.Log(sb1.ToString());
        AssetDatabase.Refresh();
    }

    [MenuItem("Lua/Gen LuaBinder File", false, 12)]
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

    [MenuItem("Lua/Clear LuaBinder File", false, 13)]
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

    [MenuItem("Lua/Gen u3d Wrap Files", false, 11)]
    public static void U3dBinding()
    {
        List<string> dropList = new List<string>
        {      
            //特殊修改
            "UnityEngine.Object",

            //编辑器相关
            "HideInInspector",
            "ExecuteInEditMode",
            "AddComponentMenu",
            "ContextMenu",
            "RequireComponent",
            "DisallowMultipleComponent",
            "SerializeField",
            "AssemblyIsEditorAssembly",
            "Attribute",  //一些列文件，都是编辑器相关的       
            "Types",
            "UnitySurrogateSelector",
            "TrackedReference",
            "TypeInferenceRules",

            //
            "FFTWindow",

            //RPC网络,一般不用
            "RPC",
            "Network",
            "MasterServer",
            "BitStream",
            "HostData",
            "ConnectionTesterStatus",

            //unity 自带GUI
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
            "Gizmos",

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

    static string GetOS()
    {
#if UNITY_STANDALONE
        return "Win";
#elif UNITY_ANDROID
        return "Android";
#elif UNITY_IPHONE
        return "IOS";
#endif
    }

    [MenuItem("Lua/Build Lua with luajit", false, 1)]
    public static void BuildLua()
    {
        BuildAssetBundleOptions options = BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets | BuildAssetBundleOptions.DeterministicAssetBundle;

        System.Diagnostics.Process proc = System.Diagnostics.Process.Start(Application.dataPath + "/Lua/Build.bat");
        proc.WaitForExit();
        AssetDatabase.Refresh();
        string[] files = Directory.GetFiles("Assets/Lua/Out", "*.lua.bytes");
        List<Object> list = new List<Object>();

        for (int i = 0; i < files.Length; i++)
        {
            Object obj = AssetDatabase.LoadMainAssetAtPath(files[i]);
            list.Add(obj);
        }

        if (files.Length > 0)
        {
            string output = string.Format("{0}/Bundle/Lua.unity3d", Application.dataPath);
            BuildPipeline.BuildAssetBundle(null, list.ToArray(), output, options, EditorUserBuildSettings.activeBuildTarget);
            string output1 = string.Format("{0}/{1}/Lua.unity3d", Application.persistentDataPath, GetOS());
            FileUtil.DeleteFileOrDirectory(output1);
            Directory.CreateDirectory(Path.GetDirectoryName(output1));
            FileUtil.CopyFileOrDirectory(output, output1);
            AssetDatabase.Refresh();
        }

        UnityEngine.Debug.Log("编译lua文件结束");
    }

    [MenuItem("Lua/Build Lua without jit", false, 2)]
    public static void BuildLuaNoJit()
    {
        BuildAssetBundleOptions options = BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets | BuildAssetBundleOptions.DeterministicAssetBundle;

        string[] files = Directory.GetFiles("Assets/Lua/Out", "*.lua.bytes");

        for (int i = 0; i < files.Length; i++)
        {            
            FileUtil.DeleteFileOrDirectory(files[i]);
        }

        files = Directory.GetFiles(Application.dataPath + "/Lua/", "*.lua", SearchOption.TopDirectoryOnly);

        for (int i = 0; i < files.Length; i++)
        {
            string fname = Path.GetFileName(files[i]);
            FileUtil.CopyFileOrDirectory(files[i], Application.dataPath + "/Lua/Out/" + fname + ".bytes");
        }

        AssetDatabase.Refresh();

        files = Directory.GetFiles("Assets/Lua/Out", "*.lua.bytes");
        List<Object> list = new List<Object>();

        for (int i = 0; i < files.Length; i++)
        {
            Object obj = AssetDatabase.LoadMainAssetAtPath(files[i]);
            list.Add(obj);
        }

        if (files.Length > 0)
        {
            string output = string.Format("{0}/Bundle/Lua.unity3d", Application.dataPath);
            BuildPipeline.BuildAssetBundle(null, list.ToArray(), output, options, EditorUserBuildSettings.activeBuildTarget);
            string output1 = string.Format("{0}/{1}/Lua.unity3d", Application.persistentDataPath, GetOS());
            FileUtil.DeleteFileOrDirectory(output1);
            Directory.CreateDirectory(Path.GetDirectoryName(output1));
            FileUtil.CopyFileOrDirectory(output, output1);
            AssetDatabase.Refresh();
        }

        UnityEngine.Debug.Log("编译lua文件结束");
    }
}
