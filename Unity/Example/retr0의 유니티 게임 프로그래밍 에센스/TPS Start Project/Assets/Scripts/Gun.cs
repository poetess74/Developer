using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour {
    public enum State {
        Ready,
        Empty,
        Reloading
    }

    public AudioClip shotClip;
    public AudioClip reloadClip;

    public ParticleSystem muzzleFlashEffect;
    public ParticleSystem shellEjectEffect;

    public Transform fireTransform;
    public Transform leftHandMount;

    public float damage = 25;
    public float fireDistance = 100f;

    public int ammoRemain = 100;
    public int magAmmo;
    public int magCapacity = 30;

    public float timeBetFire = 0.12f;
    public float reloadTime = 1.8f;

    [Range(0f, 10f)] public float maxSpread = 3f;
    [Range(1f, 10f)] public float stability = 1f;
    [Range(0.01f, 3f)] public float restoreFromRecoilSpeed = 2f;
    private LineRenderer bulletLineRenderer;
    private float currentSpread;
    private float currentSpreadVelocity;

    private LayerMask excludeTarget;

    private AudioSource gunAudioPlayer;

    private PlayerShooter gunHolder;

    private float lastFireTime;
    public State state { get; private set; }

    private void Awake() {
    }

    private void Update() {
    }

    private void OnEnable() {
    }

    private void OnDisable() {
        StopAllCoroutines();
    }

    public void Setup(PlayerShooter gunHolder) {
    }

    public bool Fire(Vector3 aimTarget) {
        return false;
    }

    private void Shot(Vector3 startPoint, Vector3 direction) {
    }

    private IEnumerator ShotEffect(Vector3 hitPosition) {
        yield return null;
    }

    public bool Reload() {
        return false;
    }

    private IEnumerator ReloadRoutine() {
        yield return null;
    }
}