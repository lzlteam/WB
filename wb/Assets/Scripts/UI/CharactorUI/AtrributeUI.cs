using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtrributeUI : CharactorUI
{
    public Text m_name;
    public Slider m_hp;
    public Image m_headPortrait;
    public GameObject m_atrributeUI;


    /// <summary>
    /// 将机器人的基本属性赋值给UI，完成初始化,通过find方法找到对应的gameobject
    /// </summary>
    public void Init()
    {
        /*    初始化 示例
        */

        m_name = m_atrributeUI.GetComponentInChildren<Text>();
        m_name.text = RobotManager.instance.m_robot.m_attribut.m_name;
        m_hp = m_atrributeUI.GetComponentInChildren<Slider>();
        m_hp.value = RobotManager.instance.m_robot.m_attribut.m_hp;
    }

    /// <summary>
    /// 更新血条
    /// </summary>
    void Update() {

    }
}
