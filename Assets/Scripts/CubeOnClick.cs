using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CubeOnClick : MonoBehaviour
{
    void Update()
    {
        
    }

    void OnMouseDown()     
    {
        GameObject rope = GameObject.Find("rope");
        rope.transform.position = rope.transform.position + new Vector3(-1, 0, 0);
    }
}
