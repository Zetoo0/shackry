using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Weapon", order = 1)]
public class WeaponSO : ScriptableObject
{
    public new string weaponName;

    public WeaponType weaponType;
    
    public byte damage;
    public byte fireRate;
    public bool isCanBurst;
    public byte magazine;
    public float distance;

    
    public AmmoType WPBulletType;
    public WeaponBulletSpecial WPBSpecial;


    public float recoilX;
    public float recoilY;
    public float recoilZ;



}
