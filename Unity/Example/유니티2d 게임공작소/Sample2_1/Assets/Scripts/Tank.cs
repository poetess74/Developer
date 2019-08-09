using UnityEngine;
using UnityEngine.SceneManagement;

public class Tank : MonoBehaviour {
    private Rigidbody2D rbody;

    private GameObject goShell;
    private bool action;

	// Use this for initialization
	private void Start () {
        rbody = GetComponent<Rigidbody2D>();
        goShell = transform.Find("Tank_Shell").gameObject;
        goShell.SetActive(false);
	}
	
	// Update is called once per frame
	private void Update () {
        if(Input.GetMouseButtonDown(0)) {
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D col = Physics2D.OverlapPoint(tapPoint);

            if (col && col.gameObject == gameObject) { action = true; }

            if (action) {
                rbody.AddForce(new Vector2(1000f, 0f)); 
            }

        } else if (Input.GetMouseButtonUp(0) && action) {
            if (goShell) {
                goShell.SetActive(true);
                goShell.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f, 700f));
                Destroy(goShell.gameObject, 3f);
            }
            action = false;
        }
	}

    private void OnGUI () {
        GUI.TextField(new Rect(10, 10, 300, 60),
                     "[Unity 2D Sample 2-1]\n" +
                     "탱크를 클릭하면 가속\n놓으면 발사!");
        if (GUI.Button(new Rect(10, 80, 100, 20), "RESTART")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}
