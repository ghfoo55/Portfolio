//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/PlayerInputAction/PlayerInput.inputactions
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

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""e62f28bc-14c3-4770-bae2-8753706f8e8a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""54991fe4-68d3-4e6e-a197-4040c87a7f56"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""e9d0d639-8078-47fb-9b5a-62bfda201912"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""c2dccdb9-655e-49bf-a5db-b128af14ece3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""fbe6556e-e601-4a33-9e26-5ddc33ee75a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""31cca718-b79d-44d4-9b3e-72d8f8cbcb21"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Parrying"",
                    ""type"": ""Button"",
                    ""id"": ""b9723fef-0ab5-4eac-9a4e-f4d8cdc5746f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LockOn"",
                    ""type"": ""Button"",
                    ""id"": ""7d574aee-2a79-4a1c-a27a-23450edb72e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""f2b3099a-ce3b-4dd9-9ef8-dc7048855cfd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a3e2c69e-cc16-41ee-8543-4f4bf3d3f6b0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""129b1550-0885-4bac-ac96-cff0cd128005"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""2d5b9842-26cb-41f4-9b17-47aa342ecd66"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""02886994-e9b7-4282-834f-51f6077684c7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""a55687fc-2599-4a34-8db4-1dc406c6b886"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8442c963-f673-454e-8e69-f0be6d289f66"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1cbe542c-b2a1-4882-8244-7eed538f77bb"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32d5bcce-74b7-4c2f-85f8-9b29768db941"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c60de4b5-89ea-4d3f-8439-3d327581e475"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae65bedf-a59e-4f05-90d1-acb4929ad3bb"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Parrying"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""132ef65e-b144-4a7d-827a-fb9c8611f21c"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3914b73-c80b-4ba0-8f4e-0f29785cd04d"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""QuickSlot"",
            ""id"": ""bad590c9-32b8-49ad-b295-ee8f1aece2be"",
            ""actions"": [
                {
                    ""name"": ""Quick1"",
                    ""type"": ""Button"",
                    ""id"": ""a4d5b10f-ed55-4a1b-9a9d-101e962d2936"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Quick2"",
                    ""type"": ""Button"",
                    ""id"": ""62628f8f-2add-499c-ba25-8c4c6afed1d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Quick3"",
                    ""type"": ""Button"",
                    ""id"": ""5a10d895-bbcd-4407-82b3-eaafb61214b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""988e57e4-45c9-4fa6-b6b8-ae9148f705c2"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Quick1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eabdbd14-915a-4716-9b83-ba28453782fb"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Quick2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""233f0c19-2342-4fa7-9062-a26d16d7a4dd"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Quick3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardMouse"",
            ""bindingGroup"": ""KeyboardMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_Run = m_Player.FindAction("Run", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_Dodge = m_Player.FindAction("Dodge", throwIfNotFound: true);
        m_Player_Parrying = m_Player.FindAction("Parrying", throwIfNotFound: true);
        m_Player_LockOn = m_Player.FindAction("LockOn", throwIfNotFound: true);
        m_Player_Inventory = m_Player.FindAction("Inventory", throwIfNotFound: true);
        // QuickSlot
        m_QuickSlot = asset.FindActionMap("QuickSlot", throwIfNotFound: true);
        m_QuickSlot_Quick1 = m_QuickSlot.FindAction("Quick1", throwIfNotFound: true);
        m_QuickSlot_Quick2 = m_QuickSlot.FindAction("Quick2", throwIfNotFound: true);
        m_QuickSlot_Quick3 = m_QuickSlot.FindAction("Quick3", throwIfNotFound: true);
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
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_Run;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_Dodge;
    private readonly InputAction m_Player_Parrying;
    private readonly InputAction m_Player_LockOn;
    private readonly InputAction m_Player_Inventory;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @Run => m_Wrapper.m_Player_Run;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @Dodge => m_Wrapper.m_Player_Dodge;
        public InputAction @Parrying => m_Wrapper.m_Player_Parrying;
        public InputAction @LockOn => m_Wrapper.m_Player_LockOn;
        public InputAction @Inventory => m_Wrapper.m_Player_Inventory;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Run.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Dodge.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                @Parrying.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnParrying;
                @Parrying.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnParrying;
                @Parrying.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnParrying;
                @LockOn.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLockOn;
                @LockOn.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLockOn;
                @LockOn.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLockOn;
                @Inventory.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
                @Parrying.started += instance.OnParrying;
                @Parrying.performed += instance.OnParrying;
                @Parrying.canceled += instance.OnParrying;
                @LockOn.started += instance.OnLockOn;
                @LockOn.performed += instance.OnLockOn;
                @LockOn.canceled += instance.OnLockOn;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // QuickSlot
    private readonly InputActionMap m_QuickSlot;
    private IQuickSlotActions m_QuickSlotActionsCallbackInterface;
    private readonly InputAction m_QuickSlot_Quick1;
    private readonly InputAction m_QuickSlot_Quick2;
    private readonly InputAction m_QuickSlot_Quick3;
    public struct QuickSlotActions
    {
        private @PlayerInput m_Wrapper;
        public QuickSlotActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Quick1 => m_Wrapper.m_QuickSlot_Quick1;
        public InputAction @Quick2 => m_Wrapper.m_QuickSlot_Quick2;
        public InputAction @Quick3 => m_Wrapper.m_QuickSlot_Quick3;
        public InputActionMap Get() { return m_Wrapper.m_QuickSlot; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(QuickSlotActions set) { return set.Get(); }
        public void SetCallbacks(IQuickSlotActions instance)
        {
            if (m_Wrapper.m_QuickSlotActionsCallbackInterface != null)
            {
                @Quick1.started -= m_Wrapper.m_QuickSlotActionsCallbackInterface.OnQuick1;
                @Quick1.performed -= m_Wrapper.m_QuickSlotActionsCallbackInterface.OnQuick1;
                @Quick1.canceled -= m_Wrapper.m_QuickSlotActionsCallbackInterface.OnQuick1;
                @Quick2.started -= m_Wrapper.m_QuickSlotActionsCallbackInterface.OnQuick2;
                @Quick2.performed -= m_Wrapper.m_QuickSlotActionsCallbackInterface.OnQuick2;
                @Quick2.canceled -= m_Wrapper.m_QuickSlotActionsCallbackInterface.OnQuick2;
                @Quick3.started -= m_Wrapper.m_QuickSlotActionsCallbackInterface.OnQuick3;
                @Quick3.performed -= m_Wrapper.m_QuickSlotActionsCallbackInterface.OnQuick3;
                @Quick3.canceled -= m_Wrapper.m_QuickSlotActionsCallbackInterface.OnQuick3;
            }
            m_Wrapper.m_QuickSlotActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Quick1.started += instance.OnQuick1;
                @Quick1.performed += instance.OnQuick1;
                @Quick1.canceled += instance.OnQuick1;
                @Quick2.started += instance.OnQuick2;
                @Quick2.performed += instance.OnQuick2;
                @Quick2.canceled += instance.OnQuick2;
                @Quick3.started += instance.OnQuick3;
                @Quick3.performed += instance.OnQuick3;
                @Quick3.canceled += instance.OnQuick3;
            }
        }
    }
    public QuickSlotActions @QuickSlot => new QuickSlotActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardMouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnParrying(InputAction.CallbackContext context);
        void OnLockOn(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
    }
    public interface IQuickSlotActions
    {
        void OnQuick1(InputAction.CallbackContext context);
        void OnQuick2(InputAction.CallbackContext context);
        void OnQuick3(InputAction.CallbackContext context);
    }
}