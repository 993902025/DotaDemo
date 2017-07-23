using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : UnitDefinition
{

    public int user;
    public int strength;        //属性-力量
    public int agility;         //属性-敏捷
    public int intellect;       //属性-智力
    public int strengthArr;     //力量成长
    public int agilityArr;      //敏捷成长
    public int intellectArr;    //智力成长
    public int[] skills;        //拥有技能


 //   public GameObject heroObj;

 //   // Use this for initialization
 //   public Hero()
 //   {
 //       userId = 0;
 //       life = 100;
 //       mana = 100;
 //   }
 //   public Hero(int u, int l, int m)
 //   {
 //       userId = u;
 //       life = l;
 //       mana = m;
	//}
 //   public void Get(ref int u,ref  int l,ref int m)
 //   {
 //       u = userId;
 //       l = life;
 //       m = mana;
 //   }

 //   public void addModel(string value)
 //   {
 //       heroObj = (GameObject)Resources.Load("Prefabs/" + value);
 //   }
	
}
