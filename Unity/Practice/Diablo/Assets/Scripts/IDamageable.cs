using UnityEngine;

public interface IDamageable {
    public bool Damaged(float damageAmount, bool isKnockBack, GameObject attackObject);
    public void Die(GameObject expGiven);
}