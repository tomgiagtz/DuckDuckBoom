using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] protected int magazineSize;
    
    [SerializeField] protected float reloadTime;
    
    [SerializeField] protected float fireRate;
    
    [SerializeField] protected Transform spawnPoint;
    
    [SerializeField] protected Projectile projectile;

    protected PlayerActions playerActions;
    protected int ammoRemaining;
    protected bool isMagEmpty;
    protected bool isFireReady;

    protected void Awake()
    {
        RefillAmmo();
        FireReset();
    }

    private void Update()
    {
        if (ammoRemaining <= 0)
            Reload();
    }

    public abstract void Fire();

    protected void FireReset()
    {
        isFireReady = true;
    }

    void Reload()
    {
        if (!isMagEmpty)
        {
            isMagEmpty = true;
            Invoke(nameof(RefillAmmo), reloadTime);
        }
    }

    void RefillAmmo()
    {
        isMagEmpty = false;
        ammoRemaining = magazineSize;
    }
}
