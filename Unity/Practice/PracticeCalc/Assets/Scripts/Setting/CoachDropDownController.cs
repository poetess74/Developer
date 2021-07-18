using UnityEngine;
using UnityEngine.UI;

namespace Setting {
    public class CoachDropDownController : MonoBehaviour {
        [SerializeField] private GameObject movableObject;
        [SerializeField] private GameObject form;

        private void Start() {
            switch(GameManager.instance.manageOption) {
                case GameManager.ManagerType.Disable: transform.GetComponent<Dropdown>().value = 0; break;
                case GameManager.ManagerType.Host: transform.GetComponent<Dropdown>().value = 1; break;
                case GameManager.ManagerType.Client: transform.GetComponent<Dropdown>().value = 2; break;
            }
        }

        private void Update() {
            int value = transform.GetComponent<Dropdown>().value;

            form.SetActive(value != 0);
            movableObject.GetComponent<RectTransform>().anchoredPosition = value != 0 ? new Vector3(0, 0, 0) : new Vector3(0, 100, 0);

            switch(value) {
                case 0: GameManager.instance.manageOption = GameManager.ManagerType.Disable; break;
                case 1: GameManager.instance.manageOption = GameManager.ManagerType.Host; break;
                case 2: GameManager.instance.manageOption = GameManager.ManagerType.Client; break;
            }
        }
    }
}
