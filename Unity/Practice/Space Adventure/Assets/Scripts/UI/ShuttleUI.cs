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
    [SerializeField] private Text StatusText;

    //TODO: HUD Insert.

    [SerializeField] private Text HUDAltitudeText;
    [SerializeField] private Text HUDSpeedText;
    [SerializeField] private GameObject Gizmo;

    private void Awake () {
        Instance = this;
    }

    private void Start () {
        this.StatusText.text = "OK";
    }

    private void Update () {
        Gizmo.transform.Rotate(0, 0, ShuttleDB.shuttleAngle);
    }

    private void LateUpdate () {
        if(ShuttleDB.CNTshuttleDurability < 21) {
            MasterAlert.SetActive(true);
        }
    }

    private void FixedUpdate() {
        this.SpeedText.text = ShuttleDB.shuttleSpeed.ToString();
        this.AltitudeText.text = ShuttleDB.shuttleAltitude.ToString();
        this.DurabilityText.text = ShuttleController.ReturnDurability().ToString();
        this.FuelText.text = ShuttleDB.shuttleFuel.ToString();
        this.HUDSpeedText.text = ShuttleDB.shuttleSpeed.ToString();
        this.HUDAltitudeText.text = ShuttleDB.shuttleAltitude.ToString();
    }
}
