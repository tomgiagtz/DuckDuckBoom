using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : WeaponBase
{
    public override void Fire()
    {
        if (!isMagEmpty && isFireReady)
        {
            isFireReady = false;
            Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
            Instantiate(projectile, spawnPoint.position, Quaternion.LookRotation(spawnPoint.forward + (spawnPoint.right / 3), spawnPoint.up));
            Instantiate(projectile, spawnPoint.position, Quaternion.LookRotation(spawnPoint.forward - (spawnPoint.right / 3), spawnPoint.up));

            Invoke(nameof(FireReset), fireRate);
            ammoRemaining -= 1;
        }
    }
}
