using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public  class Weapon : MonoBehaviour
{
    public  byte damageHead {  get;  set; }
    public  byte damageBody {  get;  set; }
    public  byte damageArm {  get;  set; }
    public  byte damageLeg {  get;  set; }
    public  byte fireRate {  get;  set; }
    public  bool isCanBurst {  get;  set; }
    public  byte magazine {  get;  set; }
    public  float distance {  get;  set; }



    public void ShootFire()
    {
        int[] hitIndex = { damageHead, damageBody, damageArm, damageLeg };
        int hitI;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                // shotD = hit.distance;
                //  print(shotD);
                string layername = hit.collider.gameObject.name;
                hitI = Convert.ToInt16(layername);
                print(hitIndex[hitI]);
                print(layername);
                StartCoroutine(hit.collider.gameObject.GetComponent<PlayerMotion>().player.GetDamage((byte)hitIndex[hitI]));
            }
        }
    }
}




