using UnityEngine;
using UnityEngine.UI;

namespace Setting {
    public class CoachDropDownController : MonoBehaviour {
        [SerializeField] private GameObject movableObject;
        [SerializeField] private GameObject form;

        private void Update() {
            form.SetActive(transform.GetComponent<Dropdown>().value != 0);
            movableObject.GetComponent<RectTransform>().anchoredPosition = transform.GetComponent<Dropdown>().value != 0 ? new Vector3(0, 0, 0) : new Vector3(0, 100, 0);
        }
    }
}
