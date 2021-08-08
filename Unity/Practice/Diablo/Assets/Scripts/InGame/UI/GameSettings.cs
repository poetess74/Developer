using InGame.Player;
using UnityEngine;
using UnityEngine.UI;

namespace InGame.UI {
    public class GameSettings : MonoBehaviour {
        private MapCamMovement map;
        private PlayerInput input;

        private Toggle mapRotation;
        private Dropdown inputMethod;
        private void OnEnable() {
            GamePlayManager.instance.hardInterrupt = true;
            map = FindObjectOfType<MapCamMovement>();
            input = FindObjectOfType<PlayerInput>();
            mapRotation = transform.GetChild(2).gameObject.GetComponent<Toggle>();
            inputMethod = transform.GetChild(3).gameObject.GetComponent<Dropdown>();
        }

        private void OnDisable() {
            GamePlayManager.instance.hardInterrupt = false;
        }

        private void Update() {
            map.constRotate = mapRotation.isOn;
            if(inputMethod.value == 0) {
                input.axisController = false;
                input.moveDir = new Vector3(input.transform.position.x, 0, input.transform.position.z);
            } else {
                input.axisController = true;
                input.moveDir = Vector3.zero;
            }
        }
    }
}
