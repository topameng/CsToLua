using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Text;
using System.IO;

using Object = UnityEngine.Object;
using System.Diagnostics;
using System.Collections.Generic;

public static class LuaBinding
{
    public class BindType
    {
        public string name;
        public Type type;
        public bool IsStatic;
        public string baseName = null;
        public string wrapName = "";

        public BindType(string s, Type t, bool beStatic, string bn)
        {
            name = s;
            type = t;
            IsStatic = beStatic;
            baseName = bn;
            wrapName = name;
        }

        public BindType(string wrap, string s, Type t, bool beStatic, string bn)
        {
            name = s;
            type = t;
            IsStatic = beStatic;
            baseName = bn;
            wrapName = wrap;
        }
    }

    //注意必须保持基类在其派生类前面声明，否则自动生成的注册顺序是错误的
    static BindType[] binds = new BindType[]
    {	
        //object 由于跟 Object 文件重名就不加入了
        new BindType("Type", typeof(Type), false, null),
        //new BindType("IAssetFile", typeof(IAssetFile), false, "object"),        
        new BindType("Time", typeof(Time), false, "object"),
        new BindType("Vector2", typeof(Vector2), false, "object"),
        new BindType("Vector3", typeof(Vector3), false, "object"),
        //new BindType("LuaHelper", typeof(LuaHelper), false, "object"),

        //new BindType("Object", typeof(Object), false, "object"),              //Destroy 函数做了特殊处理, 加入了gc
        new BindType("GameObject", typeof(GameObject), false, "Object"),
        new BindType("Component", typeof(Component), false, "Object"),        
        
        new BindType("Behaviour", typeof(Behaviour), false, "Component"),
        new BindType("Transform", typeof(Transform), false, "Component"),

        new BindType("MonoBehaviour", typeof(MonoBehaviour), false, "Behaviour"),
        //new BindType("UIBase", typeof(UIBase), false, "MonoBehaviour"),
        //new BindType("UIEventListener", typeof(UIEventListener), false, "MonoBehaviour"),

        //new BindType("TableMgr", typeof(TableMgr), false, "MonoBehaviour"),
        //new BindType("AssetFileMgr", typeof(AssetFileMgr), false, "MonoBehaviour"),
        new BindType("Application", typeof(Application), false, "object"),    
        //new BindType("Debugger", typeof(Debugger), true, null),                
        //new BindType("UnGfx", typeof(UnGfx), true, null),              
        new BindType("Keyframe", typeof(Keyframe), false, "object"),
        new BindType("AnimationCurve", typeof(AnimationCurve), false, "object"),
        new BindType("TestToLua", typeof(TestToLua), false, "object"),
        new BindType("TestEnum", typeof(TestEnum), false, null),
        new BindType("Space", typeof(Space), false, null),
        //new BindType("DictInt2Str", "Dictionary<int,string>", typeof(Dictionary<int,string>), false, "object"),
        new BindType("Light", typeof(Light), false, "Behaviour"),
        new BindType("LightType", typeof(LightType), false, null),
    };

    [MenuItem("Lua/Gen LuaBinding Files", false, 11)]
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
            ToLua.Generate(null);
        }

        EditorApplication.isPlaying = false;
        GenRegFile();
        UnityEngine.Debug.Log("Generate lua binding files over");
        AssetDatabase.Refresh();
    }

    static void GenRegFile()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("using System;");
        sb.AppendLine("public static class LuaBinder");
        sb.AppendLine("{");
        sb.AppendLine("\tpublic static void Bind(IntPtr L)");
        sb.AppendLine("\t{");
        sb.AppendLine("\t\tobjectWrap.Register(L);");
        sb.AppendLine("\t\tObjectWrap.Register(L);");
        sb.AppendLine("\t\tcoroutineWrap.Register(L);");

        for (int i = 0; i < binds.Length; i++)
        {
            sb.AppendFormat("\t\t{0}Wrap.Register(L);\r\n", binds[i].wrapName);
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

        Process proc = Process.Start(Application.dataPath + "/Lua/Build.bat");
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
