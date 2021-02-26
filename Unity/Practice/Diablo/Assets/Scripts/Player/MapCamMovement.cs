using UnityEngine;

namespace Player {
    public class MapCamMovement : MonoBehaviour {
        [HideInInspector] public bool manualControl;
        public bool constRotate = true;
        
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
            if(resetSpacer) {
                transform.position = player.transform.position + spacer;
            } else {
                transform.position = new Vector3(
                    player.transform.position.x, transform.position.y, player.transform.position.z
                );
            }
            if(!factoryReset) return;
            manualControl = false;
        }
    }
}