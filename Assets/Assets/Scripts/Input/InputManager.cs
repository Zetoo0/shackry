using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControl;
    PlayerControls.PlayerActions playerActions;
    Vector2 mouseInput;
    Vector2 movementInput;
    [SerializeField]Mouse mouse;
    [SerializeField] PlayerMotion fps_movement;
    [SerializeField] public FiringSystemManager shoot_fire;
    [SerializeField] SkillHandler skillHandler;
    [SerializeField] CameraMotion camMotion;
    [SerializeField] WeaponSwitchManager wpSwitchManager;
    public static Action TimeBasedSkillAction;
    public static Action InstantSkillAction;
    [SerializeField] private GameSessionManager gameSession;
    private void Awake()
    {
        SetAwake();

    }

    //chat system trigger
    //if(isNearToPressChat

    private void Update()
    {
        SendInputs();
        
    }

    private void PlayerInputEnableDisable(bool input)
    {
        
    }

    private void SetAwake()
    {
        playerControl = new PlayerControls();
        playerActions = playerControl.Player;

        playerActions.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();

        playerActions.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        playerActions.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();

        playerActions.Fire.performed += _ =>  shoot_fire.OnFirePressed();
        playerActions.Jump.performed += _ => fps_movement.OnJumping();
        playerActions.WeaponZoom.performed += _ => camMotion.OnRightClick();

      //  playerActions.FastenerTimeBSkill.performed += _ => skillHandler.Fastener();
        playerActions.Charrrge.performed += _ => skillHandler.Charrrge();

        playerActions.ToMainWeapon.performed += _ => wpSwitchManager.SwitchToMain();
        playerActions.ToSecondaryWeapon.performed += _ => wpSwitchManager.SwitchToSecondary();
        playerActions.ToMeeleWeapon.performed += _ => wpSwitchManager.SwitchToMeele();
        playerActions.Pause.performed += _ => gameSession.OnPauseBtnPressed();
        playerActions.Pause.performed += _ => OffPlayerActions();

        //  playerActions.InstantSkill.performed += _ => skillHandler.InstantSkillPerformed();

    }

    private void OffPlayerActions()
    {
        //playerControl.UI.Enable();
        if (playerActions.Fire.enabled)
        {
            playerActions.Fire.Disable();
        }
        else
        {
            playerActions.Fire.Enable();
        }
    }
    
    private void SendInputs()
    {
        fps_movement.ReceiveInput(movementInput);
        mouse.ReceiveInput(mouseInput);
    }
    

    private void OnEnable()
    {
        playerControl.Enable();
    }
    private void OnDestroy()
    {
        playerControl.Disable();
    }



}
