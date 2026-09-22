using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon")]
    public string weaponName;

    [Header("Shooting")]
    public float fireDelay = 0.2f;
    public float recoil = 2f;
    public float spread = 0f;

    [Header("References")]
    public Transform muzzlePoint;

    [Header("How This Gun Sits In Hand")]
    public Vector3 heldPosition;
    public Vector3 heldRotation;

    [Header("Pickup")]
    public GameObject worldPrefab;
}