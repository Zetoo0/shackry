using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilSystem : MonoBehaviour
{
    public Transform RotationPosition;
    public Transform RecoilPosition;

    public float positionalRecoilSpeed;
    public float rotationalRecoilSpeed;
    public float positionalReturnSpeed;
    public float rotationalReturnSpeed;

    public Vector3 recoilRotation;
    public Vector3 recoilKickback;


    Vector3 PositionalRec;
    Vector3 RotationalRec;
    Vector3 targetRot;

    public bool isRecoil;

    private void Update()
    {
        FixedRecoilUpdate();

    }

    // Update is called once per frame


    private void FixedRecoilUpdate()
    {
        //if (!WeaponSwitchManager.onSwitch)
       // {
            PositionalRec = Vector3.Lerp(PositionalRec, Vector3.zero, positionalReturnSpeed * Time.deltaTime);
            RotationalRec = Vector3.Lerp(RotationalRec, Vector3.zero, rotationalReturnSpeed * Time.deltaTime);

            RecoilPosition.localPosition = Vector3.Slerp(RecoilPosition.localPosition, PositionalRec, positionalRecoilSpeed * Time.fixedDeltaTime);

            // currRot = Vector3.Lerp(currRot, Vector3.zero, retSpeed * Time.deltaTime);
            targetRot = Vector3.Slerp(targetRot, RotationalRec, rotationalRecoilSpeed * Time.fixedDeltaTime);
            RotationPosition.localRotation = Quaternion.Euler(targetRot);
        //}
        
    }
    
    public void OnRecoil()
    {
        Debug.Log("ROTÁLJÁÁÁÁÁÁÁL LÖVÉSKOR ");
        RotationalRec += new Vector3(-35.0f, Random.Range(0, recoilRotation.y), Random.Range(0, recoilRotation.z));
        PositionalRec += new Vector3(Random.Range(0, recoilKickback.x), Random.Range(0, recoilKickback.y), recoilKickback.z);
    }

}
