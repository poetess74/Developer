using UnityEngine;

namespace Practice {
    public class KeyPadSwap : MonoBehaviour {
        [SerializeField] private GameObject keyPad;
        [SerializeField] private GameObject controller;

        private QuestionStatus status;

        private void Start() {
            status = FindObjectOfType<QuestionStatus>();
        }

        private void Update() {
            if(status.maxAnswerCountReached) {
                keyPad.SetActive(false);
                controller.SetActive(true);
            } else {
                keyPad.SetActive(true);
                controller.SetActive(false);
            }
        }
    }
}
