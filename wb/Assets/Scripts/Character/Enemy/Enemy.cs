using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Attribute mattribut;
    public EnemyAI menemyAI;
    public GameObject mprefab;
    public ParticleSystem mparticle;
    public int mID;       //敌人在敌人池中的id

    public void Revive() {
        gameObject.SetActive(true);
    }

    public void Die() {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 初始化敌人数据
    /// </summary>
    /// <param name="BirthPoint"></param>
    public void Init(float hp, float maxhp, float speed, float damage, string name,int id) {
        mattribut = new Attribute(hp, maxhp, speed, damage, name);
        mID = id;
    }

    /// <summary>
    /// 在update中根据情况，变更状态
    /// </summary>
    private void Update()
    {
        
    }

}
