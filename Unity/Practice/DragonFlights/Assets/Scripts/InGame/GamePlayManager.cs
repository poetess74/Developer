using UnityEngine;

class GamePlayManager {
    public static bool dontSpawn = false;

    public static float scrollSpeed = 5f;

    public static Vector3 playerPos;

    public static byte fireLevel = 1;
    public static int numberOfBulletTypes = 0;
    public static byte dragonsCount = 5;

    private static float distance = 0f;
    public static int score = 0;

    public static void Reset() {
        GamePlayManager.dontSpawn = false;
        GamePlayManager.scrollSpeed = 5f;
        GamePlayManager.distance = 0f;
        GamePlayManager.score = 0;
        GamePlayManager.fireLevel = 1;
        GamePlayManager.dragonsCount = 5;
    }

    public static void AddDistance(float distance) {
        GamePlayManager.distance += distance;
    }

    public static void AddScore(int score) {
        GamePlayManager.score += score;
    }

    public static float GetDistance() {
        return GamePlayManager.distance;
    }

    public static int GetScore() {
        return GamePlayManager.score;
    }

    public static int GetPlayerBulletDamage() {
        return (GamePlayManager.fireLevel - 1) / GamePlayManager.numberOfBulletTypes + 1;
    }
}