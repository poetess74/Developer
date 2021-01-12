using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] private UnityEvent onPlayerDead;
    
    private void Dead() {
        onPlayerDead.Invoke();
        Debug.Log("죽었다!");
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other) {
        Dead();
    }
}
