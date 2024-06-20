using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerIdleState : BaseEntityState
{
   

    public override void EnterState(PlayerStateMachineManager stateMachineManager)
    {
        Debug.Log("Entered Idle");
        //Idle animation
    }

    public override void UpdateState(PlayerStateMachineManager stateMachineManager)
    {
        //idle anim
        Debug.Log("Idling...");
        /*if (stateMachineManager.playerMotion.isJumpCalled && stateMachineManager.currentWhereAboutSate != stateMachineManager.playerInAirState)
        {
            stateMachineManager.SwitchWhereAboutState(stateMachineManager.playerInAirState);
        }*/

        if (!stateMachineManager.playerMotion.rb.velocity.Equals(Vector3.zero))
        {
            stateMachineManager.SwitchMotionState(stateMachineManager.PlayerMoveState);
        }
        
        
    }

    public override void OnCollisionTriggered(PlayerStateMachineManager stateMachineManager, Collision col)
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState(PlayerStateMachineManager stateMachineManager)
    {
        Debug.Log("Exited from Idle State");
    }

    public override void SwitchState(PlayerStateMachineManager stateMachineManager)
    {
        throw new System.NotImplementedException();
    }

    public override bool IsConditionsMet(PlayerStateMachineManager stateMachineManager)
    {
        if(stateMachineManager.playerMotion.rb.velocity.Equals(Vector3.zero)) return true;
        return false;
    }
}
