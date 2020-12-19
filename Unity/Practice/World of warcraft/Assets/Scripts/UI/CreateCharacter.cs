using UnityEngine;
using UnityEngine.UI;

public class CreateCharacter : MonoBehaviour {
    [SerializeField] private InputField charName;
    [SerializeField] private Dropdown job;

    private void OnClick() {
        charName.text = "";
        job.value = 0;
    }
}
