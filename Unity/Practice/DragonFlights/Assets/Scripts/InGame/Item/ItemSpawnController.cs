using UnityEngine;

public class ItemSpawnController : MonoBehaviour {
    [SerializeField] private GameObject dualshotPrefab;

    private float dualshotInterval = 15f;
    private float dualshotTimer = 0f;
	
	private void Update () {
        if (!GamePlayManager.dontSpawn) {
            dualshotTimer += Time.deltaTime;

            if (dualshotTimer >= dualshotInterval) {
                var pos = new Vector3(Random.Range(-3f, 3f), 6, 0);
                var item = Instantiate(dualshotPrefab, pos, Quaternion.identity);

                item.transform.parent = transform;

                dualshotTimer -= dualshotInterval;
                dualshotInterval = Random.Range(10f, 30f);
            }
        }
	}
}
