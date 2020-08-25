using UnityEngine;

public class NPCDB : MonoBehaviour {
    public static NPCDB instance;

    public static string NPCName;
    public static int NPCFHP;
    public static int NPCHP;
    public static string NPCRank;

    public static bool HelperReChat;

    private void Awake () {
        instance = this;
    }

    public static NPCDB Instance () {
        return NPCDB.instance;
    }
}
