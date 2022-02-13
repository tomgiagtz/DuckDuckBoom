using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public enum THROWABLE
    {
        GRENADE,
        C4,
        PROXIMITY_MINE,
        NONE
    }

    [SerializeField] int damage;

    [SerializeField] float blastRadius;

    [SerializeField] float speed;

    [SerializeField] bool isTimed;
    [SerializeField] float detTime;

    [SerializeField] bool isProximity;
    [SerializeField] float proximityRange;
    [SerializeField] LayerMask hitMask;

    [SerializeField] bool isRemote;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(!isProximity)
        {
            rb.velocity = transform.forward * speed + transform.up * (speed / 2);
        }

        if(isTimed)
            Invoke(nameof(Detonate), detTime);

    }

    void Update()
    {
        if(isProximity)
        {
            if (Physics.CheckSphere(transform.position, proximityRange, hitMask))
                Detonate();
        }
    }

    public void Detonate()
    {
        Destroy(gameObject);
    }
}
