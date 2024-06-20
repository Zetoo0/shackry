using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pickups/Health")]
public class PickupHealth : Pickup
{
    public short healthPlusOrMinus;

    public override void PickupStuff(GameObject parent)
    {
        Player player = parent.GetComponent<PlayerMotion>().player;
        player.health += healthPlusOrMinus;
        player.TextManager.AddToHealth(healthPlusOrMinus);
    }
}
