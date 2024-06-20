using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skills" , menuName = "Skills/InstantSkills")]
public class InstantSkill : ScriptableObject
{
    public KeyCode keyC;
    public string name;

    public virtual void ActivateSkill(GameObject playerObj, Enemy enemy, GameObject enemyObj, Player player)
    {

    }
}
