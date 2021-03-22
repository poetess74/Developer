using UnityEngine;
using UnityEngine.SceneManagement;

namespace Intro {
    public class StartGame : MonoBehaviour {
        private void Update() {
            if(Input.GetMouseButtonDown(0)) {
                SceneManager.LoadScene("Lobby");
            }
        }
    }
}
