using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGroundState : BaseEntityState
{
  

    public override void EnterState(PlayerStateMachineManager stateMachineManager)
    {
        Debug.Log("Entered new Whereabout state: OnGround");
        stateMachineManager.playerMotion.gravityMass = 0;
        stateMachineManager.player.movementspeed = stateMachineManager.playerMotion.baseSpeed;
        
    }

    public override void UpdateState(PlayerStateMachineManager stateMachineManager)
    {
       // Debug.Log("Ongrooound");
        
        if (stateMachineManager.playerMotion.isJumpCalled && stateMachineManager.playerMotion.isCanJump)
        {
            stateMachineManager.SwitchWhereAboutState(stateMachineManager.playerInAirState);
            //stateMachineManager.playerMotion.Jump();
           // stateMachineManager.SwitchWhereAboutState(stateMachineManager.playerInAirState);
        }
        
        
        /*if (!stateMachineManager.playerMotion.OnGround())
        {
            SwitchState(stateMachineManager);
        }*/
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
        stateMachineManager.SwitchWhereAboutState(stateMachineManager.playerInAirState);
    }

    public override bool IsConditionsMet(PlayerStateMachineManager stateMachineManager)
    {
        if (stateMachineManager.playerMotion.OnGround()) return true;
        return false;
    }
}
