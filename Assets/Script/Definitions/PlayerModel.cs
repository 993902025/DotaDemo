using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class PlayerModel : UnitDefinition
{
    public int level;       //等级
    public int exp;         //经验
    public int money;       //玩家经济
    public int[] equs;      //玩家装备
    public SkillModel[] skills;     //玩家拥有技能
    public int mp;          //当前能量
    public int maxMp;       //最大能量

    public Transform startPos;

    public List<Hero> hero = new List<Hero>();

    public bool dead;


}
