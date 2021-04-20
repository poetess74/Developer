using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public GameObject _explosion;

	void OnTriggerEnter2D(Collider2D col) {
		Instantiate(_explosion, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
