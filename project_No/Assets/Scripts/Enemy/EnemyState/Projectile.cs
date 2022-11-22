using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public GameObject muzzlePrefab;
    public GameObject hitEffect;

    public AudioClip shotSFX;
    public AudioClip hitSFX;

    private bool collided;
    private Rigidbody rigid;

    [HideInInspector]
    public AttackBehaviour attackBehaviour;

    [HideInInspector]
    public GameObject owner;

    [HideInInspector]
    public GameObject target;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        if(target)
        {
            Vector3 dest = target.transform.position;
            dest.y += 1.5f;
            transform.LookAt(dest);
        }

        if(owner)
        {
            Collider projecttileCollider = GetComponent<Collider>();
            Collider[] ownerColliders = owner.GetComponentsInChildren<Collider>();

            foreach(Collider collider in ownerColliders)
            {
                Physics.IgnoreCollision(projecttileCollider, collider);
            }
        }

        if(muzzlePrefab)
        {
            GameObject muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
            muzzleVFX.transform.forward = gameObject.transform.forward;
            ParticleSystem particle = muzzleVFX.GetComponent<ParticleSystem>();
            if(particle)
            {
                Destroy(muzzleVFX, particle.main.duration);
            }
            else
            {
                ParticleSystem chiledParticle = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                if (chiledParticle)
                {
                    Destroy(muzzleVFX, chiledParticle.main.duration);
                }
            }
        }

        if(shotSFX && GetComponent<AudioSource>())
        {
            GetComponent<AudioSource>().PlayOneShot(shotSFX);
        }
    }

    private void FixedUpdate()
    {
        if(speed != 0 && rigid != null)
        {
            rigid.position += (transform.forward) * (speed * Time.deltaTime);
        }
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if(collided)
        {
            return;
        }

        collided = true;

        Collider projecttileCollider = GetComponent<Collider>();
        projecttileCollider.enabled = false;

        if(hitSFX != null && GetComponent<AudioSource>())
        {
            GetComponent<AudioSource>().PlayOneShot(hitSFX);
        }

        speed = 0;
        rigid.isKinematic = true;

        ContactPoint contact = collision.contacts[0];
        Quaternion contactRotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 contextPosition = contact.point;

        if(hitEffect)
        {
            GameObject hitVFX = Instantiate(hitEffect, contextPosition, contactRotation);

            ParticleSystem particle = hitVFX.GetComponent<ParticleSystem>();
            if (particle)
            {
                Destroy(hitVFX, particle.main.duration);
            }
            else
            {
                ParticleSystem chiledParticle = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                if (chiledParticle)
                {
                    Destroy(hitVFX, chiledParticle.main.duration);
                }
            }
        }

        IBattle damage = collision.gameObject.GetComponent<IBattle>();
        if(damage != null)
        {
            damage.TakeDamage(attackBehaviour?.damage ?? 0);
        }

        StartCoroutine(DestoryParticle(0.1f));
    }

    public IEnumerator DestoryParticle(float waitTime)
    {
        if(transform.childCount > 0 && waitTime != 0)
        {
            List<Transform> childs = new List<Transform>();

            foreach (Transform t in transform.GetChild(0).transform)
            {
                childs.Add(t);
            }
            while(transform.GetChild(0).localScale.x > 0)
            {
                yield return new WaitForSeconds(0.0f);

                transform.GetChild(0).localScale -= new Vector3(0.1f, 0.1f, 0.1f);

                for(int i = 0; i < childs.Count; i++)
                {
                    childs[i].localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                }
            }
        }

        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
