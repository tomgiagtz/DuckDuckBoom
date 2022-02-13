using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rb;

    [SerializeField] int damage;
    
    [SerializeField] int speed;
    
    [SerializeField] bool isAOE;
    
    [SerializeField] float blastRadius;
    
    [SerializeField] bool isTimed;
    
    [SerializeField] float detTime;

    [SerializeField] LayerMask hitMask;

    private void Start()
    {
        rb.velocity = transform.forward * speed;
        if (isTimed)
            Invoke(nameof(Detonate), detTime);
    }

    private void Detonate()
    {
        Destroy(gameObject);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if((hitMask.value & 1<<collision.gameObject.layer) != 0)
        {
            if(!isTimed)
            {
                Destroy(gameObject);
            }
        }
    }
}


