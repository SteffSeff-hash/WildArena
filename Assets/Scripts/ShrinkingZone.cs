
using UnityEngine;

public class ShrinkingZone : MonoBehaviour
{
    [Header("Zone Settings")]
    public float startRadius = 40f;
    public float minimumRadius = 5f;
    public float shrinkSpeed = 0.5f;
    public float damageInterval = 1f;
    public int outsideDamage = 5;

    private float currentRadius;
    private float damageTimer;

    private void Start()
    {
        currentRadius = startRadius;
        UpdateZoneVisual();
    }

    private void Update()
    {
        if (currentRadius > minimumRadius)
        {
            currentRadius -= shrinkSpeed * Time.deltaTime;
            currentRadius = Mathf.Max(
                currentRadius,
                minimumRadius
            );

            UpdateZoneVisual();
        }

        damageTimer += Time.deltaTime;

        if (damageTimer >= damageInterval)
        {
            damageTimer = 0f;
            DamagePlayersOutsideZone();
        }
    }

    private void UpdateZoneVisual()
    {
        transform.localScale = new Vector3(
            currentRadius * 2f,
            0.2f,
            currentRadius * 2f
        );
    }

    private void DamagePlayersOutsideZone()
    {
        GameObject[] players =
            GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(
                transform.position,
                player.transform.position
            );

            if (distance > currentRadius)
            {
                PlayerHealth health =
                    player.GetComponent<PlayerHealth>();

                if (health != null)
                {
                    health.TakeDamage(outsideDamage);
                }
            }
        }

        GameObject[] bots =
            GameObject.FindGameObjectsWithTag("Bot");

        foreach (GameObject bot in bots)
        {
            float distance = Vector3.Distance(
                transform.position,
                bot.transform.position
            );

            if (distance > currentRadius)
            {
                BotController controller =
                    bot.GetComponent<BotController>();

                if (controller != null)
                {
                    controller.TakeDamage(outsideDamage);
                }
            }
        }
    }
}
