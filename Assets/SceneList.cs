using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneList : MonoBehaviour {

    public string[] gameScenes = new string[10];
    public Dictionary<string, int> sceneId = new Dictionary<string, int>();

    // Use this for initialization
    void Start () {
        for (int i = 0; i < gameScenes.Length; i++)
            sceneId[gameScenes[i]] = i;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
