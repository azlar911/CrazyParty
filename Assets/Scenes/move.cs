using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 v2 = this.transform.position;
        v2.y += 0.05f;
        this.transform.position = v2;
        // foooooo

    }
}
