using UnityEngine;

public class Player_Physics2DAndMecanim : MonoBehaviour {
    public float speed = 12f;
    public float jumpPower = 1600f;

    public GameObject filter;

    private bool grounded;
    private bool goalCheck;
    private float goalTime;

	// Use this for initialization
	private void Start () {
        grounded = false;
        goalCheck = false;
	}
	
	// Update is called once per frame
	private void Update () {
        Transform groundCheck = transform.Find("GroundCheck");
        grounded = (Physics2D.OverlapPoint(groundCheck.position) != null) ? true : false;
        if (grounded) {
            if (Input.GetButtonDown("Fire1")) {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower));
            }
            GetComponent<Animator>().SetTrigger("Run");
        } else {
            GetComponent<Animator>().SetTrigger("Jump");
        }
        if (transform.position.y < -10f) {
            filter.SetActive(true);
            Application.LoadLevel(Application.loadedLevelName);
        }
	}

    private void FixedUpdate () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        GameObject goCam = GameObject.Find("Main Camera");
        goCam.transform.position = new Vector3(transform.position.x + 5f, goCam.transform.position.y, goCam.transform.position.z);
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if(collision.gameObject.name == "Stage_Gate") {
            goalCheck = true;
            goalTime = Time.timeSinceLevelLoad;
        } else if (collision.gameObject.tag == "Respawn") {
            filter.SetActive(true);
            Application.LoadLevel(Application.loadedLevelName);
        }
    }

    private void OnGUI () {
        GUI.TextField(new Rect(10, 10, 300, 60), "[Unity2D Sample 3-1 C]\n마우스 왼쪽 버튼을 누르면 점프");
        if (goalCheck) {
            GUI.TextField(new Rect(10, 100, 330, 60), string.Format("***Goal!***\nTime {0}", goalTime));
        }
        if (GUI.Button(new Rect(10, 80, 100, 20), "리셋!")) {
            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
