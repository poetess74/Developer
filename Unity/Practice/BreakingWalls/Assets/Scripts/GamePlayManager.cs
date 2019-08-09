using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour {
    public bool cheatBool = false;
    public float ballFireSpeed = 5f;
    public float ballVelocityIncPerBounce = 0.01f;

    private Text scoreLabel;
    private Transform blocksTrans;

    private bool stageClear = false;

	// Use this for initialization
	void Start () {
        scoreLabel = GameObject.Find("UI/Score").GetComponent<Text>();
        blocksTrans = GameObject.Find("Stage/Blocks").transform;
    }
	
	// Update is called once per frame
	void Update () {
        scoreLabel.text = PlayerState.score.ToString("D6");

        stageClear = (blocksTrans.childCount == 0);

        if (cheatBool && Input.GetMouseButtonDown(1)) {
            stageClear = true;
        }

        if (stageClear) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
