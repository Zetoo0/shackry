using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using System;

public class enemyChaseState : BaseState
{
    private IEnumerator AgentDecideStatesBacker;
    MonoBehaviour behav;
    DateTime LastSwitchedTime;
    enemyStateMachine e;
    Vector3 chaseVel;

    public enemyChaseState(enemyStateMachine enemy) : base()
    {
        base.state_machine = enemy;
        this.e = (enemyStateMachine)state_machine;
       // chaseVel.x = 2.7f;
    }

    public override void EnterState()
    {
       
      /*  chaseVel.y = e.agent.velocity.y;
        chaseVel.z = e.agent.velocity.z;
        e.agent.velocity = chaseVel;*/
        Debug.Log("Entered chase state????");
        e.agent.SetDestination(e.player.transform.position);
        Debug.Log(e.agent.destination);
        AnimationHandler.ChangeAnimation(e.CHASE_ANIMATION, e.currAnim, out e.currAnim, e.anim);
    }

    public override bool IsConditionsMet( )
    {
        return e.a_CouldIAttack.Equals(CouldIAttack.No) && e.a_WhatISee.Equals(WhatISee.Player) && e.isChasing.Equals(false);
     
    }

    public  void OnCollisionEnter( )
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState( )
    {
        Debug.Log("yes");
        e.soundManager.PlayAudioAt(SoundManager.Sound.e_Chase,e.transform.position,false);
        /*chaseVel.x = e.agent.velocity.x;
        chaseVel.y = e.agent.velocity.y;
        chaseVel.z = e.agent.velocity.z;
        Mathf.Clamp(chaseVel.x, 2.0f, 2.7f);
        e.agent.velocity = chaseVel;*/
        //  enemy.SetEverythingBack();
    }
    public override bool IsCoolingDown()
    {
      //  Debug.Log()
        throw new System.NotImplementedException();
    }

    public IEnumerator SetEverythingBackAtAgent( )
    {
        return new WaitForSecondsRealtime(12f);
        Debug.Log("Meghívva");
        e.SetEverythingBack();
    }
}
