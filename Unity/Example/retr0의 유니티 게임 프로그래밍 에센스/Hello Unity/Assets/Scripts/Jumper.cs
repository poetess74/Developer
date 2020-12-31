using UnityEngine;

public class Jumper : MonoBehaviour {
    [SerializeField] private Rigidbody myRigidbody;
    
    // Start is called before the first frame update
    private void Start() {
        myRigidbody.AddForce(0, 500, 0);
    }

    // Update is called once per frame
    private void Update() {
        
    }
}
