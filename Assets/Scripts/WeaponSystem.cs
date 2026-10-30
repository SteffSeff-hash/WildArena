
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [System.Serializable]
    public class Weapon
    {
        public string weaponName;
        public int damage;
        public float range;
        public float fireRate;
    }

    [Header("Available Weapons")]
    public Weapon[] weapons =
    {
        new Weapon
        {
            weaponName = "Pistol",
            damage = 20,
            range = 12f,
            fireRate = 0.5f
        },
        new Weapon
        {
            weaponName = "Shotgun",
            damage = 45,
            range = 6f,
            fireRate = 1.2f
        },
        new Weapon
        {
            weaponName = "Rifle",
            damage = 15,
            range = 20f,
            fireRate = 0.15f
        }
    };

    private int currentWeaponIndex = 0;
    private float nextFireTime;

    public void SelectWeapon(int index)
    {
        if (index < 0 || index >= weapons.Length)
            return;

        currentWeaponIndex = index;
    }

    public void NextWeapon()
    {
        if (weapons.Length == 0)
            return;

        currentWeaponIndex =
            (currentWeaponIndex + 1) % weapons.Length;
    }

    public void Fire()
    {
        if (weapons.Length == 0)
            return;

        if (Time.time < nextFireTime)
            return;

        Weapon weapon = weapons[currentWeaponIndex];

        nextFireTime = Time.time + weapon.fireRate;

        RaycastHit hit;

        Vector3 direction = transform.forward;

        if (Physics.Raycast(
            transform.position + Vector3.up,
            direction,
            out hit,
            weapon.range))
        {
            PlayerHealth health =
                hit.collider.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(weapon.damage);
                return;
            }

            BotController bot =
                hit.collider.GetComponent<BotController>();

            if (bot != null)
            {
                bot.TakeDamage(weapon.damage);
            }
        }
    }

    public string GetCurrentWeaponName()
    {
        if (weapons.Length == 0)
            return "No weapon";

        return weapons[currentWeaponIndex].weaponName;
    }
}
