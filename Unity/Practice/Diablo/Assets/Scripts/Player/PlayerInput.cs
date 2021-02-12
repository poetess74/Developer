using UnityEngine;

namespace Player {
    public class PlayerInput : MonoBehaviour {
        public Vector3 moveDir { get; private set; }
        public RaycastHit targetPos { get; private set; }

        private Camera followCam;
        private TargetSelector targetSelector;
        private Animator animator;
        
        [SerializeField] private LayerMask characterLayer;
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private LayerMask enemyLayer;

        private void Start() {
            followCam = Camera.main;
            animator = GetComponent<Animator>();
        }
        
        private void Update() {
            Ray ray = followCam.ScreenPointToRay(Input.mousePosition);
            if(Input.GetMouseButtonUp(0)) {
                if(Physics.Raycast(ray, out RaycastHit target, int.MaxValue, enemyLayer)) {
                    targetPos = target;
                } else if(Physics.Raycast(ray, out RaycastHit dir, int.MaxValue, ~characterLayer)) {
                    if (animator.GetBool("Damage")) return;
                    moveDir = dir.point;
                }
            } else if(Input.GetMouseButtonUp(0) && Input.GetKey(KeyCode.LeftShift)) {
                if(Physics.Raycast(ray, out RaycastHit dir, int.MaxValue, ~playerLayer)) {
                    if (animator.GetBool("Damage")) return;
                    moveDir = dir.point;
                } 
            }
        }
    }
}
