using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : Prop {
    private string name = "Test1";
    private bool IsOwn = false;
    private int allNum = 0;


    private void Start()
    {
        PropMgr.instance.AllProp.Add(name, this); //将道具自加载到所有道具目录下
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
        return allNum;
    }
}
