using UnityEngine;

public class HealthPack : MonoBehaviour, IItem {
    [SerializeField] private float health = 50;

    public void Use(GameObject target) {
        var leavingEntity = target.GetComponent<LivingEntity>();
        if(leavingEntity != null) {
            leavingEntity.RestoreHealth(health);
        }
        Destroy(gameObject);
    }
}