using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : WeaponBase
{
    [SerializeField] GameObject loadedRocket;
    public override void Fire()
    {
        if (!isMagEmpty && isFireReady)
        {
            isFireReady = false;
            Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);

            Invoke(nameof(FireReset), fireRate);
            ammoRemaining -= 1;

            loadedRocket.SetActive(false);
            Invoke(nameof(ShowLoadedRocket), fireRate);
        }
    }

    void ShowLoadedRocket()
    {
        loadedRocket.SetActive(true);
    }
}
