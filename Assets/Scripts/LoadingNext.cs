using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class LoadingNext : MonoBehaviour
{
    public string[] gameScenes = new string[10];

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextLevel();
        }
    }

    void NextLevel()
    {
        var s = gameScenes[new System.Random().Next(0, gameScenes.Length)];
        Persist.net.ServerChangeScene(s);
    }
}
