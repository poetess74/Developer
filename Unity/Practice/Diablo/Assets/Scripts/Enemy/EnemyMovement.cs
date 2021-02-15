using UnityEngine;
using UnityEngine.AI;

namespace Enemy {
    public class EnemyMovement : MonoBehaviour {
        [SerializeField] private float allowTargetingDistance = 10f;
        [SerializeField] private float allowTraceDistance = 7f;
        
        [HideInInspector] public CurrentState state = CurrentState.idle;

        private Vector3 startTraceLocation;
        private Transform target;
        private NavMeshAgent navMesh;

        public enum CurrentState {
            idle, trace, attack, escape
        } 
    }
}