using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public int _eHP = 25;
	public int _eScore = 500;
	public GameObject _explosion;

	void OnTriggerEnter2D(Collider2D col) {
		Instantiate(_explosion, transform.position, Quaternion.identity);
		PlayerState.eHP--;
		_eHP--;
		PlayerState.score += 100;
		if (_eHP <= 0) {
			PlayerState.score += _eScore;
			PlayerState.score *= PlayerState.slot;
			PlayerState.slot = 0;
			Destroy(gameObject);
		}
	}
}
