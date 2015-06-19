using UnityEngine;
using System.Collections;
using LuaInterface;

public class CallLuaFunction_01 : MonoBehaviour {

    private string script = @"
            function luaFunc(message)
                print(message)
                return 42
            end
        ";

	// Use this for initialization
	void Start () {
        LuaState l = new LuaState();

        // First run the script so the function is created
        l.DoString(script);

        // Get the function object
        LuaFunction f = l.GetFunction("luaFunc");

        // Call it, takes a variable number of object parameters and attempts to interpet them appropriately
        object[] r = f.Call("I called a lua function!");

        // Lua functions can have variable returns, so we again store those as a C# object array, and in this case print the first one
        print(r[0]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
