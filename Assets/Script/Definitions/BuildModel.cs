using UnityEngine;
using System.Collections;

public class BuildModel : UnitDefinition
{
    public bool born;               //是否重生
    public int bornTime;            //重生时间
    public bool initiative;         //是否攻击
    public bool infrared;           //红外线 （是否反隐）


    public BuildModel()
    {
    }


    public BuildModel(int id, int modelId, int hp, int hpMax, int atk, int def, bool reborn, int rebornTime, bool initiative, bool infrared, string name)
    {
        this.id = id;
        this.modelId = modelId;
        this.hp = hp;
        this.maxHp = hpMax;
        this.atk = atk;
        this.def = def;
        this.born = reborn;
        this.bornTime = rebornTime;
        this.initiative = initiative;
        this.infrared = infrared;
        this.name = name;
    }

}
