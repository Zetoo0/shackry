using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class PlayerInAirState : BaseEntityState
{

    private bool jumpedAgainSinceItIsInTheAir;
    public override void EnterState(PlayerStateMachineManager stateMachineManager)
    { 
        Debug.Log("Entered new Whereabout state: In Air");

        stateMachineManager.playerMotion.isJumpCalled = false;
        jumpedAgainSinceItIsInTheAir = false;
        DaJump(stateMachineManager);
    }

    private void DaJump(PlayerStateMachineManager stateMachineManager)
    {
        stateMachineManager.playerMotion.Jump();
    }

    public override void UpdateState(PlayerStateMachineManager stateMachineManager)
    {
        stateMachineManager.playerMotion.gravityMass +=
            stateMachineManager.playerMotion.additionalGravityMassWhilePlayerInThe * Mathf.PI;
        stateMachineManager.playerMotion.transform.Translate(UnityEngine.Vector3.Cross(UnityEngine.Vector3.right,UnityEngine.Vector3.left) * 0.2f, Space.Self);
        /*if (stateMachineManager.playerMotion.isJumpCalled && !jumpedAgainSinceItIsInTheAir)
        {
            jumpedAgainSinceItIsInTheAir = true;
            stateMachineManager.playerMotion.isJumpCalled = false;
            DaJump(stateMachineManager);
        }*/
        if(stateMachineManager.playerMotion.IsOnGround())
            stateMachineManager.SwitchWhereAboutState(stateMachineManager.playerOnGroundState);
        Debug.Log("In Air.");
        
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
        throw new System.NotImplementedException();
    }

    public override bool IsConditionsMet(PlayerStateMachineManager stateMachineManager)
    {
        if (!stateMachineManager.playerMotion.isJumpCalled) return true;
        return false;
    }
}
