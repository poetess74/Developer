using UnityEngine;

public class ArrowController : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        this.player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, -0.1f, 0);

        if (transform.position.y < -5f) {
            Destroy(gameObject);
        }

        Vector2 arrow = transform.position;
        Vector2 player = this.player.transform.position;
        Vector2 dir = arrow - player;

        float d = dir.magnitude;
        float arrowpi = 0.5f;
        float playerpi = 1.0f;

        if (d < arrowpi + playerpi) {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            Destroy(gameObject);
        }
	}
}
