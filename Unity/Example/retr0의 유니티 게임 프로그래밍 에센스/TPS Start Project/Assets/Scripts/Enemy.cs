﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class Enemy : LivingEntity {
    [SerializeField] private Transform attackRoot;
    [SerializeField] private Transform eyeTransform;
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
    }

    private void Start() {
        StartCoroutine(UpdatePath());
    }

    private void Update() {
    }

    private void FixedUpdate() {
        if(dead) return;
    }


#if UNITY_EDITOR

    private void OnDrawGizmosSelected() {
    }

#endif

    public void Setup(float health, float damage,
        float runSpeed, float patrolSpeed, Color skinColor) {
    }

    private IEnumerator UpdatePath() {
        while(!dead) {
            if(hasTarget) {
                agent.SetDestination(targetEntity.transform.position);
            } else {
                if(targetEntity != null) targetEntity = null;
            }

            yield return new WaitForSeconds(0.2f);
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
        return false;
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