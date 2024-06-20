using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Shooting : MonoBehaviour
{
    //Shooting
    //[SerializeField] Animator triggerAnim;
    [SerializeField] Animator weaponAnim;
  //  [SerializeField] Transform WeaponShotObject;
    List<GameObject> bulletList;
    public GameObject bullet;
    [SerializeField] hitScanTest hitScan;
    public bool IsCanShootS;
    public bool IsCanShootP;
    Weapon weapon;
    //[SerializeField] GameObject wpObj;
    float rotateSpeed = 5.0f;
    public static Action shootP;
    public static Action shootS;

    public static Action shoot;
    public bool isCanShoot;

    bool isCanMeele;



    // public static bool isShot;
    // Start is called before the first frame update
    void Start()
    {
        isCanShoot = false;
        IsCanShootP = false;
        IsCanShootS = false;
    }

    public static void DaWpCanShoot()
    {
        shoot?.Invoke();   
    }

    private void Update()
    {
       // CheckDamage();
    }
    public void CheckDamage()
    {

      /*  if (IsCanShootP)
        {
            ShootP();
        }
        if (IsCanShootS)
        {
            ShootS();
        }*/

        if (isCanShoot) CanShoot();

    }
 


    void CanShoot()
    {
        shoot?.Invoke();
    }

    void ShootP()
    {
        Debug.Log("AAASDFGH");

        
        Debug.Log("AAASDASDYXYF");


        shootP?.Invoke();
        IsCanShootP = false;    


    }

    void ShootS()
    {
        Debug.Log("AAASDFGH");


        Debug.Log("AAASDASDYXYF");


        shootS?.Invoke();
        IsCanShootS = false;


    }

    private void OnDestroy()
    {
        shoot = null;
        shootP = null;
        shootS = null;
    }
}
