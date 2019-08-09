using UnityEngine;
using System.Collections.Generic;

public class BulletFireController : MonoBehaviour {
    public GameObject[] bulletPrefabs;

    public float fireInterval = 0.05f;

    private Transform bulletSpawn;
    private float timer = 0f;

    private List<Vector2[]> fireOffsets = new List<Vector2[]>();

    private GameObject bulletParent;

    private void Start () {
        GamePlayManager.numberOfBulletTypes = bulletPrefabs.Length;

        this.fireOffsets.Add(new Vector2[] { 
            new Vector2(+0.00f, +0.00f) 
        }); // level 1
        this.fireOffsets.Add(new Vector2[] { 
            new Vector2(-0.09f, +0.00f), 
            new Vector2(+0.09f, +0.00f) 
        }); // level 2
        this.fireOffsets.Add(new Vector2[] { 
            new Vector2(-0.18f, -0.05f), 
            new Vector2(+0.00f, +0.00f),
            new Vector2(+0.18f, -0.05f) 
        }); // level 3
        this.fireOffsets.Add(new Vector2[] {
            new Vector2(-0.24f, -0.05f),
            new Vector2(-0.09f, +0.00f),
            new Vector2(+0.09f, +0.00f),
            new Vector2(+0.24f, -0.05f)
        }); // level 4
        this.fireOffsets.Add(new Vector2[] {
            new Vector2(-0.36f, -0.10f),
            new Vector2(-0.18f, -0.05f),
            new Vector2(+0.00f, +0.00f),
            new Vector2(+0.18f, -0.05f),
            new Vector2(+0.36f, -0.10f)
        }); // level 4
        this.bulletSpawn = this.transform.Find("Bullet_spawn");
        this.bulletParent = new GameObject("Bullets");
	}

	private void Update () {
        this.timer += Time.deltaTime;
        if (this.timer >= this.fireInterval) {
            int level = (GamePlayManager.fireLevel - 1) % this.fireOffsets.Count;
            int type = ((GamePlayManager.fireLevel - 1) / this.fireOffsets.Count) % GamePlayManager.numberOfBulletTypes;

            foreach (var offset in this.fireOffsets[level]) {
                var pos = this.bulletSpawn.position;
                pos.x += offset.x;
                pos.y += offset.y;
                var bullet = Instantiate(this.bulletPrefabs[type], pos, Quaternion.identity);
                bullet.transform.parent = this.bulletParent.transform;
            }
            this.timer -= this.fireInterval;
        }
	}
}
