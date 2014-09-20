using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;

public class Client : MonoBehaviour 
{
    LuaScriptMgr lua = null;

    void Awake()
    {
        lua = new LuaScriptMgr();
        lua.Start();   
     
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type[] types = assembly.GetTypes();
        List<Type> wrapList = new List<Type>();
        Type wrapType = typeof(ILuaWrap);

        for (int i = 0; i < types.Length; i++)
        {
            Type t = types[i];

            if (wrapType.IsAssignableFrom(t) && !t.IsAbstract)
            {
                wrapList.Add(t);
            }
        }

        lua.LuaBinding(wrapList);
    }

	void Start () 
    {        
	}
		
	void OnGUI() 
    {
	    if (GUI.Button(new Rect(10,10,120,50), "Test"))
        {
            lua.DoFile("Test.Lua");
            float time = Time.realtimeSinceStartup;

            for (int i = 0; i < 10000; i++)
            {
                transform.position = Vector3.one;
            }

            Debug.Log("c# cost time: " + (Time.realtimeSinceStartup - time));
            time = Time.realtimeSinceStartup;

            lua.CallLuaFunction("Test", transform);

            Debug.Log("lua cost time: " + (Time.realtimeSinceStartup - time));
        }
	}
}
