using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 将这个脚本放到起始点，然后实例化出来的机器人作为他的子对象
/// </summary>

public class RobotManager : GameManager
{

    public Robot m_robot = new Robot();
    public static RobotManager instance;
    private Vector3 m_direction = new Vector3(0, 0, 0);
    private int m_rotate = 0;
    private bool isRun;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// 初始化机器人数据，及调用资源加载类生成机器人,加载特效所需的参数
    /// 把机器人模型上的组件获取到控制器上
    /// </summary>
    /// <param name="hp"></param>
    /// <param name="maxhp"></param>
    /// <param name="speed"></param>
    /// <param name="damage"></param>
    /// <param name="name"></param>
    public void Init(float hp, float maxhp, float speed, float damage, string name, string prefab, string particle)
    {


        m_robot.m_Robot = m_LoadResource.LoadRobot(prefab);

        m_robot.Init(hp, maxhp, speed, damage, name, prefab, particle);



    }
    private void Update()
    {
        if (Time.time - m_robot.lastMtime < 0.5f)
        {
            m_robot.Move(m_direction, isRun);
        }
        else if (Time.time - m_robot.lastMtime >= 0.5f)
        {
            m_robot.MoveStop();
        }

        if (Time.time - m_robot.lastRtime < 0.5f)
        {
            m_robot.Rotate(m_rotate);
        }
        else
        {
            m_robot.Rotate();
        }

        if (Time.time - m_robot.lastJtime > 0.5f)
        {
            m_robot.Jumpend();
        }
    }
    public void RobotMove(Vector3 direction, bool isrun)
    {
        m_robot.Animon("M");
        isRun = isrun;
        m_direction = direction;
        m_rotate = 0;
    }
    public void RobotRotate(int rotate)
    {
        m_robot.Animon("R");
        m_direction = new Vector3(0, 0, 0);
        m_rotate = rotate;
    }
    public void RobotJump()
    {
        m_robot.Animon("J");
        m_robot.Jumpon();
    }
}
