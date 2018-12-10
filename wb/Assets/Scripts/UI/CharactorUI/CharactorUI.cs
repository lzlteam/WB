using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorUI: MonoBehaviour {

    protected RobotManager player;

    private void Awake()
    {
        player = RobotManager.instance;
    }


}
