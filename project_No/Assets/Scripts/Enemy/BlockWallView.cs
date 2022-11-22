using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockWallView : MonoBehaviour
{
    public float viewRaidus = 5.0f;
    [Range(0, 360)]
    public float viewAngle = 90.0f;

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    
    private List<Transform> visibleTargets = new List<Transform>();
    private Transform nearestTarget;
    private float distanceToTarget = 0.0f;

    public float delay = 0.2f;
    public List<Transform> VisibleTargets => visibleTargets;
    public Transform NearestTarget => nearestTarget;


    private void Start()
    {
        StartCoroutine("FindTarget", delay);
    }

    IEnumerator FindTarget(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        distanceToTarget = 0.0f;
        nearestTarget = null;
        visibleTargets.Clear();

        Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRaidus, targetMask);
        for(int i = 0; i < targetInViewRadius.Length; ++i)
        {
            Transform target = targetInViewRadius[i].transform;

            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);
                if(!Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                    if(nearestTarget == null || (distanceToTarget > distToTarget))
                    {
                        nearestTarget = target;
                        distanceToTarget = distToTarget;
                    }
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
