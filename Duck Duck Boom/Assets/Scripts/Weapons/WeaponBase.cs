using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] public int magazineSize;
    
    [SerializeField] protected float reloadTime;
    
    [SerializeField] protected float fireRate;
    
    [SerializeField] protected Transform spawnPoint;
    
    [SerializeField] protected Projectile projectile;

    protected PlayerActions playerActions;
    public int ammoRemaining;
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

    public abstract bool Fire();

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

    public void RefillAmmo()
    {
        isMagEmpty = false;
        ammoRemaining = magazineSize;
    }

    public void EmptyMagazine()
    {
        ammoRemaining = 0;
        isMagEmpty = true;
        Invoke(nameof(RefillAmmo), reloadTime);
    }
}
