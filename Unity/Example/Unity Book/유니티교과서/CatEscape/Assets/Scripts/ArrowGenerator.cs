using UnityEngine;

public class ArrowGenerator : MonoBehaviour {
    public GameObject arrowPrefab;
    private const float spawn = 1f;
    private float time;

	// Update is called once per frame
	void Update () {
        this.time += Time.deltaTime;
        if (this.time > spawn) {
            this.time = 0;
            GameObject go = Instantiate(arrowPrefab) as GameObject;
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector2(px, 7);
        }
	}
}
