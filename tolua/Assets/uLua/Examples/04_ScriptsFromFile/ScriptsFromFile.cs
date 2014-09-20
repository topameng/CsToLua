using UnityEngine;
using System.Collections;
using LuaInterface;

public class ScriptsFromFile : MonoBehaviour {

    public TextAsset scriptFile;

	// Use this for initialization
	void Start () {
        LuaState l = new LuaState();
		l.DoString(scriptFile.text);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
