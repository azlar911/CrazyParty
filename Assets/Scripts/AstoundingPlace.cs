using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class AstoundingPlace : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Persist.net = (NetworkManager)GameObject.Find("NetworkManager").GetComponent(typeof(NetworkManager));
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.B)){
            Persist.net.ServerChangeScene("MainMenu");
            Debug.Log("123");
            //SceneManager.LoadScene("MainMenu");
		}
	}
}
