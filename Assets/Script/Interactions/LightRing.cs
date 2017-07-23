using UnityEngine;
using System.Collections;
using System;

public class LightRing : Interaction
{

    public GameObject ShowLightRing;    //被选中时 显示光圈

    

    public override void DeSelect()
    {
        ShowLightRing.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + gameObject.transform.lossyScale.y, gameObject.transform.position.z);
        ShowLightRing.SetActive(false);
    }

    public override void Select()
    {
        ShowLightRing.SetActive(true);
    }
    // Use this for initialization
    void Start()
    {
        ShowLightRing.SetActive(false);
        
    }

    private void Update()
    {

    }

    public override void  LightRingAnim()
    {
        //ShowLightRing.transform.position = new Vector3(Mathf.Lerp(gameObject.transform.position.x, gameObject.transform.position.x, 0.0001f), Mathf.Lerp(gameObject.transform.position.y + gameObject.transform.localScale.y, gameObject.transform.position.y - gameObject.transform.lossyScale.y, 0.01f * Time.deltaTime), Mathf.Lerp(gameObject.transform.position.z, gameObject.transform.position.z, 0.0001f));
        Debug.Log("lightringanim\t" + gameObject.transform.position + "\t" + gameObject.transform.position.y + gameObject.transform.lossyScale.y);
        //ShowLightRing.transform.position = Vector3.SmoothDamp(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + gameObject.transform.lossyScale.y, gameObject.transform.position.z), new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - gameObject.transform.lossyScale.y, gameObject.transform.position.z),ref vz, 0.1f * Time.deltaTime);

        ShowLightRing.transform.position = Vector3.MoveTowards(ShowLightRing.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - gameObject.transform.lossyScale.y, gameObject.transform.position.z), 0.1f);

        Debug.Log(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 2 * gameObject.transform.lossyScale.y, gameObject.transform.position.z));
    }

}
