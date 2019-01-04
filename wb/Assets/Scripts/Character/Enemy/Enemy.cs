using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy{

    public Attribute m_attribut;
    public EnemyAI m_enemyAI;
    public GameObject m_prefab;
    public ParticleSystem m_particle;
    public int m_ID;       //敌人在敌人池中的id
    

    public void Revive() {
        m_prefab.SetActive(true);
    }

    public void Die() {
        m_prefab.SetActive(false);
    }

    /// <summary>
    /// 初始化敌人数据
    /// </summary>
    /// <param name="BirthPoint"></param>
    public void Init(float hp, float maxhp, float speed, float damage, string name,int id) {
        m_attribut = new Attribute(hp, maxhp, speed, damage, name);
        m_ID = id;
        m_enemyAI = new EnemyAI();
    }

    /// <summary>
    /// 在update中根据情况，变更状态
    /// </summary>
    private void Update()
    {
        
    }

}
