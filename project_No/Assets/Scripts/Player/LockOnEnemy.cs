using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnEnemy : MonoBehaviour
{
    float lockRange = 10.0f;

    Transform lockOnTarget;
    public Transform LockOnTarget { get => lockOnTarget; }

    public GameObject lockOnEffect;

    Enemy enemy;

    void Start()
    {
        enemy = GameManager.Inst.enemyMonster.GetComponent<Enemy>();
        if (lockOnEffect == null)
        {
            lockOnEffect = GameObject.Find("LockOnEffect");
        }
        lockOnEffect.SetActive(false);
    }

    void Update()
    {
        if (lockOnEffect != null)
        {
            lockOnEffect.transform.Rotate(Vector3.right * 360 * Time.deltaTime);
        }
    }
    public void LockOnToggle()
    {
        if(lockOnTarget == null)
        {
            LockOn();
        }
        else
        {
            if(!LockOn())
            {
                LockOff();
            }
        }

    }

    bool LockOn()
    {
        bool result = false;

        Collider[] coll = Physics.OverlapSphere(transform.position, lockRange, LayerMask.GetMask("Enemy"));

        if(coll.Length > 0)
        {
            Collider nearest = null;
            float nearestDistance = float.MaxValue;
            foreach (Collider col in coll)
            {
                float distanceSqr = (col.transform.position - transform.position).sqrMagnitude;
                if(distanceSqr < nearestDistance)
                {
                    nearestDistance = distanceSqr;
                    nearest = col;
                }
            }

            if (lockOnTarget?.gameObject != nearest.gameObject)
            {
                if(LockOnTarget != null)
                {
                    LockOff();
                }
                
                lockOnTarget = nearest.transform;                               
                lockOnEffect.transform.position = new Vector3(lockOnTarget.position.x, lockOnTarget.position.y + 2, lockOnTarget.position.z);
                lockOnEffect.transform.parent = lockOnTarget;                
                lockOnEffect.SetActive(true);                

                result = true;
            }
        }
        Debug.Log(lockOnTarget.name);
        return result;
    }

    void LockOff()
    {
        lockOnTarget = null;
        lockOnEffect.transform.parent = null;
        lockOnEffect.SetActive(false);
        enemy.enemyHPBar.SetActive(false);
    }
}
