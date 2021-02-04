using UnityEngine;

namespace Player {
    public class PlayerInput : MonoBehaviour {
        public Vector3 targetPos { get; private set; }

        private Camera followCam;

        private void Start() {
            followCam = Camera.main;
        }
        
        private void Update() {
            if(Input.GetMouseButtonUp(0)) {
                Ray ray = followCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit, int.MaxValue)) {
                    targetPos = hit.point;
                }
            }
        }
    }
}
