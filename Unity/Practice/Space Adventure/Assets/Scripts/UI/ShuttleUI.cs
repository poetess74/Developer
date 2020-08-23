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

    //TODO: HUD Insert.

    [SerializeField] private Text HUDAltitudeText;
    [SerializeField] private Text HUDSpeedText;
    [SerializeField] private GameObject Gizmo;

    private void Awake () {
        Instance = this;
    }

    private void Update () {
        Gizmo.transform.Rotate(0, 0, GamePlayManager.shuttleAngle);
    }

    private void LateUpdate () {
        this.SpeedText.text = GamePlayManager.shuttleSpeed.ToString();
        this.AltitudeText.text = GamePlayManager.shuttleAltitude.ToString();
        this.FuelText.text = GamePlayManager.shuttleFuel.ToString();
        this.HUDSpeedText.text = GamePlayManager.shuttleSpeed.ToString();
        this.HUDAltitudeText.text = GamePlayManager.shuttleAltitude.ToString();
    }
}
