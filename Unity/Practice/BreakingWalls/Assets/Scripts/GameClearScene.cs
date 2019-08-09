using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClearScene : MonoBehaviour {
    public Text scoreLabel;

	// Use this for initialization
	void Start () {
        scoreLabel.text = "YOUR SCORE IS : " + PlayerState.score.ToString();
        PlayerState.Reset();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("Start");
        }
    }
}
