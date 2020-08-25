using System;
using UnityEngine;

public class ShuttleController : MonoBehaviour {

    private float Fuel = 18250;
    private const int maxShuttleDurability = 8000;
    private static int shuttleDurability = 8000;
    private Rigidbody rb;

    private void Awake () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start () {
        rb = GetComponent<Rigidbody>();
        ShuttleDB.MAXshuttleDurability = maxShuttleDurability;
        ShuttleDB.CNTshuttleDurability = shuttleDurability;
    }

    private void Update () {
        ShuttleDB.shuttleAngle = -this.transform.rotation.z;
        ShuttleRotate();
        ShuttleMovement();
    }

    private void FixedUpdate () {
        ShuttleDB.shuttleSpeed = rb.velocity.magnitude * 1.94384f;
        ShuttleDB.shuttleAltitude = this.transform.position.y * 3.28084f;
        ShuttleDB.shuttleFuel = this.Fuel * 0.264172f;
        ShuttleDB.shuttleFuel -= 0.00002f;

        // if (Input.GetKeyDown(KeyCode.Escape)) {
        //     Cursor.lockState = CursorLockMode.None;
        //     Cursor.visible = true;
        // } else if (Input.GetMouseButtonDown(0)) {
        //     Cursor.lockState = CursorLockMode.Locked;
        //     Cursor.visible = false;
        // }
    }

    private void ShuttleRotate() {
       if (Input.GetKey(KeyCode.UpArrow)) {
            rb.AddForce(transform.up * 100000);
            rb.AddForce(transform.forward * 50000);
            ShuttleDB.shuttleFuel -= 0.0001f;
       } else if (Input.GetKey(KeyCode.DownArrow)) {
            rb.AddForce(transform.up * -100000);
            rb.AddForce(transform.forward * -50000);
            ShuttleDB.shuttleFuel -= 0.00005f;
       } else if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(0, 0, Time.deltaTime * 2);
            rb.AddForce(transform.forward * 50000);
            rb.AddForce(Vector3.left * 25000);
            ShuttleDB.shuttleFuel -= 0.000025f;
       } else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(0, 0, -Time.deltaTime * 2);
            rb.AddForce(transform.forward * 50000);
            rb.AddForce(Vector3.right * 25000);
            ShuttleDB.shuttleFuel -= 0.000025f;
       }
    }

    private void ShuttleMovement() {
        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(transform.forward * 50000);
            ShuttleDB.shuttleFuel -= 0.00005f;
        } else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)) {
            rb.AddForce(transform.forward * 75000);
            ShuttleDB.shuttleFuel -= 0.00007f;
        }
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0, -Time.deltaTime, 0);
            ShuttleDB.shuttleFuel -= 0.00005f;
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0, Time.deltaTime, 0);
            ShuttleDB.shuttleFuel -= 0.00005f;
        }
        if (Input.GetKey(KeyCode.S)) {
            rb.AddForce(transform.forward * -50000);
            ShuttleDB.shuttleFuel -= 0.00005f;
        } else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift)) {
            rb.AddForce(transform.forward * -70000);
            ShuttleDB.shuttleFuel -= 0.00007f;
        }
    }
    
    public static int ReturnDurability () {
        return shuttleDurability;
    }

    private void OnCollisionEnter (Collision col) {
        Debug.Log(gameObject.name + " collision by " + col.gameObject.name + ". (tag: " + col.gameObject.tag + ")");
        switch (col.gameObject.tag) {
            case "Player":
                break;
            case "Weapon":
                shuttleDurability -= BasicLaserController.ReturnDamage();
                General.Target = gameObject;
                break;
            default:
                if(col.relativeVelocity.magnitude > 10) {
                    shuttleDurability -= (int)col.relativeVelocity.magnitude;
                    ShuttleDB.CNTshuttleDurability = shuttleDurability;
                }
                break;
        }
    }
}
