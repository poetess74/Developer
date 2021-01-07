using System.Collections.Generic;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour {
    [SerializeField] private GameObject[] propPrefabs;
    [SerializeField] private int count = 100;
    
    private BoxCollider area;
    private List<GameObject> props = new List<GameObject>();
    
    private void Start() {
        area = GetComponent<BoxCollider>();
        for(int i = 0; i < count; i++) {
            Spawner();
        }

        area.enabled = false;
    }

    private void Spawner() {
        int selection = Random.Range(0, propPrefabs.Length);
        GameObject selectedPrefab = propPrefabs[selection];
        Vector3 spawnPos = GetRandomPos();
        props.Add(Instantiate(selectedPrefab, spawnPos, Quaternion.identity));
    }

    private Vector3 GetRandomPos() {
        Vector3 basePos = transform.position;
        Vector3 size = area.size;

        float posX = basePos.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePos.y + Random.Range(-size.y / 2f, size.y / 2f);
        float posZ = basePos.z + Random.Range(-size.z / 2f, size.z / 2f);

        return new Vector3(posX, posY, posZ);
    }

    public void Reset() {
        foreach(var prop in props) {
            prop.transform.position = GetRandomPos();
            prop.SetActive(true);
        }
    }
}
