using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using LuaInterface;

public class Client : MonoBehaviour 
{
    LuaScriptMgr luaMgr = null;
    LuaThread thread = null;

    void Awake()
    {
        luaMgr = new LuaScriptMgr();
        luaMgr.Start();

        luaMgr.DoFile("Test.Lua");
    }

	void Start () 
    {

	}

    void Update()
    {
        if (thread != null && !thread.IsDead())
        {
            thread.Resume();
        }
    }
		
	void OnGUI() 
    {
	    if (GUI.Button(new Rect(10,10,120,50), "Test"))
        {            
            float time = Time.realtimeSinceStartup;

            for (int i = 0; i < 100000; i++)
            {
                transform.position = Vector3.one;
            }

            Debug.Log("c# cost time: " + (Time.realtimeSinceStartup - time));
            time = Time.realtimeSinceStartup;

            luaMgr.CallLuaFunction("Test", transform);            
        }
        else if (GUI.Button(new Rect(10, 80, 120, 50), "Coroutine"))
        {
            LuaFunction func = luaMgr.GetLuaFunction("myFunc");
            thread = new LuaThread(luaMgr.lua, func);
            thread.Start();
        }
	}
}
