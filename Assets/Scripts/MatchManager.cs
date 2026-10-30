
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public float checkInterval = 1f;

    private float timer;
    private bool matchFinished;

    private void Update()
    {
        if (matchFinished)
            return;

        timer += Time.deltaTime;

        if (timer >= checkInterval)
        {
            timer = 0f;
            CheckMatchStatus();
        }
    }

    private void CheckMatchStatus()
    {
        GameObject[] players =
            GameObject.FindGameObjectsWithTag("Player");

        GameObject[] bots =
            GameObject.FindGameObjectsWithTag("Bot");

        int alivePlayers = CountAlive(players);
        int aliveBots = CountAlive(bots);

        if (alivePlayers == 0)
        {
            FinishMatch("Ai fost eliminat!");
        }
        else if (alivePlayers == 1 && aliveBots == 0)
        {
            FinishMatch("VICTORIE! Ai câștigat arena!");
        }
    }

    private int CountAlive(GameObject[] characters)
    {
        int count = 0;

        foreach (GameObject character in characters)
        {
            if (character != null &&
                character.activeInHierarchy)
            {
                count++;
            }
        }

        return count;
    }

    private void FinishMatch(string message)
    {
        matchFinished = true;
        Debug.Log(message);
        Time.timeScale = 0f;
    }
}
