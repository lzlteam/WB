using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute{
    
    public float m_hp;                    //生命值
    public float m_damage;                //伤害值
    public float m_hpmax;                 //最大生命值
    public string m_name;                 //名字
    public float m_speed;                 //速度

    public Attribute(float hp,float maxhp,float speed,float damage,string name) {
        m_hp = hp;
        m_hpmax = maxhp;
        m_speed = speed;
        m_damage = damage;
        m_name = name;
    }

    public void HpUp(float vhp) {
        m_hp += vhp;
    }
    public void HpDown(float vhp) {
        m_hp -= vhp;
    }

    public float GetCurrentHp() {
        return m_hp;
    }
}
