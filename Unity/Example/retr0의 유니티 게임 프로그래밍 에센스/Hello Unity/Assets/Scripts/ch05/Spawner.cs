using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject target;
    // Start is called before the first frame update
    private void Start() {
        GameObject instance = Instantiate(target, spawnPoint.position, spawnPoint.rotation);
        instance.GetComponent<Rigidbody>().AddForce(0, 1000, 0);
        Debug.Log(instance.name);
    }
}
