using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : GameManager
{
    private MainMeul mainmeulUI;
    private PropUI propUI;
    private AtrributeUI atrributeUI;
    private TaskUI taskUI;
    private bool isBagOpen = false;            //保存背包的状态
    private bool isMeulOpen = false;           //保存菜单的状态 

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
        mainmeulUI = new MainMeul();
        propUI = new PropUI();
        atrributeUI = new AtrributeUI();
        taskUI = new TaskUI();

        propUI.Init();
        atrributeUI.Init();
        taskUI.Init();
    }


    /// <summary>
    /// 打开/关闭背包UI
    /// </summary>
    public void ShowBagUI() {

    }

    

    /// <summary>
    /// 打开/关闭菜单UI
    /// </summary>
    public void ShowMeulUI() {

    }
}
