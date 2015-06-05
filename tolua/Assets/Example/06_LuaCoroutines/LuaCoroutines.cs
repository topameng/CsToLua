using UnityEngine;
using System.Collections;
using LuaInterface;

public class LuaCoroutines : MonoBehaviour 
{
    private string script = @"                                   
            function fib(n)
                local a, b = 0, 1
                while n > 0 do
                    a, b = b, a + b
                    n = n - 1
                end

                return a
            end

            function CoFunc()
                print('Coroutine started')
                local i = 0
                for i = 0, 10, 1 do
                    print(fib(i))                    
                    coroutine.wait(1)
                end
                print('Coroutine ended')
            end

            function myFunc()
                coroutine.start(CoFunc)
            end
        ";

    private LuaScriptMgr lua = null;

	void Awake () 
    {
        lua  = new LuaScriptMgr();
        lua.Start();
        lua.DoString(script);        
        LuaFunction f = lua.GetLuaFunction("myFunc");
        f.Call();
        f.Release();
	}
	
	// Update is called once per frame
	void Update () 
    {        
        lua.Update();
	}

    void LateUpdate()
    {
        lua.LateUpate();
    }

    void FixedUpdate()
    {
        lua.FixedUpdate();
    }
}
