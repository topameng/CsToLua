using UnityEngine;
using System.Collections;
using LuaInterface;
using System;

public class CallLuaFunction_02 : MonoBehaviour {

    private string script = @"
            function luaFunc(num)                
                return num
            end
        ";

    LuaFunction func = null;

	// Use this for initialization
	void Start () {
        LuaScriptMgr mgr = new LuaScriptMgr();
        
        mgr.DoString(script);

        // Get the function object
        func = mgr.GetLuaFunction("luaFunc");

        //有gc alloc
        object[] r = func.Call(123456);        
        print(r[0]);

        // no gc alloc
        int num = CallFunc();
        print(num);
	}

    void OnDestroy()
    {
        if (func != null)
        {
            func.Release();
        }
    }

    int CallFunc()
    {
        int top = func.BeginPCall();
        IntPtr L = func.GetLuaState();
        LuaScriptMgr.Push(L, 123456);
        func.PCall(top, 1);
        int num = (int)LuaScriptMgr.GetNumber(L, -1);
        func.EndPCall(top);
        return num;
    }
	
	// Update is called once per frame
	void Update () 
    {
        //func.Call(123456);
        //CallFunc();
	}
}
