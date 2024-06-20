using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponGun", menuName = "Weapon/Meele")]
public class MeeleWeapon : ScriptableObject {
    public new string weaponName;
    public byte damage;
    public ElementType weaponELementType;
}
