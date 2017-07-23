using UnityEngine;
using System.Collections;
using System;


#if IO

#endif



public class MainCameraFree : MonoBehaviour {

    public bool isCameraMove;

    public Quaternion cameraRot;   //俯视角度
    public float speed;     //移动速度
    
    //public float view_value;    //滚轮视野缩放的速率
    
    public float move_speed;    //控制摄像机移动的速率
    //关于鼠标滑轮的参数
    float MouseWhellSensitivity;    //滚轮控制视野缩放的速率
    //float MouseZoomMin = -2.4f;
    //float MouseZoomMax = 1.0f;
    //float norMalDistance = -1.1f;
    //水平和垂直的移动速度
    float horizontalMoveSpeed = 0.1f;
    float verticalMoveSpeed = 0.1f;
    //上左下右的标记
    short topTag = 8;
    short leftTag = 4;
    short botTag = 2;
    short rightTag = 1;

    private float field;    //广角值
    private Vector3 leftPos = new Vector3(20,40,2);
    private Vector3 rightPos = new Vector3(485, 40, 468);

    // Use this for initialization

    void Awake()
    {
#if UNITY_ANDROID || UNITY_IPHONE
        Debug.Log("这里是移动设备^_^");
        isCameraMove = false;
#endif


#if UNITY_STANDALONE_WIN
        Debug.Log("我是从Windows的电脑上运行的T_T");
        isCameraMove = false;
#endif
    }



    void Start ()
    {


        //gameObject.transform.position = new Vector3(10, 20, 0);
        cameraRot = gameObject.transform.rotation; // = Quaternion.Euler(45, 0, 0);
        speed = 350;
        MouseWhellSensitivity = 1000;
        move_speed = 50;
    }
	
	// Update is called once per frame
	void Update () {
        if (isCameraMove)
        {
            CameraMove();
            CameraSize();
        }


    }


    void CameraSize()
    {
        //放大、缩小
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            //this.gameObject.transform.Translate(new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * view_value));
            if (Camera.main.fieldOfView <= 60 && Camera.main.fieldOfView >=30)
            {
                Camera.main.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * MouseWhellSensitivity;
            }
            if (Camera.main.fieldOfView > 60) 
            {
                Camera.main.fieldOfView = 60;
            }
            if (Camera.main.fieldOfView < 30)
            {
                Camera.main.fieldOfView = 30;
            }

        }
        //移动视角
        if (Input.GetMouseButton(2))
        {
            
                transform.Translate(Vector3.left * Input.GetAxis("Mouse X") *  -move_speed * Time.deltaTime);
                //transform.Translate(Vector3.up * Input.GetAxis("Mouse Y") * -move_speed); 

                transform.Translate(new Vector3(0, 1, 1) * Input.GetAxis("Mouse Y") * move_speed * Time.deltaTime);
            transform.localPosition = new Vector3(transform.localPosition.x, leftPos.y, transform.localPosition.z);
            if (transform.localPosition.x < leftPos.x)
            {
                transform.localPosition = new Vector3(leftPos.x, leftPos.y, transform.localPosition.z);
            }
            if (transform.localPosition.z < leftPos.z)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, leftPos.y, leftPos.z);
            }
            if (transform.localPosition.x > rightPos.x)
            {
                transform.localPosition = new Vector3(rightPos.x, rightPos.y, transform.localPosition.z);
            }
            if (transform.localPosition.z > rightPos.z)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, rightPos.y, rightPos.z);
            }
        }
    }


    void CameraMove()
    {
        //if (Input.GetAxis("Mouse ScrollWheel") != 0)
        //{
        //    this.gameObject.transform.Translate(new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 500));
        //}
        //获取cursor坐标
        Vector3 msPos = Input.mousePosition;

        float widthBorder = 5;//Screen.width / 100;
        float heightBorder = 5;// Screen.height / 100;


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
            if (msPos.y > Screen.height - heightBorder)
                posTag = posTag | topTag;
            if (msPos.x < widthBorder)
                posTag = posTag | leftTag;
            if (msPos.y < heightBorder)
                posTag = posTag | botTag;
            if (msPos.x > Screen.width - widthBorder)
                posTag = posTag | rightTag;

            switch (posTag)
            {
                case 0: break;
                case 1: x = horizontalMoveSpeed; break;
                case 2: y = -verticalMoveSpeed; break;
                case 3: x = horizontalMoveSpeed; y = -verticalMoveSpeed; break;
                case 4: x = -horizontalMoveSpeed; break;
                case 6: x = -horizontalMoveSpeed; y = -verticalMoveSpeed; break;
                case 8: y = verticalMoveSpeed; break;
                case 9: x = horizontalMoveSpeed; y = verticalMoveSpeed; break;
                case 12: x = -horizontalMoveSpeed; y = verticalMoveSpeed; break;
                default: break;
            }
            z = y;

            x *= speed * Time.deltaTime;

            z *= (float)((Math.Cos(cameraRot.x) * speed * Time.deltaTime));

            y *= (float)((speed * Math.Sin(cameraRot.x) * Time.deltaTime));

            //y *= (float)(Math.Sqrt(2) * (speed * Time.deltaTime) / 2);

            transform.Translate(x, z, y);
            transform.localPosition = new Vector3(transform.localPosition.x, leftPos.y, transform.localPosition.z);
            if (transform.localPosition.x < leftPos.x)
            {
                transform.localPosition = new Vector3(leftPos.x, leftPos.y, transform.localPosition.z) ;
            }
            if (transform.localPosition.z < leftPos.z)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, leftPos.y, leftPos.z);
            }
            if (transform.localPosition.x > rightPos.x)
            {
                transform.localPosition = new Vector3(rightPos.x, rightPos.y, transform.localPosition.z);
            }
            if (transform.localPosition.z > rightPos.z)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, rightPos.y, rightPos.z);
            }
        }
    }
}
