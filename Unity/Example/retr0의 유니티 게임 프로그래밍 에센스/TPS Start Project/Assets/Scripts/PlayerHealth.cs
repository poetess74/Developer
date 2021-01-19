using UnityEngine;

public class PlayerHealth : LivingEntity {
    public AudioClip deathClip;
    public AudioClip hitClip;
    private Animator animator;
    private AudioSource playerAudioPlayer;


    private void Awake() {
        playerAudioPlayer = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    protected override void OnEnable() {
        base.OnEnable();
    }

    public override void RestoreHealth(float newHealth) {
        base.RestoreHealth(newHealth);
    }

    private void UpdateUI() {
        UIManager.Instance.UpdateHealthText(dead ? 0f : health);
    }

    public override bool ApplyDamage(DamageMessage damageMessage) {
        if(!base.ApplyDamage(damageMessage)) return false;


        return true;
    }

    public override void Die() {
        base.Die();
    }
}