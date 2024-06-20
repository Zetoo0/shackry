using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class NunSummonState : BaseState
{
    private NunStateMaMonoBehavior nunStateMachine;

    [SerializeField] private int rage;
    [SerializeField] private int health;

    public NunSummonState(EntityStateMachine e)
    {
        base.state_machine = e;
        this.nunStateMachine = (NunStateMaMonoBehavior)e;
    }
    
    
    public override void EnterState()
    {
        Debug.Log("Nun summon enter");
        nunStateMachine.PerformAnimation(nunStateMachine.A_NUN_SUMMON);
        nunStateMachine.CoroutineToHide();
    }

    public override void UpdateState()
    {
        Debug.Log("Nun Summon Update");
    }

   

    public override bool IsConditionsMet()
    {
        return true;
    }
}
