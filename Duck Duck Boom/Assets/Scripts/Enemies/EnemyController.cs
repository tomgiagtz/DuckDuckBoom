using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState {
    Wander,
    Agro,
    Attacking
}

public class EnemyController : MonoBehaviour{

    private NavMeshAgent agent;
    public EnemyData data;
    [SerializeField]
    private EnemyState state;
    private Transform target;
    private Vector3 homeTarget;
    [SerializeField] Animator animator;
    [SerializeField, Tooltip("Time to wait before refresh")]
    private float refreshTime = 0.5f;

    private bool isAttacking = false;

    [SerializeField]
    WeaponBase activeWeapon;

    [SerializeField]
    GameObject deathEffect;




    void Start() {
        InitAgent();
        homeTarget = transform.position;
        InvokeRepeating("RefreshTarget", 0, refreshTime);
        activeWeapon.EmptyMagazine();
    }

    void InitAgent() {
        agent = GetComponent<NavMeshAgent>();
        UpdateAgentStats();
    }

    void UpdateAgentStats() {
        if (agent != null) {
            agent.speed = data.speed;
            agent.stoppingDistance = data.attackRange;
        }
        
    }

    void Update() {
        if (target != null) {
            transform.LookAt(target);
            HandleAttack();
        } else {
            transform.LookAt(agent.steeringTarget.normalized);
        }
    }

    void HandleAttack() {
        activeWeapon.Fire();
        animator.SetTrigger("Fire");
    }

    float currAgroTime;

    void RefreshTarget() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, data.agroRange,  1 << LayerMask.NameToLayer("Player"));
        
        if (hitColliders.Length > 0) {
            target = hitColliders[0].transform;
            if (CanSeePlayer()) {
                agent.SetDestination(target.position + (Random.onUnitSphere));
                currAgroTime = data.agroTimeout;
                isAttacking = true;
                // SetState(EnemyState.Agro);
            } else {
                isAttacking = false;
            }
            
        } else {
            currAgroTime -= refreshTime;

            if (target == null) {
                //go home
                agent.SetDestination(homeTarget);
                // SetState(EnemyState.Wander);
                return;
            }
            //delay forgetting about enemy until agro time is up
            if (currAgroTime <= 0) {
                
                target = null;
                // SetState(EnemyState.Wander);
                //reset timer
            } else {
                agent.SetDestination(target.position);
            }
        }

    }

    //casts a ray to see if has line of sight to target
    public LayerMask groundMask;
    private bool CanSeePlayer() {
        RaycastHit hit;
        Debug.DrawRay(transform.position, target.position - transform.position, Color.red, refreshTime);
        if (Physics.Raycast(transform.position,  target.position - transform.position,  out hit, data.agroRange, groundMask)) {
            // Debug.Log("hit terrain");
            return false;
            
        } else {
            //Player is in LoS
            // Debug.Log("can see player");
            return true;
        }
    }

    public void TakeDamage()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            Instantiate(deathEffect, hit.point, Quaternion.identity);
        }
        DropManager.Instance.DropCheck(transform, data.type);
        GameManager.Instance.IncrementEnemiesKilled();
        Destroy(gameObject);
    }

    private void OnValidate() {
        UpdateAgentStats();
    }
}
