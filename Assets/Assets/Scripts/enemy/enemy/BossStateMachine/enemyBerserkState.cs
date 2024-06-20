
using UnityEngine;

public class enemyBerserkState : BaseState
{
    public override void EnterState( )
    {
       // enemy.myEnemy.baseDamage += 20;
        Debug.Log("WHAAA IM STARTED TO BERSERK");

    }

    public override void UpdateState( )
    {
        
      /*  if(enemy.myEnemy.health <= 25)
        {
            enemy.SwitchState(enemy.dyingState);
        }*/
    }

    public  void OnCollisionEnter( )
    {

    }

    public override bool IsConditionsMet( )
    {
        throw new System.NotImplementedException();
    }

    public override bool IsCoolingDown()
    {
        throw new System.NotImplementedException();
    }
}
