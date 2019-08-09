using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    private bool dragging = false;

    private Vector3 originPos;
    private Vector3 dragOriginPos;

    private void Update () {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) {
            this.dragging = true;
            this.originPos = transform.position;
            this.dragOriginPos = mousePos;
        }

        if (Input.GetMouseButtonUp(0)) {
            this.dragging = false;
        }

        if (this.dragging) {
            var pos = this.originPos;
            var diffX = (mousePos - this.dragOriginPos).x;

            pos.x = Mathf.Clamp(pos.x + diffX, -3.5f, 3.5f);

            this.transform.position = pos;

            GamePlayManager.playerPos = pos;
        }
	}
    private void LateUpdate() {
        //Debuger
        //Debug.Log("Dragons.Count = " + GamePlayManager.dragonsCount);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Laser" || collision.gameObject.tag == "Player") {
            return;
        }
        if (collision.gameObject.tag == "Item") {
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
