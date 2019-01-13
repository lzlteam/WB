using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using System;


public class Test1:BagProp{

    /// <summary>
    /// 初始化该类道具的一些基本信息，并将其加载到所有道具目录下
    /// </summary>
    public Test1()
    {
        m_name = "Test1";
        m_IsOwn = false;
        m_OwnAllNum = 0;
        m_allNum = 2;
        m_ID = -1;
        m_Proptype = 1;
        //m_Prefeb = new GameObject();
        try
        {
            PropMgr.instance.m_AllProp.Add(m_name, this); //将道具自加载到所有道具目录下 

        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
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

    public override string GetAllNum(){
        return m_OwnAllNum.ToString();
    }
}
