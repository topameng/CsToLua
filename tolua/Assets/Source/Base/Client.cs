using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using LuaInterface;


public class Client : MonoBehaviour 
{    
    LuaScriptMgr luaMgr = null;

    void Awake()
    {        
        luaMgr = new LuaScriptMgr();
        luaMgr.Start();            
    }

	void Start () 
    {
        luaMgr.DoFile("Test.Lua");    
	}

    void Update()
    {
        if (luaMgr != null)
        {
            luaMgr.Update();
        }
    }

    void LateUpdate()
    {
        if (luaMgr != null)
        {
            luaMgr.LateUpate();
        }
    }

    void FixedUpdate()
    {
        if (luaMgr != null)
        {
            luaMgr.FixedUpdate();
        }
    }
		
	void OnGUI() 
    {
	    if (GUI.Button(new Rect(10,10,120,50), "Test"))
        {            
            float time = Time.realtimeSinceStartup;
            Vector3 v = Vector3.one;

            for (int i = 0; i < 800000; i++)
            {
                v = transform.position;
                v += Vector3.one;
                transform.position = Vector3.one;
            }

            Debug.Log("c# cost time: " + (Time.realtimeSinceStartup - time));

            transform.position = Vector3.zero;
            luaMgr.CallLuaFunction("Test", transform);            
        }

        if (GUI.Button(new Rect(10,70,120,50), "Test2"))
        {
            float time = Time.realtimeSinceStartup;
            Vector3 v = Vector3.one;

            for (int i = 0; i < 800000; i++)
            {
                v += Vector3.one;                
            }

            Debug.Log("c# cost time: " + (Time.realtimeSinceStartup - time));            
            luaMgr.CallLuaFunction("Test2", transform);    
        }
	}
}
