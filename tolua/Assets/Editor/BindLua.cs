using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

using Object = UnityEngine.Object;
using System.Text;
using System.IO;

public static class LuaBinding
{
    public class BindType
    {
        public string name;
        public Type type;
        public bool IsStatic;
        public string baseName = null;

        public BindType(string s, Type t, bool beStatic, string bn)
        {
            name = s;
            type = t;
            IsStatic = beStatic;
            baseName = bn;
        }
    }

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
        //new BindType("object", typeof(object), false, null), 
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
            ToLua.Generate(null);
        }

        EditorApplication.isPlaying = false;
        GenRegFile();
        Debug.Log("Generate lua binding files over");
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
        sb.AppendLine("\t\tObjectWrap.Register(L)");

        for (int i = 0; i < binds.Length; i++)
        {
            sb.AppendFormat("\t\t{0}Wrap.Register(L);\r\n", binds[i].name);
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
}
