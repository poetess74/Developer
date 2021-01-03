using UnityEngine;

public class Mover : MonoBehaviour {
    [SerializeField] private Vector3 move = new Vector3(-5, 5, -5);
    [SerializeField] private bool global;

    private void Move() {
        transform.Translate(move * Time.deltaTime, !global ? Space.Self : Space.World);
    }

    // Update is called once per frame
    private void Update() {
        if(Input.GetKey(KeyCode.Space)) {
            Move();
        }
    }
}
