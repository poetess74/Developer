using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {
    [SerializeField] private AudioClip itemPickupClip;
    [SerializeField] private int lifeRemains = 3;
    
    private Animator animator;
    private AudioSource playerAudioPlayer;
    private PlayerHealth playerHealth;
    private PlayerMovement playerMovement;
    private PlayerShooter playerShooter;

    private void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        playerMovement = GetComponent<PlayerMovement>();
        playerShooter = GetComponent<PlayerShooter>();
        playerHealth = GetComponent<PlayerHealth>();
        playerAudioPlayer = GetComponent<AudioSource>();

        playerHealth.OnDeath += HandleDeath;
        UIManager.Instance.UpdateLifeText(lifeRemains);
    }


    private void OnTriggerEnter(Collider other) {
        if(playerHealth.dead) return;
        var item = other.GetComponent<IItem>();
        if(item == null) return;
        item.Use(gameObject);
        playerAudioPlayer.PlayOneShot(itemPickupClip);
    }

    private void HandleDeath() {
        playerMovement.enabled = false;
        playerShooter.enabled = false;

        if(lifeRemains > 0) {
            lifeRemains--;
            UIManager.Instance.UpdateLifeText(lifeRemains);
            Invoke("Respawn", 3f);
        } else {
            GameManager.Instance.EndGame();
        }
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Respawn() {
        gameObject.SetActive(false);
        transform.position = Utility.GetRandomPointOnNavMesh(transform.position, 30f, NavMesh.AllAreas);
        playerMovement.enabled = true;
        playerShooter.enabled = true;
        gameObject.SetActive(true);

        playerShooter.gun.ammoRemain = 120;
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}