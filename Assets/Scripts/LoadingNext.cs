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
        int r = Random.Range(0, 1);
        var gos = SceneManager.GetSceneByName(gameScenes[r]).GetRootGameObjects();
        var loader = (SceneLoader)System.Array.Find(gos, x => x.Equals("SceneLoader")).GetComponent(typeof(SceneLoader));
        PlayerController.localPlayer.CmdSpawn(loader.prefab);
    }
}
