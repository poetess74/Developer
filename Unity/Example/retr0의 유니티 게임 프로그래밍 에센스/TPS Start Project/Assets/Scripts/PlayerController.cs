using UnityEngine;

public class PlayerController : MonoBehaviour {
    public AudioClip itemPickupClip;
    public int lifeRemains = 3;
    private Animator animator;
    private AudioSource playerAudioPlayer;
    private PlayerHealth playerHealth;
    private PlayerMovement playerMovement;
    private PlayerShooter playerShooter;

    private void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void OnTriggerEnter(Collider other) {
    }

    private void HandleDeath() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Respawn() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}