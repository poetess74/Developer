using UnityEngine;
using UnityEngine.UI;

public class UIController_Space : MonoBehaviour {
    [SerializeField]
    private Text cam1Power;
    [SerializeField]
    private Text cam1Status;
    [SerializeField]
    private Text cam2Power;
    [SerializeField]
    private Text cam2Mode;
    [SerializeField]
    private Text cam2Dist;      //TODO : Dist use it
    [SerializeField]
    private Text cam7Status;
    [SerializeField]
    private Text cam8Status;

    private float power;
    private string status;
    private string mode;
    private string dist;


    // Update is called once per frame
    private void Update() {
        float _power = UserInfo.power;
        string _status = UserInfo.status;
        string _mode = UserInfo.mode;

        if (System.Math.Abs(power - _power) > 0.000001f) {
            this.cam1Power.text = string.Format("{0}%", power.ToString("N2"));
            this.cam2Power.text = string.Format("{0}%", power.ToString("N2"));
            this.power = _power;
        }
        if (status != _status) {
            this.cam1Status.text = status;
            this.cam7Status.text = status;
            this.cam8Status.text = status;
            this.status = _status;
        }
        if (mode != _mode) {
            this.cam2Mode.text = mode;
            this.mode = _mode;
        }
    }
}