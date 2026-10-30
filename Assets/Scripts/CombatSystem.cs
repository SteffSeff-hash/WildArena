
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    [Header("Combat Settings")]
    public float attackRange = 3f;
    public float attackCooldown = 1f;
    public int damage = 25;

    private float nextAttackTime;

    public void Attack()
    {
        if (Time.time < nextAttackTime)
            return;

        nextAttackTime = Time.time + attackCooldown;

        Collider[] targets = Physics.OverlapSphere(
            transform.position,
            attackRange
        );

        foreach (Collider target in targets)
        {
            if (target.gameObject == gameObject)
                continue;

            PlayerHealth health =
                target.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(damage);
                continue;
            }

            BotController bot =
                target.GetComponent<BotController>();

            if (bot != null)
            {
                bot.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(
            transform.position,
            attackRange
        );
    }
}
