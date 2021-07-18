using UnityEngine;

namespace Setting {
    public class EnvironmentAddressChecker : MonoBehaviour {
        private GameObject clientInput;
        private void Start() {
            clientInput = transform.GetChild(0).gameObject;
        }

        private void Update() {
            if(!GameManager.instance.manageOption) return;

            clientInput.SetActive(GameManager.instance.manageOption);
        }
    }
}
