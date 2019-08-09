using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    public int hp = 1;
    public int score = 100;

    void OnCollisionEnter2D(Collision2D col) {
        hp--;
        if (hp <= 0) {
            Destroy(gameObject);
            PlayerState.score += score;
        } else {
            PlayerState.score += 10;
        }
    }
}
