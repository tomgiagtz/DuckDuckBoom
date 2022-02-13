using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : WeaponBase
{
    [SerializeField] GameObject loadedRocket;
    public override bool Fire()
    {
        if (!isMagEmpty && isFireReady)
        {
            isFireReady = false;
            Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);

            Invoke(nameof(FireReset), fireRate);
            ammoRemaining -= 1;
            HUDController.Instance.SetCurrAmmo(ammoRemaining);

            loadedRocket.SetActive(false);
            Invoke(nameof(ShowLoadedRocket), fireRate);
            return true;
        }
        return false;
    
    }

    void ShowLoadedRocket()
    {
        loadedRocket.SetActive(true);
    }
}
