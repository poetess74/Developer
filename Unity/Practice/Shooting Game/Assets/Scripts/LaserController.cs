using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {
	public float _speed = 5f;

	// Update is called once per frame
	void Update () {
		transform.position += Vector3.up* _speed * Time.deltaTime;
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag != "Player") {
			Destroy(gameObject);
		}
	}
}
