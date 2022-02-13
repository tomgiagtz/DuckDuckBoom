using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : WeaponBase
{
    protected override void Fire()
    {
        if (!isMagEmpty && isFireReady)
        {
            isFireReady = false;
            Debug.Log("Bang");
            Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
            Instantiate(projectile, spawnPoint.position, Quaternion.LookRotation(spawnPoint.forward + spawnPoint.right, spawnPoint.up));
            Instantiate(projectile, spawnPoint.position, Quaternion.LookRotation(spawnPoint.forward - spawnPoint.right, spawnPoint.up));

            Invoke(nameof(FireReset), fireRate);
            ammoRemaining -= 1;
        }
    }
}
