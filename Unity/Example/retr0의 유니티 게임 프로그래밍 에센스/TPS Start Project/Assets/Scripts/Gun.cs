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
    public Transform leftHandMount;

    [SerializeField] private float damage = 25;
    public float fireDistance = 100f;

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
        muzzleFlashEffect = GameObject.Find("MuzzleFlash").GetComponent<ParticleSystem>();
        shellEjectEffect = GameObject.Find("ShellEjectEffect").GetComponent<ParticleSystem>();
        gunAudioPlayer = GetComponent<AudioSource>();
        bulletLineRenderer = GetComponent<LineRenderer>();

        bulletLineRenderer.positionCount = 2;
        bulletLineRenderer.enabled = false;
    }

    private void Update() {
        currentSpread = Mathf.Clamp(currentSpread, 0f, maxSpread);
        currentSpread = Mathf.SmoothDamp(
            currentSpread, 0f, ref currentSpreadVelocity, 1f / restoreFromRecoilSpeed
        );
    }

    private void OnEnable() {
        magAmmo = magCapacity;
        currentSpread = 0f;
        lastFireTime = 0f;
        state = State.Ready;
    }

    private void OnDisable() {
        StopAllCoroutines();
    }

    public void Setup(PlayerShooter gunHolder) {
        this.gunHolder = gunHolder;
        excludeTarget = gunHolder.excludeTarget;
    }

    public bool Fire(Vector3 aimTarget) {
        if(state == State.Ready && Time.time >= lastFireTime + timeBetFire) {
            Vector3 fireDir = aimTarget - fireTransform.position;
            
            float xError = Utility.GedRandomNormalDistribution(0f, currentSpread);
            float yError = Utility.GedRandomNormalDistribution(0f, currentSpread);
            fireDir = Quaternion.AngleAxis(yError, Vector3.up) * fireDir;
            fireDir = Quaternion.AngleAxis(xError, Vector3.right) * fireDir;

            currentSpread += 1f / stability;
            
            lastFireTime = Time.time;
            Shot(fireTransform.position, fireDir);
        }
        return false;
    }

    private void Shot(Vector3 startPoint, Vector3 direction) {
        RaycastHit hit;
        Vector3 hitPosition;
        if(Physics.Raycast(startPoint, direction, out hit, fireDistance, ~excludeTarget)) {
            var target = hit.collider.GetComponent<IDamageable>();
            if(target != null) {
                DamageMessage damageMessage;
                damageMessage.damager = gunHolder.gameObject;
                damageMessage.amount = damage;
                damageMessage.hitPoint = hit.point;
                damageMessage.hitNormal = hit.normal;

                target.ApplyDamage(damageMessage);
            }

            hitPosition = hit.point;
        } else {
            hitPosition = startPoint + direction * fireDistance;
        }

        StartCoroutine(ShotEffect(hitPosition));
        magAmmo--;
        if(magAmmo <= 0) state = State.Empty;
    }

    private IEnumerator ShotEffect(Vector3 hitPosition) {
        muzzleFlashEffect.Play();
        shellEjectEffect.Play();
        
        gunAudioPlayer.PlayOneShot(shotClip);
        bulletLineRenderer.enabled = true;
        bulletLineRenderer.SetPosition(0, fireTransform.position);
        bulletLineRenderer.SetPosition(1, hitPosition);
        yield return new WaitForSeconds(0.03f);
        bulletLineRenderer.enabled = false;
    }

    public bool Reload() {
        if(state == State.Reloading || ammoRemain <= 0 || magAmmo >= magCapacity) return false;
        StartCoroutine(ReloadRoutine());
        return true;
    }

    private IEnumerator ReloadRoutine() {
        state = State.Reloading;
        gunAudioPlayer.PlayOneShot(reloadClip);
        yield return new WaitForSeconds(reloadTime);

        int ammoToFill = Mathf.Clamp(magCapacity - magAmmo, 0, ammoRemain);
        magAmmo += ammoToFill;
        ammoRemain -= ammoToFill;
        state = State.Ready;
    }
}