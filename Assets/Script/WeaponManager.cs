using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Transform weaponHolder;

    public Weapon CurrentWeapon { get; private set; }

    private void Start()
    {
        // Player starts with no weapon.
        CurrentWeapon = null;
    }

    public void PickUpWeapon(Weapon newWeapon)
    {
        if (newWeapon == null)
            return;

        // Drop the gun we're currently holding.
        if (CurrentWeapon != null)
        {
            DropCurrentWeapon();
        }

        // Pick up new gun.
        newWeapon.transform.SetParent(weaponHolder);

        newWeapon.transform.localPosition = newWeapon.heldPosition;
        newWeapon.transform.localRotation =
            Quaternion.Euler(newWeapon.heldRotation);

        Rigidbody rb = newWeapon.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        Collider col = newWeapon.GetComponent<Collider>();

        if (col != null)
        {
            col.enabled = false;
        }

        CurrentWeapon = newWeapon;
    }

    private void DropCurrentWeapon()
    {
        Weapon oldWeapon = CurrentWeapon;

        oldWeapon.transform.SetParent(null);

        oldWeapon.transform.position =
            transform.position +
            transform.forward * 1.5f +
            Vector3.up * 0.5f;

        Collider col = oldWeapon.GetComponent<Collider>();

        if (col != null)
        {
            col.enabled = true;
        }

        Rigidbody rb = oldWeapon.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = false;
            rb.AddForce(transform.forward * 2f, ForceMode.Impulse);
        }

        CurrentWeapon = null;
    }
}