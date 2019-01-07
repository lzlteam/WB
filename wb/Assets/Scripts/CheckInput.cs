using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInput : GameManager {

    //输入命令位符
    private static int m_Enter = 0;
    //记录输入间隔
    private float m_time = 0.0f;
    //隔多少秒接收一次输入
    private float m_interput = 0.3f;

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
