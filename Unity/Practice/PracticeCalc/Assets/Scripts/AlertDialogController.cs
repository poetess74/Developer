using UnityEngine;
using UnityEngine.UI;

public class AlertDialogController : MonoBehaviour {
    [Header("Alert frame")]
    [SerializeField] private Text header;
    [SerializeField] private Text context;
    [SerializeField] private Button positive;
    [SerializeField] private Button negative;

    [Header("Controllable alert dialog")]
    [SerializeField] private GameObject dimmer;
    [SerializeField] private GameObject dialog;

    public void SetAlertDialog(string header, string context, string positive, string negative) {
        this.header.text = header;
        this.context.text = context;
        this.positive.transform.GetChild(0).GetComponent<Text>().text = positive;
        this.negative.transform.GetChild(0).GetComponent<Text>().text = negative;

        SetActiveAlertDialog(true);
    }

    public void SetAlertDialog(string header, string context, string positive, string negative, bool positiveBold, bool negativeBold) {
        this.header.text = header;
        this.context.text = context;
        this.positive.transform.GetChild(0).GetComponent<Text>().text = positive;
        this.negative.transform.GetChild(0).GetComponent<Text>().text = negative;
        this.positive.transform.GetChild(0).GetComponent<Text>().fontStyle = positiveBold ? FontStyle.Bold : FontStyle.Normal;
        this.negative.transform.GetChild(0).GetComponent<Text>().fontStyle = negativeBold ? FontStyle.Bold : FontStyle.Normal;

        SetActiveAlertDialog(true);
    }

    public void SetAlertDialog(string header, string context, string positive, string negative, bool positiveBold, bool negativeBold, Color positiveColor, Color negativeColor) {
        this.header.text = header;
        this.context.text = context;
        this.positive.transform.GetChild(0).GetComponent<Text>().text = positive;
        this.negative.transform.GetChild(0).GetComponent<Text>().text = negative;
        this.positive.transform.GetChild(0).GetComponent<Text>().fontStyle = positiveBold ? FontStyle.Bold : FontStyle.Normal;
        this.negative.transform.GetChild(0).GetComponent<Text>().fontStyle = negativeBold ? FontStyle.Bold : FontStyle.Normal;
        if(positiveColor != Color.clear) { this.positive.transform.GetChild(0).GetComponent<Text>().color = positiveColor; }
        if(negativeColor != Color.clear) { this.negative.transform.GetChild(0).GetComponent<Text>().color = negativeColor; }

        SetActiveAlertDialog(true);
    }

    public void SetActiveAlertDialog(bool active) {
        dimmer.SetActive(active);
        dialog.SetActive(active);
    }
}
