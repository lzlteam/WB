using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{

    public int m_id;
    public CharacterAttribute m_attribute;
    public ParticleSystem m_particle;
    public GameObject m_prefab;
    public EnemyAI m_enemyAI;
    public Animator m_animator;

    public void Init(float hp, float maxhp, float speed, float damage, string name, int id)
    {
        m_attribute = new CharacterAttribute(hp, maxhp, speed, damage, name);
        m_id = id;
        m_enemyAI = new EnemyAI(this);
    }

    public void Die()
    {
        m_prefab.SetActive(false);
        m_animator.SetBool("Death", true);
    }

    /// <summary>
    /// 敌人攻击减血
    /// </summary>
    /// <param name="value"></param>
    public void TakeDamage(float value ) {
        RobotManager.instance.m_robot.m_attribut.HpDown(value);
    }

    public void ReLive()
    {
        m_prefab.SetActive(true);
        m_prefab.transform.position = m_enemyAI.m_patrolPostionArray[0];
    }

    public IEnumerator LaterDeath()
    {
        yield return new WaitForSeconds(1000);
        Die();
    }
}
