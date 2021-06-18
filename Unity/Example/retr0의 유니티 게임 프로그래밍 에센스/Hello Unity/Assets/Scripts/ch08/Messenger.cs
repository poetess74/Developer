using UnityEngine;

public class Messenger : MonoBehaviour {
    private delegate void Send(string receiver);
    private event Send onSend;

    private void SendMail(string receiver) {
        Debug.LogFormat("Mail sent to: {0}", receiver);
    }
    
    private void SendMoney(string receiver) {
        Debug.LogFormat("Money sent to: {0}", receiver);
    }
    
    // Start is called before the first frame update
    private void Start() {
        onSend += SendMail;
        onSend += SendMoney;
        //float a = 3.14f;
        onSend += man => Debug.LogFormat("Assassinate {0}", man);
        onSend += (string man) => {
            Debug.LogFormat("Assassinate {0}", man);
            Debug.Log("Hide body");
        };
    }

    // Update is called once per frame
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            onSend("Jone");
        }
    }
}
