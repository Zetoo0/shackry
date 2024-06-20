using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    [SerializeField] public Transform FeetPlace;
    [SerializeField] PlayerMotion Movement;

    //Fall Damage Params
    [SerializeField] float FallDmgMinDistance;
    [SerializeField] float FallDmgDistanceRangeUpgrade;
    [SerializeField] public float FallDmgDamageMultiplier;
    [SerializeField] float FallDmgBaseDamage;

    // Start is called before the first frame update



    // Update is called once per frame

    //K�s�bb �t�r�s nem voidra
    public float CheckGroundDistance()
    {
        RaycastHit hit;

        float distance = 0.0f;
        if(Physics.Raycast(FeetPlace.position, Vector3.down, out hit)){
            if (hit.transform.CompareTag("Ground"))
            {
              //  Debug.Log("T�vols�g a kurvaistenit");
                distance = hit.distance;
               // Debug.Log("Distance: " + distance);
            }
        }

        return distance;
       
    }

    

}
