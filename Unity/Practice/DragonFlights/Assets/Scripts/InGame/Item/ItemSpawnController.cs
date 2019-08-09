using UnityEngine;

public class ItemSpawnController : MonoBehaviour {
    public GameObject dualshotPrefab;

    private float dualshotInterval = 15f;
    private float dualshotTimer = 0f;
	
	void Update () {
        if (!GamePlayManager.dontSpawn) {
            this.dualshotTimer += Time.deltaTime;

            if (this.dualshotTimer >= this.dualshotInterval) {
                var pos = new Vector3(Random.Range(-3f, 3f), 6, 0);
                var item = Instantiate(dualshotPrefab, pos, Quaternion.identity);

                item.transform.parent = this.transform;

                this.dualshotTimer -= this.dualshotInterval;
                this.dualshotInterval = Random.Range(10f, 30f);
            }
        }
	}
}
