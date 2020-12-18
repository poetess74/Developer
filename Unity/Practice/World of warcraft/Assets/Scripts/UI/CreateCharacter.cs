using UnityEngine;
using UnityEngine.UI;

public class CreateCharacter : MonoBehaviour {
    [SerializeField] private Text charName;
    [SerializeField] private Dropdown job;

    private void OnClickEnter() {
        charName.text = "";
        job.value = 0;
    }
}
