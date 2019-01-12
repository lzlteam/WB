using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorUI{
    
    protected string GetRobotName() {
        return RobotManager.instance.m_robot.m_attribut.m_name;
    }

    protected float GetRobotHp() {

        return RobotManager.instance.m_robot.m_attribut.GetCurrentHp() / RobotManager.instance.m_robot.m_attribut.m_hpmax;
    }

}
