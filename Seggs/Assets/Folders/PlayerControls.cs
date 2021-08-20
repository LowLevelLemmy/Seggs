// GENERATED AUTOMATICALLY FROM 'Assets/Folders/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""ActMap"",
            ""id"": ""77ad92ad-4eb2-42a6-8678-55de27bdb001"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""194675de-4ab8-4d0f-b250-174f605d0df7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""c425fb01-f24d-4af1-9e05-0ec120b7d04c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""7755b0e1-a464-4419-8e93-2b1a418d9921"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""287d87fa-28cb-43a6-9856-973e1fe087fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""046fbd3d-a6e9-43a2-a97d-ded03b2be6a9"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7ee5566-d2e7-4e61-9dee-2c2a4a63b33d"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4147aba-9327-40bf-bfd6-02e94b9bcba7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32f0c869-e697-4975-bdd0-f4593dadf23b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ActMap
        m_ActMap = asset.FindActionMap("ActMap", throwIfNotFound: true);
        m_ActMap_Up = m_ActMap.FindAction("Up", throwIfNotFound: true);
        m_ActMap_Down = m_ActMap.FindAction("Down", throwIfNotFound: true);
        m_ActMap_Left = m_ActMap.FindAction("Left", throwIfNotFound: true);
        m_ActMap_Right = m_ActMap.FindAction("Right", throwIfNotFound: true);
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

    // ActMap
    private readonly InputActionMap m_ActMap;
    private IActMapActions m_ActMapActionsCallbackInterface;
    private readonly InputAction m_ActMap_Up;
    private readonly InputAction m_ActMap_Down;
    private readonly InputAction m_ActMap_Left;
    private readonly InputAction m_ActMap_Right;
    public struct ActMapActions
    {
        private @PlayerControls m_Wrapper;
        public ActMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_ActMap_Up;
        public InputAction @Down => m_Wrapper.m_ActMap_Down;
        public InputAction @Left => m_Wrapper.m_ActMap_Left;
        public InputAction @Right => m_Wrapper.m_ActMap_Right;
        public InputActionMap Get() { return m_Wrapper.m_ActMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActMapActions set) { return set.Get(); }
        public void SetCallbacks(IActMapActions instance)
        {
            if (m_Wrapper.m_ActMapActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_ActMapActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_ActMapActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_ActMapActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_ActMapActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_ActMapActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_ActMapActionsCallbackInterface.OnDown;
                @Left.started -= m_Wrapper.m_ActMapActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_ActMapActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_ActMapActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_ActMapActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_ActMapActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_ActMapActionsCallbackInterface.OnRight;
            }
            m_Wrapper.m_ActMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
            }
        }
    }
    public ActMapActions @ActMap => new ActMapActions(this);
    public interface IActMapActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
}
