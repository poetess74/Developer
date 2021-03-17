using InGame.Player;
using UnityEngine;
using UnityEngine.UI;

namespace InGame.UI {
    public class GameSettings : MonoBehaviour {
        private MapCamMovement map;

        private Toggle mapRotation;
        private void OnEnable() {
            map = FindObjectOfType<MapCamMovement>();
            mapRotation = transform.GetChild(2).gameObject.GetComponent<Toggle>();
        }

        private void Update() {
            map.constRotate = mapRotation.isOn;
        }
    }
}
