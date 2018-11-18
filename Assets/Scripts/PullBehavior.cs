using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PullBehaviour : PlayerBehaviour
{
    bool isLeft
    {
        get { return role % 2 == 0; }
    }

    void Awake()
    {
        if (!isLeft)
        {
            var dx = GameObject.Find("Main Camera").transform.position.x - transform.position.x;
            transform.position += new Vector3(2 * dx, 0, 0);
        }
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;
    }

    void OnMouseDown()
    {
        if (isLeft)
        {
            GameObject.Find("rope").transform.position += new Vector3(-1, 0, 0);
        }
        else
        {
            GameObject.Find("rope").transform.position += new Vector3(1, 0, 0);
        }
        gameObject.SetActive(true);
    }

}
