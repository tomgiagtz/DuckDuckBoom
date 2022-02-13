using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponBase
{
    public override void Fire()
    {
        if (!isMagEmpty && isFireReady)
        {
            isFireReady = false;
            Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);

            Invoke(nameof(FireReset), fireRate);
            ammoRemaining -= 1;
        }
    }
}
