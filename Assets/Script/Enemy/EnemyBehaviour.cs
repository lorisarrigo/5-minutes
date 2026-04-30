using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    GameObject collObj;
    [SerializeField] float Dam;
    private void OnTriggerEnter2D(Collider2D other)
    {
        collObj = other.gameObject;

        if (collObj == null) return;
        collObj.TryGetComponent(out IDamageable dmg);
        collObj.TryGetComponent(out Player pl);

        if (dmg == null) return;
        dmg.TakeDamage(Dam);

        if (pl == null) return;
        if (pl.currentHealth <= 0)
        {
            dmg.Despawn();
        }
    }
}
