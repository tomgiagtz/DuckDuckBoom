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

    public void SetHealth(int health) {
        currHealth = health;
        UpdateHealthDisplay();
    }

    public void OnPickupArmor() {
        armorGo.SetActive(true);
    }

    public void OnDestroyArmor() {
        armorGo.SetActive(false);
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
    int currAmmo;

    void WeaponInit() {
        currWeaponImage.sprite = weaponImages[0];
    }

    


    public void SetActiveWeapon(WeaponBase activeWeapon, WeaponPickup.WEAPON _weaponType) {
        this.activeWeapon = activeWeapon;
        currAmmo = activeWeapon.magazineSize;
        currAmmoText.SetText(currAmmo.ToString());
        maxAmmoText.SetText(activeWeapon.magazineSize.ToString());
        currWeaponImage.sprite = weaponImages[(int) _weaponType];
    }

    public void SetCurrAmmo(int _ammo) {
        currAmmo = _ammo;
        currAmmoText.SetText(currAmmo.ToString());
    }


    public TextMeshProUGUI campsRemainingText;

    public void SetCampsRemaining(int num) {
        campsRemainingText.SetText(num.ToString() + " Camps Remaining!");
    }

    public void Start() {
        ResetHealth();
        WeaponInit();
        Time.timeScale = 1;
        deathGo.SetActive(false);
        winGo.SetActive(false);
    }

    [Header("End States")]
    public GameObject deathGo;
    public GameObject winGo;

    public TextMeshProUGUI winText;
    public TextMeshProUGUI deathText;

    public void OnPlayerDied() {
        Time.timeScale = 0;
        deathText.SetText("But you managed to duck " + GameManager.Instance.GetEnemiesKilled() + " geese!");
        deathGo.SetActive(true);
    }
    
    public void OnPlayerWon() {
        Time.timeScale = 0;
        winText.SetText("You ducked " + GameManager.Instance.GetEnemiesKilled() + " geese!");
        winGo.SetActive(true);

    }

}
