using UnityEngine;

public class BoxRotate : MonoBehaviour {
    public float xRotateSpeed = 15f;
    public float yRotateSpeed = 15f;
    public float zRotateSpeed = 15f;

    public float frequency = 7f;

    private float t = 0f;

    // Update is called once per frame
    void Update () {
        t += Time.deltaTime;

        transform.Rotate(
            xRotateSpeed * Time.deltaTime * Mathf.Sin(t * frequency * Mathf.Deg2Rad),
            yRotateSpeed * Time.deltaTime * Mathf.Cos(t * frequency * Mathf.Deg2Rad),
            zRotateSpeed * Time.deltaTime * Mathf.Sin(t * frequency * Mathf.Deg2Rad)
        );
    }
}