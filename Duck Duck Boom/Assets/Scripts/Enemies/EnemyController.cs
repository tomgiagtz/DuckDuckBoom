using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState {
    Idle,
    Patrol,
    Chase
}

public class EnemyController : MonoBehaviour{

    private NavMeshAgent agent;
    public EnemyData data;
    public EnemyState state;

    void Start() {
        InitAgent();
    }

    void InitAgent() {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = data.speed;
        agent.stoppingDistance = data.attackRange;
        agent.SetDestination(Vector3.zero);
    }

    void SetState() {

    }
}
