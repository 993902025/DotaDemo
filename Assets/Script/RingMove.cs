using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMove : MonoBehaviour {



    private GameObject g2;

	// Use this for initialization
	void Start () {

        //gameObject.transform.position = new Vector3(0, 12, 0);

        Debug.Log(gameObject.active + "光圈开关状态？");
    }
	
	// Update is called once per frame
	void Update () {

        if (gameObject.active == false)
        {
            gameObject.transform.position = new Vector3(0, 24, 0);
            return;
        }
        else
        {
            foreach (var item in PlayerControl.controlObj)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, item.transform.position, 0.5f);
            }
            
        }
	}
}
