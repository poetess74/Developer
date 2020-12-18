using UnityEngine;
using UnityEngine.UI;

public class CreateCharacter : MonoBehaviour {
    [SerializeField] private InputField charName;
    [SerializeField] private Dropdown job;

    private void Awake() {
        charName = GetComponent<InputField>();
    }

    private void OnClick() {
        charName.text = "";
        job.value = 0;
    }
}
