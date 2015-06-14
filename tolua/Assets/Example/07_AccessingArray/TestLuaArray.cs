using UnityEngine;
using System.Collections;
using LuaInterface;

public class TestLuaArray : MonoBehaviour
{
    private string script = @"                                   
            function TestArray(objs)                
                local len = objs.Length
                
                for i = 0, len - 1 do
                    print(objs[i])
                end
                return 1, '123', true
            end
        ";

    string[] objs = { "aaa", "bbb", "ccc" };

    void Start()
    {
        LuaScriptMgr lua = new LuaScriptMgr();
        lua.Start();
        lua.DoString(script);
        LuaFunction f = lua.GetLuaFunction("TestArray");
        //转换一下类型，避免可变参数拆成多个参数传递
        object[] rts = f.Call((object)objs);
        f.Release();

        for (int i = 0; i < objs.Length; i++)
        {
            Debug.Log(rts[i].ToString());
        }
    }
}
