using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DropdownManager : MonoBehaviour
{
    [SerializeField] private InputActionReference jump;
    [SerializeField] private InputActionReference grab;
    [SerializeField] private InputActionReference switchCharacter;
    [SerializeField] private InputActionReference teleport;

    public void HandleJumpInputData(int val)
    {
        if (val == 0)
        {
            jump.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonNorth"
            });
        }
        else if (val == 1)
        {
            jump.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonWest"
            });
        }
        else if (val == 2)
        {
            jump.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonEast"
            });
        }
        else if (val == 3)
        {
            jump.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonSouth"
            });
        }
    }
    public void HandleGrabInputData(int val)
    {
        if (val == 0)
        {
            grab.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonWest"
            });
        }
        else if (val == 1)
        {
            grab.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonNorth"
            });
        }
        else if (val == 2)
        {
            grab.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonEast"
            });
        }
        else if (val == 3)
        {
            grab.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonSouth"
            });
        }
    }
    public void HandleSwitchCharacterInputData(int val)
    {
        if (val == 0)
        {
            switchCharacter.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonEast"
            });

        }
        else if (val == 1)
        {
            switchCharacter.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonNorth"
            });

        }
        else if (val == 2)
        {
            switchCharacter.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonWest"
            });
        }
        else if (val == 3)
        {
            switchCharacter.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonSouth"
            });
        }
    }
    public void HandleTeleportInputData(int val)
    {
        if (val == 0)
        {
            teleport.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonSouth"
            });
        }
        else if (val == 1)
        {
            teleport.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonNorth"
            });
        }
        else if (val == 2)
        {
            teleport.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonWest"
            });
        }
        else if (val == 3)
        {
            teleport.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonEast"
            });
        }
    }
}
