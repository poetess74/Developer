using UnityEngine;

public class BasicLaserController : MonoBehaviour {
    private const float laserSpeed = 2.0f;
    private const float deadTime = 1.0f;

    private float spawnTime;

	private void Update () {
        transform.Translate(Vector3.forward * laserSpeed * Time.deltaTime);
        spawnTime = Time.deltaTime + spawnTime;

        if (spawnTime >= deadTime) {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter (Collision col) {
        Debug.Log(col);
        if (col.gameObject.tag == "Enemy") {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
