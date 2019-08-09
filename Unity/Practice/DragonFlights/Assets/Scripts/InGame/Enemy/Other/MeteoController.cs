using UnityEngine;
using System.Collections;

public class MeteoController : MonoBehaviour {
    private const float MIN_Y = -15f;

    public GameObject warningPrefab;

    private float rotatePerSecond = 180f;
    private float speed = 5f;

    private Transform spriteTransform;

    private GameObject warning;

    private void Start() {
        this.spriteTransform = this.transform.Find("meteo_03");

        var pos = new Vector3(this.transform.position.x, 0, 0);
        this.warning = Instantiate(this.warningPrefab, pos, Quaternion.identity);

        StartCoroutine(DeleteWarning());
    }

    private IEnumerator DeleteWarning() {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.warning);
        this.warning = null;
    }

    private void Update () {
        this.transform.position += Vector3.down * this.speed * Time.deltaTime;
        this.spriteTransform.Rotate(new Vector3(0, 0, rotatePerSecond * Time.deltaTime));

        if (this.transform.position.y <= MIN_Y) {
            Destroy(this.gameObject);
        }
	}

}
