using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute{
    
    public float mhp;                    //生命值
    public float mdamage;                //伤害值
    public float mhpmax;                 //最大生命值
    public string mname;                 //名字
    public float mspeed;                 //速度

    public Attribute(float hp,float maxhp,float speed,float damage,string name) {
        mhp = hp;
        mhpmax = maxhp;
        mspeed = speed;
        mdamage = damage;
        mname = name;
    }

    public void HpUp(float vhp) {
        mhp += vhp;
    }
    public void HpDown(float vhp) {
        mhp -= vhp;
    }

    public float GetCurrentHp() {
        return mhp;
    }
}
