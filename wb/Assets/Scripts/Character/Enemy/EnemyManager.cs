using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public int maxNum;
    public int currentNum;
    public Transform BirthPoint;       //敌人出生点
    private Enemy[] mEnemy;            //敌人池
    public string[] mprefab;           //敌人模型
    public static EnemyManager instance;

    private void Awake()
    {
        instance = this;
        mEnemy = new Enemy[maxNum];
    }


    /// <summary>
    /// 初始化敌人数据，通过资源加载类实例化敌人
    /// </summary>
    public void Init() {
        
    }

    public void Die(int num) {
        mEnemy[num].Die();
    }

    public void Revive(int num) {
        mEnemy[num].Revive();
    }
}
