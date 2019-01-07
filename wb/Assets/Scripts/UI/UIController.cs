using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : GameManager
{
    private MainMeul m_mainmeulUI;
    private PropUI m_propUI;
    private AtrributeUI m_atrributeUI;
    private TaskUI m_taskUI;
    private bool m_isBagOpen = false;            //保存背包的状态
    private bool m_isMeulOpen = false;           //保存菜单的状态 

    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// 初始化UI相关
    /// </summary>
    public void Init()
    {
        m_mainmeulUI = new MainMeul();
        m_propUI = new PropUI();
        m_atrributeUI = new AtrributeUI();
        m_taskUI = new TaskUI();
        

        m_mainmeulUI.m_meul = GameObject.Find("UIController/Meul");
        m_propUI.m_bag = GameObject.Find("UIController/CharactorUI/PropUI");
        m_atrributeUI.m_atrributeUI = GameObject.Find("UIController/CharactorUI/AtrributeUI");
        //m_taskUI.m_TaskUI = GameObject.Find("TaskUI");

        m_propUI.Init();
        m_mainmeulUI.Init();
        m_atrributeUI.Init();
        m_taskUI.Init();


        Cursor.visible = false;
    }


    /// <summary>
    /// 打开/关闭背包UI
    /// </summary>
    public void ShowBagUI() {

        if (m_isBagOpen)
        {
            m_propUI.Hide();
            Cursor.visible = false;
            m_isBagOpen = false;
        }
        else
        {
            Cursor.visible = true;
            m_propUI.Show();
            m_isBagOpen = true;
        }
    }

    

    /// <summary>
    /// 打开/关闭菜单UI
    /// </summary>
    public void ShowMeulUI() {
        if (m_isMeulOpen)
        {
            m_mainmeulUI.Hide();
            m_propUI.Hide();
            Cursor.visible = false;
            m_isMeulOpen = false;
        }
        else if (m_isBagOpen)
        {
            m_propUI.Hide();
            Cursor.visible = false;
            m_isBagOpen = false;
        }
        else {
            Cursor.visible = true;
            m_mainmeulUI.Show();
            m_isMeulOpen = true;
        }
    }
}
