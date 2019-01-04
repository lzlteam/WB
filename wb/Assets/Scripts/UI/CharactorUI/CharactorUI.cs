using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorUI{

    protected RobotManager m_player;

    private void Awake()
    {
        m_player = RobotManager.instance;
    }


}
