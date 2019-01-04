using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : GameManager
{

    public int m_maxNum;
    public int m_currentNum;
    public Transform[] m_BirthPoint;       //敌人出生点
    private Enemy[] m_Enemy_type1;            //类型1敌人池
    private Enemy[] m_Enemy_type2;            //类型2敌人池

    public static EnemyManager instance;

    private void Awake()
    {
        instance = this;
        m_Enemy_type1 = new Enemy[m_maxNum];
    }


    /// <summary>
    /// 初始化敌人数据，通过资源加载类实例化敌人
    /// </summary>
    public void Init() {

        /*  实例化模板
        mEnemy_type1[0] = new Enemy();
        mEnemy_type1[0].mprefab = m_LoadResource.LoadEnemy("mEnemy_type1");
        mEnemy_type1[0].mprefab.transform.parent = BirthPoint[0];
        mEnemy_type1[0].Init(100f,100f,2f,20f,"asd",0);
        */
    }

    public void Die(int num) {
        
    }

    public void Revive(int num) {

    }
}
