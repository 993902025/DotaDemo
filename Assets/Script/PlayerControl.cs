using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour
{

    

    public float speed;
    private Camera mainCamera;
    protected UnityEngine.AI.NavMeshAgent agent;
    protected Animator anim;
    protected static int  state = AnimState.IDLE;

    private Vector3 target;

    public static List<Transform> controlObj = new List<Transform>();
    public static List<Animator> playerAni;
    public static List<UnityEngine.AI.NavMeshAgent> playerAgent;
    public static List<Transform> playObj = new List<Transform>();

    // Use this for initialization
    void Start()
    {
        mainCamera = Camera.main;
        //myHero = (GameObject)Resources.Load("Prefabs/Hero_Ali");
        try
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Player"))
            {
                
                playObj.Add(go.transform);
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex);
        }

        foreach (Transform item in MouseSelect.characters)
        {
            item.GetComponent<Animator>().SetInteger("state", AnimState.IDLE); Debug.Log("Unit 中的对象有：" + item);
            //    playerAni.Add(item.GetComponent<Animator>());
            //    playerAgent.Add(item.GetComponent<UnityEngine.AI.NavMeshAgent>());
        }
        //agent.speed = 6;
        //agent.angularSpeed = 5000;
        //agent.acceleration = 1000;
       
    }

    // Update is called once per frame
    void Update()
    {

        switch (state)
        {
            case AnimState.RUN:
                if (playObj.Count > 0)
                {

                    foreach (Transform item in playObj)
                    {
                        if (item.GetComponent<UnityEngine.AI.NavMeshAgent>().pathStatus == UnityEngine.AI.NavMeshPathStatus.PathComplete && item.GetComponent<UnityEngine.AI.NavMeshAgent>().remainingDistance <= 0.1 && !item.GetComponent<UnityEngine.AI.NavMeshAgent>().pathPending)
                        {
                            state = AnimState.IDLE;
                            item.GetComponent<Animator>().SetInteger("state", AnimState.IDLE);
                        }
                        else
                        {
                            if (item.GetComponent<UnityEngine.AI.NavMeshAgent>().isOnOffMeshLink)
                            {
                                item.GetComponent<UnityEngine.AI.NavMeshAgent>().CompleteOffMeshLink();
                            }
                        }

                    }
                }
                break;
        }


        if (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1))
        {
            if (controlObj.Count > 0)
            {

                //获取屏幕坐标
                Vector3 mScreenPos = Input.mousePosition;
                Ray ray = mainCamera.ScreenPointToRay(mScreenPos);
                RaycastHit[] hits = Physics.RaycastAll(ray, 200);
                for (int i = hits.Length - 1; i >= 0; i--)
                {
                    RaycastHit item = hits[i];

                    //如果是敌方单位 则进行普通攻击
                    //if (item.transform.gameObject.layer == LayerMask.NameToLayer("enemy"))
                    //{
                    //    PlayerCon con = item.transform.GetComponent<PlayerCon>();
                    //    if (Vector3.Distance(myHero.transform.position, item.transform.position) < con.data.aRange)
                    //    {
                    //        //记住扩展 如果需要实现分裂攻击 消息体改为 范围内敌人ID数组

                    //        return;
                    //    }
                    //    continue;
                    //}
                    //己方单位无视
                    //如果是地板层 则开始寻路
                    if (item.transform.gameObject.layer == LayerMask.NameToLayer("Terrain"))
                    {

                        target = new Vector3(item.point.x, item.point.y, item.point.z);

                        move(target);
                        return;

                    }
                }
            }
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //获取屏幕坐标
        //    Vector3 mScreenPos = Input.mousePosition;
        //    Ray ray = mainCamera.ScreenPointToRay(mScreenPos);
        //    RaycastHit[] hits = Physics.RaycastAll(ray, 200);
        //    for (int i = hits.Length - 1; i >= 0; i--)
        //    {
        //        RaycastHit item = hits[i];

        //        //如果是敌方单位 则进行普通攻击
        //        //if (item.transform.gameObject.layer == LayerMask.NameToLayer("enemy"))
        //        //{
        //        //    PlayerCon con = item.transform.GetComponent<PlayerCon>();
        //        //    if (Vector3.Distance(myHero.transform.position, item.transform.position) < con.data.aRange)
        //        //    {
        //        //        //记住扩展 如果需要实现分裂攻击 消息体改为 范围内敌人ID数组

        //        //        return;
        //        //    }
        //        //    continue;
        //        //}
        //        //己方单位无视
        //        //如果是地板层 则开始寻路
        //        if (item.transform.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        //        {

        //            target = new Vector3(item.point.x, item.point.y, item.point.z);
        //            //move(target);
        //            controlObj.Clear();
        //            return;
        //        }
        //    }
        //}
    }


    public static void move(Vector3 target)
    {
        foreach (Transform pobj in controlObj)
        {
            pobj.GetComponent<UnityEngine.AI.NavMeshAgent>().ResetPath();
            pobj.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(target);
            pobj.GetComponent<Animator>().SetInteger("state", AnimState.RUN);
            state = AnimState.RUN;
        }
        //Debug.Log(myHero + "\n" + state + "\n" + myHero.transform.position);
    }


    void Ray()
    {
        //获取屏幕坐标
        Vector3 mScreenPos = Input.mousePosition;
        Ray ray = mainCamera.ScreenPointToRay(mScreenPos);
        RaycastHit[] hits = Physics.RaycastAll(ray, 200);
        for (int i = hits.Length - 1; i >= 0; i--)
        {
            RaycastHit item = hits[i];

            //如果是敌方单位 则进行普通攻击
            //if (item.transform.gameObject.layer == LayerMask.NameToLayer("enemy"))
            //{
            //    PlayerCon con = item.transform.GetComponent<PlayerCon>();
            //    if (Vector3.Distance(myHero.transform.position, item.transform.position) < con.data.aRange)
            //    {
            //        //记住扩展 如果需要实现分裂攻击 消息体改为 范围内敌人ID数组

            //        return;
            //    }
            //    continue;
            //}
            //己方单位无视
            //如果是地板层 则开始寻路
            if (item.transform.gameObject.layer == LayerMask.NameToLayer("Terrain"))
            {

                target = new Vector3(item.point.x, item.point.y, item.point.z);
                move(target);
                return;

            }
        }
    }


}
