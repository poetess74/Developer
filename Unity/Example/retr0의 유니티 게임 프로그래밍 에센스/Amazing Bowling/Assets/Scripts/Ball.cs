using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] private float maxDamage = 100f;
    [SerializeField] private float explosionForce = 1000f;
    [SerializeField] private float explosionRadius = 20f;
    
    private ParticleSystem explosionParticle;
    private AudioSource explosionAudio;
    
    private const float lifeTime = 10f;

    private void Start() {
        Destroy(gameObject, lifeTime);
        explosionParticle = GetComponentInChildren<ParticleSystem>();
        explosionAudio = GetComponentInChildren<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        explosionParticle.transform.parent = null;
        explosionParticle.Play();
        explosionAudio.Play();
        
        Destroy(explosionParticle.gameObject, explosionParticle.main.duration);
        Destroy(gameObject);
    }
}
