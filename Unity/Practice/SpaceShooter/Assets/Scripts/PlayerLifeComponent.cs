using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeComponent : MonoBehaviour {
	private const float SCALE_FACTOR = 0.009765625f;

	public Player _player;

	private List<GameObject> _icons;
	private int _lastPlayerLife;

	void Start() {
		_icons = new List<GameObject>();

		var lifeIcon = transform.Find("Template").gameObject;

		for (int i = 0; i < Player.MaxLife; i++) {
			var icon = Instantiate(lifeIcon, transform);
			icon.transform.position += Vector3.left * i * 45f * SCALE_FACTOR;
			icon.name = i.ToString();
			icon.SetActive(true);
			_icons.Add(icon);
		}

		_lastPlayerLife = -1;
	}

	void Update() {
		if (_lastPlayerLife != _player.CurrentLife) {
			for (int i = 0; i < Player.MaxLife; i++) {
				_icons[i].SetActive(i < _player.CurrentLife);
			}
			_lastPlayerLife = _player.CurrentLife;
		}
	}
}
