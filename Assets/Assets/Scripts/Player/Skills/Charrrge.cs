using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skills", menuName = "Skills/InstantSkills/Charrrge")]
public class Charrrge : InstantSkill
{
    // Start is called before the first frame update

    //public KeyCode keyC;
    //public string name;
    public int range;
    public int speed;
   // [SerializeField] private Player player;
    public virtual void ActivateSkill(GameObject playerObj, Enemy enemy, GameObject enemyObj, Player player)
    {

    }

    public virtual void ActivateSkill(GameObject playerObj, GameObject enemyObj, Player player)
    {

    }

    public virtual void ActivateSkill(GameObject playerObj, Enemy enemy, Player player)
    {

    }

    public virtual void ActivateSkill(GameObject playerObj, Player player)
    {

    }

    public virtual void ActivateSkill()
    {

    }

    public virtual void ActivateSkill(GameObject playerOrEnemyObj)
    {

    }

    public virtual void ActivateSkill(Rigidbody playerRb, GameObject playerObj, GameObject enemyObject, PlayerMotion playerMov)
    {
        /*float dist = Vector3.Distance(playerObj.transform.position, enemyObject.transform.position);
        playerMov.chrController.
        playerRb.AddForce(dist * playerMov.moving, 0f);*/
    }

    public virtual void ActivateSkill(GameObject playerObj, GameObject enemyObject)
    {
        //playerObj.transform.position += Vector3.Lerp(playerObj.transform.position, enemyObject.transform.position,
          //  4.2f * Time.deltaTime);
        playerObj.transform.Translate(playerObj.transform.forward*3.4f, Space.Self);
        Debug.Log("Charrge?");
    }

    /*private bool IsCanCharge(GameObject playerObj, GameObject enemyObject)
    {
       // bool isInDist = Vector3.Distance(playerObj.transform.position, enemyObject.transform.position) <= range;
    }*/

    public virtual void ActivateSkill(Player player)
    {
    }

    public virtual void ActivateSkill(PlayerMotion playerMovement)
    {
        
    }

    public virtual void ActivateSkill(Enemy enemy, GameObject enemyObj)
    {

    }
    
    public virtual void ActivateSkill(Enemy enemy)
    {

    }
}
