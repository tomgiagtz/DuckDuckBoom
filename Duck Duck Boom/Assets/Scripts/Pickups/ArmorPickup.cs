using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickup : MonoBehaviour
{
    [SerializeField] float lifetime = 20f;

    [SerializeField] float degreesPerSecond = 30f;
    [SerializeField] float amplitude = 0.5f;
    [SerializeField] float frequency = 0.5f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    void Start()
    {
        posOffset = transform.position;
        Invoke(nameof(Despawn), lifetime);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }

    void Despawn()
    {
        DropManager.Instance.activeArmorDropCount -= 1;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("Player"))
        {
            PlayerController player = col.GetComponent<PlayerController>();
            if (player.allowWeaponPickup)
            {
                player.HandleArmorPickup();
                DropManager.Instance.activeArmorDropCount -= 1;
                Destroy(gameObject);
            }
        }
    }
}
