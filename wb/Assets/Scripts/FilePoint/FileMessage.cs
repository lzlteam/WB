using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileMessage
{

    public float hp;
    public float x;
    public float y;
    public float z;

    //所有道具字典
    public int m_MaxPropNum;
    public string[] m_prop_name;
    public bool[] m_prop_IsOwn;
    public int[] m_prop_allnum;
    public int[] m_prop_proptype;

    //背包道具属性
    public int m_MaxBagPropNum;
    public string[] m_name;
    public int[] m_allNum;
    public int[] m_OwnAllNum;
    public int[] m_ID;
    public int[] m_Proptype;
    public bool[] m_IsOwn;

    //背包UI属性
    public int m_MaxPropUINum;
    public int[] m_panelNum;
    public bool[] m_isNull;
    public string[] m_sprite;



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
        int i = 0;  //for循环Index

        hp = robotInfo.m_attribut.m_hp;
        x = robotInfo.m_Robot.transform.position.x;
        y = robotInfo.m_Robot.transform.position.y;
        z = robotInfo.m_Robot.transform.position.z;

        List<Enemy> enemiesList = EnemyManager.instance.GetAllEnemies();
        EnemiesPosition_X = new float[enemiesList.Count];
        EnemiesPosition_Y = new float[enemiesList.Count];
        EnemiesPosition_Z = new float[enemiesList.Count];
        Enemytypes = new EnemyAI.Enemytype[enemiesList.Count];
        for (i = 0; i < enemiesList.Count; i++)
        {
            Enemytypes[i] = enemiesList[i].m_enemyAI.m_enemytype;
            EnemiesPosition_X[i] = enemiesList[i].m_prefab.transform.position.x;
            EnemiesPosition_Y[i] = enemiesList[i].m_prefab.transform.position.y;
            EnemiesPosition_Z[i] = enemiesList[i].m_prefab.transform.position.z;
        }


        //所有道具字典信息
        i = 0;
        m_MaxPropNum = PropMgr.instance.m_AllProp.Count;
        m_prop_allnum = new int[m_MaxPropNum];
        m_prop_IsOwn = new bool[m_MaxPropNum];
        m_prop_name = new string[m_MaxPropNum];
        m_prop_proptype = new int[m_MaxPropNum];
        foreach (KeyValuePair<string, Prop> kvps in PropMgr.instance.m_AllProp)
        {
            m_prop_proptype[i] = kvps.Value.m_Proptype;
            m_prop_allnum[i] = kvps.Value.m_allNum;
            m_prop_name[i] = kvps.Value.m_name;
            m_prop_IsOwn[i] = kvps.Value.m_IsOwn;
            i++;
        }

        //存储道具背包信息
        i = 0;
        m_MaxBagPropNum = PropMgr.instance.m_OwnProp.Count;
        m_name = new string[m_MaxBagPropNum];
        m_allNum = new int[m_MaxBagPropNum];
        m_ID = new int[m_MaxBagPropNum];
        m_IsOwn = new bool[m_MaxBagPropNum];
        m_OwnAllNum = new int[m_MaxBagPropNum];
        m_Proptype = new int[m_MaxBagPropNum];
        foreach (KeyValuePair<string, BagProp> kyls in PropMgr.instance.m_OwnProp) {
            m_allNum[i] = kyls.Value.m_allNum;
            m_name[i] = kyls.Value.m_name;
            m_ID[i] = kyls.Value.m_ID;
            m_IsOwn[i] = kyls.Value.m_IsOwn;
            m_Proptype[i] = kyls.Value.m_Proptype;
            m_OwnAllNum[i] = kyls.Value.m_OwnAllNum;
            i++;
        }

        //存储背包UI信息
        i = 0;
        m_MaxPropUINum = UIController.instance.m_propUI.GetMaxBagNum();
        m_panelNum = new int[m_MaxPropUINum];
        m_isNull = new bool[m_MaxPropUINum];
        m_sprite = new string[m_MaxPropUINum];
        foreach (KeyValuePair<int, bool> kyls in UIController.instance.m_propUI.m_bagIndex) {
            m_panelNum[i] = kyls.Key;
            m_isNull[i] = kyls.Value;
            m_sprite[i] = UIController.instance.m_propUI.m_images[kyls.Key].name;
            i++;
        }

        /* foreach (KeyValuePair<int, bool> kvps in UIController.instance.m_propUI.GetPropDictionary())
         {


         }*/


    }
}
