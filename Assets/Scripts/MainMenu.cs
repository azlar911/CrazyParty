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
        Persist.net = (NetworkManager)GameObject.Find("NetworkManager").GetComponent(typeof(NetworkManager));
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nextLevel();
            //Persist.net.ServerChangeScene("AstoundingPlace");
            
        }

    }
    
    void nextLevel()
    {
        int r = Random.Range(1, 2);//SceneManager.sceneCountInBuildSettings
        SceneManager.LoadScene(r);
        //Debug.Log("number " + r);

        string ss = SceneManager.GetSceneByBuildIndex(r).name;
        //Debug.Log("scenename " + ss);

        Persist.net.ServerChangeScene(ss);
    }
}
