using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bottom : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collider) {
        Destroy(collider.gameObject);
        SceneManager.LoadScene("GameOver");
    }
}
