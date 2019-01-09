using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 将这个脚本放到起始点，然后实例化出来的机器人作为他的子对象
/// </summary>

public class RobotManager : GameManager
{

    public Robot m_robot = new Robot();
    public static RobotManager instance;


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
        if (Input.GetKey(KeyCode.W))
        {
            RobotMove();
            if (Input.GetKey(KeyCode.F))
            {
                if (Time.time - m_robot.lastMtime < 0.5f)
                {
                    m_robot.Run(m_robot.m_Robot.transform.forward);
                }
            }
            else if (Time.time - m_robot.lastMtime < 0.5f)
            {
                m_robot.Walk(m_robot.m_Robot.transform.forward);
            }

        }
        if (Input.GetKey(KeyCode.S))
        {
            RobotMove();
            if (Time.time - m_robot.lastMtime < 0.5f)
            {
                m_robot.Walk(-m_robot.m_Robot.transform.forward);
            }
        }
        if (Time.time - m_robot.lastMtime >= 0.5f)
        {
            m_robot.MoveStop();
        }

        m_robot.Rotate();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RobotJump();
        }
        if (Time.time - m_robot.lastJtime > 0.5f)
        {
            m_robot.Jumpend();
        }
    }
    public void RobotMove()
    {
        m_robot.Animon("M");
    }
    public void RobotRotate()
    {
        m_robot.Animon("R");
    }
    public void RobotJump()
    {
        m_robot.Animon("J");
        m_robot.Jumpon();
    }


    public void PickUp() {

        RaycastHit hitInfo;
        LayerMask mask = 1 << (LayerMask.NameToLayer("Prop"));
        if (Physics.Raycast(m_robot.m_Robot.transform.position, m_robot.m_Robot.transform.forward, out hitInfo, 2f, mask))
        {
            string name = hitInfo.transform.gameObject.name;

            try
            {
                if (PropMgr.instance.m_OwnProp[name] == null)
                {
                }

                UIController.instance.Add(name);
                Destroy(hitInfo.transform.gameObject);
            }
            catch (Exception e)
            {

                Debug.Log(e);

                UIController.instance.Add(name);
                PropMgr.instance.m_OwnProp[name].m_Prefeb = hitInfo.transform.gameObject;
                PropMgr.instance.m_OwnProp[name].m_Prefeb.SetActive(false);
            }

        }

    }
}
