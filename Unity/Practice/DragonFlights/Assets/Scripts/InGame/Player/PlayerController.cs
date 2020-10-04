using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    private bool dragging;

    private Vector3 originPos;
    private Vector3 dragOriginPos;
    private Vector3 mousePos;

    private void Update () {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) {
            dragging = true;
            originPos = transform.position;
            dragOriginPos = mousePos;
        }

        if (Input.GetMouseButtonUp(0)) {
            dragging = false;
        }

        if (dragging) {
            var pos = originPos;
            var diffX = (mousePos - dragOriginPos).x;

            pos.x = Mathf.Clamp(pos.x + diffX, -3.5f, 3.5f);

            transform.position = pos;

            GamePlayManager.playerPos = pos;
        }
	}
    private void LateUpdate() {
        //Debuger
        // Debug.Log("PlayerPos = " + GamePlayManager.playerPos);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Laser") || collision.gameObject.CompareTag("Player")) {
            return;
        }
        if (collision.gameObject.CompareTag("Item")) {
            if (collision.gameObject.GetComponent<DualshotController>() != null) {
                GamePlayManager.fireLevel++;
            }

            Destroy(collision.gameObject);
            return;
        }

        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
