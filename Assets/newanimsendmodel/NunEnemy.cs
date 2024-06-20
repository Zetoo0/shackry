using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NunEnemy : BaseEnemy
{
    private float health;
    private bool isDead;

    public NunEnemy(float health)
    {
        this.health = health;
    }
    
    public override void GetDamage(float dmg)
    {
        this.health -= dmg;
        if (this.health <= 0) isDead = true;
    }

    public bool Dead()
    {
        if (this.isDead) return true;
        return false;
    }
}
   