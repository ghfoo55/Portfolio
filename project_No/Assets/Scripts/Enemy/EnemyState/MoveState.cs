using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : State<EnemyController>
{
    private Animator anim;
    private NavMeshAgent agent;    

    private int hashMove = Animator.StringToHash("IsMove");    
    public override void OnInitialized()
    {
        anim = context.GetComponent<Animator>();
        agent = context.GetComponent<NavMeshAgent>();        
    }

    public override void OnEnter()
    {
        agent.SetDestination(context.Target.position);
        anim.SetBool(hashMove, true);
    }

    public override void Update(float deltaTime)
    {
        Transform Player = context.SearchPlayer();
        if (Player)
        {
            agent.SetDestination(context.Target.position);
            if (agent.remainingDistance > agent.stoppingDistance)
            {                
                agent.stoppingDistance = context.attackRange;                
                return;
            }
            else
            {
                stateMachine.ChangeState<AttackState>();
            }
        }
        if (!Player && agent.remainingDistance <= agent.stoppingDistance)
        {            
            stateMachine.ChangeState<IdleState>();
        }
    }

    public override void OnExit()
    {
        anim.SetBool(hashMove, false);        
        agent.ResetPath();
    }
}
