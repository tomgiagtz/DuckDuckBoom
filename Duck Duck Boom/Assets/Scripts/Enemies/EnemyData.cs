using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType {
    CloseRange,
    Artillery,
    Bomber
}

public class EnemyData : ScriptableObject {
    public float health;
    public float speed;
    public float damage;
    public float fireRate;
    public float fireRange;
    
    public float agroRange;
    public float attackRange;
}
