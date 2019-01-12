using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeulState : ISceneState{


    public MeulState(SceneStateController controller) : base("MeulState", controller) {
    }
    private Image mLogo;
    private float mSmoothingSpeed = 1;
    private float mWaitTime = 2;

    public override void StateStart()
    {
        //Debug.Log("MeulState");
    }

    public override void StateUpdate()
    {
        //Debug.Log(getName());
    }

    public override void StateEnd()
    {
        base.StateEnd();
        mController.SetState(new GameState(mController), true);
    }
}
