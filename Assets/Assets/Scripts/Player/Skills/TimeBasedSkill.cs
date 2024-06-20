using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skills", menuName = "Skills/TimeBasedSkills")]
public class TimeBasedSkill : ScriptableObject
{
    public KeyCode keyC;
    public float activeTime;
    public string name;

    public virtual void ActivateSkill(GameObject playerObj, Enemy enemy, GameObject enemyObj, Player player)
    {

    }

    public virtual void ActivateSkill(GameObject playerObj, GameObject enemyObj, Player player)
    {

    }

    public virtual void ActivateSkill(GameObject playerObj, Enemy enemy , Player player)
    {

    }

    public virtual void ActivateSkill(GameObject playerObj, Player player)
    {

    }
    public virtual void ActivateSkill(GameObject playerOrEnemyObj)
    {

    }

    public virtual void ActivateSkill(Player player)
    {
        player.movementspeed += 10;
    }

    public virtual void ActivateSkill( Enemy enemy, GameObject enemyObj)
    {

    }


    public virtual void ActivateSkill(Enemy enemy)
    {

    }
}
