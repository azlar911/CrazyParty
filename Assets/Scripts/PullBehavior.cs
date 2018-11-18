using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PullBehavior : PlayerBehaviour
{

    void Start()
    {
    }

    void Update()
    {

        if (!isLocalPlayer)
            return;
        //OnMouseDown();
    }

    void OnMouseDown()
    {
        if (role % 2 == 0)
        {
            Debug.Log("right1");
            GameObject rope = GameObject.Find("rope");
            rope.transform.position = rope.transform.position + new Vector3(1, 0, 0);
            Debug.Log("right2");
        }
        else
        {
            GameObject rope = GameObject.Find("rope");
            rope.transform.position = rope.transform.position + new Vector3(-1, 0, 0);
            Debug.Log("left");
        }
        gameObject.SetActive(true);
    }

}
