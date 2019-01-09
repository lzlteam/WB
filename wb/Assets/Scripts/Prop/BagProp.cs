using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagProp : Prop {
    
    public int m_ID;                //在背包的哪一格
    public GameObject m_Prefeb;     //道具的prefeb
    public int m_OwnAllNum;         //已经拥有的该类道具的数量

    /// <summary>
    /// 将道具添加到背包中
    /// </summary>
    public virtual void Add() { }

    /// <summary>
    /// 使用后，减少，若只有一个，就删除
    /// </summary>
    public virtual void Dele() { }

    /// <summary>
    /// 获取该种道具共有多少个
    /// </summary>
    /// <returns></returns>
    public virtual string GetAllNum() { return m_OwnAllNum.ToString(); }
}
