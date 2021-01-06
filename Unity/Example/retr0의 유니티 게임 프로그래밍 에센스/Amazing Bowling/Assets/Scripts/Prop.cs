using System.Collections;
using UnityEngine;

public class Prop : MonoBehaviour {
    [SerializeField] private int score;
    [SerializeField] private float healthPoint;

    private ParticleSystem explosionParticle;
    private AudioSource explosionAudio;

    public void TakeDamage(float damage) {
        healthPoint -= damage;
        if(!(healthPoint <= 0)) return;
        StartCoroutine(Disable());
    }
    
    private void Start() {
        explosionParticle = GetComponentInChildren<ParticleSystem>();
        explosionAudio = GetComponentInChildren<AudioSource>();
    }

    private IEnumerator Disable() {
        explosionParticle.Play();
        explosionAudio.Play();
        yield return new WaitForSeconds(explosionParticle.main.duration);
        gameObject.SetActive(false);
    }
}
