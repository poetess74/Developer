using UnityEngine;
using UnityEngine.UI;

namespace Setting {
    public class CoachFormController : MonoBehaviour {
        [SerializeField] private GameObject movableObject;
        [SerializeField] private GameObject form;

        private void Start() {
            transform.GetComponent<Toggle>().isOn = GameManager.instance.manageOption;
        }

        private void Update() {
            GameManager.instance.manageOption = transform.GetComponent<Toggle>().isOn;

            form.SetActive(GameManager.instance.manageOption);
            movableObject.GetComponent<RectTransform>().anchoredPosition = GameManager.instance.manageOption ? new Vector3(0, 0, 0) : new Vector3(0, 100, 0);
        }
    }
}
