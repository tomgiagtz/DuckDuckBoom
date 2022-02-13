using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPlayer : MonoBehaviour
{


    [SerializeField] WeaponBase activeWeapon;
    [SerializeField] WeaponBase[] weapons;

    [SerializeField] Animator animator;

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

        //playerActions.Player_Map.Attack.performed += _ => Attack();
        //playerActions.Player_Map.Throw.performed += _ => CheckThrowable();
        //playerActions.Player_Map.CycleThrowable.performed += _ => CycleThrowable();
    }

    void Update()
    {
        movement = playerActions.Player_Map.Movement.ReadValue<Vector2>();

        /*int cycleVal = (int)playerActions.Player_Map.CycleWeapon.ReadValue<float>();
        if (cycleVal != 0)
            CycleWeapon(cycleVal);*/

        float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
        float velocityX = Vector3.Dot(movement.normalized, transform.right);
        animator.SetFloat("moveZ", velocityZ);
        animator.SetFloat("moveX", velocityX);
        if (velocityZ == 0 && velocityX == 0) { animator.SetBool("moving", false); } else { animator.SetBool("moving", true); }
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
