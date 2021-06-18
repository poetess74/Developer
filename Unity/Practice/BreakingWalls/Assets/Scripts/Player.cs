using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Use this for initialization
    void Start() {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        Camera cam = Camera.main;
        Vector3 Player = transform.position;
        Vector3 mousePos = Input.mousePosition;
        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(mousePos);
        transform.position = new Vector3(Mathf.Clamp(mouseWorldPos.x, -6f, 6f), Player.y, Player.z);
    }
}
