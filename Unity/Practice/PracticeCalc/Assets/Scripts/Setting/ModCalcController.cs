using UnityEngine;
using UnityEngine.UI;

namespace Setting {
    public class ModCalcController : MonoBehaviour {
        private void Start() {
            transform.GetComponent<Toggle>().isOn = GameManager.instance.modCalc;
        }

        private void Update() {
            GameManager.instance.modCalc = transform.GetComponent<Toggle>().isOn;
        }
    }
}
