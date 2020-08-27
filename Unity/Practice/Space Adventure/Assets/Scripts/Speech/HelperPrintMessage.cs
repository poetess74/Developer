using UnityEngine;

public class HelperPrintMessage : MonoBehaviour {
    private int Signal;
    private bool Done;

    private void LateUpdate () {
        if (PlayerDB.whoIs == "Helper") {
            IndexPath();
        }

        if (PlayerDB.whoIs == "Helper") {
            if (General.NextMessage && Done) {
                Done = false;
            }
            Message();
        }
    }

    private void Message () {
        if (!NPCDB.HelperReChat) {
            if (General.MessageShow && Signal == 0) {
                General.MessageTitle = "Helper";
                General.MessageText = "Welcome!\n This game is no funs Sky. \n" +
                    "If you wants some helps press key space";
            }

            if (General.MessageShow && Signal == 1) {
                General.MessageTitle = "Helper";
                General.MessageText = "This game will trip space. And it's very boring.";
            }

            if (General.MessageShow && Signal == 2) {
                General.MessageTitle = "Helper";
                General.MessageText = "So have a good trip!";
            }

            if (General.MessageShow && Signal == 3) {
                General.MessageTitle = "Helper - End Chat";
                General.MessageText = "Please exit chat press space.";
                if (Input.GetKeyUp(KeyCode.Space)) {
                    General.MessageShow = false;
                    NPCDB.HelperReChat = true;
                    General.NextMessage = false;
                    Signal = 0;
                    Done = false;
                }
            }
        } else {
            if (General.MessageShow && Signal == 0) {
                General.MessageTitle = "Helper";
                General.MessageText = "Ahh? What did I say?\n This Game is really funny!\n ";
            }
            if (General.MessageShow && Signal == 1) {
                General.MessageTitle = "Helper";
                General.MessageText = "That ship will teaching control.\n So have a good trip~!";
            }

            if (General.MessageShow && Signal == 2) {
                General.MessageTitle = "Helper - End Chat";
                General.MessageText = "Please exit chat press space.";
                if (Input.GetKeyUp(KeyCode.Space)) {
                    General.MessageShow = false;
                    General.NextMessage = false;
                    Signal = 0;
                    Done = false;
                }
            }
        }
    }

    private void IndexPath () {
        if (General.MessageShow && !NPCDB.HelperReChat && !Done) {
            if (General.NextMessage && Signal < 4) {
                Signal += 1;
                General.NextMessage = false;
            }
            Done = true;
        } else if (General.MessageShow && NPCDB.HelperReChat && !Done) {
            if (General.NextMessage && Signal < 3) {
                Signal += 1;
                General.NextMessage = false;
            }
            Done = true;
        }
    }
}
