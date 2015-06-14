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

            function AddDelegate(listener)                     
                listener.OnClick = DoClick1
                click2 = DelegateFactory.Action_GameObject(DoClick2)                
                listener.OnClick = listener.OnClick + click2                                    
            end

            function RemoveDelegate(listener)                
                listener.OnClick = listener.OnClick - click2       
                return delegate         
            end
    ";
   
    //需要删除的转LuaFunction为委托，不需要删除的直接加或者等于即可
    void Start()
    {
        LuaScriptMgr mgr = new LuaScriptMgr();
        mgr.Start();
        TestEventListenerWrap.Register(mgr.GetL());
        mgr.DoString(script);
        GameObject go = new GameObject("TestGo");
        TestEventListener listener = (TestEventListener)go.AddComponent(typeof(TestEventListener));         

        LuaFunction func = mgr.GetLuaFunction("AddDelegate");
        func.Call(listener);                
        listener.OnClick(go);
        func.Release();
        Debug.Log("---------------------------------------------------------------------");        
        func = mgr.GetLuaFunction("RemoveDelegate");
        func.Call(listener);
        listener.OnClick(go);
        func.Release();        
    }
}
