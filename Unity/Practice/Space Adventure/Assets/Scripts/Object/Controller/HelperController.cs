using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class HelperController : MonoBehaviour {
    private const int helperMAXHP = 50;
    private int helperHP = 50;
    
    private void Start () {
        NPCDB.NPCFHP = helperMAXHP;
        NPCDB.NPCHP = helperHP;
        NPCDB.NPCRank = "T";
    }
}
