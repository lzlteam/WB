using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : ISceneState
{
    public Test(SceneStateController controller) : base("Test", controller)
    {
    }
    public override void StateStart()
    {
        Debug.Log("test");
    }

    public override void StateUpdate()
    {
        Debug.Log(getName());
    }
}
