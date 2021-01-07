using UnityEngine;
using UnityEngine.UI;

public class BallShooter : MonoBehaviour {
    [Header("InGame asset")]
    [SerializeField] private Rigidbody ball;
    [SerializeField] private CamFollow cam;
    [Header("Sound clip")]
    [SerializeField] private AudioClip fireClip;
    [SerializeField] private AudioClip chargingClip;
    [Header("User control force")]
    [SerializeField] private float minimumForce = 15f;
    [SerializeField] private float maximumForce = 30f;
    [SerializeField] private float chargingTime = 0.75f;
    
    private Transform firePos;
    private Slider powerSlider;
    private AudioSource shootingAudio;

    private float cntForce;
    private float chargeSpeed;
    private bool isFired;

    private void OnEnable() {
        cntForce = minimumForce;
        
        firePos = GameObject.Find("FirePos").transform;
        powerSlider = GetComponentInChildren<Slider>();
        shootingAudio = GetComponent<AudioSource>();
        
        powerSlider.minValue = minimumForce;
        powerSlider.maxValue = maximumForce;
        powerSlider.value = minimumForce;
        
        isFired = false;
    }
    
    private void Start() {
        chargeSpeed = (maximumForce - minimumForce) / chargingTime;
    }

    private void Update() {
        if(isFired) return;
        if(cntForce >= maximumForce && !isFired) {
            cntForce = maximumForce;
            Fire();
        } else if(Input.GetButtonDown("Fire1")) {
            cntForce = minimumForce;

            shootingAudio.clip = chargingClip;
            shootingAudio.Play();
        } else if(Input.GetButton("Fire1") && !isFired) {
            cntForce += chargeSpeed * Time.deltaTime;
            powerSlider.value = cntForce;
        } else if(Input.GetButtonUp("Fire1") && !isFired) {
            Fire();
        }
    }

    private void Fire() {
        isFired = true;
        Rigidbody instance = Instantiate(ball, firePos.position, firePos.rotation);
        instance.velocity = cntForce * firePos.forward;

        shootingAudio.clip = fireClip;
        shootingAudio.Play();

        cntForce = minimumForce;
        powerSlider.value = minimumForce;
        
        cam.SetTarget(instance.transform, CamFollow.State.Tracking);
    }
}
