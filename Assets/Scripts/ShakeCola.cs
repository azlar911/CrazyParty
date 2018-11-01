using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCola : MonoBehaviour {
    private GameObject colaColor;

	// Use this for initialization
	void Start () {
		colaColor = GameObject.Find("ColaColor");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        //print("test");
        //colaColor.transform.Translate(Vector2.up);
        colaColor.transform.Translate(new Vector2(0,10));
    }
}
