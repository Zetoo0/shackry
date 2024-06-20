using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitchManager : MonoBehaviour
{
    public GameObject currentMeeleWp;
    public GameObject currentSecondaryWp;
    public GameObject currentMainWp;
    [SerializeField] private GameObject _playerHand;

    private bool switchFromMeele;
    private bool switchFromMain;
    private bool switchFromSecondary;

    private Quaternion targetRot;
    private Quaternion baseRot;

    [SerializeField] Vector3 weaponSwitchRotationVector;
    Vector3 weaponSwitchAnyad;
    Vector3 weaponBaseLocalRotationVector;
    // = Quaternion.Euler(1.0f,-190.0f,1.0f);

    [SerializeField] FiringSystemManager wpShootManager;
    
    [SerializeField] float rotationalSpeed;//speed value of weapon rotation on switch
    Vector3 targetRotation;//target rotation of the weapon
    [SerializeField]Transform rotPos;//position of the rotation
    public static bool onSwitch;
    GameObject switchFrom;
    GameObject SwitchTo;

    [SerializeField] private GameObject rotationPosition;
    private Quaternion ide;

    private Quaternion a, b,c,d;
    [SerializeField] float onWeaponSwitchRotationalAngle;
    
    public IWeapon activeWP;

    public static Action weaponChange;
    public enum CurrentActive
    {
        Meele,
        Secondary,
        Main
    };

    public CurrentActive wpHold = CurrentActive.Main;

    private void Start()
    {
        weaponSwitchAnyad = new Vector3(0,180,0);
        ide = Quaternion.Euler(weaponSwitchAnyad);
        // weaponBaseLocalRotationVector = 
        baseRot = currentMainWp.transform.localRotation;
        Debug.Log(baseRot);
        targetRot = Quaternion.Euler(weaponSwitchRotationVector); //Quaternion.Euler(weaponSwitchRotationVector);
        //targetRot.x = baseRot.x;
        //targetRot.y = baseRot.y;
    }

    private void Awake()
    {
        activeWP = GetComponentInChildren<IWeapon>();
        wpShootManager.SetCurrentActiveWeapon(activeWP);
    }

    public void WeaponSwitch(GameObject from, GameObject to, CurrentActive currActiveWpEnum)
    {
      //  RotateWeapon(from);
        from.transform.localRotation = baseRot;
        from.SetActive(false);
        to.SetActive(true);
       // rotationPosition.transform.localRotation = Quaternion.Slerp(targetRot, baseRot,
          //  rotationalSpeed * Time.fixedDeltaTime);
        //TODO go up from below to the target position
        wpShootManager.currActiveWpState = currActiveWpEnum;
        wpHold = currActiveWpEnum;
        IWeapon wp = to.GetComponent<IWeapon>();
        activeWP = wp;
        wpShootManager.SetCurrentActiveWeapon(wp);
        onSwitch = false;
        weaponChange?.Invoke();

      //  if(currActiveWpEnum != CurrentActive.Meele) GetComponentInChildren<GunGun>().ChangedAmmo();

    }



    private void Update()
    {
        
        //TODO
       /* if (onSwitch)
        {
            //rotationPosition.transform.localRotation = Quaternion.Euler(targetRot.eulerAngles)

          /*  float angle1 = 0.0f;
            Vector3 axis1 = Vector3.zero;
            switchFrom.transform.localRotation.ToAngleAxis(out angle1,out axis1);
            Debug.Log("Szaros angle: " + angle1);
            angle1 = 180f;
            switchFrom.transform.localRotation = Quaternion.AngleAxis(angle1, axis1);
          //  switchFrom.transform.localRotation = Quaternion.AngleAxis(330f, angle);
       //     switchFrom.transform.localRotation = Quaternion.Slerp(switchFrom.transform.localRotation, targetRot, 
         //      rotationalSpeed * Time.deltaTime);
            //d = Quaternion.Slerp(b, targetRot, rotationalSpeed * Time.deltaTime);
           //  targetRot = Quaternion.Slerp(targetRot, ide, rotationalSpeed * Time.deltaTime);
           //  Quaternion finalRot = d * c;
           
          // switchFrom.transform.Rotate(Vector3.right , onWeaponSwitchRotationalAngle*rotationalSpeed*Time.deltaTime, Space.Self);
           //switchFrom.transform.RotateAround(switchFrom.transform.position,Vector3.right, 360*Time.deltaTime*rotationalSpeed);
           StartCoroutine(RotateTheWeaponToDeactivate());
        }*/
    }

    IEnumerator WaitASec()
    {
        yield return new WaitForSecondsRealtime(1f);
        targetRot.z = -180f;
        targetRot.x = 0;
        switchFrom.transform.localRotation =
            Quaternion.RotateTowards(switchFrom.transform.localRotation, targetRot,360f * Time.deltaTime);
        
    }
    
    IEnumerator RotateTheWeaponToDeactivate()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        WeaponSwitch(switchFrom, SwitchTo, wpHold);
    }

    public void SwitchToMeele()
    {
        Debug.Log("Switched to meele");
        onSwitch = true;
        _playerHand.SetActive(false);
        switch (wpHold)
        {
            case CurrentActive.Secondary:
                switchFrom = currentSecondaryWp;
                SwitchTo = currentMeeleWp;
                wpHold = CurrentActive.Meele;
               WeaponSwitch(currentSecondaryWp, currentMeeleWp, CurrentActive.Meele);
                break;
            case CurrentActive.Main:
                switchFrom = currentMainWp;
                SwitchTo = currentMeeleWp;
                wpHold = CurrentActive.Meele;
               WeaponSwitch(currentMainWp, currentMeeleWp, CurrentActive.Meele);
                break;
        }
    }

    public void SwitchToSecondary()
    {
        Debug.Log("Switched to sec");
        onSwitch = true;

        switch (wpHold)
        {
            case CurrentActive.Main:
                switchFrom = currentMainWp;
                SwitchTo = currentSecondaryWp;
                wpHold = CurrentActive.Secondary;
                 WeaponSwitch(currentMainWp, currentSecondaryWp, CurrentActive.Secondary);
                break;
            case CurrentActive.Meele:
                switchFrom = currentMeeleWp;
                SwitchTo = currentSecondaryWp;
                wpHold = CurrentActive.Secondary;
                WeaponSwitch(currentMeeleWp, currentSecondaryWp, CurrentActive.Secondary);
                break;
        }
    }

    public void SwitchToMain()
    {
        Debug.Log("Switched to main");
        onSwitch = true;

        switch (wpHold)
        {
            case CurrentActive.Secondary:
                switchFrom = currentSecondaryWp;
                SwitchTo = currentMainWp;
                wpHold = CurrentActive.Main;
                WeaponSwitch(currentSecondaryWp, currentMainWp, CurrentActive.Main);
                break;
            case CurrentActive.Meele:
                _playerHand.SetActive(true);
                switchFrom = currentMeeleWp;
                SwitchTo = currentMainWp;
                wpHold = CurrentActive.Main;
                WeaponSwitch(currentMeeleWp, currentMainWp, CurrentActive.Main);
                break;
        }
    }
}
