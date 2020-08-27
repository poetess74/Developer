using UnityEngine;

public class TutorialShuttleMessage : MonoBehaviour {
    private int Signal;
    private bool Done;

    
    private void LateUpdate () {
        if (PlayerDB.whoIs == "Shuttle") {
            IndexPath();
        }

        if (Input.GetMouseButtonDown(0) && ShuttleDB.TutorialShuttleReChat) {
            PlayerDB.whoIs = "Shuttle";
            General.Instance().SwithCamera();
            if (General.NextMessage && Done) {
                Done = false;
            }
            Message();
        }

        if (PlayerDB.whoIs == "Shuttle") {
            if (General.NextMessage && Done) {
                Done = false;
            }
            Message();
        }

        GetComponent<ShuttleController>().enabled = PlayerDB.isOnboard;
    }

    private void Message () {
        if (!ShuttleDB.TutorialShuttleReChat && !PlayerDB.isOnboard) {
            if (General.MessageShow && Signal == 0) {
                General.MessageTitle = "Tutorial Suttle";
                General.MessageText = "Hi! If you hard control in real, practice control in here.";
            }

            if (General.MessageShow && Signal == 1) {
                General.MessageTitle = "Tutorial Suttle";
                General.MessageText = "If you restart or end practice control tutotial talk me again.";
            }

            if (General.MessageShow && Signal == 2) {
                General.MessageTitle = "Tutorial Suttle";
                General.MessageText = "So let's get start!";
            }

            if (General.MessageShow && Signal == 3) {
                General.MessageTitle = "Tutorial Suttle - End Chat";
                General.MessageText = "Please exit chat press space.";
                if (Input.GetKeyUp(KeyCode.Space)) {
                    General.MessageShow = false;
                    ShuttleDB.TutorialShuttleReChat = true;
                    General.NextMessage = false;
                    Signal = 0;
                    Done = false;
                    General.Instance().SwithCamera();
                }
            }
        } else {
            if (General.MessageShow && Signal == 0) {
                General.MessageTitle = "Tutorial Suttle";
                General.MessageText = "Okay, now the tutorial is over.\n If you restart turorial talk me again.";
            }

            if (General.MessageShow && Signal == 1) {
                General.MessageTitle = "Tutorial Suttle - End Chat";
                General.MessageText = "Please exit chat press space.";
                if (Input.GetKeyUp(KeyCode.Space)) {
                    General.MessageShow = false;
                    General.NextMessage = false;
                    ShuttleDB.TutorialShuttleReChat = false;
                    Signal = 0;
                    Done = false;
                }
            }
        }
    }

    private void IndexPath () {
        if (General.MessageShow && !ShuttleDB.TutorialShuttleReChat && !Done) {
            if (General.NextMessage && Signal < 4) {
                Signal += 1;
                General.NextMessage = false;
            }
            Done = true;
        } else if (General.MessageShow && ShuttleDB.TutorialShuttleReChat && !Done) {
            if (General.NextMessage && Signal < 4) {
                Signal += 1;
                General.NextMessage = false;
            }
            Done = true;
        }
    }
}

