using UnityEngine;

public class MonsterManager : MonoBehaviour {
    public int count {
        get {
            GameObject[] monsters = GameObject.FindGameObjectsWithTag("EditorOnly");
            return monsters.Length;
        }
    }
}
