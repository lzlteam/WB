using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot
{

    public CharacterAttribute m_attribut;        //基本属性
    public string m_prefab;                      //机器人模型
    public string m_particle;                    //自带的特效
    public bool m_IsCollide;                     //检测是否碰到可触发的东西
    public GameObject m_Robot;                   //用来接收实例化的机器人
    private Animator m_Animator;
    private CharacterController m_characterController;
    public float lastMtime;
    public float lastHtime;
    public float lastJtime;



    /// <summary>
    /// 初始化机器人数据,调用资源加载类加载模型特效等
    /// </summary>
    /// <param name="BirthPoint"></param>
    public void Init(float hp, float maxhp, float speed, float damage, string name, string prefab, string particle)
    {
        m_attribut = new CharacterAttribute(hp, maxhp, speed, damage, name);
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
            case "H":
                lastHtime = Time.time;
                break;
            case "J":
                lastJtime = Time.time;
                break;
        }
    }

    //人物的移动
    public void Walk(Vector3 direction)
    {
        if (m_Animator.gameObject.activeSelf)
            m_Animator.SetFloat("Speed_f", 0.3f);
        m_characterController.Move(direction * m_attribut.m_speed * Time.deltaTime);
    }
    public void Run(Vector3 direction)
    {
        if (m_Animator.gameObject.activeSelf)
            m_Animator.SetFloat("Speed_f", 1.0f);
        m_characterController.Move(direction * m_attribut.m_speed * 2 * Time.deltaTime);
    }
    public void MoveStop()
    {
        if (m_Animator.gameObject.activeSelf)
            m_Animator.SetFloat("Speed_f", 0);
    }

    //人物的旋转
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
        if (m_Animator.gameObject.activeSelf)
            m_Animator.SetBool("Jump_b", true);
    }
    public void Jumpend()
    {
        if (m_Animator.gameObject.activeSelf)
            m_Animator.SetBool("Jump_b", false);
    }

    //人物的交互动画
    public void Handon()
    {
        if (m_Animator.gameObject.activeSelf)
            m_Animator.SetInteger("Handon", 1);
    }
    public void Handend()
    {
        if (m_Animator.gameObject.activeSelf)
            m_Animator.SetInteger("Handon", 0);
    }
    public void Pickup()
    {
        if (m_Animator.gameObject.activeSelf)
            m_Animator.SetInteger("WeaponType_int", 12);
    }
    public void Pickend()
    {
        if (m_Animator.gameObject.activeSelf)
            m_Animator.SetInteger("WeaponType_int", 0);
    }


    //机器人死了，可以触发重新开始，退出游戏等
    public void Die()
    {
        if (m_Animator.gameObject.activeSelf)
            m_Animator.SetBool("Death_b", true);
    }
}