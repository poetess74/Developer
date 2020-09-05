using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour {
    [SerializeField] private List<GameObject> players;
    [SerializeField] private bool isControllable;
    
    private float jumpSpeed = 30;
    private GameObject playerImage;
    private void Start() {
        if (isControllable)
            GamePlayManager.IsGameOver = false;
        foreach(var player in players) {
            player.SetActive(false);
        }
    
        int activeIndex = Random.Range(0, players.Count);
        playerImage = players[activeIndex];
        playerImage.SetActive(true);
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0) && !GamePlayManager.IsGameOver && isControllable) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(!other.transform.CompareTag("Respawn")) return;
        GamePlayManager.IsGameOver = true;
        playerImage.GetComponent<Animation>().Stop();
    }
}
