using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultViewer : MonoBehaviour {
     public void RestartGame() {
         GamePlayManager.Reset();
         SceneManager.LoadScene(1);
     }
}
