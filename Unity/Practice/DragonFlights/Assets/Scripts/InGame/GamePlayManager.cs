using UnityEngine;

class GamePlayManager {
    public static bool dontSpawn;

    public static float scrollSpeed = 5f;

    public static Vector3 playerPos;

    public static byte fireLevel = 1;
    public static int numberOfBulletTypes = 0;
    public static byte dragonsCount = 5;

    private static float distance;
    public static int score = 0;

    public static void Reset() {
        dontSpawn = false;
        scrollSpeed = 5f;
        distance = 0f;
        score = 0;
        fireLevel = 1;
        dragonsCount = 5;
    }

    public static void AddDistance(float distance) {
        GamePlayManager.distance += distance;
    }

    public static void AddScore(int score) {
        GamePlayManager.score += score;
    }

    public static float GetDistance() {
        return distance;
    }

    public static int GetScore() {
        return score;
    }

    public static int GetPlayerBulletDamage() {
        return (fireLevel - 1) / numberOfBulletTypes + 1;
    }
}