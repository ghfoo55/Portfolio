using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSelect : StateMachineBehaviour
{
    int stateNum = 3;
    float minTime = 0.0f;
    float maxTime = 3.0f;
    float randomTime;

    readonly int randomIdle = Animator.StringToHash("IdleSelect");
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        randomTime = Random.Range(minTime, maxTime);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).fullPathHash == stateInfo.fullPathHash)
        {
            animator.SetInteger(randomIdle, 0);
        }
        if(stateInfo.normalizedTime > randomTime && !animator.IsInTransition(0))
        {
            animator.SetInteger(randomIdle, Random.Range(0, stateNum));
        }
    }

}
