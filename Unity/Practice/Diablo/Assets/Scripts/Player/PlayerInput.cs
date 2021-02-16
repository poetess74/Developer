using UnityEngine;

namespace Player {
    public class PlayerInput : MonoBehaviour {
        public Vector3 moveDir { get; private set; }
        public GameObject target { get; private set; }

        private Camera followCam;
        private TargetSelector targetSelector;
        private Animator animator;

        [SerializeField] private float maximumGetIDTarget;
        [SerializeField] private LayerMask characterLayer;
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private LayerMask enemyLayer;

        private void Start() {
            followCam = Camera.main;
            animator = GetComponent<Animator>();
        }
        
        private void Update() {
            if(GamePlayManager.instance.isGameOver) return;
            
            Ray ray = followCam.ScreenPointToRay(Input.mousePosition);
            if(Input.GetMouseButtonUp(0) && Input.GetKey(KeyCode.LeftShift)) {
                if(Physics.Raycast(ray, out RaycastHit dir, int.MaxValue, ~playerLayer)) {
                    if (animator.GetBool("Damage") || dir.transform.CompareTag("Wall")) return;
                    moveDir = dir.point;
                } 
            } else if(Input.GetMouseButtonUp(0)) {
                if(Physics.Raycast(ray, out RaycastHit target, int.MaxValue, enemyLayer)) {
                    this.target = target.transform.gameObject;
                } else if(Physics.Raycast(ray, out RaycastHit dir, int.MaxValue, ~characterLayer)) {
                    if(animator.GetBool("Damage") || !dir.transform.CompareTag("Ground")) return;
                    moveDir = dir.point;
                }
            }
        }

        private void LateUpdate() {
            if(target == null) return;
            if(Vector3.Distance(target.transform.position, transform.position) > maximumGetIDTarget) {
                target = null;
            }
        }
    }
}
