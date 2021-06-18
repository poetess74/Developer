using System.Collections.Generic;
using UnityEngine;

// 적 게임 오브젝트를 주기적으로 생성
public class EnemySpawner : MonoBehaviour {
    [SerializeField] private float damageMax = 40f;
    [SerializeField] private float damageMin = 20f;
    [SerializeField] private Enemy enemyPrefab;

    [SerializeField] private float healthMax = 200f;
    [SerializeField] private float healthMin = 100f;

    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private float speedMax = 12f;
    [SerializeField] private float speedMin = 3f;

    private Color strongEnemyColor = Color.red;
    private readonly List<Enemy> enemies = new List<Enemy>();
    private int wave;

    private void Update() {
        if(GameManager.Instance != null && GameManager.Instance.isGameover) return;

        if(enemies.Count <= 0) SpawnWave();

        UpdateUI();
    }

    private void UpdateUI() {
        UIManager.Instance.UpdateWaveText(wave, enemies.Count);
    }

    private void SpawnWave() {
        wave++;
        int spawnCount = Mathf.RoundToInt(wave * 5f);

        for(int i = 0; i < spawnCount; i++) {
            float enemyStrong = Random.Range(0f, 1f);
            CreateEnemy(enemyStrong);
        }
    }

    private void CreateEnemy(float intensity) {
        float health = Mathf.Lerp(healthMin, healthMax, intensity);
        float damage = Mathf.Lerp(damageMin, damageMax, intensity);
        float speed = Mathf.Lerp(speedMin, speedMax, intensity);
        Color skinColor = Color.Lerp(Color.white, strongEnemyColor, intensity);
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        var enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemy.Setup(health, damage, speed, speed * 0.3f, skinColor);
        enemies.Add(enemy);
        enemy.OnDeath += () => enemies.Remove(enemy);
        enemy.OnDeath += () => Destroy(enemy.gameObject, 10f);
        enemy.OnDeath += () => GameManager.Instance.AddScore(100);
    }
}