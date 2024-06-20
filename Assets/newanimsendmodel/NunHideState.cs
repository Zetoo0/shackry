using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NunHideState : BaseState
{
    private NunStateMaMonoBehavior state_machine_nun;
    public NunHideState(EntityStateMachine e)
    {
        base.state_machine = e;
        this.state_machine_nun = (NunStateMaMonoBehavior)e;
    }

    public override void EnterState()
    {
        Debug.Log("Im hidden");
    }

    public override bool IsConditionsMet()
    {
        return true;
    }
}
