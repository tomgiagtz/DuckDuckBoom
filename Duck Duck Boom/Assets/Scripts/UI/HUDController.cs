using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pixelplacement;
using TMPro;
public class HUDController : Singleton<HUDController> {



    int maxHealth = 3;
    int currHealth = 3;

    [Header("Health")]
    public Image[] healthImages;
    public GameObject armorGo;

    public Color greyColor = new Color(0.5f, 0.5f, 0.5f, 1f);
    public Color redColor = new Color(1f, 0f, 0f, 1f);

    public void ResetHealth() {
        currHealth = maxHealth;
        armorGo.SetActive(false);
        UpdateHealthDisplay();
    }

    public void OnTakeDamage() {
        currHealth--;
        if (currHealth <= 0) {
            currHealth = 0;
            //death logic
        }

        if(armorGo.activeSelf) {
            armorGo.SetActive(false);
        }
    }

    public void OnHeal() {
        
        if (currHealth < maxHealth) {
            currHealth = maxHealth;
        }
    }

    public void OnPickupArmor() {
        currHealth++;
        armorGo.SetActive(true);
    }

    public void UpdateHealthDisplay() {
        for (int i = 0; i < healthImages.Length; i++) {
            if (i < currHealth) {
                healthImages[i].color = redColor;
            } else {
                healthImages[i].color = greyColor;
            }
        }
    }

    [Header("Weapons")]
    public Image currWeaponImage;
    public Sprite[] weaponImages;
    public WeaponBase activeWeapon;

    [SerializeField]
    TextMeshProUGUI currAmmoText, maxAmmoText;


    void WeaponInit() {
        currWeaponImage.sprite = weaponImages[0];
    }


    public void SetActiveWeapon(WeaponBase activeWeapon, WeaponPickup.WEAPON _weaponType) {
        this.activeWeapon = activeWeapon;
        maxAmmoText.SetText(activeWeapon.magazineSize.ToString());
        currWeaponImage.sprite = weaponImages[(int) _weaponType];
    }

    public void Start() {
        ResetHealth();
        WeaponInit();
    }

}
