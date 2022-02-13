using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType {
    CloseRange,
    Artillery,
    Bomber
}

[System.Serializable]
[CreateAssetMenu(fileName = "Enemy", menuName = "EnemyData")]
public class EnemyData : ScriptableObject {
    EnemyType type;
    public float health = 100f;
    public float speed = 3f;
    public float damage = 20f;

    public float targetDeadzone = 3f;

    [Tooltip("Time till enemy forgets about player")]
    public float agroTimeout = 3f;
    
    public float agroRange;
    public float attackRange;
}
