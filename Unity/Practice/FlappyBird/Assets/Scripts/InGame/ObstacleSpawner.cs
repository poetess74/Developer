using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    [SerializeField] private List<GameObject> obstacleObject;
    [SerializeField] private float spawnTime;

    private GameObject activeObstacleObject;

    private void Start() {
        foreach(var obj in obstacleObject) {
            obj.SetActive(false);
        }
        int activeIndex = Random.Range(0, obstacleObject.Count); activeObstacleObject = obstacleObject[activeIndex]; activeObstacleObject.SetActive(true);
        StartCoroutine(Spawner());
    }

    private void Update() {
        if(GamePlayManager.IsGameOver) StopCoroutine(Spawner());
    }

    private IEnumerator Spawner() {
        while(!GamePlayManager.IsGameOver) {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(activeObstacleObject, new Vector2(gameObject.transform.position.x, Random.Range(4f, -3f)), Quaternion.identity);
        }
    }
}
