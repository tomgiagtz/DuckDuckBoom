using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int HP = 3;
    [SerializeField] bool hasArmor = false;
    [SerializeField] float invincabilityTime = 0.5f;

    [SerializeField] float speed = 10f;

    [SerializeField] LayerMask groundMask;

    [SerializeField] WeaponBase activeWeapon;
    [SerializeField] WeaponBase[] weapons;

    [SerializeField] Throwable.THROWABLE activeThrowable;
    [SerializeField] Throwable[] throwables;
    [SerializeField] Transform throwableSpawn;
    [SerializeField] Animator animator;

    public bool allowWeaponPickup = true;
    bool allowDamage = true;

    PlayerActions playerActions;
    Rigidbody rigidbody;

    Throwable remoteThrowable;
    bool remoteSet = false;
    int weaponIndex;
    int ThrowableIndex;

    Vector2 movement;
    Vector2 mousePos;
    Vector3 mouseWorldPos;

    private void Awake()
    {
        playerActions = new PlayerActions();
        rigidbody = GetComponent<Rigidbody>();
        playerActions.Player_Map.Attack.performed += _ => Attack();
        playerActions.Player_Map.Throw.performed += _ => CheckThrowable();
        //playerActions.Player_Map.CycleThrowable.performed += _ => CycleThrowable();
    }

    void Start() 
    {
        activeWeapon.RefillAmmo();
        HUDController.Instance.SetActiveWeapon(weapons[0], WeaponPickup.WEAPON.PISTOL);
    }

    void Update()
    {
        movement = playerActions.Player_Map.Movement.ReadValue<Vector2>();
        mousePos = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, groundMask))
        {
            mouseWorldPos = hit.point;
        }
        mouseWorldPos.y = 0;

        /*int cycleVal = (int)playerActions.Player_Map.CycleWeapon.ReadValue<float>();
        if (cycleVal != 0)
            CycleWeapon(cycleVal);*/

        float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
        float velocityX = Vector3.Dot(movement.normalized, transform.right);
        animator.SetFloat("moveZ", velocityZ);
        animator.SetFloat("moveX", velocityX);
        if (velocityZ == 0 && velocityX == 0) { animator.SetBool("moving", false); } else { animator.SetBool("moving", true); }

        HUDController.Instance.SetCurrAmmo(activeWeapon.ammoRemaining);
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + new Vector3(movement.x, 0.0f, movement.y) * speed * Time.fixedDeltaTime);
        transform.LookAt(mouseWorldPos);
    }

    void Attack()
    {
        if (activeWeapon.Fire()) HUDController.Instance.SetCurrAmmo(activeWeapon.ammoRemaining);
        animator.SetTrigger("Fire");
    }

    void CheckThrowable()
    {
        if(!remoteSet)
        {
            switch (activeThrowable)
            {
                case Throwable.THROWABLE.NONE:
                    break;
                case Throwable.THROWABLE.GRENADE:
                    Throw(throwables[0], throwableSpawn, false);
                    break;
                case Throwable.THROWABLE.C4:
                    Throw(throwables[1], throwableSpawn, true);
                    break;
                case Throwable.THROWABLE.PROXIMITY_MINE:
                    Throw(throwables[2], transform, false);
                    break;
            }
        }
        else
        {
            remoteThrowable.Detonate();
            remoteSet = false;
        }
    }

    void Throw(Throwable throwable, Transform spawn, bool isRemote)
    {
        Throwable obj = Instantiate(throwable, spawn.position, spawn.rotation);
        if(isRemote)
        {
            remoteSet = true;
            remoteThrowable = obj;
        }
    }

    void CycleWeapon(int dir)
    {
        weaponIndex = (weapons.Length + weaponIndex + dir) % weapons.Length;

        activeWeapon.gameObject.SetActive(false);
        activeWeapon = weapons[weaponIndex];
        activeWeapon.gameObject.SetActive(true);
    }

    void CycleThrowable()
    {
        ThrowableIndex += 1;
        if (ThrowableIndex >= throwables.Length)
            ThrowableIndex = 0;

        activeThrowable = (Throwable.THROWABLE)ThrowableIndex;
    }

    public void HandleWeaponPickup(WeaponPickup.WEAPON type, float duration)
    {
        switch(type)
        {
            case WeaponPickup.WEAPON.SHOTGUN:
                SetActiveWeapon(1);
                break;
            case WeaponPickup.WEAPON.ROCKET:
                SetActiveWeapon(2);
                break;
            case WeaponPickup.WEAPON.GRENADE_LAUNCHER:
                SetActiveWeapon(3);
                break;
        }
        allowWeaponPickup = false;
        Invoke(nameof(EnablePistol), duration);
    }

    public void HandleArmorPickup()
    {
        if (!hasArmor) {
            hasArmor = true;
            HUDController.Instance.OnPickupArmor();
        }
    }

    void SetActiveWeapon(int index)
    {
        activeWeapon.gameObject.SetActive(false);
        activeWeapon = weapons[index];
        HUDController.Instance.SetActiveWeapon(weapons[index], (WeaponPickup.WEAPON) index);
        activeWeapon.gameObject.SetActive(true);
        activeWeapon.RefillAmmo();
    }
    void EnablePistol()
    {
        allowWeaponPickup = true;
        activeWeapon.gameObject.SetActive(false);
        activeWeapon = weapons[0];
        HUDController.Instance.SetActiveWeapon(weapons[0], WeaponPickup.WEAPON.PISTOL);
        activeWeapon.gameObject.SetActive(true);
        activeWeapon.RefillAmmo();
    }


    public void TakeDamage()
    {
        if(allowDamage)
        {
            allowDamage = false;
            
            if (hasArmor) {
                hasArmor = false;
                HUDController.Instance.OnDestroyArmor();
            } else {
                HP -= 1;
                HUDController.Instance.SetHealth(HP);
            }
                
            Invoke(nameof(EndInvincability), invincabilityTime);
        }
        if (HP <= 0)
            Death();
    }

    void EndInvincability()
    {
        allowDamage = true;
    }

    void Death()
    {
        HUDController.Instance.OnPlayerDied();
    }
    private void OnEnable()
    {
        playerActions.Player_Map.Enable();
    }

    private void OnDisable()
    {
        playerActions.Player_Map.Disable();
    }
}
