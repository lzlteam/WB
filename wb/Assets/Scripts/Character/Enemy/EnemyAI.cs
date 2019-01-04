using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI{
    public enum m_enemytype
    {
        NullState,
        AttackState,
        PatrolState
    };

    public void Move(float speed) {

    }

    public void Attack(float damage) {

    }

    public void Patrol(float speed) {

    }

    /// <summary>
    /// type==0  空状态 
    /// type==1  攻击状态 
    /// type==2  巡逻状态 
    /// </summary>
    /// <param name="type"></param>
    public void StateChange(int type) {

    }
}
