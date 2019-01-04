using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropUI : CharactorUI {

    Dictionary<int, bool> BagIndex;         //背包状态UI字典
    int maxpanel;                           //背包最大格数
    public Image[] images;                  //道具小图标
    public GameObject Bag;                  //背包UI对象

    /// <summary>
    /// 初始化道具背包（道具状态字典等）,通过find方法找到对应的gameobject
    /// </summary>
    public void Init() {
    }


    public void Show() {

    }
    public void Hide()
    {

    }

    public void AddProp() {

    }

    public void DeletProp() {

    }

    public void UseProp() {

    }
}
