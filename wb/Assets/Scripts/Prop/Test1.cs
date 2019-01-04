using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : BagProp {


    /// <summary>
    /// 这里记得要给add方法try，catch 若字典中已有，则数量++
    /// </summary>
    private void Start()
    {
        PropMgr.instance.m_AllProp.Add(name, this); //将道具自加载到所有道具目录下
        m_name = "Test1";
        m_IsOwn = false;
        m_allNum = 0;
    }

    public override void Use() {
        Debug.Log("Test1 被使用.");
    }
    public override void Add() {

        Debug.Log("Test1 被添加.");
    }
    public override void Dele() {
        Debug.Log("Test1 被删除.");
    }

    public override int GetAllNum(){
        return m_allNum;
    }
}
