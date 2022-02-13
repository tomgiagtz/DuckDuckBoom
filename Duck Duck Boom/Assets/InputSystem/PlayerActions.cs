// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/PlayerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""Player_Map"",
            ""id"": ""a8a9e06c-7239-45d8-b4bd-2ef4fa151ed0"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""792e54db-159a-4bc9-9487-97eb5bbb2782"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""bc83c46b-be0d-4eae-ae2a-e9138236a80d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""ce8aa927-f32d-4692-88cf-2bfd99e01064"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CycleWeapon"",
                    ""type"": ""Value"",
                    ""id"": ""4515ab91-fd99-4d3a-b6d8-00c035b8322b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""Clamp(min=-1,max=1)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CycleThrowable"",
                    ""type"": ""Button"",
                    ""id"": ""ee1ec1b9-4de9-41df-9331-5c0cf4551205"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2478662f-6444-47eb-9453-27b7f9a7234b"",
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
                    ""id"": ""90097f40-8fc9-421e-a5b1-c439db421345"",
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
                    ""id"": ""001c9cf2-7398-4307-9b4e-55b006d5987c"",
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
                    ""id"": ""2b02e1a8-6a2a-47c9-a64b-5e7994bc26c1"",
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
                    ""id"": ""066585ed-e763-4112-9ae8-139e479c511f"",
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
                    ""id"": ""0307131c-c05c-4599-9078-0729d60f0e5c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6cbc2b70-9215-4bb3-a566-b475c7f9a6c5"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""964f2444-f7bb-4b34-8f3b-afdefea59480"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": ""Normalize(min=-1,max=1)"",
                    ""groups"": """",
                    ""action"": ""CycleWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9a6fa2a-6372-49d4-8ab8-8e46003ebb54"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleThrowable"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player_Map
        m_Player_Map = asset.FindActionMap("Player_Map", throwIfNotFound: true);
        m_Player_Map_Movement = m_Player_Map.FindAction("Movement", throwIfNotFound: true);
        m_Player_Map_Attack = m_Player_Map.FindAction("Attack", throwIfNotFound: true);
        m_Player_Map_Throw = m_Player_Map.FindAction("Throw", throwIfNotFound: true);
        m_Player_Map_CycleWeapon = m_Player_Map.FindAction("CycleWeapon", throwIfNotFound: true);
        m_Player_Map_CycleThrowable = m_Player_Map.FindAction("CycleThrowable", throwIfNotFound: true);
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

    // Player_Map
    private readonly InputActionMap m_Player_Map;
    private IPlayer_MapActions m_Player_MapActionsCallbackInterface;
    private readonly InputAction m_Player_Map_Movement;
    private readonly InputAction m_Player_Map_Attack;
    private readonly InputAction m_Player_Map_Throw;
    private readonly InputAction m_Player_Map_CycleWeapon;
    private readonly InputAction m_Player_Map_CycleThrowable;
    public struct Player_MapActions
    {
        private @PlayerActions m_Wrapper;
        public Player_MapActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Map_Movement;
        public InputAction @Attack => m_Wrapper.m_Player_Map_Attack;
        public InputAction @Throw => m_Wrapper.m_Player_Map_Throw;
        public InputAction @CycleWeapon => m_Wrapper.m_Player_Map_CycleWeapon;
        public InputAction @CycleThrowable => m_Wrapper.m_Player_Map_CycleThrowable;
        public InputActionMap Get() { return m_Wrapper.m_Player_Map; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player_MapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer_MapActions instance)
        {
            if (m_Wrapper.m_Player_MapActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnMovement;
                @Attack.started -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnAttack;
                @Throw.started -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnThrow;
                @CycleWeapon.started -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnCycleWeapon;
                @CycleWeapon.performed -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnCycleWeapon;
                @CycleWeapon.canceled -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnCycleWeapon;
                @CycleThrowable.started -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnCycleThrowable;
                @CycleThrowable.performed -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnCycleThrowable;
                @CycleThrowable.canceled -= m_Wrapper.m_Player_MapActionsCallbackInterface.OnCycleThrowable;
            }
            m_Wrapper.m_Player_MapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
                @CycleWeapon.started += instance.OnCycleWeapon;
                @CycleWeapon.performed += instance.OnCycleWeapon;
                @CycleWeapon.canceled += instance.OnCycleWeapon;
                @CycleThrowable.started += instance.OnCycleThrowable;
                @CycleThrowable.performed += instance.OnCycleThrowable;
                @CycleThrowable.canceled += instance.OnCycleThrowable;
            }
        }
    }
    public Player_MapActions @Player_Map => new Player_MapActions(this);
    public interface IPlayer_MapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnCycleWeapon(InputAction.CallbackContext context);
        void OnCycleThrowable(InputAction.CallbackContext context);
    }
}
