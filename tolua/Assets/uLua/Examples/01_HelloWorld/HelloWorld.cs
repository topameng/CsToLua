using UnityEngine;
using System.Collections;
using LuaInterface;

public class HelloWorld : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LuaState l = new LuaState();
        l.DoString("print('hello world 世界')");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
