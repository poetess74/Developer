using Player;
using UnityEngine;

public class DamageTest : MonoBehaviour {
    [SerializeField] private PlayerDamage player;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.A)) {
            if(!player.Damaged(5.5f, false, gameObject)) {
                Debug.Log("Immuned General attack.");
            }
        }

        if(Input.GetKeyDown(KeyCode.S)) {
            if(!player.Damaged(10.0f, true, gameObject)) {
                Debug.Log("Immuned Knock-Back attack.");
            }
        }
    }
}
