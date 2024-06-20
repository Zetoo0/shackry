using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalState : BaseEntityState
{
    public override void EnterState(PlayerStateMachineManager stateMachineManager)
    {
        Debug.Log("Entered to normalState");
    }

    public override void UpdateState(PlayerStateMachineManager stateMachineManager)
    {
        if (!stateMachineManager.player.isPlayerCured()) stateMachineManager.SwitchHealthState(stateMachineManager.playerInfectedState);

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
        throw new System.NotImplementedException();
    }
}
