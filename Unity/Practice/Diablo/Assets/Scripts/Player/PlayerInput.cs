using UnityEngine;

namespace Player {
    public class PlayerInput : MonoBehaviour {
        public Vector3 moveDir { get; private set; }
        public RaycastHit targetPos { get; private set; }

        private Camera followCam;
        private TargetSelector targetSelector;
        
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private LayerMask enemyLayer;

        private void Start() {
            followCam = Camera.main;
        }
        
        private void Update() {
            if(Input.GetMouseButtonUp(0)) {
                Ray ray = followCam.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out RaycastHit target, int.MaxValue, enemyLayer)) {
                    targetPos = target;
                } else if(Physics.Raycast(ray, out RaycastHit dir, int.MaxValue, ~playerLayer)) {
                    moveDir = dir.point;
                }
            }
        }
    }
}
