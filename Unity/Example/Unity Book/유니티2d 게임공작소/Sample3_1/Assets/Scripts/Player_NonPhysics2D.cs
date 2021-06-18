using UnityEngine;

public class Player_NonPhysics2D : MonoBehaviour {

    public float speed = 15f;
    public Sprite[] run;
    public Sprite jump;

    public GameObject filter;

    private float jumpVy;
    private int animIndex;
    private bool goalCheck;

	// Use this for initialization
	private void Start () {
        jumpVy = 0f;
        animIndex = 0;
        goalCheck = false;
	}
	
	// Update is called once per frame
	private void Update () {
		if (goalCheck) {
            return;
        }
        float height = transform.position.y + jumpVy;
        if (height <= 0f) {
            height = 0f;
            jumpVy = 0f;
            if (Input.GetButtonDown("Fire1")) {
                jumpVy += 1.3f;
                GetComponent<SpriteRenderer>().sprite = jump;
            } else {
                animIndex++;
                if (animIndex >= run.Length) {
                    animIndex = 0;
                }
                GetComponent<SpriteRenderer>().sprite = run[animIndex];
            }
        } else {
            jumpVy -= 6.0f * Time.deltaTime;
        }

        transform.position += new Vector3(speed * Time.deltaTime, jumpVy, 0f);
        GameObject goCam = GameObject.Find("Main Camera");
        goCam.transform.Translate(speed * Time.deltaTime, 0f, 0f);
	}

    private void OnGUI () {
        GUI.TextField(new Rect(10, 10, 300, 60), "[Unity2D Sample 3-1 A]\n마우스 왼쪽 버튼을 누르면 가속\n놓으면 점프!\n");
        if (GUI.Button(new Rect(10, 80, 100, 20), "리셋")) {
            Application.LoadLevel(Application.loadedLevelName);
        }
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.name == "Stage_Gate") {
            goalCheck = true;
            return;
        } else {
            filter.SetActive(true);
            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
