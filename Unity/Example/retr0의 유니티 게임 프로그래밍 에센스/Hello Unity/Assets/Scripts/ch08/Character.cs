using UnityEngine;

public class Character : MonoBehaviour {
    public string playerName = "Jone";
    public float hp = 100;
    public float defense = 50;
    public float damage = 30;

    public delegate void Boost(Character target);
    public event Boost playerBoost;
    
    private void Start() {
        playerBoost(this);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            playerBoost(this);
        }
    }
}
