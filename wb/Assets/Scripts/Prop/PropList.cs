using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropList {

    /// <summary>
    /// 道具列表，保存了所有类别道具的管理类
    /// </summary>
    public List<Prop> m_Proplist = new List<Prop>();

    public PropList() {
        m_Proplist.Add(new Test1());
    }
	
}
