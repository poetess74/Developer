using UnityEngine;

namespace InGame.Player {
    public class MapCamMovement : MonoBehaviour {
        [HideInInspector] public bool manualControl;
        [HideInInspector] public bool constRotate = true;
        
        private GameObject player;
        private Vector3 spacer;
        
        private void Start() {
            player = GameObject.FindWithTag("Player");
            spacer = new Vector3(0, 25, 0);
        }

        private void Update() {
            if(manualControl) return;
            if(constRotate) {
                transform.position = player.transform.position + spacer;
                transform.rotation = Quaternion.Euler(90, 0, 0);
            } else {
                transform.position = player.transform.position + spacer;
                transform.rotation = Quaternion.Euler(
                    90, player.transform.eulerAngles.y, player.transform.eulerAngles.z
                );
            }
        }

        public void ResetPos(bool factoryReset, bool resetSpacer) {
            transform.position = player.transform.position + spacer;
            if(resetSpacer) {
                gameObject.GetComponent<Camera>().orthographicSize = 5f;
            }
            if(!factoryReset) return;
            manualControl = false;
        }
    }
}
