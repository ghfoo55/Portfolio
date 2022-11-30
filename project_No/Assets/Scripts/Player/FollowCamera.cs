using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform target = null;
    
    public float speed = 0.0f;

    Vector3 offset = Vector3.zero;

    //public static GameManager instance;

    private void Start()
    {
        if (target == null)
        {
            target = FindObjectOfType<Player>().transform;
        }
        offset = transform.position - target.position;
    }

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        DontDestroyOnLoad(this);
    //        return;
    //    }
    //    else
    //    {
    //        if (instance != this)
    //        {
    //            Destroy(this);
    //        }
    //    }
    //}

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);
    }
}
