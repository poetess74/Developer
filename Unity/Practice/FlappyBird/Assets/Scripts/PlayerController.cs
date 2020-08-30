using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour {
    [SerializeField] private List<GameObject> players;
    
    private float jumpSpeed = 30;
    private GameObject activeBackground;
    private void Start() {
        GamePlayManager.isGameOver = false;
        foreach(var player in players) {
            player.SetActive(false);
        }
    
        int activeIndex = Random.Range(0, players.Count);
        activeBackground = players[activeIndex];
        activeBackground.SetActive(true);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("Respawn")) {
            GamePlayManager.isGameOver = true;
            Destroy(gameObject);
        }
    }
}
