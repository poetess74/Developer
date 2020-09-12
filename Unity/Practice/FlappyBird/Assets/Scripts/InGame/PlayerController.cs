using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour {
    [SerializeField] private List<GameObject> players;
    [SerializeField] private bool isControllable;
    [SerializeField] private bool isDamageable;
    
    private float jumpSpeed = 30;
    private GameObject playerImage;
    private void Start() {
        if (isControllable)
            GamePlayManager.IsGameOver = false;
        if(!isDamageable)
            gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
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

        if(Mathf.Abs(transform.position.x) > Mathf.Abs(GamePlayManager.limitPosition)) {
            if(isDamageable) {
                Destroy(gameObject);
            } else {
                if(transform.position.y < -3.62f || transform.position.y > 4.86f) {
                    gameObject.GetComponent<Rigidbody2D>().position = new Vector2(0, -1.8f);
                } else {
                    gameObject.GetComponent<Rigidbody2D>().position = new Vector2(0, transform.position.y);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(!isDamageable) {
            if(other.transform.CompareTag("Finish")) {
                GamePlayManager.IsGameOver = true;
                playerImage.GetComponent<Animation>().Stop();
            }
        } else {
            if(other.transform.CompareTag("Respawn") || other.transform.CompareTag("Finish")) {
                GamePlayManager.IsGameOver = true;
                playerImage.GetComponent<Animation>().Stop();
            }
        }
    }
}
