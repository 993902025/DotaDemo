using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
//
// 摘要:
//     ///
//     单位属性
//     ///
public class UnitDefinition
{

    public int id;            //单位唯一标识id
    public ModelType type;      //单位类型
    public int modelId;      //单位对应的模型编号（可能多个单位使用同一个模型）
    public int team;            //单位所属阵营 0=中立  1=天辉    2=夜魇
    public bool inSelect;       //单位是否被选择
    public string name;         //单位的名称 例如显示在信息栏中  显示在头顶  显示在小地图
    public float maxHp;         //生命上限
    public float hp;            //当前生命
    public float hpRecovery;    //生命恢复速度
    public float maxMana;       //魔法上限
    public float mana;          //当前魔法
    public int atk;             //攻击力
    public int def;             //护甲
    public int magicDef;        //魔法抗性
    public float movespeed;     //移动速度
    public float atkSpeed;      //攻击速度
    public float atkRange;      //攻击范围
    public float eyeRange;      //视野范围
    public bool ifSelect;       //是否能被选取    (例如技能)
    public bool ifAtk;          //是否能被普通攻击
    public bool ifMagic;        //是否能被技能攻击
    
    //private GameObject unit;        

    //public UnitDefinition()
    //{
    //}

    //public UnitDefinition(int team ,int id, string modelid)
    //{
    //    this.team = team;
    //    this.id = id;
    //    this.modelId = modelid;
    //    unit = GameObject.Find(ModelId);
    //}

    //public void InitUnit(int team, int id, string modelid)
    //{
    //    teamId = team;
    //    Id = id;
    //    ModelId = modelid;
    //    unit = GameObject.Find(ModelId);
    //}

}


/// <summary>
/// 单位类型
/// </summary>
public enum ModelType
{
    BUILD,  //建筑
    HUMAN   //生物
}