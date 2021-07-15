using UnityEngine;
using UnityEngine.UI;

namespace Setting {
    public class CreateQuestionCount : MonoBehaviour {
        [HideInInspector] public Toggle random;
        [HideInInspector] public InputField count;

        private void Start() {
            random = transform.GetChild(1).GetComponent<Toggle>();
            count = transform.GetChild(2).GetComponent<InputField>();
            count.text = GameManager.instance.providedQuestionCount.ToString();
        }

        private void Update() {
            if(random.isOn) {
                count.gameObject.SetActive(false);
            } else {
                count.gameObject.SetActive(true);

                if(count.text.Length == 0) return;
                GameManager.instance.providedQuestionCount = int.Parse(count.text);
            }
        }
    }
}
