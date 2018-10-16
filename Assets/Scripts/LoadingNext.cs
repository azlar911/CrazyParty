
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class LoadingNext : NetworkBehaviour
{
    public string[] gameScenes = new string[10];
    public GameObject[] playerPrefabs = new GameObject[10];

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
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
        int r = Random.Range(1, 3); //SceneManager.sceneCountInBuildSettings
    }

    [Command]
    void CmdSpawn()
    {

    }
}
