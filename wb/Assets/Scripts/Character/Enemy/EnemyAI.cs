using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI
{

    private float m_eatTimer = 0f;
    /// <summary>
    /// 当前巡逻地点下标
    /// </summary>
    private int m_nowPostionIndex = 0;
    /// <summary>
    /// 攻击间隔计时器
    /// </summary>
    private float m_attackTimer = 0;
    /// <summary>
    /// 当前第几次攻击
    /// </summary>
    private int m_attackCount = 0;
    /// <summary>
    /// 巡逻地点数组最大下标
    /// </summary>
    public int m_maxIndex;
    /// <summary>
    /// 攻击间隔
    /// </summary>
    public float m_attackColdTime = 1.15f;
    public Animator m_animator;
    /// <summary>
    /// 巡逻地点数组
    /// </summary>
    public Vector3[] m_patrolPostionArray;
    /// <summary>
    /// 机器人transform
    /// </summary>
    public Transform m_robotTransform;
    /// <summary>
    /// 所绑定的敌人
    /// </summary>
    public Enemy m_enemy;

    /// <summary>
    /// 0：空状态
    /// 1：攻击状态
    /// 2：追击状态
    /// 3：巡逻状态
    /// </summary>
    public enum Enemytype
    {
        NullState,
        AttackState,
        PursuitState,
        PatrolState,
    };
    public Enemytype m_enemytype;
    public Transform transform;

    public EnemyAI() { }

    /// <summary>
    /// 含参构造函数，初始化AI并且绑定所属的敌人
    /// </summary>
    /// <param name="enemy"></param>
    public EnemyAI(Enemy enemy)
    {
        m_enemy = enemy;
        m_robotTransform = GameObject.FindWithTag("Player").transform;
        m_animator = m_enemy.m_prefab.GetComponent<Animator>();
        transform = m_enemy.m_prefab.transform;
        m_enemytype = Enemytype.NullState;
        m_patrolPostionArray = new Vector3[10];
        for (int i = 0; i < 10; i++)
        {
            m_patrolPostionArray[i] = new Vector3(UnityEngine.Random.Range(0, 100) * i, 0, UnityEngine.Random.Range(0, 100) * i);
        }
    }
    /// <summary>
    /// 朝目的方向移动移动
    /// </summary>
    /// <param name="speed"></param>
    public void Move(float speed, Vector3 target)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
    /// <summary>
    /// 攻击主角
    /// </summary>
    /// <param name="damage"></param>
    public void Attack(float damage)
    {
        if (m_attackCount == 0)
        {
            m_attackTimer += Time.deltaTime;
            //机器人受到伤害
            m_enemy.TakeDamage(damage);
            ++m_attackCount;
        }
        else
        {
            if (m_attackTimer < m_attackColdTime)
                m_attackTimer += Time.deltaTime;
            else
            {
                //机器人受到伤害
                m_enemy.TakeDamage(damage);
                m_attackTimer = 0;
                ++m_attackCount;
                //Debug.Log(RobotManager.instance.m_robot.m_attribut.m_hp);
            }
        }
    }
    /// <summary>
    /// 在固定几个地点之间巡逻
    /// </summary>
    /// <param name="speed"></param>
    public void Patrol(float speed)
    {
        if (m_eatTimer > 0 && m_eatTimer < 1.5f)
        {
            m_eatTimer += Time.deltaTime;
            return;
        }
        else
        {
            m_eatTimer = 0f;
        }
        if (Random.Range(0, 5000) > 4990)
        {
            m_eatTimer += Time.deltaTime;
            m_animator.SetBool("Eat", true);
            return;
        }
        m_animator.SetBool("Eat", false);
        transform.LookAt(-(transform.position - m_patrolPostionArray[m_nowPostionIndex]));
        //未到达地点,继续移动
        if (Vector3.Distance(transform.position, m_patrolPostionArray[m_nowPostionIndex]) > 0.2f)
            Move(speed, m_patrolPostionArray[m_nowPostionIndex]);
        //到达地点
        else
        {
            //没有走完预定的路线，走向下一个预定的巡逻地点
            if (m_nowPostionIndex < m_maxIndex)
            {
                m_nowPostionIndex++;
                Move(speed, m_patrolPostionArray[m_nowPostionIndex]);
            }
            //巡逻一圈后，从第一个巡逻点开始重新巡逻
            else
            {
                m_nowPostionIndex = 0;
                Move(speed, m_patrolPostionArray[m_nowPostionIndex]);
            }
        }
    }

    /// <summary>
    /// 朝主角追击
    /// </summary>
    public void Pursuit()
    {
        transform.LookAt(m_robotTransform.transform);
        Move(m_enemy.m_attribute.m_speed, m_robotTransform.position);
    }

    public void StateChange(Enemytype type)
    {
        switch (type)
        {
            case Enemytype.NullState://当为空状态
                this.m_enemytype = Enemytype.PatrolState;
                Patrol(m_enemy.m_attribute.m_speed);
                break;
            case Enemytype.AttackState://当为攻击状态
                //当主角脱离攻击范围
                if (Vector3.Distance(transform.position, m_robotTransform.position) > 1f && Vector3.Distance(transform.position, m_robotTransform.position) < 10f)
                {
                    m_animator.SetBool("Attack", false);
                    m_attackTimer = 0;
                    m_enemytype = Enemytype.PursuitState;
                    Pursuit();
                }
                //仍在攻击范围，等待攻击间隔，继续攻击
                else if (Vector3.Distance(transform.position, m_robotTransform.position) < 1.5f)
                    Attack(m_enemy.m_attribute.m_damage);
                break;
            case Enemytype.PatrolState://当为巡逻状态
                //主角进入警戒范围，开始追击
                if (Vector3.Distance(transform.position, m_robotTransform.position) < 10f)
                {
                    this.m_enemytype = Enemytype.PursuitState;
                    Pursuit();
                }
                else
                    Patrol(m_enemy.m_attribute.m_speed);
                break;
            case Enemytype.PursuitState://当为追击状态
                //主角脱离警戒范围，恢复巡逻
                if (Vector3.Distance(transform.position, m_robotTransform.position) > 10f)
                {
                    this.m_enemytype = Enemytype.PatrolState;
                    Patrol(m_enemy.m_attribute.m_speed);
                }
                //追击主角到攻击范围，开始攻击
                else if (Vector3.Distance(transform.position, m_robotTransform.position) < 1.5f)
                {
                    this.m_enemytype = Enemytype.AttackState;
                    m_animator.SetBool("Attack", true);
                    Attack(m_enemy.m_attribute.m_damage);
                }
                //继续追击
                else
                {
                    Pursuit();
                }
                break;
        }
    }
}

