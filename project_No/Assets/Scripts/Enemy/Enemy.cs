using UnityEngine;
using UnityEngine.AI;


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

    public enum EnemyType { Enemy, Boss }
    public EnemyType enemyType;
    public System.Action onHPChange { get; set; }

    public float attackPower = 30.0f;

    public float defencePower = 10.0f;
    public float AttackPower { get => attackPower; }

    public float DefencePower { get => defencePower; }

    public string enemyName;
    public GameObject enemyHPBar;

    public GameObject item;

    IBattle playerAttack;
    Animator anim;
    NavMeshAgent agent;
    Player player;
    new Collider collider;

    public AudioClip slimeAttack;
    public AudioClip golemAttack;
    public AudioClip dragonMove;
    public AudioClip dragonAttack;
    public AudioClip dragonFly;
    public AudioClip fireBall;
    AudioSource audioSource;

    public GameObject gameClear;
    void Start()
    {
        playerAttack = GameManager.Inst.MainPlayer.GetComponent<IBattle>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();        
        enemyHPBar.SetActive(false);
        player = GameManager.Inst.MainPlayer;
        collider = GetComponent<Collider>();
        if (enemyType == EnemyType.Boss)
        {
            gameClear.SetActive(false);
        }
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerWeapon")
        {
            playerAttack = GameManager.Inst.MainPlayer.GetComponent<IBattle>();
            Attack(this);
        }
    }          

    public void Attack(IBattle target)
    {
        if (target != null)
        {            
            float damage = playerAttack.AttackPower;
            target.TakeDamage(damage);
            enemyHPBar.SetActive(true);
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage - playerAttack.DefencePower;
        if (hp > 0.0f)
        {            
            anim.SetTrigger("Hit");
            enemyHPBar.SetActive(true);
        }
        else
        {
            anim.SetTrigger("OnDead");
            Invoke("OnDead", 4);
            agent.isStopped = true;
            agent.enabled = false;
            collider.enabled = false;
            DropItem();
            player.money += Random.Range(100, 500);
        }
    }

    private void OnDead()
    {
        enemyHPBar.SetActive(false);
        Destroy(this.gameObject);
        if(enemyType == EnemyType.Boss)
        {
            gameClear.SetActive(true);
            enemyHPBar.SetActive(false);
            Destroy(this.gameObject);
            Cursor.visible = true;
        }
    }

    private void DropItem()
    {
        Instantiate(item, transform.position, transform.rotation);
    }

    public void PlaySound(string action)
    {
        switch (action)
        {
            case "SlimeAttack":
                audioSource.clip = slimeAttack;
                break;
            case "GolemAttack":
                audioSource.clip = golemAttack;
                break;
            case "DragonAttack":
                audioSource.clip = dragonAttack;
                break;
            case "DragonMove":
                audioSource.clip = dragonMove;
                break;
            case "DragonFly":
                audioSource.clip = dragonFly;
                break;
            case "FireBall":
                audioSource.clip = fireBall;
                break;
        }
        audioSource.Play();
    }
}
