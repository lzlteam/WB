using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 管理背包UI，每一个格子的信息
/// </summary>
public class PropUI : CharactorUI {

    private static Dictionary<int, bool> m_bagIndex = new Dictionary<int, bool>();                 //背包状态UI字典
    private static int m_maxpanel = 10;                                                            //背包最大格数
    private static Image[] m_images = new Image[m_maxpanel];                                       //道具小图标
    public GameObject m_bag;                                                                       //背包UI对象
    

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
    /// 拾取道具时调用，先将物品添加到道具管理类的道具字典，然后再添加UI类的背包里，若已拥有，则只需更新显示数量
    /// 背包已有该类道具返回1，未拥有返回0,错误道具返回-1，其他错误返回-2
    /// </summary>
    /// <param name="name"></param>
    public int AddProp(string name) {
        switch (PropMgr.instance.Add(name))
        {
            case 1:
                for (int i = 1; i < m_maxpanel; i++)
                {
                    //找到一个空的背包格子，存入未拥有的道具
                    if (!m_bagIndex[i])
                    {
                        m_images[i].name = name;
                        m_images[i].sprite = PropMgr.instance.GetSprite(name);
                        PropMgr.instance.m_OwnProp[name].m_ID = i;
                        PropMgr.instance.m_OwnProp[name].m_IsOwn = true;
                        m_images[i].gameObject.GetComponentInChildren<Text>().text = PropMgr.instance.m_OwnProp[name].GetAllNum();
                        m_bagIndex[i] = true;
                        break;
                    }
                }
                return 0;
            case 0:
                m_images[PropMgr.instance.m_OwnProp[name].m_ID].gameObject.GetComponentInChildren<Text>().text = PropMgr.instance.m_OwnProp[name].GetAllNum();
                return 1;
            case -1:
                return -1;
            default:
                return -2;
        }
    }


    /// <summary>
    /// 使用道具后，根据name值减少对应格子内的道具的数量，若小于等于0，则将格子空出来
    /// </summary>
    /// <param name="name"></param>
    public void DeletProp(string name,int id)
    {

        //Debug.Log(PropMgr.instance.m_OwnProp[name].m_OwnAllNum);

        if (PropMgr.instance.m_OwnProp[name].m_OwnAllNum <= 0)
        {
            m_images[id].sprite = PropMgr.instance.GetSprite("null");
            m_bagIndex[id] = false;
            m_images[id].gameObject.GetComponentInChildren<Text>().text = "";

            PropMgr.instance.m_OwnProp[name].m_IsOwn = false;
            PropMgr.instance.Dele(name);
        }
        else
        {
            m_images[id].gameObject.GetComponentInChildren<Text>().text = PropMgr.instance.m_OwnProp[name].GetAllNum();
        }

    }


    /// <summary>
    /// 点击格子，根据格子内物品的名字调用对应物品的使用方法
    /// </summary>
    /// <param name="id"></param>
    public void UseProp(int id) {
        if (m_bagIndex[id]) {
            //Debug.Log("道具 " + (id) + "使用");

            PropMgr.instance.Use(m_images[id].name);
            
            DeletProp(m_images[id].name,id);
        }
    }
}
