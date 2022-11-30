using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackState : State<EnemyController>
{
    private Animator anim;

    private int hashAttack = Animator.StringToHash("Attack");

    private float attackDelay;
    public override void OnInitialized()
    {
        anim = context.GetComponent<Animator>();        
        attackDelay = context.attackDelay;
    }

    public override void OnEnter()
    {
        if (context.IsAvailableAttack && attackDelay > context.attackDelay)
        {
            anim.SetTrigger(hashAttack);
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
