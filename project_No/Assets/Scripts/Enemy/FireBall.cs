using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    Rigidbody rigid;

    public float speed;
    public float damage;
    Player target;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();        
    }

    private void Start()
    {
        target = GameManager.Inst.MainPlayer;
        transform.LookAt(target.transform);
    }

    private void Update()
    {        
        transform.Translate(speed * Time.deltaTime * transform.forward, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        IBattle player = other.gameObject.GetComponent<IBattle>();
        if (other.tag == "Player")
        {
            player.TakeDamage(damage);
            Destroy(this.gameObject);
        }

        if (other.tag == "Wall")
        {
            Destroy(this.gameObject, 3);
        }
    }
}
