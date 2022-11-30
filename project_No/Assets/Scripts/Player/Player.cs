using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class Player : MonoBehaviour, IHealth, IStamina, IBattle
{
    // 움직일때 속도 --------------------------------------------
    float speed;
    float walkSpeed = 1.0f;
    float runSpeed = 3.0f;
    float turnSpeed = 1.0f;
    // 체력 ----------------------------------------------------
    public float hp = 1500.0f;
    public float maxHP = 1500.0f;
    public float HP
    {
        get => hp;
        set
        {
            if(hp != value)
            {
                hp = Mathf.Clamp(value, 0.0f, maxHP);
                onHPChange?.Invoke();
            }
        }
    }
    public float MaxHP
    {
        get => maxHP;
    }    

    public Action onHPChange { get; set; }

    // 스태미너-----------------------------------------------

    public float stamina = 150.0f;
    public float maxStamina = 150.0f;
    public float Stamina
    {
        get => stamina;
        set
        {
            if(stamina != value)
            {
                stamina = Mathf.Clamp(value, 0.0f, maxStamina);
                onStaminaChange?.Invoke();
            }
        }
    }

    public float MaxStamina
    {
        get => maxStamina;
    }

    public Action onStaminaChange { get; set; }

    float DodgeStamina = 30.0f;

    float StaminaRecovery = 7.0f;

    float DodgeDelay = 1.0f;

    float WeaponDelay = 1.0f;

    // -------------------------------------------------------
    public float attackPower = 50.0f;
    public float defencePower = 10.0f;

    public float AttackPower { get => attackPower; }
    public float DefencePower { get => defencePower; }
    enum MoveMode
    {
        Walk = 0,
        Run
    }

    MoveMode moveMode = MoveMode.Walk;    

    PlayerInput inputAction;
    Rigidbody rigid;
    Animator anim;   
    Vector3 inputDir = Vector3.zero;

    private GameObject cam;

    float battledelay;

    GameObject weapon;

    IBattle attackTarget;

    ParticleSystem particleWeapon;

    LockOnEnemy lockOnEnemy;

    public GameObject inventory;

    bool onInven = false;

    [SerializeField]
    private InventoryObject inventoryObject;

    public GameObject quickSlot;

    [SerializeField]
    private InventoryObject quickSlotUI;

    public int money;

    public AudioClip walkAudio;
    public AudioClip runAudio;
    public AudioClip attackAudio;

    AudioSource audioSource;

    public GameObject playerDead;
    private void Awake()
    {        
        inputAction = new();
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        cam = GameObject.Find("MainCamera");
        weapon = GetComponentInChildren<FindWeapon>().gameObject;
        particleWeapon = weapon.GetComponentInChildren<ParticleSystem>();
        lockOnEnemy = GetComponent<LockOnEnemy>();
        inventory = GameObject.Find("Inventory");
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        inputAction.Player.Enable();
        inputAction.Player.Move.performed += Move;
        inputAction.Player.Move.canceled += Move;
        inputAction.Player.Look.performed += Look;
        inputAction.Player.Run.performed += Run;
        inputAction.Player.Run.canceled += Run;
        inputAction.Player.Attack.performed += OnAttack;
        inputAction.Player.Dodge.performed += Dodge;      
        inputAction.Player.LockOn.performed += LockOn;
        inputAction.Player.Inventory.performed += OnInven;
    }    

    private void OnDisable()
    {
        inputAction.Player.Inventory.performed -= OnInven;
        inputAction.Player.LockOn.performed -= LockOn;
        inputAction.Player.Dodge.performed -= Dodge;
        inputAction.Player.Attack.performed -= OnAttack;
        inputAction.Player.Run.canceled -= Run;
        inputAction.Player.Run.performed -= Run;
        inputAction.Player.Look.performed -= Look;
        inputAction.Player.Move.canceled -= Move;
        inputAction.Player.Move.performed -= Move;
        inputAction.Player.Disable();
    }

    private void FixedUpdate()
    {
        OnMove();
        StaminaFill();
    }
   
    private void Start()
    {
        attackTarget = GameManager.Inst.enemyMonster.GetComponent<IBattle>();
        inventoryObject.OnUseItem += OnUseItem;
        inventory.SetActive(false);
        weapon.SetActive(false);
        weapon.gameObject.GetComponentInChildren<BoxCollider>().enabled = false;
        playerDead.SetActive(false);
        Cursor.visible = false;        
    }    

    private void Move(InputAction.CallbackContext context)
    {
        inputDir = context.ReadValue<Vector2>();
    }    
    
    private void OnMove()
    {
        if (inputDir.sqrMagnitude > 0.0f)
        {
            anim.SetBool("isMove", true);
            if (moveMode == MoveMode.Walk)
            {
                anim.SetFloat("Run", 0.5f);
                speed = walkSpeed;         
            }
            else if (moveMode == MoveMode.Run)
            {
                stamina -= 10.0f * Time.deltaTime;
                anim.SetFloat("Run", 1.0f);
                speed = runSpeed;               
            }
            if (stamina <= 0.0f)
            {
                inputAction.Player.Run.Disable();
            }
            else if (stamina >= 10.0f)
            {
                inputAction.Player.Run.Enable();
            }            
        }
        else
        {
            anim.SetFloat("Run", 0.0f);
            anim.SetBool("isMove", false);
        }
        
        if (inputDir != Vector3.zero)
        {                   
            Vector3 lookForward = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z).normalized;
            Vector3 lookRight = new Vector3(cam.transform.right.x, 0, cam.transform.right.z).normalized;
            Vector3 moveDir = lookForward * inputDir.y + lookRight * inputDir.x;

            rigid.transform.forward = moveDir;
            transform.position += moveDir * speed * Time.fixedDeltaTime;
        }        
    }

    private void Look(InputAction.CallbackContext context)
    {        
        float mx = context.ReadValue<Vector2>().x;
        float my = context.ReadValue<Vector2>().y;
        
        Vector3 camAngle = cam.transform.rotation.eulerAngles;
        float x = camAngle.x - my;

        if(x < 180f)
        {
            x = Mathf.Clamp(x, -10.0f, 30.0f);
        }
        else
        {
            x = Mathf.Clamp(x, 330.0f, 360.0f);                        
        }
        cam.transform.rotation = Quaternion.Euler(x, camAngle.y - mx * -1, camAngle.z * turnSpeed * Time.deltaTime);                
    }

    private void Run(InputAction.CallbackContext _)
    {
        if (moveMode == MoveMode.Walk)
        {
            moveMode = MoveMode.Run;
        }
        else
        {
            moveMode = MoveMode.Walk;            
        }
    }
    
    private void OnAttack(InputAction.CallbackContext _)
    {
        anim.ResetTrigger("Attack");
        anim.SetTrigger("Attack");
        BattleModeChange();        
        inputDir = Vector3.zero;
        if (lockOnEnemy.LockOnTarget != null)
        {
            rigid.transform.forward = lockOnEnemy.LockOnTarget.position - transform.position;
        }
    }

    private void Dodge(InputAction.CallbackContext _)
    {        
        if (stamina <= maxStamina && stamina >= DodgeStamina && DodgeDelay >= 1.0f)
        {            
            anim.ResetTrigger("Dodge");
            anim.SetTrigger("Dodge");
            stamina -= DodgeStamina;
            inputAction.Player.Dodge.Disable();
            DodgeDelay -= 1.0f;
            if (DodgeDelay >= 0.0f)
            {
                inputAction.Player.Dodge.Enable();
            }
        }
    }

    private void LockOn(InputAction.CallbackContext _)
    {
        lockOnEnemy.LockOnToggle();
    }

    private void OnInven(InputAction.CallbackContext _)
    {
        if (!onInven)
        {
            inventory.SetActive(true);
            onInven = true;
            inputAction.Player.Attack.Disable();
            inputAction.Player.Look.Disable();
            Cursor.visible = true;            
        }
        else if(onInven)
        {
            inventory.SetActive(false);
            onInven = false;
            inputAction.Player.Attack.Enable();
            inputAction.Player.Look.Enable();
            Cursor.visible = false;
        }
    }

    void StaminaFill()
    {
        if (stamina < maxStamina)
        {
            stamina += StaminaRecovery * Time.deltaTime;
        }
        else
        {
            stamina = maxStamina;
        }
        if (DodgeDelay < 1.0f)
        {
            DodgeDelay += 1.0f * Time.deltaTime;
        }

        battledelay -= 1.0f * Time.deltaTime;
        if (battledelay < 0.0f)
        {
            anim.SetBool("BattleMode", false);
            WeaponDelay -= 1.0f * Time.deltaTime;
            if (WeaponDelay < 0.0f)
            {
                weapon.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyAttack")
        {            
            Attack(this);
        }
        if(other.tag == "EnemyFireBall")
        {
            Attack(this);
        }
        if(other.tag == "ItemShop")
        {
            ItemShop shop = other.GetComponent<ItemShop>();
            shop.Enter(this);
            inputAction.Player.Attack.Disable();
            inputAction.Player.Look.Disable();
            Cursor.visible = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ItemShop")
        {
            ItemShop shop = other.GetComponent<ItemShop>();
            shop.Exit();
            inputAction.Player.Attack.Enable();
            inputAction.Player.Look.Enable();
            Cursor.visible = false;
        }
    }

    void BattleModeChange()
    {
        anim.SetBool("BattleMode", true);
        weapon.SetActive(true);
        battledelay = 10.0f;
    }

    public void TurnPaticle(bool turnOn)
    {
        if (particleWeapon != null)
        {
            if(turnOn)
            { 
                particleWeapon.Play();
            }
            else
            {
                particleWeapon.Stop();
            }
        }
    }

    private void OnUseItem(ItemObject itemObject)
    {
        foreach (ItemBuff buff in itemObject.data.buffs)
        {            
            if (buff.stat == CharacterAttribute.Health)
            {
                this.hp += buff.value;
            }
            if (buff.stat == CharacterAttribute.Stamina)
            {
                this.stamina += buff.value;
            }
            else
            {
                hp = maxHP;
            }
        }
    }

    public void Attack(IBattle target)
    {
        if(target != null)
        {          
            float damage = attackTarget.AttackPower;
            target.TakeDamage(damage);
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage - attackTarget.DefencePower;
        if (hp > 0.0f)
        {            
            anim.SetTrigger("Hit");
            inputDir = Vector3.zero;
            BattleModeChange();
        }
        else
        {            
            Ondead();
        }
    }

    private void Ondead()
    {
        anim.SetTrigger("Dead");
        inputAction.Disable();
        playerDead.SetActive(true);
        Cursor.visible = true;
    }

    public void PlaySound(string action)
    {
        switch (action)
        {
            case "Walk":
                audioSource.clip = walkAudio;
                break;
            case "Run":
                audioSource.clip = runAudio;
                break;
            case "Attack":
                audioSource.clip = attackAudio;
                break;
        }
        audioSource.Play();
    }

}
