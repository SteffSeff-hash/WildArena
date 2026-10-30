
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    [Header("Arena Settings")]
    public float arenaRadius = 50f;
    public float minimumRadius = 5f;
    public float shrinkSpeed = 0.5f;
    public float shrinkDelay = 30f;

    [Header("Battle Settings")]
    public int maximumPlayers = 20;
    public int botsToSpawn = 10;
    public GameObject botPrefab;

    private float timer;
    private bool shrinking;

    void Start()
    {
        timer = shrinkDelay;
        SpawnBots();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
            shrinking = true;

        if (shrinking && arenaRadius > minimumRadius)
        {
            arenaRadius -= shrinkSpeed * Time.deltaTime;
            arenaRadius = Mathf.Max(arenaRadius, minimumRadius);
        }
    }

    void SpawnBots()
    {
        if (botPrefab == null) return;

        for (int i = 0; i < botsToSpawn; i++)
        {
            Vector2 randomPosition =
                Random.insideUnitCircle * arenaRadius * 0.8f;

            Vector3 spawnPosition = new Vector3(
                randomPosition.x,
                0f,
                randomPosition.y
            );

            Instantiate(
                botPrefab,
                spawnPosition,
                Quaternion.identity
            );
        }
    }

    public bool IsInsideArena(Vector3 position)
    {
        return new Vector2(position.x, position.z).magnitude
               <= arenaRadius;
    }
}
