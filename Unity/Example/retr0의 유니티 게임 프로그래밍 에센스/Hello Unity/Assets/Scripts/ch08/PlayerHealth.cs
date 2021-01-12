using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    private void Dead() {
        Debug.Log("죽었다!");
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other) {
        Dead();
    }
}
