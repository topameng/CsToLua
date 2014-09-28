using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using LuaInterface;

public struct TestToLua
{
    public TestToLua(params object[] objs)
    {

    }

    public int Test(ref int x, ref int y)
    {
        int ret = x + y;
        x = 1;
        y = 2;
        return ret;
    }

    public void Empty(Func<int, int, int, string> s1)
    {

    }

    public void TestDef(int i = 234, string str = "123")
    {

    }

    public void Test2(int i, params object[] objs)
    {

    }

    public void Test3(params GameObject[] objs)
    {

    }

    public void Test4(int i, object o)
    {
        Debug.Log("test4 obj");
    }

    public void Test4(int i, string str)
    {
        Debug.Log("test4 str");
    }
}

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
