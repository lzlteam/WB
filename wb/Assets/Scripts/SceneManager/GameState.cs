using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : ISceneState
{
    public GameState(SceneStateController controller) : base("GameState", controller)
    {
    }
    public override void StateStart()
    {
        
    }

    public override void StateUpdate()
    {
        Debug.Log(getName());
    }
}
