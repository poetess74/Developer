using UnityEngine;

public abstract class Monster : MonoBehaviour {
    private float damage = 100f;

    // Update is called once per frame
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Attack();
        }
    }

    protected abstract void Attack();

    private class Goblin : Monster {
        protected override void Attack() {
            Debug.LogFormat("한 캐릭터를 공격했다. 공격력: {0}", damage);
        }
    }
    
    private class Orc : Monster {
        protected override void Attack() {
            Debug.LogFormat("광역 공격을 했다. 공격력: {0}", damage);
        }
    }
}
