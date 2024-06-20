using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEntityState
{
    public abstract void EnterState(PlayerStateMachineManager stateMachineManager);
    public abstract void UpdateState(PlayerStateMachineManager stateMachineManager);
    public abstract void OnCollisionTriggered(PlayerStateMachineManager stateMachineManager, Collision col);
    /// <summary>
    /// Do something before switch to a new state
    /// </summary>
    /// <param name="stateMachineManager"></param>
    public abstract void ExitState(PlayerStateMachineManager stateMachineManager);
    public abstract void SwitchState(PlayerStateMachineManager stateMachineManager);
/// <summary>
///     //I need transition conditions for player state machine as well because it can save me some braincells later
/// </summary>
/// <param name="stateMachineManager"></param>
/// <returns></returns>
    public abstract bool IsConditionsMet(PlayerStateMachineManager stateMachineManager);
}
