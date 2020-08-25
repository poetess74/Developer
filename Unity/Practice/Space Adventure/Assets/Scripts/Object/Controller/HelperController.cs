using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class HelperController : MonoBehaviour {
    ThirdPersonCharacter NPCController;
    private const int helperMAXHP = 50;
    private int helperHP = 50;
    private bool guard = true;
    private void Start () {
        NPCController = GetComponent<ThirdPersonCharacter>();
    }

    private void Update () {
        if (guard) {
            NPCController.Move(Vector3.zero, true, false);
            guard = false;
        }
    }

    private void OnCollisionEnter (Collision col) {
        Debug.Log(gameObject.name + " collision " + col.gameObject.name + ". (tag: " + col.gameObject.tag + ")");
        switch (col.gameObject.tag) {
            case "Player":
                break;
            case "Weapon":
                helperHP -= BasicLaserController.ReturnDamage();
                General.targetName = gameObject.name;
                General.targetMAXHP = helperMAXHP;
                General.targetCNTHP = helperHP;
                General.targetRank = "T";
                break;
            default:
                break;
        }
    }
}
