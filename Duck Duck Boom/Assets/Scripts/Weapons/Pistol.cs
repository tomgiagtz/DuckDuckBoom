using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponBase
{
    protected override void Fire()
    {
        if (!isMagEmpty && isFireReady)
        {
            isFireReady = false;
            Debug.Log("Bang");
            Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);

            Invoke(nameof(FireReset), fireRate);
            ammoRemaining -= 1;
        }
    }
}
