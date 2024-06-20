using UnityEngine;


public class PlayerGrapplingState : BaseEntityState
{
    public override void EnterState(PlayerStateMachineManager stateMachineManager)
    {
        Debug.Log("Motion State: GrapplingState");
    }

    public override void UpdateState(PlayerStateMachineManager stateMachineManager)
    {
        throw new System.NotImplementedException();
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
