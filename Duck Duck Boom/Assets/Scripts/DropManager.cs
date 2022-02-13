using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    private static DropManager _Instance;
    public static DropManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<DropManager>();
            }
            return _Instance;
        }
    }

    [SerializeField] int maxWeaponDrops = 5;
    [SerializeField] int maxArmorDrops = 2;
    [SerializeField] WeaponPickup[] closeRangePickups;
    [SerializeField] WeaponPickup[] artillaryPickups;
    [SerializeField] ArmorPickup armorPickup;

    public int activeWeaponDropCount = 0;
    public int activeArmorDropCount = 0;
    public void DropCheck(Transform point, EnemyType type)
    {
        if (activeWeaponDropCount >= maxWeaponDrops)
        {
            if (activeArmorDropCount >= maxArmorDrops)
                return;

            if (RollArmorDrop())
                DropArmor(point);
            return;
        }

        if (RollWeaponDrop())
        {
            DropWeapon(point, type);
            return;
        }

        if(RollArmorDrop())
            DropArmor(point);

    }

    bool RollArmorDrop()
    {
        float armorDropChance = ((maxArmorDrops - activeArmorDropCount) / maxArmorDrops) - 0.25f;
        if (UnityEngine.Random.Range(0f, 1f) <= armorDropChance)
        {
            return true;
        }
        return false;
    }

    bool RollWeaponDrop()
    {
        float weaponDropChance = ((maxWeaponDrops - activeWeaponDropCount) / maxWeaponDrops) - 0.15f;
        if (UnityEngine.Random.Range(0f, 1f) <= weaponDropChance)
        {
            return true;
        }
        return false;
    }

    void DropWeapon(Transform point, EnemyType type)
    {
        activeWeaponDropCount += 1;
        if(type == EnemyType.Artillery)
        {
            Instantiate(artillaryPickups[UnityEngine.Random.Range(0, artillaryPickups.Length)], point.position, point.rotation);
        }
        else if(type == EnemyType.CloseRange)
        {
            Instantiate(closeRangePickups[UnityEngine.Random.Range(0, closeRangePickups.Length)], point.position, point.rotation);
        }
    }

    void DropArmor(Transform point)
    {
        activeArmorDropCount += 1;
        Instantiate(armorPickup, point.position, point.rotation);
    }
}
