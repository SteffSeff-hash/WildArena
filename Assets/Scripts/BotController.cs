using UnityEngine;

public class BotController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float attackDistance = 2f;
    public int health = 100;

    private Transform target;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
            target = player.transform;
    }

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(
            transform.position, target.position
        );

        if (distance > attackDistance)
        {
            Vector3 direction =
                (target.position - transform.position).normalized;

            direction.y = 0;
            transform.position +=
                direction * moveSpeed * Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Destroy(gameObject);
    }
}
