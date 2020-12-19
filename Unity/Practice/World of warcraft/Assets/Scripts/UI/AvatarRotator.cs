using UnityEngine;

public class AvatarRotator : MonoBehaviour {
    private float rotationSpeed = 50f;
    private void Update() {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
