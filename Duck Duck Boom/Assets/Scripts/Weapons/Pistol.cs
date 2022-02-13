using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponBase
{
    public override bool Fire()
    {
        if (!isMagEmpty && isFireReady)
        {
            isFireReady = false;
            Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);

            Invoke(nameof(FireReset), fireRate);
            ammoRemaining -= 1;
            return true;
        }
        return false;
    }
}
