using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    private Rigidbody playerRigidbody;
    
    // Start is called before the first frame update
    private void Start() {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame (사양에 따라 가변적)
    // 영화 24fps, 모바일: 30fps, PC: 60fps
    private void Update() {
        //유저 입력을 넣자
        if(Input.GetKey(KeyCode.W)) {
            playerRigidbody.AddForce(Vector3.forward * speed);
        }
        if(Input.GetKey(KeyCode.A)) {
            playerRigidbody.AddForce(Vector3.left * speed);
        }
        if(Input.GetKey(KeyCode.S)) {
            playerRigidbody.AddForce(Vector3.back * speed);
        }
        if(Input.GetKey(KeyCode.D)) {
            playerRigidbody.AddForce(Vector3.right * speed);
        }
    }
}
