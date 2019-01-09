using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot
{

    public Attribute m_attribut;        //基本属性
    public string m_prefab;             //机器人模型
    public string m_particle;           //自带的特效
    public bool m_IsCollide;            //检测是否碰到可触发的东西
    public GameObject m_Robot;          //用来接收实例化的机器人
    private Animator m_Animator;
    private CharacterController m_characterController;
    public float lastMtime;
    public float lastRtime;
    public float lastJtime;



    /// <summary>
    /// 初始化机器人数据,调用资源加载类加载模型特效等
    /// </summary>
    /// <param name="BirthPoint"></param>
    public void Init(float hp, float maxhp, float speed, float damage, string name, string prefab, string particle)
    {
        m_attribut = new Attribute(hp, maxhp, speed, damage, name);
        m_prefab = prefab;
        m_particle = particle;


        m_Animator = m_Robot.GetComponent<Animator>();
        m_characterController = m_Robot.GetComponent<CharacterController>();
    }


    //设置动画开始的时间
    public void Animon(string anim)
    {
        switch (anim)
        {
            case "M":
                lastMtime = Time.time;
                break;
            case "R":
                lastRtime = Time.time;
                break;
            case "J":
                lastJtime = Time.time;
                break;
        }
    }

    //人物的移动
    public void Walk(Vector3 direction)
    {
        m_Animator.SetFloat("Speed_f", 0.3f);
        m_characterController.Move(direction * m_attribut.m_speed * Time.deltaTime);
    }
    public void Run(Vector3 direction)
    {
        m_Animator.SetFloat("Speed_f", 1.0f);
        m_characterController.Move(direction * m_attribut.m_speed * 2 * Time.deltaTime);
    }
    public void MoveStop()
    {
        m_Animator.SetFloat("Speed_f", 0);
    }

    //人物的旋转
    public void Rotate(int rotate)
    {
        m_Robot.transform.Rotate(Vector3.up, rotate * m_attribut.m_speed * 0.5f);
    }
    public void Rotate()
    {
        float pTarget = GameObject.Find("Main Camera").transform.eulerAngles.y;
        float angle = m_Robot.transform.eulerAngles.y - pTarget;
        if (angle < 0) angle += 360;
        if (angle > 180 && angle < 360 - m_attribut.m_speed) m_Robot.transform.Rotate(0, m_attribut.m_speed, 0);
        if (angle > m_attribut.m_speed && angle < 180) m_Robot.transform.Rotate(0, -m_attribut.m_speed, 0);
    }

    //人物的跳跃
    public void Jumpon()
    {
        m_Animator.SetBool("Jump_b", true);
    }
    public void Jumpend()
    {
        m_Animator.SetBool("Jump_b", false);
    }


    //机器人死了，可以触发重新开始，退出游戏等
    public void Die()
    {
        m_Animator.SetBool("Death_b", true);
    }
}
