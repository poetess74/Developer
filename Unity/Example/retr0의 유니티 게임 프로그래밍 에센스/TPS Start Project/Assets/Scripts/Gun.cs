using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour {
    public enum State {
        Ready,
        Empty,
        Reloading
    }

    [SerializeField] private AudioClip shotClip;
    [SerializeField] private AudioClip reloadClip;

    private ParticleSystem muzzleFlashEffect;
    private ParticleSystem shellEjectEffect;

    public Transform fireTransform;
    private Transform leftHandMount;

    [SerializeField] private float damage = 25;
    [SerializeField] private float fireDistance = 100f;

    public int ammoRemain = 100;
    public int magAmmo;
    [SerializeField] private int magCapacity = 30;

    [SerializeField] private float timeBetFire = 0.12f;
    [SerializeField] private float reloadTime = 1.8f;

    [Range(0f, 10f)] [SerializeField] private float maxSpread = 3f;
    [Range(1f, 10f)] [SerializeField] private float stability = 1f;
    [Range(0.01f, 3f)] [SerializeField] private float restoreFromRecoilSpeed = 2f;
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

    private void Start() {
        muzzleFlashEffect = GameObject.Find("MuzzleFlash").GetComponent<ParticleSystem>();
        shellEjectEffect = GameObject.Find("ShellEjectEffect").GetComponent<ParticleSystem>();
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