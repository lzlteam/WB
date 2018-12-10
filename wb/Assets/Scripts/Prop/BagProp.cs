using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagProp : Prop {
    
    public Image pic2D;

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
    public virtual int GetAllNum() { return allNum; }
}
