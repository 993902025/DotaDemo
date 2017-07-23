using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotaUi : MonoBehaviour
{
    public RawImage ima01;

    private bool tragima;
    Scene scene;
    Hero hero;
    public List<GameObject> objlist = new List<GameObject>();
    public Transform startPos;

    public RawImage miniMap0;
    public static RawImage miniMap;
    private Camera mainCamera;
    public Terrain terrain;


    private GameObject miniMapUi;
    public static Vector2 miniMapLeftPos;
    public static Vector2 miniMapRightPos;
    public static Vector2 miniMapSize;
    public RawImage test;
    public static bool miniMapDown;

    private bool isTestMenuOpen = false;

    public GameObject testMenu;
    public void Start()
    {
        testMenu = transform.Find("MainUI/TestMenu").gameObject;                 //////这个find又不要空格，我也不知道为毛
        testMenu.GetComponent<RectTransform>().pivot = new Vector2(-0.5f, -0.5f);

        //ima01.color = new Color(1, 1, 1, 1);
        //Debug.Log("1:" + ima01Vec);
        //hero = Scene.hero;
        miniMap = miniMap0;
        //miniMapUi = GameObject.Find("MiniMapUi");

        mainCamera = Camera.main;
        MiniMapSize();


        //test.rectTransform.position = miniMapLeftPos;
    }

    private void FixedUpdate()
    {
        TestMenuAnim();

    }


    public static void MiniMapSize()
    {
        //miniMap.rectTransform.pivot = new Vector3(0.5f, 0.5f);  //确保图片的坐标从图片中心计算(只要不是从(0,0)就行，否则不知道size）
        //miniMapLeftPos = Vector3.zero - miniMap.rectTransform.position;
        //miniMapSize = new Vector2(miniMap.rectTransform.position.x / miniMap.rectTransform.pivot.x, miniMap.rectTransform.position.y / miniMap.rectTransform.pivot.y);

        //Debug.Log(miniMap);

        miniMap.rectTransform.pivot = new Vector2(1, 1);
        miniMapRightPos = miniMap.rectTransform.position;

        miniMap.rectTransform.pivot = new Vector3(0, 0);
        miniMapLeftPos = miniMap.rectTransform.position;

        miniMapSize = miniMapRightPos - miniMapLeftPos;
        //Debug.Log("Minimapsize:" + miniMapSize);

    }

    /// <summary>
    /// 关闭的按钮
    /// </summary>
    public void CloseClick()
    {
        Debug.Log("Close");
        Application.Quit();
    }

    Transform heroObj;

    /// <summary>
    /// add的按钮
    /// </summary>
    public void AddClick()
    {
        if (tragima)
        {
            Debug.Log("23");
            IniObj(ima01);
            MouseSelect.characters.Add(heroObj);
            PlayerControl.playObj.Add(heroObj);
        }
    }


    /// <summary>
    /// 图片点击变色  开关效果
    /// </summary>
    public void Image1Click()
    {
        Debug.Log("mimimimini");
        tragima = !tragima;
        if (tragima)
        {
            Color co = new Color(1, 1, 1, 1);
            Debug.Log(co);
            ima01.color = co;
        }
        else
        {
            Color co = new Color(155f / 255f, 155f / 255f, 155f / 255f, 155f / 255f);
            Debug.Log(co);
            ima01.color = co;
        }

    }


    /// <summary>
    /// 小地图点击事件(将弃用)  只能一下下的点
    /// </summary>
    public void MiniMapDown()
    {
        //MiniMapSize();

        miniMapDown = true;
        //Vector3 mScreenPos = Input.mousePosition;
        //Vector2 sizePos = new Vector2(miniMap.transform.position.x - miniMap.rectTransform.sizeDelta.x/2, miniMap.transform.position.y - miniMap.rectTransform.sizeDelta.y/2);

        //Debug.Log("mScreenpos=" + mScreenPos + "\t" + "thispos" + miniMap.transform.position + " \t" + miniMap.rectTransform.sizeDelta);
        ////Debug.Log("terrain.terrainData.alphamapWidth=" + terrain.terrainData.bounds.size.z+ "\t" );

        //Vector3 getpos = new Vector3((mScreenPos.x - sizePos.x) * terrain.terrainData.bounds.size.x / miniMap.rectTransform.sizeDelta.x,40f, (mScreenPos.y - sizePos.y) * terrain.terrainData.bounds.size.z / miniMap.rectTransform.sizeDelta.y);

        //Debug.Log("getpos=" + getpos +  "\t" );

        ////110 - 
        //mainCamera.transform.position = getpos;


    }
    public void MiniMapUp()
    {

        miniMapDown = false;
    }


    bool IsPointInMatrix(Vector2 point, object matrix)
    {
        Vector2 imaVec = Camera.main.WorldToScreenPoint(ima01.transform.position);
        Vector2 imaSize = ima01.rectTransform.sizeDelta;

        //Vector2 p1 = imaVec;
        //Vector2 p3 = new Vector2(imaVec.x + imaScale.x, imaVec.y + imaScale.y);

        Debug.Log(imaSize + "1:" + point + "\t" + imaVec);
        Debug.Log(point.x > imaVec.x);
        Debug.Log(point.x < imaVec.x + imaSize.x );

        bool result = false;
        if (point.x > imaVec.x && point.x < imaVec.x + imaSize.x && point.y < imaVec.y && point.y > imaVec.y + imaSize.y)
        {
            result = true;
        }
        return result;
    }


    /// <summary>
    /// 实例化对象到场景起始点
    /// </summary>
    /// <param name="value"></param>
    void IniObj(RawImage value)
    {
        //GameObject go= (GameObject)Resources.Load("Prefabs/" + value.name);
        //Debug.Log("1:" + go + "\t" + go.tag);
        heroObj = Instantiate((Transform)Resources.Load("Prefabs/" + value.name), startPos.position, startPos.rotation);
    }


    /// <summary>
    /// 测试菜单按钮
    /// </summary>
    public void TestMenuBtnClick()
    {
        isTestMenuOpen = !isTestMenuOpen;
    }

    void TestMenuAnim()
    {
        GameObject gb = testMenu.transform.Find(" MenuInfo").gameObject;  //////////////Find主要查找的名字与前面的冒号要有空格，否则找不到实例
        float menuInfoWide = testMenu.GetComponent<RectTransform>().rect.size.x;
        Vector2 testMenuPos = testMenu.GetComponent<RectTransform>().position;
        //Debug.Log(gb.transform.position);
        if (isTestMenuOpen)
        {
            // GameObject gb = GameObject.Find("../MenuInfo");
            gb.transform.position = new Vector2(Mathf.Lerp(testMenuPos.x + menuInfoWide, testMenuPos.x, Time.deltaTime), Mathf.Lerp(gb.transform.position.y, gb.transform.position.y, 0.01f* Time.deltaTime));
            //gb.transform.Translate(new Vector2(menuInfoWide, 0));
        }
        else
        {

            gb.transform.position = new Vector2(Mathf.Lerp(testMenuPos.x, testMenuPos.x + menuInfoWide, 0.0001f), Mathf.Lerp(gb.transform.position.y, gb.transform.position.y, 0.001f * Time.deltaTime));
            //            gb.transform.position = new Vector2(Mathf.Lerp(gb.transform.position.x, gb.transform.position.x + menuInfoWide, Time.deltaTime), Mathf.Lerp(gb.transform.position.y, gb.transform.position.y, Time.deltaTime));
        }
    }
}

