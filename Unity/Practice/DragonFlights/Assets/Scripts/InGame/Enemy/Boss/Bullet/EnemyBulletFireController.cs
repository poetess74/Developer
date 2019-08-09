using UnityEngine;

public class EnemyBulletFireController : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform[] bulletSpawns;
    public float fireInterval = 2.10f;

    private float timer = 0f;

    private GameObject bulletParent;

    private void Start () {
        this.bulletParent = new GameObject("Enemy_Bullets");
	}

	private void Update () {
        this.timer += Time.deltaTime;

        if (this.timer >= this.fireInterval) {
            foreach (var spawn in this.bulletSpawns) {
                var bullet = Instantiate(this.bulletPrefab, spawn.position, spawn.rotation);
                bullet.transform.parent = this.bulletParent.transform;
            }
            this.timer -= this.fireInterval;
        }
	}
}
