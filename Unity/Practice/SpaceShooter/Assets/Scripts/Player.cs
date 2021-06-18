using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public const int MaxLife = 3;

	public float _speed = 1f;
	public float _cooldownTime = 1f;

	private int _currentLife = 3;
	public int CurrentLife {
		get { return _currentLife; }
	}

	public GameObject _laserPrefab;

	public Transform _frontLaserSpawn;
	public Transform _leftWingLaserSpawn;
	public Transform _rightWingLaserSpawn;

	public Transform _projectilesRoot;

	private float _cooldownTimer;

	void Start() {
		_cooldownTimer = 0f;
	}

	void Update() {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * _speed * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * _speed * Time.deltaTime;
		}

		_cooldownTimer -= Time.deltaTime;
		if (Input.GetKeyDown(KeyCode.Space) && _cooldownTimer <= 0f) {
			var projectile = Instantiate(_laserPrefab, _frontLaserSpawn.position, Quaternion.identity);
			projectile.transform.parent = _projectilesRoot;
			_cooldownTimer = _cooldownTime;
		}

		var pos = transform.position;
		pos.x = Mathf.Clamp(pos.x, -3.4f, 3.4f);

		transform.position = pos;
	}
}
