using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Use this for initialization
    void Awake()
    {
        Persist.net = (NetworkLobbyManager)GameObject.Find("NetworkLobbyManager").GetComponent(typeof(NetworkLobbyManager));
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Persist.net.ServerChangeScene("AstoundingPlace");
        }
    }
}
