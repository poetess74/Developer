using UnityEngine;

public class Jumper : MonoBehaviour {
    [SerializeField] private Rigidbody myRigidbody;
    
    // Start is called before the first frame update
    private void Start() {
        myRigidbody.AddForce(0, 500, 0);
    }
}
