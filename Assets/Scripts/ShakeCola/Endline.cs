using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endline : MonoBehaviour {
    // Use this for initialization
    void Start () {
    }

	
	// Update is called once per frame
	void Update () {
		
	}

    //可樂搖滿房間
    void OnTriggerEnter2D(Collider2D collision)
    {
        //print("success!");
        // Step one
        GameObject clone = (GameObject)Instantiate((GameObject)Resources.Load("prefabs/Click", typeof(GameObject)));

        // Step two
        ShakeCola shakeCola = clone.GetComponent<ShakeCola>();

        // Step three
        shakeCola.getEnd();

    }
}
