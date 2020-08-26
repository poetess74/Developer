using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class NPCController : MonoBehaviour {
    ThirdPersonCharacter npcCharacter;
    
    public enum NPCState { Idle, Trace, Attack, Runaway, Dead }
    public NPCState cntState = NPCState.Idle;
    private float traceDist = 15.0f;
    private float attackDist = 3f;
    private bool isDead = false;

    private Transform _transform;
    private Transform targetTransform;
    
    void Start() {
        _transform = gameObject.GetComponent<Transform>();
        npcCharacter = GetComponent<ThirdPersonCharacter>();
    }

    void Update() {
        StartCoroutine(CheckStateForAction());
        if(NPCDB.NPCHP <= 0) {
            Destroy(gameObject);
        }
    }    
    
    private void OnCollisionEnter (Collision col) {
        Debug.Log(gameObject.name + " collision " + col.gameObject.name + ". (tag: " + col.gameObject.tag + ")");
        switch (col.gameObject.tag) {
            case "Player":
                break;
            case "Weapon":
                NPCDB.NPCName = gameObject.name;
                NPCDB.NPCHP -= BasicLaserController.ReturnDamage();
                General.Target = gameObject;
                targetTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
                StartCoroutine(this.CheckState());
                break;
        }
    }

    private IEnumerator CheckState() {
        while(!isDead) {
            int HP = NPCDB.NPCHP;
            yield return new WaitForSeconds(0.2f);
            float distance = Vector3.Distance(targetTransform.position, _transform.position);
            
            if(distance <= attackDist) {
                cntState = NPCState.Attack;
            } else if(distance <= traceDist) {
                cntState = NPCState.Trace;
            } else if(HP < NPCDB.NPCHP) {
                cntState = NPCState.Runaway;
            } else {
                cntState = NPCState.Idle;
            }
        }
    }

    private IEnumerator CheckStateForAction() {
        while(!isDead) {
            switch(cntState) {
                case NPCState.Idle:
                    npcCharacter.Move(new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), false, false);
                    break;
                case NPCState.Trace:
                    npcCharacter.Move(targetTransform.position, false, false);
                    break;
                case NPCState.Runaway:
                    npcCharacter.Move(-targetTransform.position, true, false);
                    break;
                case NPCState.Attack:
                    break;
            }

            yield return null;
        }
    }
}
