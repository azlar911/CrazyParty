using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour {

    // What the game object should be for the four players
    public GameObject PrefabFor(int i)
    {
<<<<<<< HEAD
        return null;
=======
        get; set;
    }

    void OnStartLocalPlayer()
    {
        PlayerController.localPlayer.CmdSpawn(prefab);
>>>>>>> parent of 7fc8467... WIP
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
