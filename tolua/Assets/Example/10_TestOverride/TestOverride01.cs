using UnityEngine;
using System.Collections;
using LuaInterface;

public class TestOverride
{
    public enum Space
    {
        World = 1
    }

    public int Test(object o, string str)
    {
        Debug.Log("call Test(object o, string str)");
        return 1;
    }

    public int Test(char c)
    {
        Debug.Log("call Test(char c)");
        return 2;
    }

    public int Test(int i)
    {
        Debug.Log("call Test(int i)");
        return 3;
    }

    //有这个函数要扔掉上面两个精度不匹配的，因为lua是double
    public int Test(double d)
    {
        Debug.Log("call Test(double d)");
        return 4;
    }

    public int Test(int i, int j)
    {
        Debug.Log("call Test(int i, int j)");
        return 5;
    }


    public int Test(string str)
    {
        Debug.Log("call Test(string str)");
        return 6;
    }

    public static int Test(string str1, string str2)
    {
        Debug.Log("call static Test(string str1, string str2)");
        return 7;
    }

    public int Test(object o)
    {
        Debug.Log("call Test(object o)");
        return 8;
    }

    public int Test(params object[] objs)
    {
        Debug.Log("call Test(params object[] objs)");
        return 9;
    }

    public int Test(Space e)
    {
        Debug.Log("call Test(TestEnum e)");
        return 10;
    }
}

public class TestOverride01 : MonoBehaviour
{
    private string script =
    @"                  
        function Test(to)
            assert(to:Test(1) == 4)
            assert(to:Test('hello') == 6)
            assert(to:Test(object.New()) == 8)
            assert(to:Test(123, 456) == 5)            
            assert(to:Test('123', '456') == 1)
            assert(to:Test(object.New(), '456') == 1)
            assert(to:Test('123', 456) == 9)
            assert(to:Test('123', object.New()) == 9)
            assert(to:Test(1,2,3) == 9)            
            assert(to:Test(TestOverride.Space.World) == 10)        
        end
    ";
    
    //反射已经无法区分这些重载函数了
    void Start()
    {
        LuaScriptMgr mgr = new LuaScriptMgr();
        mgr.Start();
        TestOverrideWrap.Register(mgr.GetL());
        TestOverride_SpaceWrap.Register(mgr.GetL());
        mgr.DoString(script);

        TestOverride to = new TestOverride();
        LuaFunction func = mgr.GetLuaFunction("Test");
        func.Call(to);   
    }
}
