using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State<EnemyController>
{
    public bool isPatrol = true;
    private float minIdleTime = 0.0f;
    private float maxIdleTime = 3.0f;
    private float idleTime = 0.0f;

    Enemy enemy;
    private Animator anim;

    protected int hashMove = Animator.StringToHash("IsMove");    
        
    public override void OnInitialized()
    {
        anim = context.GetComponent<Animator>();
        enemy = GameManager.Inst.enemyMonster;
    }

    public override void OnEnter()
    {
        anim.SetBool(hashMove, false);        

        if (isPatrol)
        {
            idleTime = Random.Range(minIdleTime, maxIdleTime);
        }        
    }

    public override void Update(float deltaTime)
    {
        Transform Player = context.SearchPlayer();
        if(Player)
        {            
            if(context.IsAvailableAttack)
            {
                stateMachine.ChangeState<AttackState>();
            }            
            else
            {
                stateMachine.ChangeState<MoveState>();
            }
            if (enemy.enemyType == Enemy.EnemyType.Boss && enemy.hp < enemy.MaxHP * 0.5f)
            {
                stateMachine.ChangeState<BossAttackState>();
            }
        }
        else if(isPatrol && stateMachine.ElapsedTimeInState > idleTime)
        {
            stateMachine.ChangeState<PatrolWayPoint>();
        }
    }

    public override void OnExit()
    {
        
    }
}
