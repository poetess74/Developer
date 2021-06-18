using UnityEngine;

public class Core : MonoBehaviour {
    private Rigidbody2D rbody;

	// Use this for initialization
	private void Start () {
		rbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	private void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "Tank_Shell") {
			Debug.Log("Hit!");
			transform.localScale += new Vector3(1f, 1f, 1f);
			rbody.AddForce(new Vector2(1000f, -1000f));
		}
	}
}
