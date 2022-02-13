using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] float seconds;
    private void Awake()
    {
        Invoke(nameof(Kill), seconds);
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
