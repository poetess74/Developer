using UnityEngine;

public class PrintInputField : MonoBehaviour {
    public void OnInputFieldTextChanged(string input) {
        Debug.LogFormat("타이핑 하는 중!\n{0}", input);
    }

    public void OnInputFieldTextDone(string input) {
        Debug.LogFormat("타이핑 완료!\n{0}", input);
    }
}
