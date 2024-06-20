using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="WeaponGun", menuName ="Weapon/Gun")]
public partial class RangedWeapon : ScriptableObject
{
    public new string weaponName;
        
    public byte damage;
    public byte fireRate;
    public bool isCanBurst;
    public byte magazine;
    public byte maximumLoadableBullet;
    public float distance;
    public AmmoType WPBulletType;
    public ElementType weaponElementType;
    public WeaponBulletSpecial WPBSpecial;

    public float recoilRotationX;
    public float recoilRotationY;
    public float recoilRotationZ;

    public float recoilKickbackX;
    public float recoilKickbackY;
    public float recoilKickbackZ;
}
