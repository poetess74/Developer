using UnityEngine;

public class Booster : MonoBehaviour {
    private void HealthBoost(Character target) {
        Debug.LogFormat("{0}의 체력을 강화했다!", target.playerName);
        target.hp += 10;
    }

    private void ShieldBoost(Character target) {
        Debug.LogFormat("{0}의 방어력을 강화했다!", target.playerName);
        target.defense += 10;
    }

    private void DamageBoost(Character target) {
        Debug.LogFormat("{0}의 공격력을 강화했다!", target.playerName);
        target.damage += 10;
    }

    private void Awake() {
        Character player = FindObjectOfType<Character>();
        player.playerBoost += HealthBoost;
        player.playerBoost += ShieldBoost;
        player.playerBoost += DamageBoost;
    }
}
