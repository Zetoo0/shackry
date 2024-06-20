
using UnityEngine;
using System;
public class enemyDyingState : BaseState
{
    enemyStateMachine e;

    public enemyDyingState(EntityStateMachine enemy) : base()
    {
        base.state_machine = enemy;
        this.e = (enemyStateMachine)state_machine;
    }

    public override void EnterState( )
    {
        Debug.Log("IM dying");
        e.myEnemy.movementSpeed -= 10.0f;
    }

    public override void UpdateState( )
    {
        
        if(e.myEnemy.health <= 0)
        {
            e.isDead = true;
            e.gameObject.SetActive(false);
        }
    }

    public  void OnCollisionEnter( )
    {

    }

    public override bool IsConditionsMet( )
    {
        throw new NotImplementedException();
    }

    public override bool IsCoolingDown()
    {
        throw new NotImplementedException();
    }
}
