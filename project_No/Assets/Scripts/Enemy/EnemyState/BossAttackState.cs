using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : State<EnemyController>
{
    private Animator anim;
    private int hashFireBall = Animator.StringToHash("FlyAttack");
    private float fireBallDelay;
    Enemy enemy;
    public override void OnInitialized()
    {
        anim = context.GetComponent<Animator>();
        fireBallDelay = context.fireBallDelay;
        enemy = GameManager.Inst.enemyMonster;
    }

    public override void OnEnter()
    {
        if (enemy.enemyType == Enemy.EnemyType.Boss)
        {
            if (context.IsAvailableAttack && fireBallDelay > context.fireBallDelay && enemy.hp < enemy.maxHP * 0.5f)
            {
                anim.SetTrigger(hashFireBall);
                fireBallDelay = 0;
            }
            else
            {
                stateMachine.ChangeState<IdleState>();
                fireBallDelay += Time.deltaTime;
            }
        }
    }

    public override void Update(float deltaTime)
    {

    }
}
