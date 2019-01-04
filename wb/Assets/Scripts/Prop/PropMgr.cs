using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropMgr : GameManager
{

    public static PropMgr instance;
    public Dictionary<string, BagProp> OwnProp;  //道具字典，存储当前拥有的道具
    public Dictionary<string, InteractiveProp> UseProp;  //可交互道具，包括设备等
    public Dictionary<string, Prop> AllProp;  // 所有道具

    private void Awake()
    {
        instance = this;
        AllProp = new Dictionary<string, Prop>();
        UseProp = new Dictionary<string, InteractiveProp>();
        OwnProp = new Dictionary<string, BagProp>();
    }

    public void Use(string propName) { }
    public void Add(string propName) { }
    public void Dele(string propName) { }


}
