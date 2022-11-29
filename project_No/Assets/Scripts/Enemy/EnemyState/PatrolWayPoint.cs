using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolWayPoint : State<EnemyController>
{
    private Animator anim;
    private Rigidbody rigid;
    private NavMeshAgent agent;

    protected int hashMove = Animator.StringToHash("IsMove");

    Enemy enemy;
    public override void OnInitialized()
    {
        anim = context.GetComponent<Animator>();
        rigid = context.GetComponent<Rigidbody>();
        agent = context.GetComponent<NavMeshAgent>();
        enemy = GameManager.Inst.enemyMonster.GetComponent<Enemy>();
    }

    public override void OnEnter()
    {
        if (context.targetWayPoint == null)
        {
            context.FindNextWayPoint();
        }
        if(context.targetWayPoint)
        {
            agent.SetDestination(context.targetWayPoint.position);
            anim.SetBool(hashMove, true);
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
        }
        else
        {
            if(!agent.pathPending && (agent.remainingDistance <= agent.stoppingDistance))
            {
                Transform nextDest = context.FindNextWayPoint();
                if(nextDest)
                {
                    agent.SetDestination(nextDest.position);                    
                }
                stateMachine.ChangeState<IdleState>();
            }
        }
    }

    public override void OnExit()
    {        
        anim.SetBool(hashMove, false);
        agent.ResetPath();
    }
}
