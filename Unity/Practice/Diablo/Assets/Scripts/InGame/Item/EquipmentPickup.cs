using System.Collections;
using UnityEngine;

namespace InGame.Item {
    public class EquipmentPickup : MonoBehaviour, IPickable {
        public string itemName;
        public string description;
        public bool isRare;

        public void ItemPickUp() {
            throw new System.NotImplementedException();
        }

        public void ItemDestroy() {
            if(isRare) return;
            StartCoroutine(DestroyItem());
        }

        private IEnumerator DestroyItem() {
            float timer = 0f;
            while(timer > 60f) {
                yield return new WaitForSeconds(0.01f);
                timer += 0.01f;
            }

            Destroy(gameObject);
        }
    }
}
