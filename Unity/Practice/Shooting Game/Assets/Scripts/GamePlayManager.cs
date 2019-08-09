using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour {
	public bool cheatBool = false;

	private Text scoreLabel;
	private Text slotLable;
	private Text eHPLable;

	//private bool stageClear = false;

	// Use this for initialization
	void Start () {
		scoreLabel = GameObject.Find("UI/ScoreLable").GetComponent<Text>();
		slotLable = GameObject.Find("UI/SlotLable").GetComponent<Text>();
		eHPLable = GameObject.Find("UI/e-HPLable").GetComponent<Text>();
		}
	
	// Update is called once per frame
	void Update () {
		scoreLabel.text = PlayerState.score.ToString("D6");
		slotLable.text = PlayerState.slot.ToString("D6");
		eHPLable.text = PlayerState.eHP.ToString("D6");
		//stageClear = (Enemy.eScore <= 0);
		if (PlayerState.score == 65000) {
			PlayerState.score *= PlayerState.score;
		} else if (PlayerState.score == 0 && PlayerState.slot == 0) {
			PlayerState.score = 1300;
		}
		/*
		if (cheatBool && Input.GetMouseButtonDown(1)) {
			stageClear = true;
		}
		if (stageClear) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		*/
	}
	void LateUpdate() {
		int _bool = 0;
		if (cheatBool == true) {
			_bool = 1;
		} else {
			_bool = 0;
		}
		print("GPM : " + _bool);	
	}
}
