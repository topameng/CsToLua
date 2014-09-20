using UnityEngine;
using System.Collections;
using LuaInterface;

public class LuaCoroutines : MonoBehaviour {

    // This example will print a fibonacci sequence for 1 to 10, waiting 1 second between each iteration
    //
    private string script = @"
            luanet.load_assembly('UnityEngine')
            local Time = luanet.import_type('UnityEngine.Time')

            -- This yields every frame that the global game time is still less than the desired timestamp
            function waitSeconds(t)
                local timeStamp = Time.time + t
                while Time.time < timeStamp do
                    coroutine.yield()
                end
            end

            function fib(n)
                local a, b = 0, 1
                while n > 0 do
                    a, b = b, a + b
                    n = n - 1
                end

                return a
            end

            function myFunc()
                print('Coroutine started')
                local i = 0
                for i = 0, 10, 1 do
                    print(fib(i))
                    waitSeconds(1)
                end
                print('Coroutine ended')
            end
        ";

    private LuaThread co = null;

	// Use this for initialization
	void Start () {
        LuaState l = new LuaState();

        // First run the script so the function is created
        l.DoString(script);

        // Get the function object
        LuaFunction f = l.GetFunction("myFunc");

        // Create a paused lua coroutine object from the parent state and a function
        co = new LuaThread(l, f);

        // The coroutine needs to be resumed each frame, since it is yielding each frame, alternatively you could only resume it on conditions in C# instead
        co.Start();
	}
	
	// Update is called once per frame
	void Update () {
        if( !co.IsDead() )
        {
            co.Resume();
        }
        else
        {
            print("Coroutine has exited.");

            // In order to destroy a coroutine (but not the function in lua, just the coroutine stack instance) simply allow C# to clean up the wrapped object
            co = null;
        }
	}
}
