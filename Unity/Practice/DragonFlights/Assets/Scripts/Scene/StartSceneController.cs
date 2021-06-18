using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour {
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(1);
        }
    }
}
