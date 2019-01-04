using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderExecute : GameManager {

    //执行操作位符
    private static int mExecute = 0;



    //读取命令，执行操作
    void Update()
    {

        switch (mOperat[mExecute++])
        {
            case KeyCode.W:
                RobotManager.instance.RobotMove(Vector2.up);
                ResetQueue();
                break;
            case KeyCode.S:
                RobotManager.instance.RobotMove(Vector2.down);
                ResetQueue();
                break;
            case KeyCode.A:
                RobotManager.instance.RobotMove(Vector2.left);
                ResetQueue();
                break;
            case KeyCode.D:
                RobotManager.instance.RobotMove(Vector2.right);
                ResetQueue();
                break;
            case KeyCode.B:
                UIController.instance.ShowBagUI();
                ResetQueue();
                break;
            case KeyCode.E:

                ResetQueue();
                break;
            default:
                break;
        }
        mExecute++;
        mExecute %= 10;
    }

    //执行完命令后，将其从命令队列中移除
    private void ResetQueue() {
        mOperat[mExecute] = KeyCode.None;
        mOperat[mExecute - 1] = KeyCode.None;
    }
}
