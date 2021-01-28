using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class Enemy : LivingEntity {
    private Transform attackRoot;
    private Transform eyeTransform;
    [SerializeField] private AudioClip hitClip;
    [SerializeField] private AudioClip deathClip;

    [SerializeField] private float runSpeed = 10f;
    [Range(0.01f, 2f)] [SerializeField] private float turnSmoothTime = 0.1f;

    [SerializeField] private float damage = 30f;
    [SerializeField] private float attackRadius = 2f;

    [SerializeField] private float fieldOfView = 50f;
    [SerializeField] private float viewDistance = 10f;
    [SerializeField] private float patrolSpeed = 3f;

    [HideInInspector] public LivingEntity targetEntity;
    public LayerMask whatIsTarget;

    private NavMeshAgent agent;
    private Animator animator;
    private float attackDistance;

    private AudioSource audioPlayer;


    private RaycastHit[] hits = new RaycastHit[10];
    private readonly List<LivingEntity> lastAttackedTargets = new List<LivingEntity>();

    private Renderer skinRenderer;

    private State state;
    private float turnSmoothVelocity;

    private bool hasTarget => targetEntity != null && !targetEntity.dead;

    private void Awake() {
        attackRoot = GameObject.Find("AttackRoot").GetComponent<Transform>();
        eyeTransform = GameObject.Find("Eye").GetComponent<Transform>();
        
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        skinRenderer = GetComponentInChildren<Renderer>();

        Vector3 attackPivot = attackRoot.position;
        attackPivot.y = transform.position.y;
        attackDistance = Vector3.Distance(transform.position, attackPivot) + attackRadius;
        
        agent.stoppingDistance = attackDistance;
        agent.speed = patrolSpeed;
    }

    private void Start() {
        StartCoroutine(UpdatePath());
    }

    private void Update() {
        if(dead) return;

        if(state == State.Tracking && Vector3.Distance(
            targetEntity.transform.position, transform.position
        ) <= attackDistance) {
            BeginAttack();
        }

        animator.SetFloat("Speed", agent.desiredVelocity.magnitude);
    }

    private void FixedUpdate() {
        if(dead) return;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected() {
        if(attackRoot != null) {
            Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
            Gizmos.DrawSphere(attackRoot.position, attackRadius);
        }

        if (eyeTransform == null) return;
        Quaternion leftEye = Quaternion.AngleAxis(-fieldOfView * 0.5f, Vector3.up);
        Vector3 leftDir = leftEye * transform.forward;
        Handles.color = new Color(1f, 1f, 1f, 0.2f);
        Handles.DrawSolidArc(
            eyeTransform.position, Vector3.up, leftDir, fieldOfView, viewDistance
        );
    }
#endif

    public void Setup(float health, float damage,
        float runSpeed, float patrolSpeed, Color skinColor) {
        startingHealth = health;
        this.health = health;
        skinRenderer.material.color = skinColor;

        this.damage = damage;
        this.runSpeed = runSpeed;
        this.patrolSpeed = patrolSpeed;
        
        agent.speed = patrolSpeed;
    }

    private IEnumerator UpdatePath() {
        while(!dead) {
            if(hasTarget) {
                if(state == State.Patrol) {
                    state = State.Tracking;
                    agent.speed = runSpeed;
                }
                agent.SetDestination(targetEntity.transform.position);
            } else {
                if(targetEntity != null) targetEntity = null;
                
                if(state != State.Patrol) {
                    state = State.Patrol;
                    agent.speed = patrolSpeed;
                }

                if(agent.remainingDistance <= 1f) {
                    Vector3 patrolTargetPos = Utility.GetRandomPointOnNavMesh(
                        transform.position, 20f, NavMesh.AllAreas
                    );
                    agent.SetDestination(patrolTargetPos);
                }

                var colliders = Physics.OverlapSphere(eyeTransform.position, viewDistance, whatIsTarget);
                foreach(var collider in colliders) {
                    if(!IsTargetOnSight(collider.transform)) continue;
                    var livingEntity = collider.GetComponent<LivingEntity>();
                    if(livingEntity == null || livingEntity.dead) continue;
                    targetEntity = livingEntity;
                    break;
                }
            }

            yield return new WaitForSeconds(0.05f);
        }
    }

    public override bool ApplyDamage(DamageMessage damageMessage) {
        if(!base.ApplyDamage(damageMessage)) return false;

        return true;
    }

    public void BeginAttack() {
        state = State.AttackBegin;

        agent.isStopped = true;
        animator.SetTrigger("Attack");
    }

    public void EnableAttack() {
        state = State.Attacking;

        lastAttackedTargets.Clear();
    }

    public void DisableAttack() {
        state = State.Tracking;

        agent.isStopped = false;
    }

    private bool IsTargetOnSight(Transform target) {
        Vector3 direction = target.position - eyeTransform.position;
        direction.y = eyeTransform.forward.y;
        if(Vector3.Angle(direction, eyeTransform.forward) > fieldOfView * 0.5f) return false;
        direction = target.position - eyeTransform.position;
        if(!Physics.Raycast(eyeTransform.position, direction, out var hit, viewDistance, whatIsTarget)) return false;
        return hit.transform == target;
    }

    public override void Die() {
    }

    private enum State {
        Patrol,
        Tracking,
        AttackBegin,
        Attacking
    }
}