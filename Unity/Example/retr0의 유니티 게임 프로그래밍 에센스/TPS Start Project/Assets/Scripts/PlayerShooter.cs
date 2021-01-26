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

    private float waitingTimeForRelease = 2.5f;
    private float lastFireInputTime;

    public AimState aimState { get; private set; }
    private bool linedUp => !(Mathf.Abs(playerCamera.transform.eulerAngles.y - transform.eulerAngles.y) > 1f);

    private bool hasEnoughDistance => !Physics.Linecast(transform.position + Vector3.up * gun.fireTransform.position.y,
        gun.fireTransform.position, ~excludeTarget);

    private void Awake() {
        if(excludeTarget != (excludeTarget | (1 << gameObject.layer))) excludeTarget |= 1 << gameObject.layer;
    }

    private void Start() {
        playerCamera = Camera.main;
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update() {
        UpdateAimTarget();
        
        float angle = playerCamera.transform.eulerAngles.x;
        if(angle > 270) angle -= 360f;
        angle = angle / -180f + 0.5f;
        playerAnimator.SetFloat("Angle", angle);

        if(!playerInput.fire && Time.time >= lastFireInputTime + waitingTimeForRelease) {
            aimState = AimState.Idle;
        }
        
        UpdateUI();
    }

    private void FixedUpdate() {
        if(playerInput.fire) {
            lastFireInputTime = Time.time;
            Shoot();
        } else if(playerInput.reload) {
            Reload();
        }
    }

    private void OnEnable() {
        aimState = AimState.Idle;
        gun.gameObject.SetActive(true);
        gun.Setup(this);
    }

    private void OnDisable() {
        aimState = AimState.Idle;
        gun.gameObject.SetActive(false);
    }

    private void OnAnimatorIK(int layerIndex) {
        if(gun == null || gun.state == Gun.State.Reloading) return;
        playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
        playerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
        
        playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, gun.leftHandMount.position);
        playerAnimator.SetIKRotation(AvatarIKGoal.LeftHand, gun.leftHandMount.rotation);
    }

    public void Shoot() {
        if(aimState == AimState.Idle) {
            if(linedUp) aimState = AimState.HipFire;
        } else if(aimState == AimState.HipFire) {
            if(hasEnoughDistance) {
                gun.Fire(aimPoint);
                playerAnimator.SetTrigger("Shoot");
            } else {
                aimState = AimState.Idle;
            }
        }
    }

    public void Reload() {
        if(gun.Reload()) {
            playerAnimator.SetTrigger("Reload");
        }
    }

    private void UpdateAimTarget() {
        RaycastHit hit;
        var ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if(Physics.Raycast(ray, out hit, gun.fireDistance, ~excludeTarget)) {
            aimPoint = hit.point;
            if(Physics.Linecast(gun.fireTransform.position, hit.point, out hit, ~excludeTarget)) {
                aimPoint = hit.point;
            }
        } else {
            aimPoint = playerCamera.transform.position + playerCamera.transform.forward * gun.fireDistance;
        }
    }

    private void UpdateUI() {
        if(gun == null || UIManager.Instance == null) return;

        UIManager.Instance.UpdateAmmoText(gun.magAmmo, gun.ammoRemain);

        UIManager.Instance.SetActiveCrosshair(hasEnoughDistance);
        UIManager.Instance.UpdateCrossHairPosition(aimPoint);
    }
}