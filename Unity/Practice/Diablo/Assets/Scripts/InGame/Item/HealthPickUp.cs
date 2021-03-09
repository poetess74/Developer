using System.Collections;
using InGame.Player;
using UnityEngine;

namespace InGame.Item {
    public class HealthPickUp : MonoBehaviour, IPickable {
        public readonly string itemName = "Health";
        public int effectAmount;

        private PlayerStatus player;

        public void ItemPickUp() {
            player = FindObjectOfType<PlayerStatus>();
            player.healthPointCNT = Utility.remainResourceProcess(
                player.healthPoint, player.healthPointCNT, effectAmount
            );

            Destroy(gameObject);
        }

        public void ItemDestroy() {
            StartCoroutine(DestroyItem());
        }

        private IEnumerator DestroyItem() {
            float timer = 0f;
            while(timer > 30f) {
                yield return new WaitForSeconds(0.01f);
                timer += 0.01f;
            }

            Destroy(gameObject);
        }
    }
}
