using UnityEngine;
using System.Collections;

public class GameMain : MonoBehaviour {
	public GameObject background;
	public GameObject gameOver;

	public GameObject tilePrefab;

	private bool gameWasOver = false;

	private Tile[,] tiles = new Tile[4, 4];

	// Use this for initialization
	void Start() {
		float xp = 0;
		float yp = 0;

		for (int y = 0; y < 4; y++) {
			for (int x = 0; x < 4; x++) {
				xp =  x * 110 - 166;
				yp = -y * 110 + 166;

				GameObject tile = Instantiate(tilePrefab);

				tile.transform.position = new Vector3(xp, yp, 0) + background.transform.position;
				tile.transform.SetParent(background.transform);
				tile.name = string.Format("{0}{1}", x, y);

				tiles[x, y] = tile.GetComponent<Tile>();
			}
		}

		resetStage();
	}

	private bool isNoEmptySlot() {
		bool noEmptySlot = true;

		for (int x = 0; x < 4; x++) {
			for (int y = 0; y < 4; y++) {
				if (tiles[x, y].Number == 0) {
					noEmptySlot = false;
					goto OUT_OF_LOOP;
				}
			}
		}

		OUT_OF_LOOP:
		return noEmptySlot;
	}

	private void GenerateNewNumber() {
		if (isNoEmptySlot()) {
			return;
		}

		int x = Random.Range(0, 4);
		int y = Random.Range(0, 4);

		while (tiles[x, y].Number != 0) {
			x = Random.Range(0, 4);
			y = Random.Range(0, 4);
		}

		if (Random.Range(0, 10) == 0) {
			tiles[x, y].Number = 4;
		} else {
			tiles[x, y].Number = 2;
		}

		if (isGameOver()) {
			gameWasOver = true;
			gameOver.SetActive(true);
		}
	}

	// Update is called once per frame
	void Update() {
		if (!gameWasOver) {
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				MoveUp();
			} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
				MoveDown();
			} else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
				MoveLeft();
			} else if (Input.GetKeyDown(KeyCode.RightArrow)) {
				MoveRight();
			}
		}
	}

	private bool MoveUp(bool testOnly = false) {
		bool canMove = false;
		int[] numbers = new int[4];

		for (int x = 0; x < 4; x++) {
			for (int y = 0; y < 4; y++) {
				numbers[y] = tiles[x, y].Number;
			}

			canMove |= collapse(numbers, testOnly);

			if (!testOnly) {
				for (int y = 0; y < 4; y++) {
					tiles[x, y].Number = numbers[y];
				}
			}
		}

		if (testOnly) {
			return canMove;
		}

		GenerateNewNumber();

		return true;
	}

	private bool MoveDown(bool testOnly = false) {
		bool canMove = false;
		int[] numbers = new int[4];

		for (int x = 0; x < 4; x++) {
			for (int y = 0; y < 4; y++) {
				numbers[y] = tiles[x, 3 - y].Number;
			}

			canMove |= collapse(numbers, testOnly);

			if (!testOnly) {
				for (int y = 0; y < 4; y++) {
					tiles[x, 3 - y].Number = numbers[y];
				}
			}
		}

		if (testOnly) {
			return canMove;
		}

		GenerateNewNumber();

		return true;
	}

	private bool MoveLeft(bool testOnly = false) {
		bool canMove = false;
		int[] numbers = new int[4];

		for (int y = 0; y < 4; y++) {
			for (int x = 0; x < 4; x++) {
				numbers[x] = tiles[x, y].Number;
			}

			canMove |= collapse(numbers, testOnly);

			if (!testOnly) {
				for (int x = 0; x < 4; x++) {
					tiles[x, y].Number = numbers[x];
				}
			}
		}

		if (testOnly) {
			return canMove;
		}

		GenerateNewNumber();

		return true;
	}

	private bool MoveRight(bool testOnly = false) {
		bool canMove = false;
		int[] numbers = new int[4];

		for (int y = 0; y < 4; y++) {
			for (int x = 0; x < 4; x++) {
				numbers[x] = tiles[3 - x, y].Number;
			}

			canMove |= collapse(numbers, testOnly);

			if (!testOnly) {
				for (int x = 0; x < 4; x++) {
					tiles[3 - x, y].Number = numbers[x];
				}
			}
		}

		if (testOnly) {
			return canMove;
		}

		GenerateNewNumber();

		return true;
	}

	private bool collapse(int[] numbers, bool testOnly) {
		bool canMove = false;

		for (int i = 0; i < numbers.Length - 1; i++) {
			if (numbers[i] != 0) {
				for (int k = i + 1; k < numbers.Length; k++) {
					if (numbers[k] != 0 && numbers[i] != numbers[k]) {
						break;
					} else if (numbers[i] == numbers[k]) {
						numbers[i] *= 2;
						numbers[k] = 0;
						canMove = true;
						break;
					}
				}
			}
		}

		if (testOnly) {
			return canMove;
		}

		for (int i = 0; i < numbers.Length - 1; i++) {
			if (numbers[i] == 0) {
				for (int k = i + 1; k < numbers.Length; k++) {
					if (numbers[k] != 0) {
						numbers[i] = numbers[k];
						numbers[k] = 0;
						break;
					}
				}
			}
		}

		return true;
	}

	private bool isGameOver() {
		return !MoveUp(true) && !MoveDown(true) && !MoveLeft(true) && !MoveRight(true) && isNoEmptySlot();
	}

	public void Replay() {
		gameWasOver = false;
		gameOver.SetActive(false);
		resetStage();
	}

	private void resetStage() {
		for (int y = 0; y < 4; y++) {
			for (int x = 0; x < 4; x++) {
				tiles[x, y].Number = 0;
			}
		}

		GenerateNewNumber();
		GenerateNewNumber();
	}
}
