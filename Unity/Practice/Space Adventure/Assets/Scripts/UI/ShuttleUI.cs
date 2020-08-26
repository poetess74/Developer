using System;
using UnityEngine;
using UnityEngine.UI;

public class ShuttleUI : MonoBehaviour {
    public static ShuttleUI Instance;

    [SerializeField] private Animation messageAnim;

    [SerializeField] private GameObject MasterAlert;
    [SerializeField] private GameObject Tutorial;

    [SerializeField] private Image FuelAlert;
    [SerializeField] private Image AltitudeAlert;
    [SerializeField] private Image SpeedAlert;

    [SerializeField] private Text FuelText;
    [SerializeField] private Text AltitudeText;
    [SerializeField] private Text SpeedText;
    [SerializeField] private Text DurabilityText;
    [SerializeField] private Text AccelerationOfGravityText;
    [SerializeField] private Text StatusText;

    //TODO: HUD Insert.

    [SerializeField] private Text HUDAltitudeText;
    [SerializeField] private Text HUDSpeedText;
    [SerializeField] private GameObject Gizmo;

    private void Awake () {
        Instance = this;
    }

    private void Start () {
        StatusText.text = "OK";
    }

    private void Update () {
        Gizmo.transform.rotation = Quaternion.Euler(0, 0, ShuttleDB.shuttleAngle);
    }

    private void LateUpdate () {
        if(ShuttleDB.CNTshuttleDurability < 21) {
            MasterAlert.SetActive(true);
            StatusText.text = "ERR";
        }
    }

    private void FixedUpdate() {
        SpeedText.text = ShuttleDB.shuttleSpeed.ToString();
        AltitudeText.text = ShuttleDB.shuttleAltitude.ToString();
        DurabilityText.text = ShuttleController.ReturnDurability().ToString();
        FuelText.text = ShuttleDB.shuttleFuel.ToString();
        HUDSpeedText.text = ShuttleDB.shuttleSpeed.ToString();
        HUDAltitudeText.text = ShuttleDB.shuttleAltitude.ToString();
        AccelerationOfGravityText.text = ShuttleDB.accelerationOfGravity.ToString();
    }
}
