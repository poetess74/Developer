using System.Collections;
using UnityEngine;

namespace InGame.Player {
    public class PlayerInput : MonoBehaviour {
        public Vector3 moveDir { get; private set; }

        private Camera followCam;
        private TargetSelector targetSelector;
        private Animator animator;
        private float idlingTime;

        [SerializeField] private LayerMask characterLayer;

        private void Start() {
            followCam = Camera.main;
            animator = GetComponent<Animator>();
        }
        
        private void Update() {
            if(GamePlayManager.instance.isGameOver || GamePlayManager.instance.interrupt) return;
            
            Ray ray = followCam.ScreenPointToRay(Input.mousePosition);
            if(Input.GetMouseButtonUp(0)) {
                if(Physics.Raycast(ray, out RaycastHit dir, int.MaxValue, ~characterLayer)) {
                    if(animator.GetBool("Damage") || !dir.transform.CompareTag("Ground")) return;
                    moveDir = dir.point;
                }
            }
        }

        private void LateUpdate() {
            string[] idlingAnimClips = {"WAIT01", "WAIT02", "WAIT03", "WAIT04"};
            int idlingIndex = Random.Range(0, idlingAnimClips.Length);
            
            IEnumerator animController = Utility.animPlayOneShot(
                animator, idlingAnimClips[idlingIndex], "Rest", "IdleAnim", idlingIndex, true
            );
            
            idlingTime += Time.deltaTime;

            if(GamePlayManager.instance.interrupt || GamePlayManager.instance.isGameOver || 
               animator.GetFloat("Movement") > 0.1f || animator.GetBool("Damage")) {
                idlingTime = 0f;
                animator.SetBool("Rest", false);
                return;
            }
            
            if(idlingTime < 120f) return;
            idlingTime = 0f;
            StartCoroutine(animController);
        }
    }
}
