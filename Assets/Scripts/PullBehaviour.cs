using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PullBehaviour : PlayerBehaviour
{
    float dir
    {
        get { return role % 2 == 0 ? 1 : -1; }
    }

    void Start()
    {
        transform.position += new Vector3(dir * 7, 0, 0);
    }

    float elapsed;

    void Update()
    {
<<<<<<< HEAD
        if (isLocalPlayer) {
            
            
            if (Input.GetMouseButtonDown(0))
            {
            Debug.Log(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    Debug.Log(dir);

                    //Debug.Log(hit.collider.gameObject.name == "Mole(Clone)");
                    if (hit.collider.gameObject.transform.position.x == 7 && dir == 1)
                    {
                        Debug.Log("right");
                        Cmdmove();                       
                    }
                    else if(hit.collider.gameObject.transform.position.x == -7 && dir == -1)
                    {
                        Debug.Log("left");
                        Cmdmove();
                    }
                    
                    //Cmdmove();
                }
            }
        }

        
        Timer += Time.deltaTime;
        //print("yee");
        //print(Timer);

        if (Timer > 10)
        {
=======
        if (!isLocalPlayer)
            return;

        elapsed += Time.deltaTime;

        if (elapsed > 10)
>>>>>>> 0c0e5ebf03934cce28f7eaee99981e27c6efc336
            LevelDone();

    }
    /*
    void OnMouseDown()
    {
        if (!isLocalPlayer)
            return;

        GameObject.Find("rope").transform.position += new Vector3(dir / 2, 0, 0);
    }
<<<<<<< HEAD
    */
    [Command]
    void Cmdmove()
    {
        GameObject.Find("rope").transform.position += new Vector3(dir, 0, 0);
    }
=======
>>>>>>> 0c0e5ebf03934cce28f7eaee99981e27c6efc336
}
