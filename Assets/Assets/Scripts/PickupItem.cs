using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]Pickup pickup;
    [SerializeField]GameObject Player;

    

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pickup.PickupStuff(collision.gameObject);
            Debug.Log("Picked up daa stuff");
            gameObject.SetActive(false);
        }
    }
}
