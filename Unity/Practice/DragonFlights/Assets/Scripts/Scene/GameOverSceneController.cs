using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverSceneController : MonoBehaviour {
    private void Start() {
        float dist = GamePlayManager.GetDistance();
        int score = GamePlayManager.GetScore();

        GameObject.Find("Canvas/dist").GetComponent<Text>().text = string.Format("{0} km", dist.ToString("N2"));
        GameObject.Find("Canvas/score").GetComponent<Text>().text = score.ToString("D7");
        GameObject.Find("Explosion").transform.position = GamePlayManager.playerPos;
    }

	private void Update () {
        if (Input.GetMouseButtonDown(0)) {
            GamePlayManager.Reset();
            SceneManager.LoadScene(1);
        }
	}
}
