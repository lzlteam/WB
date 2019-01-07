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
    /// 根据道具名，实例化道具
    /// </summary>
    /// <param name="propName"></param>
    public void Use(string propName) {

    }


    /// <summary>
    /// 根据道具名，增加所拥有道具个数(已拥有该物品则返回false，否则返回true)
    /// </summary>
    /// <param name="propName"></param>
    public bool Add(string propName) {
        
        try {
            m_OwnProp[propName].m_allNum++;
            Debug.Log(propName + "物品增加1个");
            return false;
        }
        catch(Exception e) {

            m_OwnProp.Add(propName, (BagProp)m_AllProp[propName]);
            Debug.Log("错误:" + e);
            return true;
        }

    }

    /// <summary>
    /// 根据道具名，减少所拥有道具个数,若只剩下0个，则从拥有道具字典中删除
    /// </summary>
    /// <param name="propName"></param>
    public void Dele(string propName) {

        if (--m_OwnProp[propName].m_allNum <= 0) {
            //m_OwnProp[propName].Dele
        }
        
    }


}
