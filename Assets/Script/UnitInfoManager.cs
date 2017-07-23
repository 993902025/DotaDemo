using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UnitInfoManager : MonoBehaviour {

    public static UnitInfoManager Current;

    public Image HeadPic;
    public Text unitAggressivity, unitArmor, unitMoveSpeed, unitLiDao, unitShenfa, unitYuanqi;


    public UnitInfoManager()
    {
        Current = this;
    }


    public void SetInfo(string agg, string armor, string mvspeed, string ld, string sf, string yq)
    {
        unitAggressivity.text = agg;
        unitArmor.text = armor;
        unitMoveSpeed.text = mvspeed;
        unitLiDao.text = ld;
        unitShenfa.text = sf;
        unitYuanqi.text = yq;
    }

    public void ClearInfo()
    {
        SetInfo(" ", " ", " ", " ", " ", " ");
    }

    /// <summary>
    /// 设置头像
    /// </summary>
    public void SetHeadPic(string pic)
    {
        
    }

    public void ClearHeadPic()
    {
        SetHeadPic(" ");
    }


	// Use this for initialization
	void Start () {

    }
	
}
