using UnityEngine;

public class ShuttleController : MonoBehaviour {

    private float Fuel = 18250;
    private Rigidbody rb;

    private void Awake () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start () {
        rb = GetComponent<Rigidbody>();
    }

    private void Update () {
        GamePlayManager.shuttleAngle = -this.transform.rotation.z;

        if (Input.GetKey(KeyCode.UpArrow)) {
            rb.AddForce(transform.up * 100000);
            rb.AddForce(transform.forward * 50000);
            GamePlayManager.shuttleFuel -= 0.0001f;
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            rb.AddForce(transform.up * -100000);
            rb.AddForce(transform.forward * -50000);
            GamePlayManager.shuttleFuel -= 0.00005f;
        } 

        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(0, 0, Time.deltaTime * 2);
            rb.AddForce(transform.forward * 50000);
            rb.AddForce(Vector3.left * 25000);
            GamePlayManager.shuttleFuel -= 0.000025f;
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(0, 0, -Time.deltaTime * 2);
            rb.AddForce(transform.forward * 50000);
            rb.AddForce(Vector3.right * 25000);
            GamePlayManager.shuttleFuel -= 0.000025f;
        }

        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(transform.forward * 50000);
            GamePlayManager.shuttleFuel -= 0.00005f;
        } else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)) {
            rb.AddForce(transform.forward * 75000);
            GamePlayManager.shuttleFuel -= 0.00007f;
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0, -Time.deltaTime, 0);
            GamePlayManager.shuttleFuel -= 0.00005f;
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0, Time.deltaTime, 0);
            GamePlayManager.shuttleFuel -= 0.00005f;
        }

        if (Input.GetKey(KeyCode.S)) {
            rb.AddForce(transform.forward * -50000);
            GamePlayManager.shuttleFuel -= 0.00005f;
        } else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift)) {
            rb.AddForce(transform.forward * -70000);
            GamePlayManager.shuttleFuel -= 0.00007f;
        }

    }

    private void FixedUpdate () {
        GamePlayManager.shuttleSpeed = rb.velocity.magnitude * 1.94384f;
        GamePlayManager.shuttleAltitude = this.transform.position.y * 3.28084f;
        GamePlayManager.shuttleFuel = this.Fuel * 0.264172f;
        GamePlayManager.shuttleFuel -= 0.00002f;

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } else if (Input.GetMouseButtonDown(0)) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
