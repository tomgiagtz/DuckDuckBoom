using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType {
    CloseRange,
    Artillery,
    Bomber
}

[CreateAssetMenu(fileName = "Enemy", menuName = "EnemyData")]
public class EnemyData : ScriptableObject {
    public float health = 100f;
    public float speed = 3f;
    public float damage = 20f;
    public float fireRate;
    public float fireRange;
    
    public float agroRange;
    public float attackRange;
}
