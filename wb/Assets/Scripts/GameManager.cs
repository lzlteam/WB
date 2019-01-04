using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //场景是否已经初始化过
    private static bool m_IsInit = false;
    //命令队列
    protected static KeyCode[] m_Operat = new KeyCode[10];


    //实例化资源加载类，以供子类（其他管理类）实例化对应资源时调用
    protected LoadResource m_LoadResource = new LoadResource();

    

    /// <summary>
    /// 初始化场景中，需要预先加载的资源
    /// </summary>
    public void InitScene() {
        if (m_IsInit)
        {
            return;
        }
        else {

            //RobotManager.instance.Init();
            EnemyManager.instance.Init();
            UIController.instance.Init();
        }
    }




}
