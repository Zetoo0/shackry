using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlidingState : BaseEntityState
{
    private Vector3 wallRunVelocity;
    
    
    public override void EnterState(PlayerStateMachineManager stateMachineManager)
    {
        Debug.Log("Wall Sliding State Entered");

    }

    public override void UpdateState(PlayerStateMachineManager stateMachineManager)
    {
        stateMachineManager.playerMotion.rb.AddForce(Vector3.forward*stateMachineManager.playerMotion.rb.mass*100.0f);
    }

    public override void OnCollisionTriggered(PlayerStateMachineManager stateMachineManager, Collision col)
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState(PlayerStateMachineManager stateMachineManager)
    {
        throw new System.NotImplementedException();
    }

    public override void SwitchState(PlayerStateMachineManager stateMachineManager)
    {
        Debug.Log("Switched From Wall Sliding State");
    }

    public override bool IsConditionsMet(PlayerStateMachineManager stateMachineManager)
    {
        throw new System.NotImplementedException();
    }
}
