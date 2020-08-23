using UnityEngine;

public class TutorialShuttleMessageController : MonoBehaviour {
    private int Signal;
    private bool Done;

    
    private void LateUpdate () {
        if (GamePlayManager.whoIs == "Shuttle") {
            IndexPath();
        }

        if (Input.GetMouseButtonDown(0) && GamePlayManager.TutorialShuttleReChat) {
            GamePlayManager.whoIs = "Shuttle";
            if (GamePlayManager.NextMessage && Done) {
                Done = false;
            }
            Message();
        }

        if (GamePlayManager.whoIs == "Shuttle") {
            if (GamePlayManager.NextMessage && Done) {
                Done = false;
            }
            Message();
        }

        GetComponent<ShuttleController>().enabled = GamePlayManager.isOnboard;
    }

    private void Message () {
        if (!GamePlayManager.TutorialShuttleReChat) {
            if (GamePlayManager.MessageShow && Signal == 0) {
                GamePlayManager.MessageTitle = "Tutorial Suttle";
                GamePlayManager.MessageText = "Hi! If you hard control in real, practice control in here.";
            }

            if (GamePlayManager.MessageShow && Signal == 1) {
                GamePlayManager.MessageTitle = "Tutorial Suttle";
                GamePlayManager.MessageText = "If you restart or end practice control tutotial talk me again.";
            }

            if (GamePlayManager.MessageShow && Signal == 2) {
                GamePlayManager.MessageTitle = "Tutorial Suttle";
                GamePlayManager.MessageText = "So let's get start!";
            }

            if (GamePlayManager.MessageShow && Signal == 3) {
                GamePlayManager.MessageTitle = "Tutorial Suttle - End Chat";
                GamePlayManager.MessageText = "Please exit chat press space.";
                if (Input.GetKeyUp(KeyCode.Space)) {
                    GamePlayManager.MessageShow = false;
                    GamePlayManager.TutorialShuttleReChat = true;
                    GamePlayManager.NextMessage = false;
                    Signal = 0;
                    Done = false;
                    GamePlayManager.Instance().SwithCamera();
                }
            }
        } else {
            if (GamePlayManager.MessageShow && Signal == 0) {
                GamePlayManager.MessageTitle = "Tutorial Suttle";
                GamePlayManager.MessageText = "Okay, now the tutorial is over.\n If you restart turorial talk me again.";
            }

            if (GamePlayManager.MessageShow && Signal == 1) {
                GamePlayManager.MessageTitle = "Tutorial Suttle - End Chat";
                GamePlayManager.MessageText = "Please exit chat press space.";
                if (Input.GetKeyUp(KeyCode.Space)) {
                    GamePlayManager.MessageShow = false;
                    GamePlayManager.NextMessage = false;
                    GamePlayManager.TutorialShuttleReChat = false;
                    Signal = 0;
                    Done = false;
                    GamePlayManager.Instance().SwithCamera();
                }
            }
        }
    }

    private void IndexPath () {
        if (GamePlayManager.MessageShow && !GamePlayManager.TutorialShuttleReChat && !Done) {
            if (GamePlayManager.NextMessage && Signal < 4) {
                Signal += 1;
                GamePlayManager.NextMessage = false;
            }
            Done = true;
        } else if (GamePlayManager.MessageShow && GamePlayManager.TutorialShuttleReChat && !Done) {
            if (GamePlayManager.NextMessage && Signal < 4) {
                Signal += 1;
                GamePlayManager.NextMessage = false;
            }
            Done = true;
        }
    }
}

