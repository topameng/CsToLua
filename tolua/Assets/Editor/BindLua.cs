using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

using Object = UnityEngine.Object;
using System.Text;

public static class LuaBinding
{
    public class BindType
    {
        public string name;
        public Type type;
        public bool IsStatic;
        public string baseName = null;

        public BindType(string s, Type t, bool flag, string bn)
        {
            name = s;
            type = t;
            IsStatic = flag;
            baseName = bn;
        }
    }

    static BindType[] binds = new BindType[]
    {
        //object 由于跟 Object 文件重名就不加入了
        new BindType("Type", typeof(Type), false, null),                
        new BindType("Time", typeof(Time), false, "object"),
        new BindType("Vector2", typeof(Vector2), false, "object"),
        new BindType("Vector3", typeof(Vector3), false, "object"),
        
        new BindType("Object", typeof(Object), false, "object"),              //Destroy 函数做了特殊处理, 加入了gc
        new BindType("GameObject", typeof(GameObject), false, "Object"),
        new BindType("Component", typeof(Component), false, "Object"),        
        
        new BindType("Behaviour", typeof(Behaviour), false, "Component"),
        new BindType("Transform", typeof(Transform), false, "Component"),

        new BindType("MonoBehaviour", typeof(MonoBehaviour), false, "Behaviour"),                        
    };

    [MenuItem("Lua/Gen LuaBinding Files", false, 11)]
    public static void Binding()
    {
        if (!Application.isPlaying)
        {
            EditorUtility.DisplayDialog("警告", "必须在运行模式下,才能使用这个功能", "OK");
            return;
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

        Debug.Log("Generate lua binding files over");
        AssetDatabase.Refresh();
    }
}
