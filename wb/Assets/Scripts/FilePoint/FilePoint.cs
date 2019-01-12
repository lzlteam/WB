using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilePoint : GameManager
{

    public static FilePoint Instance;

    private void Awake()
    {
        Instance = this;
    }


    /// <summary>
    /// 存档
    /// </summary>
    /// <param name="h"></param>
    public void Save(Robot robotInfo)
    {
        FileSave fs = new FileSave();
        fs.Save(robotInfo);
    }

    /// <summary>
    /// 恢复血量
    /// </summary>
    public void Recover()
    {
        //PlayerManager.instance.HpUp();
    }

    /// <summary>
    /// 读取存档
    /// </summary>
    public void Read()
    {
        FileSave fs = new FileSave();
        FileMessage fm = fs.Read();
        PropLoadSave(fm);
        RobotLoadSave(fm);
        EnemyLoadSave(fm);
    }

    /// <summary>
    /// 载入存档背包数据
    /// </summary>
    /// <param name="fileMessage"></param>
    public void PropLoadSave(FileMessage fileMessage)
    {
        foreach (KeyValuePair<string, Prop> kvps in fileMessage.OwnProp)
        {
            UIController.instance.Add(kvps.Key);
            PropMgr.instance.m_OwnProp[kvps.Key].m_allNum = kvps.Value.m_allNum;
        }
    }

    /// <summary>
    /// 载入存档主角数据
    /// </summary>
    /// <param name="fileMessage"></param>
    public void RobotLoadSave(FileMessage fileMessage)
    {
        RobotManager.instance.m_robot.m_attribut.m_hp = fileMessage.hp;
        Vector3 Position = new Vector3(fileMessage.x, fileMessage.y, fileMessage.z);
        RobotManager.instance.m_robot.m_Robot.transform.position = Position;
    }

    /// <summary>
    /// 载入敌人数据
    /// </summary>
    /// <param name="fileMessage"></param>
    public void EnemyLoadSave(FileMessage fileMessage)
    {
        List<Enemy> enemylist = EnemyManager.instance.GetAllEnemies();
        for (int i = 0; i < enemylist.Count; i++)
        {
            Vector3 Position = new Vector3(fileMessage.EnemiesPosition_X[i], fileMessage.EnemiesPosition_Y[i], fileMessage.EnemiesPosition_Z[i]);
            enemylist[i].m_prefab.transform.position = Position;
            enemylist[i].m_enemyAI.m_enemytype = fileMessage.Enemytypes[i];
        }
        EnemyManager.instance.SetAllEnemies(enemylist);
    }


}
