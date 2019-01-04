using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //场景是否已经初始化过
    private static bool mIsInit = false;
    //命令队列
    protected static KeyCode[] mOperat = new KeyCode[10];
    //输入命令位符
    private static int mEnter = 0;
    //记录输入间隔
    private float time = 0.0f;
    //隔多少秒接收一次输入
    private float interput = 1f;

    //实例化资源加载类，以供子类（其他管理类）实例化对应资源时调用
    protected LoadResource m_LoadResource = new LoadResource();

    

    /// <summary>
    /// 初始化场景中，需要预先加载的资源
    /// </summary>
    public void InitScene() {
        if (mIsInit)
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
    /// 对输入命令进行接收
    /// </summary>
    private void OnGUI()
    {
        time += Time.deltaTime;
        Event e = Event.current;
        if (e.isKey && time > interput)
        {
            mOperat[mEnter] = e.keyCode;

            mEnter++;
            mEnter %= 10;

            time = 0.0f;
        }

        if (e.isMouse && time > interput)
        {

        }
    }


}
