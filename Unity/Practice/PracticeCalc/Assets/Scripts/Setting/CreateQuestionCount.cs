using UnityEngine;
using UnityEngine.UI;

namespace Setting {
    public class CreateQuestionCount : MonoBehaviour {
        [HideInInspector] public Toggle random;
        [HideInInspector] public InputField count;
        [HideInInspector] public Text info;

        private void Start() {
            random = transform.GetChild(1).GetComponent<Toggle>();
            count = transform.GetChild(2).GetComponent<InputField>();
            info = transform.GetChild(3).GetComponent<Text>();

            count.text = GameManager.instance.providedQuestionCount.ToString();
        }

        private void Update() {
            if(random.isOn) {
                count.gameObject.SetActive(false);
                info.gameObject.SetActive(true);
            } else {
                count.gameObject.SetActive(true);
                info.gameObject.SetActive(false);

                if(count.text.Length == 0) return;
                if(int.Parse(count.text) > 100) {
                    GameManager.instance.providedQuestionCount = 100;
                    count.text = "100";
                } else if(int.Parse(count.text) < 1){
                    GameManager.instance.providedQuestionCount = 1;
                    count.text = "1";
                } else {
                    GameManager.instance.providedQuestionCount = int.Parse(count.text);
                }
            }
        }
    }
}
