using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    /// 载入存档背包数据,场景内道具信息
    /// </summary>
    /// <param name="fileMessage"></param>
    public void PropLoadSave(FileMessage fileMessage)
    {


        int i = 0;
        PropMgr.instance.m_AllProp.Clear();
        PropMgr.instance.Init();


        //先清空背包道具字典，然后读取存档中相关的信息
        PropMgr.instance.m_OwnProp.Clear();
        for (i = 0; i < fileMessage.m_MaxBagPropNum; i++)
        {
            BagProp bagprop = new BagProp
            {
                m_name = fileMessage.m_name[i],
                m_allNum = fileMessage.m_allNum[i],
                m_ID = fileMessage.m_ID[i],
                m_IsOwn = fileMessage.m_IsOwn[i],
                m_OwnAllNum = fileMessage.m_OwnAllNum[i],
                m_Proptype = fileMessage.m_Proptype[i],
                m_Prefeb = null
            };
            PropMgr.instance.m_OwnProp.Add(bagprop.m_name, bagprop);
            
            PropMgr.instance.m_AllProp[bagprop.m_name] = bagprop;
        }

        //先清空背包UI字典，再将存档中的信息赋值给对应的
        UIController.instance.m_propUI.m_bagIndex.Clear();
        for (i = 0; i < fileMessage.m_MaxPropUINum; i++)
        {
            UIController.instance.m_propUI.m_bagIndex.Add(fileMessage.m_panelNum[i], fileMessage.m_isNull[i]);
            UIController.instance.m_propUI.m_images[i].name = fileMessage.m_sprite[i];
            UIController.instance.m_propUI.m_images[i].sprite = PropMgr.instance.GetSprite(fileMessage.m_sprite[i]);

            //格子为空的就不需要改变他的下标
            if (fileMessage.m_isNull[i])
            {
                UIController.instance.m_propUI.UpdatePanel(fileMessage.m_sprite[i]);
            }
            
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
