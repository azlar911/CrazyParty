
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingNext : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nextLevel();
        }
	}

    void nextLevel()
    {
        int r = Random.Range(1, 3); //SceneManager.sceneCountInBuildSettings
        SceneManager.LoadScene(r);
        //Debug.Log("number " + r);

        string ss = SceneManager.GetSceneByBuildIndex(r).name;
        //Debug.Log("scenename " + ss);

        Persist.net.ServerChangeScene(ss);
    }
}
