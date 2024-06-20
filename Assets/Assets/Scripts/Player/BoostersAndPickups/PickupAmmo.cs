using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pickups/Ammo")]
public class PickupAmmo : Pickup
{
    public byte ammoPlusMinus;
    public static Action ammoPickedUp;
    public override void PickupStuff(GameObject parent)
    {
        if (parent.gameObject.CompareTag("Player"))
        {
            Debug.Log("parent tag:"+ parent.gameObject.tag.ToString());
            GunGun playerWeapon = parent.GetComponentInChildren<GunGun>();
            Debug.Log("Current magazine: " + playerWeapon.wp.magazine);
            playerWeapon.weaponMagazine += ammoPlusMinus;
            ammoPickedUp?.Invoke();
        }
    }
}
