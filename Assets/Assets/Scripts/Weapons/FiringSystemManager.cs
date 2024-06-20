using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringSystemManager : MonoBehaviour
{
    [SerializeField] MeeleManager meeleMg;//meele
    [SerializeField] Shooting primaryMg;//primary
    [SerializeField] Shooting secondaryMg;//secondary
    [SerializeField] WeaponSwitchManager wpSwitchMan;
    public WeaponSwitchManager.CurrentActive currActiveWpState;
    [SerializeField]public IWeapon currentActiveWeapon;

   
    private void Start()
    {
        currActiveWpState = wpSwitchMan.wpHold;
    }


    public void SetCurrentActiveWeapon(IWeapon wp)
    {
        currentActiveWeapon = wp;
        Debug.Log("Current Active weapon is set");
    }
    
    public void OnFirePressed()
    {
        Debug.Log("Current active weapon: " + currentActiveWeapon);
        currentActiveWeapon.Attack();
        /*switch (currActiveWpState)
        {
            case WeaponSwitchManager.CurrentActive.Meele:
                meeleMg.isCanMeele = true;
                // isCanMeele = true;
                break;
            case WeaponSwitchManager.CurrentActive.Secondary:
                print("Eljutottam idáig?");
                Shooting.DaWpCanShoot();
               // IsCanShoot = true;
                break;
            case WeaponSwitchManager.CurrentActive.Main:
                Shooting.DaWpCanShoot();
                //primaryMg.IsCanShootS = true;
               // IsCanShoot = true;
                break;
        }*/
    }
}
