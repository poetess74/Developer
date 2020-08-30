using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    [SerializeField] private GameObject upSpawnerPoint;
    [SerializeField] private GameObject downSpawnerPoint;
    [SerializeField] private GameObject upObstacleObject;
    [SerializeField] private GameObject downObstacleObject;
    [SerializeField] private float spawnTime;

    private GameObject activeUpObstacleObject;
    private GameObject activeDownObstacleObject;

    private void Start() {
        for(int i = 0; i < upObstacleObject.transform.childCount; i++) {
            upObstacleObject.transform.GetChild(i).gameObject.SetActive(false);
            downObstacleObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        int activeIndex = Random.Range(0, upObstacleObject.transform.childCount);
        activeUpObstacleObject = upObstacleObject.transform.GetChild(activeIndex).gameObject;
        activeDownObstacleObject = downObstacleObject.transform.GetChild(activeIndex).gameObject;
        activeUpObstacleObject.SetActive(true);
        activeDownObstacleObject.SetActive(true);
        StartCoroutine(Spawner());
    }

    private void Update() {
        if(GamePlayManager.isGameOver) StopCoroutine(Spawner());
    }

    private IEnumerator Spawner() {
        while(!GamePlayManager.isGameOver) {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(activeUpObstacleObject, new Vector2(upSpawnerPoint.transform.position.x, Random.Range(2f, 6f)), Quaternion.identity);
            Instantiate(activeDownObstacleObject, new Vector2(downSpawnerPoint.transform.position.x, Random.Range(-2f, -6f)), Quaternion.identity);
        }
    }
}
