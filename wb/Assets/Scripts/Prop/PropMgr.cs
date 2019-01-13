using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


/// <summary>
/// 只管理道具数量及状态，具体道具的使用在对应道具里的Use方法中
/// </summary>
public class PropMgr : GameManager
{

    public static PropMgr instance;
    public Dictionary<string, BagProp> m_OwnProp;  //道具字典，存储当前拥有的道具
    public Dictionary<string, InteractiveProp> m_UseProp;  //可交互道具，包括设备等
    public Dictionary<string, Prop> m_AllProp;  // 所有道具

    private void Awake()
    {
        instance = this;
        m_AllProp = new Dictionary<string, Prop>();
        m_UseProp = new Dictionary<string, InteractiveProp>();
        m_OwnProp = new Dictionary<string, BagProp>();
    }

    /// <summary>
    /// 初始化所有道具字典以及场景内的道具实例
    /// </summary>
    public void Init() {
        PropList proplist = new PropList();
        for (int i = 0; i < proplist.m_Proplist.Count; i++)
        {
            for (int j = 0; j < proplist.m_Proplist[i].m_allNum; j++)
            {
                m_LoadResource.LoadProp(proplist.m_Proplist[i].m_name).name = proplist.m_Proplist[i].m_name;
            }
        }
    }
    


    /// <summary>
    /// 根据道具名字，加载对应道具的小图标
    /// </summary>
    /// <param name="Propname"></param>
    /// <returns></returns>
    public Sprite GetSprite(string Propname)
    {
        return m_LoadResource.LoadSprite(Propname);
    }


    /// <summary>
    /// 根据道具名，增加所拥有道具个数(已拥有该物品则返回0，未拥有返回1，没有该道具返回-1)
    /// </summary>
    /// <param name="propName"></param>
    public int Add(string propName)
    {
        try {
            m_OwnProp[propName].m_OwnAllNum++;
            //Debug.Log(propName + "物品增加1个");
            return 0;
        }
        catch(Exception e)
        {

            try
            {
                //BagProp bag = (BagProp)m_AllProp[propName];
                m_OwnProp.Add(propName, (BagProp)m_AllProp[propName]);
                m_OwnProp[propName].m_OwnAllNum++;
                return 1;
            }
            catch (Exception e2)
            {
                Debug.Log("错误！游戏中没有该道具 :" + e2);
                return -1;
            }
        }

    }

    /// <summary>
    /// 根据道具名，从拥有道具字典中删除
    /// </summary>
    /// <param name="propName"></param>
    public void Dele(string propName)
    {
        m_OwnProp.Remove(propName);
    }

    /// <summary>
    /// 根据道具名，减少所拥有道具个数
    /// </summary>
    /// <param name="propName"></param>
    public void Reduce(string propName)
    {
        --m_OwnProp[propName].m_OwnAllNum;
    }


    /// <summary>
    /// 根据道具名，调用道具的使用方法,使用完之后减少该类道具的数量
    /// </summary>
    /// <param name="propName"></param>
    public void Use(string propName)
    {
        m_OwnProp[propName].Use();

        Reduce(propName);

    }

}
