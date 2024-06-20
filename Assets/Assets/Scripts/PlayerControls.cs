//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Assets/Scripts/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""ca3105a5-739d-4fd9-a9a1-a37f6ee5e141"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""641ae758-0735-44ac-87f2-30c7e4453de7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bff22e33-bf41-4bd4-b91f-5b6a6701523d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseX"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c3b0d623-da4e-45b0-b1cc-5cb799579e08"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseY"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7d48e6a2-d8df-4946-9adf-b6d8f474dbf0"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""14451b6e-dd43-49ca-8d16-224e3c2b4f0c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FastenerTimeBSkill"",
                    ""type"": ""PassThrough"",
                    ""id"": ""df7a727e-b115-4458-954f-340fdc61e521"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""InstantSkill"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d3d6e893-2955-45fc-b30d-ab9454c8ac88"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Charrrge"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cc257061-59c8-49fc-bb3f-1880c8cc6b3b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""WeaponZoom"",
                    ""type"": ""Button"",
                    ""id"": ""f54f73be-6a01-4445-8b91-5b243e587ab7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToMainWeapon"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2ce1b600-31f6-43b3-8d6c-18a660da5078"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToSecondaryWeapon"",
                    ""type"": ""PassThrough"",
                    ""id"": ""495b28a0-0afc-4c7d-b37e-5e5d434077c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToMeeleWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""d87a3ec5-8c89-4fbd-b4dc-2542bfae219f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""500b19ea-44f6-4aa3-bb3d-ab88b4c653aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4f123376-936b-4b7f-9df5-322654019fc4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0cc1d40f-bab9-4d7a-a211-4851653fa4d2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ab6e864-28e1-4533-9653-47f20bef89aa"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31bb4df9-daa8-4a07-b9df-ff266586d451"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""3a75f35a-6e8f-44fd-931f-6e4e9e958eb4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""66c53ad7-ba68-4d5a-8b70-c4000eb18993"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ace8ade6-9cc2-40f8-b40a-911cacb7ead6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5cccefd7-b696-4da6-b3f1-c0c2c8d236e6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b97134a0-d6aa-43fe-8a0e-bd6738abda88"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4944053e-148a-4080-a4b8-9c4654a3376e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FastenerTimeBSkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0be0f811-e0e8-4f93-968a-d9bdcf4478a8"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InstantSkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3fccd71-2332-49e4-b9d3-2df183f08de6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Charrrge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e576600-3064-4bf2-a9b8-eb90862146d7"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WeaponZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75d8c722-e82e-4b26-ab84-00bdedef3d48"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToMainWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45836243-9d73-4e52-9aa4-c255db5a866c"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToSecondaryWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""694987e9-7827-4fa2-af2c-45a55f1fa1d0"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToMeeleWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""676ed901-63a2-4531-94d7-32a7063a1269"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""94692a2f-c071-42cd-950b-cde3967fc40d"",
            ""actions"": [
                {
                    ""name"": ""LClick"",
                    ""type"": ""Button"",
                    ""id"": ""97fcbb3c-ec4a-4605-a26b-3034a273635a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""Value"",
                    ""id"": ""62a0a8cf-a3b6-4e4e-8813-4875d455ac72"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d8765de3-7104-4d4c-b220-be047ba16a17"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80946bd4-ced7-4102-9f88-bf41bc2357f7"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_MouseX = m_Player.FindAction("MouseX", throwIfNotFound: true);
        m_Player_MouseY = m_Player.FindAction("MouseY", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_FastenerTimeBSkill = m_Player.FindAction("FastenerTimeBSkill", throwIfNotFound: true);
        m_Player_InstantSkill = m_Player.FindAction("InstantSkill", throwIfNotFound: true);
        m_Player_Charrrge = m_Player.FindAction("Charrrge", throwIfNotFound: true);
        m_Player_WeaponZoom = m_Player.FindAction("WeaponZoom", throwIfNotFound: true);
        m_Player_ToMainWeapon = m_Player.FindAction("ToMainWeapon", throwIfNotFound: true);
        m_Player_ToSecondaryWeapon = m_Player.FindAction("ToSecondaryWeapon", throwIfNotFound: true);
        m_Player_ToMeeleWeapon = m_Player.FindAction("ToMeeleWeapon", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_LClick = m_UI.FindAction("LClick", throwIfNotFound: true);
        m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Fire;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_MouseX;
    private readonly InputAction m_Player_MouseY;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_FastenerTimeBSkill;
    private readonly InputAction m_Player_InstantSkill;
    private readonly InputAction m_Player_Charrrge;
    private readonly InputAction m_Player_WeaponZoom;
    private readonly InputAction m_Player_ToMainWeapon;
    private readonly InputAction m_Player_ToSecondaryWeapon;
    private readonly InputAction m_Player_ToMeeleWeapon;
    private readonly InputAction m_Player_Pause;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_Player_Fire;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @MouseX => m_Wrapper.m_Player_MouseX;
        public InputAction @MouseY => m_Wrapper.m_Player_MouseY;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @FastenerTimeBSkill => m_Wrapper.m_Player_FastenerTimeBSkill;
        public InputAction @InstantSkill => m_Wrapper.m_Player_InstantSkill;
        public InputAction @Charrrge => m_Wrapper.m_Player_Charrrge;
        public InputAction @WeaponZoom => m_Wrapper.m_Player_WeaponZoom;
        public InputAction @ToMainWeapon => m_Wrapper.m_Player_ToMainWeapon;
        public InputAction @ToSecondaryWeapon => m_Wrapper.m_Player_ToSecondaryWeapon;
        public InputAction @ToMeeleWeapon => m_Wrapper.m_Player_ToMeeleWeapon;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Fire.started += instance.OnFire;
            @Fire.performed += instance.OnFire;
            @Fire.canceled += instance.OnFire;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @MouseX.started += instance.OnMouseX;
            @MouseX.performed += instance.OnMouseX;
            @MouseX.canceled += instance.OnMouseX;
            @MouseY.started += instance.OnMouseY;
            @MouseY.performed += instance.OnMouseY;
            @MouseY.canceled += instance.OnMouseY;
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @FastenerTimeBSkill.started += instance.OnFastenerTimeBSkill;
            @FastenerTimeBSkill.performed += instance.OnFastenerTimeBSkill;
            @FastenerTimeBSkill.canceled += instance.OnFastenerTimeBSkill;
            @InstantSkill.started += instance.OnInstantSkill;
            @InstantSkill.performed += instance.OnInstantSkill;
            @InstantSkill.canceled += instance.OnInstantSkill;
            @Charrrge.started += instance.OnCharrrge;
            @Charrrge.performed += instance.OnCharrrge;
            @Charrrge.canceled += instance.OnCharrrge;
            @WeaponZoom.started += instance.OnWeaponZoom;
            @WeaponZoom.performed += instance.OnWeaponZoom;
            @WeaponZoom.canceled += instance.OnWeaponZoom;
            @ToMainWeapon.started += instance.OnToMainWeapon;
            @ToMainWeapon.performed += instance.OnToMainWeapon;
            @ToMainWeapon.canceled += instance.OnToMainWeapon;
            @ToSecondaryWeapon.started += instance.OnToSecondaryWeapon;
            @ToSecondaryWeapon.performed += instance.OnToSecondaryWeapon;
            @ToSecondaryWeapon.canceled += instance.OnToSecondaryWeapon;
            @ToMeeleWeapon.started += instance.OnToMeeleWeapon;
            @ToMeeleWeapon.performed += instance.OnToMeeleWeapon;
            @ToMeeleWeapon.canceled += instance.OnToMeeleWeapon;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Fire.started -= instance.OnFire;
            @Fire.performed -= instance.OnFire;
            @Fire.canceled -= instance.OnFire;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @MouseX.started -= instance.OnMouseX;
            @MouseX.performed -= instance.OnMouseX;
            @MouseX.canceled -= instance.OnMouseX;
            @MouseY.started -= instance.OnMouseY;
            @MouseY.performed -= instance.OnMouseY;
            @MouseY.canceled -= instance.OnMouseY;
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @FastenerTimeBSkill.started -= instance.OnFastenerTimeBSkill;
            @FastenerTimeBSkill.performed -= instance.OnFastenerTimeBSkill;
            @FastenerTimeBSkill.canceled -= instance.OnFastenerTimeBSkill;
            @InstantSkill.started -= instance.OnInstantSkill;
            @InstantSkill.performed -= instance.OnInstantSkill;
            @InstantSkill.canceled -= instance.OnInstantSkill;
            @Charrrge.started -= instance.OnCharrrge;
            @Charrrge.performed -= instance.OnCharrrge;
            @Charrrge.canceled -= instance.OnCharrrge;
            @WeaponZoom.started -= instance.OnWeaponZoom;
            @WeaponZoom.performed -= instance.OnWeaponZoom;
            @WeaponZoom.canceled -= instance.OnWeaponZoom;
            @ToMainWeapon.started -= instance.OnToMainWeapon;
            @ToMainWeapon.performed -= instance.OnToMainWeapon;
            @ToMainWeapon.canceled -= instance.OnToMainWeapon;
            @ToSecondaryWeapon.started -= instance.OnToSecondaryWeapon;
            @ToSecondaryWeapon.performed -= instance.OnToSecondaryWeapon;
            @ToSecondaryWeapon.canceled -= instance.OnToSecondaryWeapon;
            @ToMeeleWeapon.started -= instance.OnToMeeleWeapon;
            @ToMeeleWeapon.performed -= instance.OnToMeeleWeapon;
            @ToMeeleWeapon.canceled -= instance.OnToMeeleWeapon;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_LClick;
    private readonly InputAction m_UI_Point;
    public struct UIActions
    {
        private @PlayerControls m_Wrapper;
        public UIActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LClick => m_Wrapper.m_UI_LClick;
        public InputAction @Point => m_Wrapper.m_UI_Point;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @LClick.started += instance.OnLClick;
            @LClick.performed += instance.OnLClick;
            @LClick.canceled += instance.OnLClick;
            @Point.started += instance.OnPoint;
            @Point.performed += instance.OnPoint;
            @Point.canceled += instance.OnPoint;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @LClick.started -= instance.OnLClick;
            @LClick.performed -= instance.OnLClick;
            @LClick.canceled -= instance.OnLClick;
            @Point.started -= instance.OnPoint;
            @Point.performed -= instance.OnPoint;
            @Point.canceled -= instance.OnPoint;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IPlayerActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnMouseX(InputAction.CallbackContext context);
        void OnMouseY(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnFastenerTimeBSkill(InputAction.CallbackContext context);
        void OnInstantSkill(InputAction.CallbackContext context);
        void OnCharrrge(InputAction.CallbackContext context);
        void OnWeaponZoom(InputAction.CallbackContext context);
        void OnToMainWeapon(InputAction.CallbackContext context);
        void OnToSecondaryWeapon(InputAction.CallbackContext context);
        void OnToMeeleWeapon(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnLClick(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
    }
}
