using UnityEngine;

namespace Player {
    public class PlayerInput : MonoBehaviour {
        public Vector3 moveDir { get; private set; }

        private Camera followCam;
        private TargetSelector targetSelector;
        private Animator animator;

        [SerializeField] private LayerMask characterLayer;

        private void Start() {
            followCam = Camera.main;
            animator = GetComponent<Animator>();
        }
        
        private void Update() {
            if(GamePlayManager.instance.isGameOver) return;
            
            Ray ray = followCam.ScreenPointToRay(Input.mousePosition);
            if(Input.GetMouseButtonUp(0)) {
                if(Physics.Raycast(ray, out RaycastHit dir, int.MaxValue, ~characterLayer)) {
                    if(animator.GetBool("Damage") || !dir.transform.CompareTag("Ground")) return;
                    moveDir = dir.point;
                }
            }
        }
    }
}
