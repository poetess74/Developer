using UnityEditor;
using UnityEngine;

public class ExitGame : MonoBehaviour {
    private void OnClickExit() {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
