using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public GameObject Player;

    private float fireSpeed = 5f;
    private const float fireAngle = 75f;
    private bool fired = false;
    private Rigidbody2D rbody;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        if (GameObject.Find("GamePlayManager") != null) {
            fireSpeed = GameObject.Find("GamePlayManager").GetComponent<GamePlayManager>().ballFireSpeed;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (!fired && Input.GetMouseButtonDown(0)) {
            fired = true;

            float fireAngleRad = fireAngle * Mathf.Deg2Rad;
            float vx = fireSpeed * Mathf.Cos(fireAngleRad);
            float vy = fireSpeed * Mathf.Sin(fireAngleRad);

            rbody.velocity = new Vector2(vx, vy);
        }
	}
    void LateUpdate() {
        if (!fired) {
            Vector3 playerPos = Player.transform.position;
            Vector3 ballPos = transform.position;

            transform.position = new Vector3(playerPos.x, ballPos.y, ballPos.z);
        }
    }
    void OnCollisionEnter2D(Collision2D collider) {
        audioSource.Play();
    }
}
