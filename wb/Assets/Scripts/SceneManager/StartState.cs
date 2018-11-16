using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartState : ISceneState{


    public StartState(SceneStateController controller) : base("StartScene", controller) {
    }
    private Image mLogo;
    private float mSmoothingSpeed = 1;
    private float mWaitTime = 2;

    public override void StateStart()
    {
        Debug.Log("StartState");
    }

    public override void StateUpdate()
    {
        Debug.Log(getName());
    }
}
