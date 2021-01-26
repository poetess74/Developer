using UnityEngine;

public class PlayerShooter : MonoBehaviour {
    public enum AimState {
        Idle,
        HipFire
    }

    [SerializeField] private Gun gun;
    public LayerMask excludeTarget;

    private Vector3 aimPoint;
    private Animator playerAnimator;
    private Camera playerCamera;

    private PlayerInput playerInput;

    public AimState aimState { get; private set; }
    private bool linedUp => !(Mathf.Abs(playerCamera.transform.eulerAngles.y - transform.eulerAngles.y) > 1f);

    private bool hasEnoughDistance => !Physics.Linecast(transform.position + Vector3.up * gun.fireTransform.position.y,
        gun.fireTransform.position, ~excludeTarget);

    private void Awake() {
        if(excludeTarget != (excludeTarget | (1 << gameObject.layer))) excludeTarget |= 1 << gameObject.layer;
    }

    private void Start() {
    }

    private void Update() {
    }

    private void FixedUpdate() {
        if(playerInput.fire)
            Shoot();
        else if(playerInput.reload) Reload();
    }

    private void OnEnable() {
        gun.gameObject.SetActive(true);
        gun.Setup(this);
    }

    private void OnDisable() {
        gun.gameObject.SetActive(false);
    }

    private void OnAnimatorIK(int layerIndex) {
    }

    public void Shoot() {
    }

    public void Reload() {
    }

    private void UpdateAimTarget() {
    }

    private void UpdateUI() {
        if(gun == null || UIManager.Instance == null) return;

        UIManager.Instance.UpdateAmmoText(gun.magAmmo, gun.ammoRemain);

        UIManager.Instance.SetActiveCrosshair(hasEnoughDistance);
        UIManager.Instance.UpdateCrossHairPosition(aimPoint);
    }
}