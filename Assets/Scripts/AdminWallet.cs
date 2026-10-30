
using UnityEngine;

public class AdminWallet : MonoBehaviour
{
    public int coins;
    public int gems;

    public bool isAdmin;

    void Start()
    {
        if (isAdmin)
        {
            coins = 999999999;
            gems = 999999999;
        }
        else
        {
            coins = 1000;
            gems = 100;
        }
    }

    public void AddCoins(int amount)
    {
        coins += Mathf.Max(0, amount);
    }

    public void AddGems(int amount)
    {
        gems += Mathf.Max(0, amount);
    }

    public bool SpendCoins(int amount)
    {
        if (amount < 0 || coins < amount)
            return false;

        coins -= amount;
        return true;
    }
}
