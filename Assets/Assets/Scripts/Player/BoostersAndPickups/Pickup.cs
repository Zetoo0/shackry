using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pickups")]
public class Pickup : ScriptableObject
{
    string pickupName;

    public virtual void PickupStuff(GameObject parent)
    {

    }
}
