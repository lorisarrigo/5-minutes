using UnityEngine;

public abstract class Damage : MonoBehaviour
{
    GameObject collObj;
    protected void OnTriggerEnter2D(Collider2D other)
    {
        collObj = other.gameObject;

        if (collObj == null) return;
        collObj.TryGetComponent(out IDamageable dmg);
        collObj.TryGetComponent(out Player pl);

        if (dmg == null) return;
        dmg.TakeDamage(1);

        if (pl == null) return;
        if (pl.currentHealth <= 0)
        {
            dmg.Despawn();
        }
    }
}
