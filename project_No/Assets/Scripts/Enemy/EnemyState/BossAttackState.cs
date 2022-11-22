using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : State<EnemyController>
{
    private Animator anim;
    private int hashAttack = Animator.StringToHash("Attack");
    private int hashFireBall = Animator.StringToHash("FlyAttack");
    private float attackDelay;
    Enemy enemy;
    public override void OnInitialized()
    {
        anim = context.GetComponent<Animator>();
        attackDelay = context.attackDelay;
        enemy = GameManager.Inst.enemyMonster;

    }

    public override void OnEnter()
    {
        if (context.IsAvailableAttack && attackDelay > context.attackDelay && enemy.hp > 0)
        {
            anim.SetTrigger(hashAttack);
            attackDelay = 0;
        }
        else if(context.IsAvailableAttack && attackDelay > context.attackDelay && enemy.hp > enemy.hp * 0.5)
        {
            anim.SetTrigger(hashFireBall);
            attackDelay = 0;
        }
        else
        {
            stateMachine.ChangeState<IdleState>();
            attackDelay += Time.deltaTime;
        }
    }

    public override void Update(float deltaTime)
    {

    }
}
