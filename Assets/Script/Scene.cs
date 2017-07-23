using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scene : MonoBehaviour {

    public List<GameObject> herolist;
    public static Hero hero;

    public Terrain dotaTerrain;

    PlayerModel player;

    Dictionary<int, Hero> idToModel = new Dictionary<int, Hero>();
    // Use this for initialization


    private void Awake()
    {
    }

    void Start () {

        foreach (var item in herolist)
        {

        }


        //objlist.Add((GameObject)image_hero01);
        //hero = new Hero();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
