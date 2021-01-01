using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    private Rigidbody playerRigidbody;
    
    // Start is called before the first frame update
    private void Start() {
        playerRigidbody = GetComponent<Rigidbody>();
        
        playerRigidbody.AddForce(0, 1000, 0);
    }

    // Update is called once per frame
    private void Update() {
        
    }
}
