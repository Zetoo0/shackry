using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMoveState : BaseEntityState
{
    
    
    public override void EnterState(PlayerStateMachineManager stateMachineManager)
    {
        Debug.Log("Motion State entered: Move");
        stateMachineManager.soundManager.PlayAudioAt(SoundManager.Sound.e_Walk,stateMachineManager.transform.position,true);
        //movementAnim
    }

    public override void UpdateState(PlayerStateMachineManager stateMachineManager)
    {
        Debug.Log("Player Velocity:"+stateMachineManager.playerMotion.rb.velocity);
       // Debug.Log("Mozgás....");
      //  Debug.Log("Distance from the earth: " + stateMachineManager.playerMotion.fallDamageCalculator.CheckGroundDistance());
        stateMachineManager.soundManager.PlayAudioAt(SoundManager.Sound.p_Walk,stateMachineManager.playerMotion.transform.position,true);
        stateMachineManager.playerMotion.HandleMovement();
        

        /*if (stateMachineManager.playerMotion.isSprinting && stateMachineManager.currentWhereAboutSate == stateMachineManager.playerOnGroundState)
        {
            Sprint(stateMachineManager.player);
            //sprint anim movement
        }*/

        if (stateMachineManager.playerMotion.rb.velocity.Equals(Vector3.zero))
        {
            stateMachineManager.SwitchMotionState(stateMachineManager.playerIdleState);
        }
        
        //move anim
    }

    private void Sprint(Player player)
    {
        player.movementspeed *= 2.0f;
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
        if (!stateMachineManager.playerMotion.rb.velocity.Equals(Vector3.zero)) return true;
        return false;
    }
}



