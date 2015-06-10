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
#pragma warning disable 219        
        if (GUI.Button(new Rect(10, 10, 120, 50), "Test"))
        {            
            float time = Time.realtimeSinceStartup;
            Vector3 v = Vector3.one;

            for (int i = 0; i < 200000; i++)
            {
                v = transform.position;                
                transform.position = Vector3.one;
            }

            Debug.Log("c# cost time: " + (Time.realtimeSinceStartup - time));

            transform.position = Vector3.zero;
            luaMgr.CallLuaFunction("Test");            
        }

        if (GUI.Button(new Rect(10,70,120,50), "Test2"))
        {
            float time = Time.realtimeSinceStartup;            

            for (int i = 0; i < 200000; i++)
            {
                transform.Rotate(Vector3.up, 1);
            }

            Debug.Log("c# cost time: " + (Time.realtimeSinceStartup - time));            
            luaMgr.CallLuaFunction("Test2", transform);    
        }

        if (GUI.Button(new Rect(10, 130, 120, 50), "Test3"))
        {
            float time = Time.realtimeSinceStartup;
            Vector3 v = Vector3.one;

            for (int i = 0; i < 200000; i++)
            {
                v = new Vector3(i, i, i);
            }

            Debug.Log("c# cost time: " + (Time.realtimeSinceStartup - time));
            luaMgr.CallLuaFunction("Test3", transform);
        }


        if (GUI.Button(new Rect(10, 190, 120, 50), "Test4"))
        {
            float time = Time.realtimeSinceStartup;            

            for (int i = 0; i < 200000; i++)
            {
                GameObject go = new GameObject();
            }

            Debug.Log("c# cost time: " + (Time.realtimeSinceStartup - time));
            luaMgr.CallLuaFunction("Test4", transform);
        }

        if (GUI.Button(new Rect(10, 250, 120, 50), "Test5"))
        {
            float time = Time.realtimeSinceStartup;            

            for (int i = 0; i < 20000; i++)
            {
                GameObject go = new GameObject();
                go.AddComponent<SkinnedMeshRenderer>();
                SkinnedMeshRenderer sm = go.GetComponent<SkinnedMeshRenderer>();
                sm.castShadows = false;
                sm.receiveShadows = false;
            }

            Debug.Log("c# cost time: " + (Time.realtimeSinceStartup - time));
            luaMgr.CallLuaFunction("Test5", transform);
        }
#pragma warning restore 219
    }
}
