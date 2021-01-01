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
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(inputX, 0, inputZ) * speed;
        velocity.y = playerRigidbody.velocity.y;
        playerRigidbody.velocity = velocity; 
    }
}
