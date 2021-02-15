using UnityEngine;
using UnityEngine.AI;

namespace Enemy {
    public class EnemyMovement : MonoBehaviour {
        [SerializeField] private float allowDistance = 10f;
        
        private Vector3 startTransform;
        
        private void Start() {
            startTransform = transform.position;
        }

        private void Update() {

        }
    }
}