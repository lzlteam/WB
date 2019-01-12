using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileMessage
{

    public float hp;
    public float x;
    public float y;
    public float z;
    public Dictionary<string, Prop> OwnProp;
    /// <summary>
    /// 敌人坐标数组
    /// </summary>
    public float[] EnemiesPosition_X;
    public float[] EnemiesPosition_Y;
    public float[] EnemiesPosition_Z;

    /// <summary>
    /// 场景中道具的位置信息
    /// </summary>
    public float[] PropPosition_X;
    public float[] PropPosition_Y;
    public float[] PropPosition_Z;





    /// <summary>
    /// 敌人状态机状态数组
    /// </summary>
    public EnemyAI.Enemytype[] Enemytypes;




    public FileMessage() { }

    public FileMessage(Robot robotInfo)
    {
        hp = robotInfo.m_attribut.m_hp;
        x = robotInfo.m_Robot.transform.position.x;
        y = robotInfo.m_Robot.transform.position.y;
        z = robotInfo.m_Robot.transform.position.z;

        List<Enemy> enemiesList = EnemyManager.instance.GetAllEnemies();
        EnemiesPosition_X = new float[enemiesList.Count];
        EnemiesPosition_Y = new float[enemiesList.Count];
        EnemiesPosition_Z = new float[enemiesList.Count];
        Enemytypes = new EnemyAI.Enemytype[enemiesList.Count];
        for (int i = 0; i < enemiesList.Count; i++)
        {
            Enemytypes[i] = enemiesList[i].m_enemyAI.m_enemytype;
            EnemiesPosition_X[i] = enemiesList[i].m_prefab.transform.position.x;
            EnemiesPosition_Y[i] = enemiesList[i].m_prefab.transform.position.y;
            EnemiesPosition_Z[i] = enemiesList[i].m_prefab.transform.position.z;
        }

        

        OwnProp = new Dictionary<string, Prop>();
        foreach (KeyValuePair<string, BagProp> kvps in PropMgr.instance.m_OwnProp)
        {
            Prop prop = new Prop
            {
                m_name = kvps.Value.m_name,
                m_allNum = kvps.Value.m_allNum,
                m_IsOwn = true
            };
            OwnProp.Add(kvps.Key, prop);
        }
    }
}
