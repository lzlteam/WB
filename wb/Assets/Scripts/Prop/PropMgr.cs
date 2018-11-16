using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropMgr : MonoBehaviour {

    public static PropMgr instance;
    public Dictionary<string, Prop> OwnProp;  //道具字典，存储当前拥有的道具
    public Dictionary<string, Prop> AllProp;  // 所有道具

    private void Awake()
    {
        instance = this;
        AllProp = new Dictionary<string, Prop>();
        OwnProp = new Dictionary<string, Prop>();
    }

    public void Use(string propName) { }
    public void Add(string propName) { }
    public void Dele(string propName) { }


}
