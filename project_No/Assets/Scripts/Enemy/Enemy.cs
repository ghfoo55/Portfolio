using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;


public class Enemy : MonoBehaviour, IHealth, IBattle
{
    public float hp = 300.0f;
    public float maxHP = 300.0f;
    public float HP
    {
        get => hp;
        set
        {
            if (hp != value)
            {
                hp = Mathf.Clamp(value, 0, maxHP);
                onHPChange?.Invoke();
            }
        }
    }
    public float MaxHP
    {
       get => maxHP;
    }    

    public System.Action onHPChange { get; set; }

    public float attackPower = 30.0f;

    public float defencePower = 10.0f;
    public float AttackPower { get => attackPower; }

    public float DefencePower { get => defencePower; }

    public string enemyName;
    public GameObject enemyHPBar;

    IBattle playerAttack;
    Animator anim;
    NavMeshAgent agent;
    Player player;
    
    void Start()
    {
        playerAttack = GameManager.Inst.MainPlayer.GetComponent<IBattle>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        enemyHPBar.SetActive(false);
        player = GameManager.Inst.MainPlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerWeapon")
        {            
            Attack(this);
        }
    }  

    

    public void Attack(IBattle target)
    {
        if (target != null)
        {
            float damage = playerAttack.AttackPower;
            target.TakeDamage(damage);
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage - playerAttack.DefencePower;
        if (hp > 0.0f)
        {            
            anim.SetTrigger("Hit");
        }
        else
        {
            anim.SetTrigger("OnDead");
            Invoke("OnDead", 4);
            agent.isStopped = true;
            player.money += UnityEngine.Random.Range(100, 500);
        }
    }

    private void OnDead()
    {
        enemyHPBar.SetActive(false);
        Destroy(this.gameObject);
    }
}
