using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    Animator anim;

    public System.Action OnFadeOut;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        StartFadeIn();
    }

    public void StartFadeIn()
    {
        anim.SetTrigger("StageStart");
    }
    
    public void StartFadeOut()
    {
        anim.SetTrigger("StageEnd");
    }
    
    public void AnimEnd()
    {
        OnFadeOut?.Invoke();
    }
}
