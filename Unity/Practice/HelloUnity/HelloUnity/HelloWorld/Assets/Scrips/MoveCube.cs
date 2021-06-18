using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour {

	public enum MoveDirection {
		MOVE_UP,
		MOVE_DOWN
	}
	public enum RotateDirection {
		ROTATE_LEFT,
		ROTATE_RIGHT
	}

	public float MoveSpeed;
	public MoveDirection moveDir;

	public float RotateSpeed;
	public RotateDirection rotateDir;

	void Start() {
		moveDir = MoveDirection.MOVE_UP;
		rotateDir = RotateDirection.ROTATE_RIGHT;
	}

	void FixedUpdate() {
		float moveSpeed = MoveSpeed;
		float rotateSpeed = RotateSpeed;

		if (moveDir == MoveDirection.MOVE_DOWN)
			moveSpeed = -moveSpeed;
		if (rotateDir == RotateDirection.ROTATE_RIGHT)
			rotateSpeed = -rotateSpeed;

		transform.Translate(0, moveSpeed, 0);
		transform.Rotate(0, 0, rotateSpeed);
	}
}
