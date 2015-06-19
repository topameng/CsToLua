using UnityEngine;
using System.Collections;
using LuaInterface;

public class ScriptsFromFile_02 : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        //只是展示如何加载文件。不是推荐这么做
        LuaState l = new LuaState();
        string path = Application.dataPath + "/uLua/Example/04_ScriptsFromFile/ScriptsFromFile02.lua";        
        l.DoFile(path);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
