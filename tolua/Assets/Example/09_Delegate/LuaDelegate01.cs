using UnityEngine;
using System;
using System.Collections;
using LuaInterface;

public class LuaDelegate01 : MonoBehaviour
{
    private string script = 
    @"                  
            function DoClick1(go)
                print('click1 on ', go.name)
            end

            function DoClick2(go)
                print('click2 on ', go.name)
            end
            
            local click2 = nil

            function AddDelegate(delegate)                     
                delegate = delegate + DoClick1
                click2 = DelegateFactory.Action_GameObject(DoClick2)                
                delegate = delegate + click2     
                return delegate                     
            end

            function RemoveDelegate(delegate)
                delegate = delegate - click2       
                return delegate         
            end
    ";
   
    //需要删除的转LuaFunction为委托，不需要删除的直接加或者等于即可
    void Start()
    {
        LuaScriptMgr mgr = new LuaScriptMgr();
        mgr.Start();                
        mgr.DoString(script);

        LuaFunction func = mgr.GetLuaFunction("AddDelegate");
        Action<GameObject> ActionGo = delegate { };
        object[] objs = func.Call(ActionGo);
        ActionGo = (Action<GameObject>)objs[0];
        GameObject go = new GameObject("TestGo");
        ActionGo(go);
        Debug.Log("---------------------------------------------------------------------");        
        LuaFunction func1 = mgr.GetLuaFunction("RemoveDelegate");
        objs = func1.Call(ActionGo);
        ActionGo = (Action<GameObject>)objs[0];
        ActionGo(go);
        func.Release();
        func1.Release();
    }
}
