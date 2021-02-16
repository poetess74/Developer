using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace Enemy {
    public class EnemyMovement : MonoBehaviour {
        [SerializeField] private float allowTargetingDistance = 10f;
        [SerializeField] private float allowTraceDistance = 5f;
        [SerializeField] private float allowAttackDistance = 2f;
        
        [HideInInspector] public CurrentState state = CurrentState.idle;
        [HideInInspector] public GameObject target;

        private Vector3 startTraceLocation;
        private NavMeshAgent navMesh;
        private Animator animator;
        private EnemySpawner spawner;

        private float currentSpeed =>
            new Vector2(navMesh.velocity.x, navMesh.velocity.z).magnitude;
 
        public enum CurrentState {
            idle, patrol, trace, attack, escape
        }

        private void Start() {
            StartCoroutine(ChangeState());
            navMesh = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            spawner = GetComponent<EnemySpawner>();
        }

        private void Update() {
            switch(state) {
                case CurrentState.idle:
                    navMesh.isStopped = false;
                    ChangePath();
                    break;
                case CurrentState.patrol:
                    navMesh.isStopped = false;
                    break;
                case CurrentState.trace:
                    startTraceLocation = transform.position;
                    navMesh.destination = target.transform.position;
                    navMesh.isStopped = false;
                    break;
                case CurrentState.attack:
                    navMesh.isStopped = true;
                    break;
                case CurrentState.escape:
                    navMesh.isStopped = false;
                    navMesh.destination = startTraceLocation;
                    break;
            }
        }

        private void LateUpdate() {
            animator.SetFloat("Movement", currentSpeed);
        }

        private IEnumerator ChangeState() {
            while(true) {
                yield return new WaitForSeconds(0.2f);

                if(target != null) {
                    float dist = Vector3.Distance(target.transform.position, transform.position);
                    if(dist <= allowAttackDistance) {
                        state = CurrentState.attack;
                    } else if(dist <= allowTraceDistance) {
                        state = CurrentState.trace;
                    } else if(dist <= allowTargetingDistance) {
                        state = CurrentState.patrol;
                    } else {
                        state = CurrentState.idle;
                        target = null;
                    }
                } else {
                    state = CurrentState.idle;
                    GameObject player = GameObject.FindWithTag("Player");
                    float dist = Vector3.Distance(player.transform.position, transform.position);
                    if(dist <= allowTargetingDistance) target = player;
                }
            }
        }

        private void ChangePath() {
            if(navMesh.pathPending || navMesh.velocity.sqrMagnitude != 0f) return;

            float possibleDest = GamePlayManager.instance.mapSize;
            navMesh.destination = new Vector3(Random.Range(-possibleDest, possibleDest), 0, Random.Range(-possibleDest, possibleDest));
        }
    }
}