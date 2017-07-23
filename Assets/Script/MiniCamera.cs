using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamera : MonoBehaviour
{


    private Camera miniCamera;
    private Vector3 target;

    // Use this for initialization
    void Start()
    {
        miniCamera = Camera.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1))
        {
            //获取屏幕坐标
            Vector3 mScreenPos = Input.mousePosition;
            Ray ray = miniCamera.ScreenPointToRay(mScreenPos);
            RaycastHit[] hits = Physics.RaycastAll(ray, 200);
            for (int i = hits.Length - 1; i >= 0; i--)
            {
                RaycastHit item = hits[i];

                if (item.transform.gameObject.layer == LayerMask.NameToLayer("Terrain"))
                {

                    target = new Vector3(item.point.x, item.point.y, item.point.z);

                    PlayerControl.move(target);
                    return;

                }
            }

        }
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            
        }

    }


    void CameraMove()
    {
        //获取屏幕坐标
        Vector3 mScreenPos = Input.mousePosition;
        Ray ray = miniCamera.ScreenPointToRay(mScreenPos);
        RaycastHit[] hits = Physics.RaycastAll(ray, 200);
        for (int i = hits.Length - 1; i >= 0; i--)
        {
            RaycastHit item = hits[i];

            if (item.transform.gameObject.layer == LayerMask.NameToLayer("Terrain"))
            {
                Vector3 camtar = new Vector3(item.point.x, item.point.y, item.point.z);

                PlayerControl.move(target);
                return;

            }
        }

        //if (Input.GetAxis("Mouse ScrollWheel") != 0)
        //{
        //    this.gameObject.transform.Translate(new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 500));
        //}
        //获取cursor坐标
        Vector3 msPos = Input.mousePosition;

        float widthBorder = Screen.width / 5;
        float heightBorder = Screen.height / 5;


        float x = 0.0f;
        float y = 0.0f;
        float z = 0.0f;
        //当前鼠标位置标记
        int posTag = 0;

        if (widthBorder <= msPos.x && msPos.x <= Screen.width - widthBorder && heightBorder <= msPos.y && msPos.y <= Screen.height - heightBorder)
        {
            transform.Translate(x, y, y);
            //Debug.Log("asd" + msPos.x + "   " + msPos.y);
        }
        else
        {
            
        }
    }
}

