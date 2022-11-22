using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBehaviour : MonoBehaviour
{
#if UNITY_EDITOR
    [Multiline]
    public string developmentDescription = "";
#endif
    public int animationIndex;

    public int priority;

    public int damage;
    public float range = 3f;

    [SerializeField]
    private float coolTime;

    public GameObject effectPrefab;

    protected float calcCoolTime = 0.0f;

    [HideInInspector]
    public LayerMask targetMask;

    [SerializeField]
    public bool IsAvailable => calcCoolTime >= coolTime;

    protected virtual void Start()
    {
        calcCoolTime = coolTime;
    }

    protected void Update()
    {
        if (calcCoolTime < coolTime)
        {
            calcCoolTime += Time.deltaTime;
        }
    }

    public abstract void ExecuteAttack(GameObject target = null, Transform startPoint = null);

}
