
using UnityEngine;

public class LootSystem : MonoBehaviour
{
    public enum LootType
    {
        Coins,
        Gems,
        Health,
        Pistol,
        Shotgun,
        Rifle
    }

    public LootType lootType;
    public int amount = 10;
    public float pickupDistance = 2f;

    private bool collected;

    private void Update()
    {
        if (collected)
            return;

        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            return;

        float distance = Vector3.Distance(
            transform.position,
            player.transform.position
        );

        if (distance <= pickupDistance)
        {
            Collect(player);
        }
    }

    private void Collect(GameObject player)
    {
        collected = true;

        switch (lootType)
        {
            case LootType.Coins:
                Debug.Log("Ai colectat monede: " + amount);
                break;

            case LootType.Gems:
                Debug.Log("Ai colectat diamante: " + amount);
                break;

            case LootType.Health:
                PlayerHealth health =
                    player.GetComponent<PlayerHealth>();

                if (health != null)
                    health.Heal(amount);
                break;

            case LootType.Pistol:
                SelectWeapon(player, 0);
                break;

            case LootType.Shotgun:
                SelectWeapon(player, 1);
                break;

            case LootType.Rifle:
                SelectWeapon(player, 2);
                break;
        }

        Destroy(gameObject);
    }

    private void SelectWeapon(GameObject player, int index)
    {
        WeaponSystem weaponSystem =
            player.GetComponent<WeaponSystem>();

        if (weaponSystem != null)
            weaponSystem.SelectWeapon(index);
    }
}
