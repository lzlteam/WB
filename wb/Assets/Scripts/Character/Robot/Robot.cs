using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot{

    public Attribute m_attribut;        //基本属性
    public string m_prefab;             //机器人模型
    public string m_particle;           //自带的特效
    public bool m_IsCollide;            //检测是否碰到可触发的东西
    public GameObject m_Robot;          //用来接收实例化的机器人
    private Animator m_Animator;
    private CharacterController m_characterController;


    /// <summary>
    /// 初始化机器人数据,调用资源加载类加载模型特效等
    /// </summary>
    /// <param name="BirthPoint"></param>
    public void Init(float hp,float maxhp,float speed,float damage,string name,string prefab,string particle)
    {
        m_attribut = new Attribute(hp, maxhp, speed, damage, name);
        m_prefab = prefab;
        m_particle = particle;
    }
    
    /// <summary>
    /// 传入方向
    /// </summary>
    /// <param name="direction"></param>
    public void Move(Vector3 direction) {
        m_Animator = m_Robot.GetComponent<Animator>();
        m_characterController = m_Robot.GetComponent<CharacterController>();
        m_Animator.SetFloat("Speed_f", 0.5f);
        m_characterController.Move(direction * m_attribut.m_speed);
    
    }
    public void Jump()
    {

    }

    //机器人死了，可以触发重新开始，退出游戏等
    public void Die() {

    }
}
