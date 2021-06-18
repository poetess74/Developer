using UnityEngine;

public class EnemyBulletFireController : MonoBehaviour {
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] bulletSpawns;
    [SerializeField] private float fireInterval = 2.10f;

    private float timer;

    private GameObject bulletParent;

    private void Start () {
        bulletParent = new GameObject("Enemy_Bullets");
	}

	private void Update () {
        timer += Time.deltaTime;

        if (timer >= fireInterval) {
            foreach (var spawn in bulletSpawns) {
                var bullet = Instantiate(bulletPrefab, spawn.position, spawn.rotation);
                bullet.transform.parent = bulletParent.transform;
            }
            timer -= fireInterval;
        }
	}
}
