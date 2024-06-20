using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyIdleState : BaseState
{
    enemyStateMachine e;

    public enemyIdleState(enemyStateMachine enemy) : base()
    {
        base.state_machine = enemy;
        this.e = (enemyStateMachine)state_machine;

    }

    public override void EnterState()
    {
       // enemy.myEnemy.movementSpeed = 2.0f;
       
        AnimationHandler.ChangeAnimation(e.IDLE_ANIMATION, e.currAnim, out e.currAnim, e.anim);
    }

    public override bool IsConditionsMet()
    {
        return true;
      //  bool isItMet = enemy.a_CouldIAttack.Equals(CouldIAttack.No) && enemy.a_WhatISee.Equals(WhatISee.Other) && enemy.a_MovementState.Equals(MovementState.InPlace) ? true : false;
    }

    public void OnCollisionEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
       // Debug.Log("Any�d");
        throw new System.NotImplementedException();
    }

    public override bool IsCoolingDown()
    {
        throw new System.NotImplementedException();
    }
}
