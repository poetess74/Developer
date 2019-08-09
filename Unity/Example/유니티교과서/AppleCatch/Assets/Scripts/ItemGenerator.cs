using UnityEngine;

public class ItemGenerator : MonoBehaviour {
    public GameObject applePrefab;
    public GameObject bombPrefab;

    private float spawnInterval = 1f;
    private float time;
    private int ratio = 2;
    private float speed = -0.03f;
	
	// Update is called once per frame
	private void Update () {
        this.time += Time.deltaTime;
        if (this.time > spawnInterval) {
            this.time = 0;
            GameObject item;
            int dice = Random.Range(1, 11);
            if (dice <= ratio) {
                item = Instantiate(bombPrefab) as GameObject;
            } else {
                item = Instantiate(applePrefab) as GameObject;
            }
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropSpeed = this.speed;
        }
	}

    public void SetParameter(float spawn, float speed, int ratio) {
        this.spawnInterval = spawn;
        this.speed = speed;
        this.ratio = ratio;
    }
}
