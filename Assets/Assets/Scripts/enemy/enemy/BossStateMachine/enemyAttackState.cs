using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class enemyAttackState : BaseState
{
    enemyStateMachine e;
    public enemyAttackState(enemyStateMachine enemy) : base()
    {
        base.state_machine = enemy;
        this.e = (enemyStateMachine)state_machine;
        
    }
    public override void EnterState()
    {
        Debug.Log("AttacK???");
        e.agent.velocity = Vector3.zero;
        AnimationHandler.ChangeAnimation(e.ATTACK_ANIMATION, e.currAnim, out e.currAnim, e.anim);
    }

    


    public override bool IsConditionsMet()
    {
        bool isItMet = e.a_CouldIAttack.Equals(CouldIAttack.Yes) && e.a_WhatISee.Equals(WhatISee.Player) ? true : false;
        return isItMet;
    }

    public override void UpdateState()
    {
        e.soundManager.PlayAudioAt(SoundManager.Sound.e_Attack,e.transform.position,false);
    }
}
