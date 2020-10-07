using UnityEngine;

public class PlayerSpawnController : MonoBehaviour {
    [SerializeField] private GameObject[] players;
    private GameObject activePlayers;
    private void Awake() {
        foreach(var player in players) {
            player.SetActive(false);
        }
        int activeIndex = Random.Range(0, players.Length);
        activePlayers = players[activeIndex];
        activePlayers.SetActive(true);
        foreach(var player in players) {
            if(!player.activeSelf) {
                Destroy(player);
            }
        }
    }
}
