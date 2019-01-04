using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropUI : CharactorUI {

    Dictionary<int, bool> m_bagIndex;         //背包状态UI字典
    int m_maxpanel;                           //背包最大格数
    public Image[] m_images;                  //道具小图标
    public GameObject m_bag;                  //背包UI对象

    /// <summary>
    /// 初始化道具背包（道具状态字典等）,通过find方法找到对应的gameobject
    /// </summary>
    public void Init() {
        m_bag.SetActive(false);

        
    }


    public void Show() {


        Cursor.visible = true;

        m_bag.SetActive(true);

    }
    public void Hide()
    {

        m_bag.SetActive(false);

        Cursor.visible = false;
    }

    public void AddProp() {

    }

    public void DeletProp() {

    }

    public void UseProp() {

    }
}
