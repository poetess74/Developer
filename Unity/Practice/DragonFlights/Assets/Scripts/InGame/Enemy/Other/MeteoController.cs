using UnityEngine;
using System.Collections;

public class MeteoController : MonoBehaviour {
    private const float MIN_Y = -15f;

    [SerializeField] private GameObject warningPrefab;

    private float rotatePerSecond = 180f;
    private float speed = 5f;

    private Transform spriteTransform;

    private GameObject warning;

    private void Start() {
        spriteTransform = transform.Find("meteo_03");

        var pos = new Vector3(transform.position.x, 0, 0);
        warning = Instantiate(warningPrefab, pos, Quaternion.identity);

        StartCoroutine(DeleteWarning());
    }

    private IEnumerator DeleteWarning() {
        yield return new WaitForSeconds(1.5f);
        Destroy(warning);
        warning = null;
    }

    private void Update () {
        transform.position += Vector3.down * speed * Time.deltaTime;
        spriteTransform.Rotate(new Vector3(0, 0, rotatePerSecond * Time.deltaTime));

        if (transform.position.y <= MIN_Y) {
            Destroy(gameObject);
        }
	}

}
