using UnityEngine;

namespace Setting {
    public class EnvironmentAddressChecker : MonoBehaviour {
        private GameObject hostLable;
        private GameObject clientInput;
        private void Start() {
            clientInput = transform.GetChild(0).gameObject;
            hostLable = transform.GetChild(1).gameObject;
        }

        private void Update() {
            if(GameManager.instance.manageOption == GameManager.ManagerType.Disable) return;

            clientInput.SetActive(GameManager.instance.manageOption == GameManager.ManagerType.Client);
            hostLable.SetActive(GameManager.instance.manageOption == GameManager.ManagerType.Host);
        }
    }
}
