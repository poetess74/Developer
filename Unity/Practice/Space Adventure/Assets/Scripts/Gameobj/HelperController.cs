using UnityEngine;

public class HelperController : MonoBehaviour {
    private int Signal;
    private bool Done;

    private void LateUpdate () {
        if (GamePlayManager.whoIs == "Helper") {
            IndexPath();
        }

        if (GamePlayManager.whoIs == "Helper") {
            if (GamePlayManager.NextMessage && Done) {
                Done = false;
            }
            Message();
        }
    }

    private void Message () {
        if (!GamePlayManager.HelperReChat) {
            if (GamePlayManager.MessageShow && Signal == 0) {
                GamePlayManager.MessageTitle = "Helper";
                GamePlayManager.MessageText = "Welcome!\n This game is no funs Sky. \n" +
                    "If you wants some helps press key space";
            }

            if (GamePlayManager.MessageShow && Signal == 1) {
                GamePlayManager.MessageTitle = "Helper";
                GamePlayManager.MessageText = "This game will trip space. And it's very boring.";
            }

            if (GamePlayManager.MessageShow && Signal == 2) {
                GamePlayManager.MessageTitle = "Helper";
                GamePlayManager.MessageText = "So have a good trip!";
            }

            if (GamePlayManager.MessageShow && Signal == 3) {
                GamePlayManager.MessageTitle = "Helper - End Chat";
                GamePlayManager.MessageText = "Please exit chat press space.";
                if (Input.GetKeyUp(KeyCode.Space)) {
                    GamePlayManager.MessageShow = false;
                    GamePlayManager.HelperReChat = true;
                    GamePlayManager.NextMessage = false;
                    Signal = 0;
                    Done = false;
                }
            }
        } else {
            if (GamePlayManager.MessageShow && Signal == 0) {
                GamePlayManager.MessageTitle = "Helper";
                GamePlayManager.MessageText = "Ahh? What did I say?\n This Game is really funny!\n ";
            }
            if (GamePlayManager.MessageShow && Signal == 1) {
                GamePlayManager.MessageTitle = "Helper";
                GamePlayManager.MessageText = "That ship will teaching control.\n So have a good trip~!";
            }

            if (GamePlayManager.MessageShow && Signal == 2) {
                GamePlayManager.MessageTitle = "Helper - End Chat";
                GamePlayManager.MessageText = "Please exit chat press space.";
                if (Input.GetKeyUp(KeyCode.Space)) {
                    GamePlayManager.MessageShow = false;
                    GamePlayManager.NextMessage = false;
                    Signal = 0;
                    Done = false;
                }
            }
        }
    }

    private void IndexPath () {
        if (GamePlayManager.MessageShow && !GamePlayManager.HelperReChat && !Done) {
            if (GamePlayManager.NextMessage && Signal < 4) {
                Signal += 1;
                GamePlayManager.NextMessage = false;
            }
            Done = true;
        } else if (GamePlayManager.MessageShow && GamePlayManager.HelperReChat && !Done) {
            if (GamePlayManager.NextMessage && Signal < 3) {
                Signal += 1;
                GamePlayManager.NextMessage = false;
            }
            Done = true;
        }
    }
}
