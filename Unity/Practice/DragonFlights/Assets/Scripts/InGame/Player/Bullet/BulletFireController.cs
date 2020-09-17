using UnityEngine;
using System.Collections.Generic;

public class BulletFireController : MonoBehaviour {
    [SerializeField] private GameObject[] bulletPrefabs;

    private float fireInterval = 0.05f;

    private Transform bulletSpawn;
    private float timer;

    private List<Vector2[]> fireOffsets = new List<Vector2[]>();

    private GameObject bulletParent;

    private void Start () {
        GamePlayManager.numberOfBulletTypes = bulletPrefabs.Length;

        fireOffsets.Add(new Vector2[] { 
            new Vector2(+0.00f, +0.00f) 
        }); // level 1
        fireOffsets.Add(new Vector2[] { 
            new Vector2(-0.09f, +0.00f), 
            new Vector2(+0.09f, +0.00f) 
        }); // level 2
        fireOffsets.Add(new Vector2[] { 
            new Vector2(-0.18f, -0.05f), 
            new Vector2(+0.00f, +0.00f),
            new Vector2(+0.18f, -0.05f) 
        }); // level 3
        fireOffsets.Add(new Vector2[] {
            new Vector2(-0.24f, -0.05f),
            new Vector2(-0.09f, +0.00f),
            new Vector2(+0.09f, +0.00f),
            new Vector2(+0.24f, -0.05f)
        }); // level 4
        fireOffsets.Add(new Vector2[] {
            new Vector2(-0.36f, -0.10f),
            new Vector2(-0.18f, -0.05f),
            new Vector2(+0.00f, +0.00f),
            new Vector2(+0.18f, -0.05f),
            new Vector2(+0.36f, -0.10f)
        }); // level 4
        bulletSpawn = transform.Find("Bullet_spawn");
        bulletParent = new GameObject("Bullets");
	}

	private void Update () {
        timer += Time.deltaTime;
        if (timer >= fireInterval) {
            int level = (GamePlayManager.fireLevel - 1) % fireOffsets.Count;
            int type = ((GamePlayManager.fireLevel - 1) / fireOffsets.Count) % GamePlayManager.numberOfBulletTypes;

            foreach (var offset in fireOffsets[level]) {
                var pos = bulletSpawn.position;
                pos.x += offset.x;
                pos.y += offset.y;
                var bullet = Instantiate(bulletPrefabs[type], pos, Quaternion.identity);
                bullet.transform.parent = bulletParent.transform;
            }
            timer -= fireInterval;
        }
	}
}
