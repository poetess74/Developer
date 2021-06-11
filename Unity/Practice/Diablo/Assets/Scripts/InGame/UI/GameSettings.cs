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
            GamePlayManager.instance.interrupt = true;
            map = FindObjectOfType<MapCamMovement>();
            input = FindObjectOfType<PlayerInput>();
            mapRotation = transform.GetChild(2).gameObject.GetComponent<Toggle>();
            inputMethod = transform.GetChild(3).gameObject.GetComponent<Dropdown>();
        }

        private void OnDisable() {
            GamePlayManager.instance.interrupt = false;
        }

        private void Update() {
            map.constRotate = mapRotation.isOn;
            input.axisController = inputMethod.value != 0;
        }
    }
}
