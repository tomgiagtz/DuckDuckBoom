using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    enum WEAPON
    { 
        PISTOL,
        SHOTGUN,
        ROCKET,
        GRENADE_LAUNCHER
    }

    enum THROWABLE
    {
        GRENADE,
        C4,
        PROXIMITY_MINE,
        NONE
    }

    [SerializeField] float speed = 10f;

    [SerializeField] LayerMask groundMask;

    [SerializeField] WeaponBase activeWeapon;
    [SerializeField] WeaponBase[] weapons;

    [SerializeField] THROWABLE activeThrowable;
    [SerializeField] Throwable[] throwables;
    [SerializeField] Transform throwableSpawn;


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
        playerActions.Player_Map.CycleThrowable.performed += _ => CycleThrowable();
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

        int cycleVal = (int)playerActions.Player_Map.CycleWeapon.ReadValue<float>();
        if (cycleVal != 0)
            CycleWeapon(cycleVal);
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + new Vector3(movement.x, 0.0f, movement.y) * speed * Time.fixedDeltaTime);
        transform.LookAt(mouseWorldPos);
    }

    void Attack()
    {
        activeWeapon.Fire();
    }

    void CheckThrowable()
    {
        if(!remoteSet)
        {
            switch (activeThrowable)
            {
                case THROWABLE.NONE:
                    break;
                case THROWABLE.GRENADE:
                    Throw(throwables[0], throwableSpawn, false);
                    break;
                case THROWABLE.C4:
                    Throw(throwables[1], throwableSpawn, true);
                    break;
                case THROWABLE.PROXIMITY_MINE:
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

        activeThrowable = (THROWABLE)ThrowableIndex;
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
