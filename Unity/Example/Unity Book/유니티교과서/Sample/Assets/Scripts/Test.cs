using UnityEngine;

public class Player {
    private int hp = 100;
    private int power = 50;

    public void Attack() {
        Debug.Log(this.power + "Give Damage");
    }

    public void Damage(int damage) {
        this.hp -= damage;
        Debug.Log(damage + "Get Damage");
    }
}

public class Test : MonoBehaviour {
    private void Start () {
        Player myPlayer = new Player();
        myPlayer.Attack();
        myPlayer.Damage(30);
    }
}
