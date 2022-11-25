using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    protected StateMachine<EnemyController> stateMachine;
    public StateMachine<EnemyController> StateMachine => stateMachine;

    private BlockWallView bwv;

    public float attackRange;

    public float attackDelay;
    public float fireBallDelay;

    public Transform Target => bwv.NearestTarget;

    public Transform[] wayPoint;
    [HideInInspector]
    public Transform targetWayPoint = null;
    
    private int wayPointIndex = 0;

    public Transform firePoint;

    public GameObject fireBall;

    protected void Start()
    {
        stateMachine = new StateMachine<EnemyController>(this, new PatrolWayPoint());
        stateMachine.AddState(new IdleState());
        stateMachine.AddState(new AttackState());
        stateMachine.AddState(new MoveState());
        stateMachine.AddState(new BossAttackState());

        bwv = GetComponent<BlockWallView>();
    }
 
    private void Update()
    {
        stateMachine.Update(Time.deltaTime);
    }
    public bool IsAvailableAttack
    {
        get
        {            
            if (!Target)
            {
                return false;
            }
            float distance = Vector3.Distance(transform.position, Target.position);
            return distance <= attackRange;
        }
    }   


    public Transform SearchPlayer()
    {
        return Target;
    }

    public Transform FindNextWayPoint()
    {
        targetWayPoint = null;
        if(wayPoint.Length > 0)
        {
            targetWayPoint = wayPoint[wayPointIndex];
        }

        wayPointIndex = (wayPointIndex + 1) % wayPoint.Length;

        return targetWayPoint;
    }

    public void FireBallShot()
    {
        Instantiate(fireBall, firePoint.position, firePoint.rotation);
    }
}
