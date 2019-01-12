using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderExecute : GameManager
{

    //执行操作位符
    private static int m_Execute = 0;



    //读取命令，执行操作
    void Update()
    {

        switch (m_Operat[m_Execute])
        {
            /*case KeyCode.W:
                RobotManager.instance.RobotMove(RobotManager.instance.m_robot.m_Robot.transform.forward, false);
                ResetQueue();
                break;
            case KeyCode.S:
                RobotManager.instance.RobotMove(-RobotManager.instance.m_robot.m_Robot.transform.forward, false);
                ResetQueue();
                break;
            case KeyCode.A:
                RobotManager.instance.RobotRotate(-1);
                ResetQueue();
                break;
            case KeyCode.D:
                RobotManager.instance.RobotRotate(1);
                ResetQueue();
                break;
            case KeyCode.Space:
                RobotManager.instance.RobotJump();
                ResetQueue();
                break;
            case KeyCode.F:
                RobotManager.instance.RobotMove(RobotManager.instance.m_robot.m_Robot.transform.forward, true);
                ResetQueue();
                break;   
             */
            case KeyCode.B:
                UIController.instance.ShowBagUI();
                ResetQueue();
                break;
            case KeyCode.Escape:
                UIController.instance.ShowMeulUI();
                ResetQueue();
                break;
            case KeyCode.E:
                RobotManager.instance.PickUp();
                ResetQueue();
                break;


              //存档读档测试
            case KeyCode.L:
                FilePoint.Instance.Save(RobotManager.instance.m_robot);
                ResetQueue();
                break;
            case KeyCode.R:
                FilePoint.Instance.Read();
                ResetQueue();
                break;
            


            default:
                break;
        }
        m_Execute++;
        m_Execute %= 10;
    }

    //执行完命令后，将其从命令队列中移除
    private void ResetQueue()
    {
        m_Operat[m_Execute] = KeyCode.None;
    }
}
