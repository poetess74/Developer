using System.Collections;
using InGame.Player;
using UnityEngine;

namespace InGame.Item {
    public class GoldPickUp : MonoBehaviour, IPickable {
        public readonly string itemName = "Gold";
        public int effectAmount;

        private PlayerStatus player;

        public void ItemPickUp() {
            player = FindObjectOfType<PlayerStatus>();
            player.gold += effectAmount;

            Destroy(gameObject);
        }

        public void ItemDestroy() {
            StartCoroutine(DestroyItem());
        }

        private IEnumerator DestroyItem() {
            float timer = 0f;
            while(timer > 10f) {
                yield return new WaitForSeconds(0.01f);
                timer += 0.01f;
            }

            Destroy(gameObject);
        }
    }
}
