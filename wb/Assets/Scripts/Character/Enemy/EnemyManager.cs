using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : GameManager
{

    private int m_maxNum = 2;
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
    /// 检测状态
    /// </summary>
    private void Update()
    {
        int i = 0;
        for (i = 0; i < m_maxNum; i++)
        {
            if (m_Enemy_type1[i].m_prefab.activeSelf == true)
            {
                m_Enemy_type1[i].m_enemyAI.StateChange(m_Enemy_type1[i].m_enemyAI.m_enemytype);
            }
        }
    }

    /// <summary>
    /// 初始化敌人数据，通过资源加载类实例化敌人
    /// </summary>
    public void Init()
    {

        /*  实例化模板
        mEnemy_type1[0] = new Enemy();
        mEnemy_type1[0].mprefab = m_LoadResource.LoadEnemy("mEnemy_type1");
        mEnemy_type1[0].mprefab.transform.parent = BirthPoint[0];
        mEnemy_type1[0].Init(100f,100f,2f,20f,"asd",0);
        */
        for (int i = 0; i < m_maxNum; i++)
        {
            m_Enemy_type1[i] = new Enemy();
            m_Enemy_type1[i].m_prefab = m_LoadResource.LoadEnemy("mEnemy_type1");


            m_Enemy_type1[i].m_prefab.transform.position = m_BirthPoint[i].position;
            m_Enemy_type1[i].Init(100f, 100f, 2f, 10f, "mEnemy_type1" , 0);


            //m_Enemy_type1[i].m_prefab.name = m_Enemy_type1[i].m_attribute.m_name;
        }
    }

    public void Die(int num)
    {
        StartCoroutine(m_Enemy_type1[num].LaterDeath());
    }

    public void Revive(int num)
    {
        m_Enemy_type1[num].ReLive();
    }


    public List<Enemy> GetAllEnemies()
    {
        List<Enemy> enemylist = new List<Enemy>(m_Enemy_type1);
        /*for (int i = 0; i < m_Enemy_type2.Length; i++)
        {
            //enemies.Add(m_Enemy_type2[i]);
        }*/
        return enemylist;
    }

    public void SetAllEnemies(List<Enemy> enemylist)
    {
        int i = 0;
        for (; i < m_Enemy_type1.Length; i++)
        {
            m_Enemy_type1[i] = enemylist[i];
        }

        /*for(; i < m_Enemy_type1.Length + m_Enemy_type2.Length; i++)
        {
            m_Enemy_type2[i] = enemylist[i];
        }*/
    }


}
