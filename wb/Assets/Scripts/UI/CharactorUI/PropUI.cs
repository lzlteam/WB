using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropUI : CharactorUI {

    private static Dictionary<int, bool> m_bagIndex = new Dictionary<int, bool>();                 //背包状态UI字典
    private static int m_maxpanel = 16;                                                            //背包最大格数
    private static Image[] m_images = new Image[m_maxpanel];                                       //道具小图标
    public GameObject m_bag;                                                               //背包UI对象

    //背包物品显示cache

    /// <summary>
    /// 初始化道具背包（道具状态字典等）,通过find方法找到对应的gameobject
    /// </summary>
    public void Init() {
        m_bag.SetActive(false);
        for (int i = 0; i < m_maxpanel; i++) {
            m_bagIndex.Add(i, false);
        }

        m_images = m_bag.GetComponentsInChildren<Image>();

    }
    


    public void Show() {

        m_bag.SetActive(true);

    }
    public void Hide()
    {
        m_bag.SetActive(false);
    }

    /// <summary>
    /// 拾取道具时调用，先将物品添加到道具管理类的道具字典，然后再添加UI类的背包里，若已拥有，则增加数量
    /// </summary>
    /// <param name="name"></param>
    public void AddProp(string name) {

        if (PropMgr.instance.Add(name))
        {
            for (int i = 1 ; i < m_maxpanel; i++)
            {
                //找到一个空的背包格子，存入未拥有的道具
                if (!m_bagIndex[i])
                {
                    m_images[i].name = name;
                    m_images[i].sprite = PropMgr.instance.m_OwnProp[name].m_pic2D.sprite;
                    PropMgr.instance.m_OwnProp[name].m_ID = i;
                    m_images[i].gameObject.GetComponentInChildren<Text>().text = PropMgr.instance.m_OwnProp[name].GetAllNum().ToString();
                    m_bagIndex[i] = true;
                    break;
                }
            }
        }
        else
        {
            PropMgr.instance.m_OwnProp[name].m_allNum++;
            m_images[PropMgr.instance.m_OwnProp[name].m_ID].gameObject.GetComponentInChildren<Text>().text = PropMgr.instance.m_OwnProp[name].GetAllNum().ToString();
        }
    }

    public void DeletProp(string name) {

        PropMgr.instance.Dele(name);
    }


    /// <summary>
    /// 点击格子，根据格子内物品的名字调用对应物品的使用方法
    /// </summary>
    /// <param name="id"></param>
    public void UseProp(int id) {
        if (m_bagIndex[id]) {
            Debug.Log("道具 " + (id) + "使用");
            PropMgr.instance.Use(m_images[id].name);
        }
    }
}
