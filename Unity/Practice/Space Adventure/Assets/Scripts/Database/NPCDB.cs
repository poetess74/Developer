using UnityEngine;

public class NPCDB : MonoBehaviour {
    public static NPCDB instance;

    public static bool HelperReChat;

    private void Awake () {
        instance = this;
    }

    public static NPCDB Instance () {
        return NPCDB.instance;
    }
}
