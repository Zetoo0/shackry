using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerStateMachineManager : MonoBehaviour
{
    //States
    
    /// <summary>
    ///Player Whereabout States
    ///Such as in air, onground
    /// </summary>
    public BaseEntityState currentWhereAboutSate;
    public PlayerOnGroundState playerOnGroundState = new PlayerOnGroundState();
    public PlayerInAirState playerInAirState = new PlayerInAirState();
    public PlayerWallSlidingState PlayerWallSlidingState = new PlayerWallSlidingState();
  
    /// <summary>
    ///Player Motion States
    ///Such as grappling, jump, idle, move
    /// </summary>
    public BaseEntityState currentMotionState;
    public PlayerDyingState playerDyingState = new PlayerDyingState();
    public PlayerIdleState playerIdleState = new PlayerIdleState();
    public PlayerMoveState PlayerMoveState = new PlayerMoveState();

    /// <summary>
  /// Player Health Issue States
  /// Such as normal, infected, hurt
  /// </summary>
    public BaseEntityState currentHealthState;
    public PlayerNormalState playerNormalState = new PlayerNormalState();
    public PlayerInfectedState playerInfectedState = new PlayerInfectedState();
    
    

    //Other stuffs for states
    public PlayerMotion playerMotion;
    public Player player;
    public static Action OnHealthChange;
    public static Action onDead;
    public SoundManager soundManager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Wall"))
        {
            SwitchMotionState(PlayerWallSlidingState);
        }
    }

    private void OnEnable()
    {
        Time.timeScale = 1.0f;
    }

    private void Start()
    {
        player = playerMotion.player;
        currentWhereAboutSate = playerOnGroundState;
        currentWhereAboutSate.EnterState(this);
        currentMotionState = playerIdleState;
        currentMotionState.EnterState(this);
        currentHealthState = playerNormalState;
        currentHealthState.EnterState(this);
    }
    
    

    private void Update()
    {
        UpdateCurrentStates();   
        if (player.health <= 0)
        {
            Debug.Log("Halálra feliratkozottak száma: " + onDead.GetInvocationList().Length);
            onDead?.Invoke();
            SwitchHealthState(playerDyingState);
            // SwitchState(playerDyingState);
        }
    }

    public void SwitchMotionState(BaseEntityState state)
    {
        if (state.IsConditionsMet(this))
        {
            currentMotionState = state;
            state.EnterState(this);
        }

    }

    private void UpdateCurrentStates()
    {
        currentMotionState.UpdateState(this);
        currentWhereAboutSate.UpdateState(this);
        currentHealthState.UpdateState(this);
    }
    
    public void SwitchHealthState(BaseEntityState state)
    {
        if (state.IsConditionsMet(this))
        {
            currentHealthState = state;
            state.EnterState(this);
        }
    }
    
    public void SwitchWhereAboutState(BaseEntityState state)
    {
        currentWhereAboutSate = state;
        state.EnterState(this); 
    }
}
