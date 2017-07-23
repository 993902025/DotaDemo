using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseSelect : MonoBehaviour {

    public static bool isMouseDown;

    private Vector3 lastMousePosition;
    public static Vector3 startMousePos;
    public static Vector3 endMousePos;

    public static List<Transform> characters = new List<Transform>();
    public Object[] AllObj = null;

    public Terrain dotaTerrain;

    private Camera mainCamera;

    private Interactive interactive;
    DotaUi dotaui;

    

    // Use this for initialization
    void Start()
    {

        interactive = Interactive.Current;
        //dotaui = new DotaUi();
        mainCamera = Camera.main;
        AllObj = FindObjectsOfType(typeof(Transform)) ;
        foreach (Transform item in AllObj)
        {
            if (item.transform.gameObject.layer == LayerMask.NameToLayer("Unit"))
            {
                characters.Add(item);
                Debug.Log("场景 Unit 对象 " + item);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !isMouseDown)
        { // 鼠标按住时
            var es = UnityEngine.EventSystems.EventSystem.current;
            if (es != null && es.IsPointerOverGameObject())//如果用户点击了2D空间中的某些UI元素，我们就要避免选中UI后的3D对象，同时还要检测是否点击了2D元素  
            { 
                MiniMapClick();
            }
        }

        if (Input.GetMouseButtonDown(0) && !IsMouseInMiniMap())
        {
            isMouseDown = true;
            startMousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0) )
        { // 鼠标松开时
            isMouseDown = false;
            MousePick(startMousePos, endMousePos);
        }
        if (isMouseDown)
        {
            endMousePos = Input.mousePosition;

            //Debug.Log("start.screen=" + startMousePosition);
            //startMousePosition = Camera.main.ScreenToWorldPoint(startMousePosition);//Camera.main.ScreenToViewportPoint(startMousePosition)
            //Debug.Log("start.World=" + startMousePosition);
        }


    }
    
    /// <summary>
    /// 鼠标选取单位
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    void MousePick(Vector3 start, Vector3 end)
    {
        Vector3 p1 = Vector3.zero;
        Vector3 p2 = Vector3.zero;
        if (start.x > end.x)
        {//这些判断是用来确保p1的xy坐标小于p2的xy坐标，因为画的框不见得就是左下到右上这个方向的
            p1.x = end.x;
            p2.x = start.x;
        }
        else
        {
            p1.x = start.x;
            p2.x = end.x;
        }
        if (start.y > end.y)
        {
            p1.y = end.y;
            p2.y = start.y;
        }
        else
        {
            p1.y = start.y;
            p2.y = end.y;
        }
        foreach (Transform obj in characters)
        {
            //Debug.Log("chara对象 " + obj);
            //把可选择的对象保存在characters数组里
            Vector3 location = Camera.main.WorldToScreenPoint(obj.position);//把对象的position转换成屏幕坐标
            if (location.x < p1.x || location.x > p2.x || location.y < p1.y || location.y > p2.y )//|| location.z < Camera.main.nearClipPlane || location.z > Camera.main.farClipPlane)//z方向就用摄像机的设定值，看不见的也不需要选择了
            {
                //disselecting(obj);//上面的条件是筛选 不在选择范围内的对象，然后进行取消选择操作，比如把物体放到default层，就不显示轮廓线了

                //Debug.Log("取消 对象 " + obj);// + "lops" +  location + "\tp1=" + p1 + "\tp2=" + p2);
            }
            else
            {
                if (PlayerControl.playObj.Contains(obj))
                {
                    PlayerControl.controlObj.Clear();
                    PlayerControl.controlObj.Add(obj);
                    Debug.Log("选中 对象 " + obj);
                    interactive.Swap = true;
                }

                //selecting(obj);//否则就进行选中操作，比如把物体放到画轮廓线的层去
            }
        }
    }

    void MiniMapMove(Vector3 value)
    {

        Vector3 getpos = new Vector3((value.x - DotaUi.miniMapLeftPos.x) * dotaTerrain.terrainData.bounds.size.x / DotaUi.miniMapSize.x, 40f, (value.y - DotaUi.miniMapLeftPos.y) * dotaTerrain.terrainData.bounds.size.z / DotaUi.miniMapSize.y);

        mainCamera.transform.position = getpos;


    }


    /// <summary>
    /// 小地图鼠标操作
    /// </summary>
    void MiniMapClick()
    {
        if (IsMouseInMiniMap())
        {
            //Debug.Log("dianji xiao ditu");
            isMouseDown = false;
            MiniMapMove(Input.mousePosition);
        }
    }


    bool IsMouseInMiniMap()
    {
        //DotaUi.MiniMapSize();
        Vector2 mousepos = Input.mousePosition;
        if (mousepos.x < DotaUi.miniMapLeftPos.x || mousepos.y < DotaUi.miniMapLeftPos.y || mousepos.x > DotaUi.miniMapRightPos.x || mousepos.y > DotaUi.miniMapRightPos.y)
        {
            //Debug.Log("minimapclick false");
            return false;
        }
        return true;
    }
}
