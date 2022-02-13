using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int damage;
    
    [SerializeField] int speed;
    
    [SerializeField] bool isAOE;
    
    [SerializeField] float blastRadius;
    
    [SerializeField] bool isTimed;
    
    [SerializeField] float detTime;

    [SerializeField] LayerMask hitMask;

    [SerializeField] bool isPlayerTargeting;

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        if (isTimed)
            Invoke(nameof(Detonate), detTime);
    }

    private void Detonate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider col in hitColliders)
        {
            if(isPlayerTargeting && col.tag.Equals("Player"))
            {
                col.GetComponent<PlayerController>().TakeDamage();
            }
            else if(!isPlayerTargeting && col.tag.Equals("Enemy"))
            {
                col.GetComponent<EnemyController>().TakeDamage();
            }
        }
        Destroy(gameObject);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (isPlayerTargeting && collision.collider.tag.Equals("Player"))
        {
            collision.collider.GetComponent<PlayerController>().TakeDamage();
        }
        else if (!isPlayerTargeting && collision.collider.tag.Equals("Enemy"))
        {
            Detonate();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if ((hitMask.value & 1 << col.gameObject.layer) != 0)
        {
            if(isAOE)
            {
                Detonate();
            }
            
            if (isPlayerTargeting && col.tag.Equals("Player"))
            {
                col.GetComponent<PlayerController>().TakeDamage();
            }
            else if (!isPlayerTargeting && col.tag.Equals("Enemy"))
            {
                col.GetComponent<EnemyController>().TakeDamage();
            }

            Destroy(gameObject);
        }
    }
}


