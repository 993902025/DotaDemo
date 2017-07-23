using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCenter : MonoBehaviour {

    public static ManagerCenter Current = null;


    public List<PlayerModel> Players = new List<PlayerModel>();
	// Use this for initialization
	void Start () {
        Current = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //private PlayerModel Init()
    //{

    //    return ;
    //}
}
