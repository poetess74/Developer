using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] private LayerMask filterProp;
    
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
        var colliders = Physics.OverlapSphere(transform.position, explosionRadius, filterProp);

        foreach(var filteredCollider in colliders) {
            Rigidbody targetRigidbody = filteredCollider.GetComponent<Rigidbody>();
            targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);

            Prop targetProp = filteredCollider.GetComponent<Prop>();

            float damage = CalcDamage(filteredCollider.transform.position);
            targetProp.TakeDamage(damage);
        }
        
        explosionParticle.transform.parent = null;
        explosionParticle.Play();
        explosionAudio.Play();
        
        GameManager.instance.OnBallDestroy();
        Destroy(explosionParticle.gameObject, explosionParticle.main.duration);
        Destroy(gameObject);
    }

    private float CalcDamage(Vector3 targetPos) {
        Vector3 explosionToTarget = targetPos - transform.position;
        float distance = explosionToTarget.magnitude;
        float edgeToCenterDistance = explosionRadius - distance;
        float ratio = edgeToCenterDistance / explosionRadius;
        return Mathf.Max(maxDamage * ratio, 0);
    }
}
