using UnityEngine;
using UnityEngine.UI;

public class ShuttleUI : MonoBehaviour {
    public static ShuttleUI Instance;

    public Animation messageAnim;

    public GameObject MasterAlert;
    public GameObject Tutorial;

    public Image FuelAlert;
    public Image AltitudeAlert;
    public Image SpeedAlert;

    public Text FuelText;
    public Text AltitudeText;
    public Text SpeedText;

    //TODO: HUD Insert.

    public Text HUDAltitudeText;
    public Text HUDSpeedText;
    public GameObject Gizmo;

    public void Awake () {
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

    private void FixedUpdate () {

    }
}
