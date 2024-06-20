using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy
{
    public float health;

    public virtual void GetDamage(float dmg)
    {
    }
}
