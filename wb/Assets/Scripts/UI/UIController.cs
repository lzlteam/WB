using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    private MainMeul mainmeulUI;
    private PropUI propUI;
    private AtrributeUI atrributeUI;
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

        propUI.Init();
    }

    /// <summary>
    /// 检测按键，触发不同的UI显示
    /// </summary>
    private void Update()
    {
        
    }
}
