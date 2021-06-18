using UnityEngine;

public class BasicLaserController : MonoBehaviour {
    private const float laserSpeed = 2.0f;
    private const float deadTime = 5.0f;

    private const int dmageAmount = 5;

    private float spawnTime;

	private void Update () {
        transform.Translate(Vector3.forward * laserSpeed * Time.deltaTime);
        spawnTime = Time.deltaTime + spawnTime;

        if (spawnTime >= deadTime) {
            Destroy(gameObject);
        }
	}

    public static int ReturnDamage() {
        return dmageAmount;
    }

    private void OnCollisionEnter (Collision col) {
        Debug.Log(gameObject.name + " collision by " + col.gameObject.name + ". (tag: " + col.gameObject.tag + ")");
        switch (col.gameObject.tag) {
            case "Player":
                break;
            case "Weapon":
                break;
            default:
                Destroy(gameObject);
                break;
        }
    }
}
