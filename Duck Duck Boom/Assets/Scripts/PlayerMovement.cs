using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    [SerializeField] LayerMask groundMask;

    PlayerActions playerActions;
    Rigidbody rigidbody;
    Vector2 movement;
    Vector2 mousePos;
    Vector3 mouseWorldPos;

    private void Awake()
    {
        playerActions = new PlayerActions();
        rigidbody = GetComponent<Rigidbody>();
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
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + new Vector3(movement.x, 0.0f, movement.y) * speed * Time.fixedDeltaTime);

        //Vector3 lookDir = mousePos - rigidbody.position;

        //float angle = Mathf.Atan2(lookDir.z, lookDir.x) * Mathf.Rad2Deg - 90f;

        //rigidbody.rotation = Quaternion.FromToRotation(mouseWorldPos, rigidbody.position);
        transform.LookAt(mouseWorldPos);
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
