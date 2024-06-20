using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfectedState : BaseEntityState
{
    public override void EnterState(PlayerStateMachineManager stateMachineManager)
    {
        Debug.Log("Im infected waaa");
    }

    public override void UpdateState(PlayerStateMachineManager stateMachineManager)
    {
        stateMachineManager.player.health -= 0.2f;
        if (stateMachineManager.player.isPlayerCured())
        {
            stateMachineManager.SwitchHealthState(stateMachineManager.playerNormalState);
        }
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
