using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDyingState : BaseEntityState
{
    public override void EnterState(PlayerStateMachineManager stateMachineManager)
    {
        Debug.Log("I'm dead");
        Time.timeScale = 0.0f;
    }

    public override void UpdateState(PlayerStateMachineManager stateMachineManager)
    {
        //do nothing cause you dead
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
        if (stateMachineManager.player.health <= 0.0f) return true;
        return false;
    }
}
