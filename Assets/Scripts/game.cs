using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System;
using UnityEngine.Events;

public class game : MonoBehaviour {

    /*
    void Awake()
    {
        Persist.net = (NetworkManager)GameObject.Find("NetworkManager").GetComponent(typeof(NetworkManager));
    }
    */
    // Use this for initialization
    void Start () {
        Button btn1 = (Button)GameObject.Find("end").GetComponent(typeof(Button));
        btn1.onClick.AddListener(endGame);
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            moveRope();
        }
        
    }

    private void moveRope()
    {
        GameObject rope = GameObject.Find("rope");
        rope.transform.Translate(-1, 0, 0);
    }






    void endGame()
    {
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button!");
        Persist.net.ServerChangeScene("loadingNext");
    }

    void TaskWithParameters(string message)
    {
        //Output this to console when the Button is clicked
        Debug.Log(message);
    }
}
