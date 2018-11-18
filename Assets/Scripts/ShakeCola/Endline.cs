using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endline : MonoBehaviour {
    // Use this for initialization
    GameObject shakeCola;
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        shakeCola = GameObject.Find("Click"); 
    }

    //可樂搖滿房間
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("success!");
        shakeCola.GetComponent<ShakeCola>().getEnd();
    }
}
