using UnityEngine;

public class WeaponPickup : MonoBehaviour, IInteractable
{
    private Weapon weapon;

    private void Awake()
    {
        weapon = GetComponent<Weapon>();
    }

    public string GetInteractText()
    {
        return "[E] PICK UP " + weapon.weaponName;
    }

    public void Interact()
    {
        WeaponManager manager =
            FindFirstObjectByType<WeaponManager>();

        if (manager != null)
        {
            manager.PickUpWeapon(weapon);
        }
    }
}