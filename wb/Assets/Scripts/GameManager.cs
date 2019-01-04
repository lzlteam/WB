using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //场景是否已经初始化过
    private static bool m_IsInit = false;
    //命令队列
    protected static KeyCode[] m_Operat = new KeyCode[10];
    //输入命令位符
    private static int m_Enter = 0;
    //记录输入间隔
    private float m_time = 0.0f;
    //隔多少秒接收一次输入
    private float m_interput = 1f;

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

    /// <summary>
    /// 对键盘输入命令进行接收
    /// </summary>
    private void OnGUI()
    {
        m_time += Time.deltaTime;
        Event e = Event.current;
        if (e.isKey && m_time > m_interput)
        {
            m_Operat[m_Enter] = e.keyCode;

            m_Enter++;
            m_Enter %= 10;

            m_time = 0.0f;
        }

        if (e.isMouse && m_time > m_interput)
        {

        }
    }


}
