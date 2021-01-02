using UnityEngine;

public class Rotator : MonoBehaviour {
    private readonly Vector3 angle = new Vector3(60, 60, 60);
    
    // Update is called once per frame
    private void Update() {
        transform.Rotate(angle * Time.deltaTime);
    }
}
