using UnityEngine;

public class Player : MonoBehaviour {
	public const int MaxLife = 3;

	public float _speed = 3f;
	public float _cooldownTime = 0.5f;

	public int _slot = 50;
	private int _currentLife = 3;
	public int CurrentLife {
		get { return _currentLife; }
	}
	public GameObject _laserPrefab;

	public Transform _frontLaserSpawn;

	public Transform _profectilesRoot;
	private float _cooldownTimer;

	// Use this for initialization
	void Start() {
        _cooldownTimer = 0f;
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * _speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * _speed * Time.deltaTime;
		}
		if (PlayerState.eHP > 0 && PlayerState.cheatBool == false) {
			_cooldownTimer -= Time.deltaTime;
		}
		if (PlayerState.cheatBool == true && Input.GetKeyDown(KeyCode.Space) && _slot > 0) {
			var projectile = Instantiate(_laserPrefab, _frontLaserSpawn.position, Quaternion.identity);
			projectile.transform.parent = _profectilesRoot;
			_slot--;
			PlayerState.slot = _slot;
		}
		if (PlayerState.cheatBool == false && Input.GetKeyDown(KeyCode.Space) && _cooldownTimer <= 0f && _slot > 0) {
			var projectile = Instantiate(_laserPrefab, _frontLaserSpawn.position, Quaternion.identity);
			projectile.transform.parent = _profectilesRoot;
			_cooldownTimer = _cooldownTime;
			_slot--;
			PlayerState.slot = _slot;
		}
		if (PlayerState.eHP <= 0) {
			_cooldownTimer = 100;
		}
		var pos = transform.position;
		pos.x = Mathf.Clamp(pos.x, -3.4f, 3.4f);
		transform.position = pos;
	}
}