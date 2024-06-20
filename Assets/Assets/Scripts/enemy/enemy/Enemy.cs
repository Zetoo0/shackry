
using UnityEngine;

public class Enemy : BaseEnemy
{
    public string enemyName { get; set; }
    public float health { get; set; }
    public float movementSpeed { get; set; }
    public float gravity { get; set; }
    public EnemyType enemyType { get; set; }
    public short baseDamage { get; set; }
    public float viewDistance { get; set; }
    public float chaseRange { get; set; }
    
    private bool isGotDmg { get; set; }

    public Enemy(string name, float hp, float mvmntSpd, float grav, EnemyType type, byte bsDmg, float viewDist, float chaseRange)
    {
        this.enemyName = name;
        this.health = hp;
        this.movementSpeed = mvmntSpd;
        this.gravity = grav;
        this.enemyType = type;
        this.baseDamage = bsDmg;
        this.viewDistance = viewDist;
        this.chaseRange = chaseRange;
    }

    public bool GetIsMeGotSomeDmg()
    {
        return isGotDmg;
    }

    public void GotDmgReset()
    {
        this.isGotDmg = false;
    }

    public void DamageEnemy(float dmg)//Crit???:?:?
    {
        this.health -= dmg;
        this.isGotDmg = true;
       // this.baseDamage += 5;
        Debug.Log("Enemy health: " + this.health);
    }
}
