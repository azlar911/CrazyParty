using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Lobby : NetworkBehaviour
{

    void Start()
    {

    }
    
    void Update()
    {
        // TODO: check host
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.Find("Persist").scores = new Score[4];
            GameObject.Find("Persist").net.ServerChangeScene("LoadingNext");
        }
    }
}
