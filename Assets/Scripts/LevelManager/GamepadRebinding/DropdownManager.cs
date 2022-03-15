using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DropdownManager : MonoBehaviour
{
    [SerializeField] private InputActionReference jump;
    [SerializeField] private InputActionReference grab;
    [SerializeField] private InputActionReference switchCharacter;
    [SerializeField] private InputActionReference teleport;

    [SerializeField] private GameObject jumpDropdown;
    [SerializeField] private GameObject grabDropdown;
    [SerializeField] private GameObject switchCharacterDropdown;
    [SerializeField] private GameObject teleportDropdown;

    private int jumpVal;
    private int grabVal;
    private int switchVal;
    private int teleportVal;

    private void OnEnable()
    {
        var jumpBinding = InputControlPath.ToHumanReadableString(jump.action.bindings[1].effectivePath,
            InputControlPath.HumanReadableStringOptions.None);
        var grabBinding = InputControlPath.ToHumanReadableString(grab.action.bindings[1].effectivePath,
            InputControlPath.HumanReadableStringOptions.None);
        var switchBinding = InputControlPath.ToHumanReadableString(switchCharacter.action.bindings[1].effectivePath,
            InputControlPath.HumanReadableStringOptions.None);
        var teleportBinding = InputControlPath.ToHumanReadableString(teleport.action.bindings[1].effectivePath,
            InputControlPath.HumanReadableStringOptions.None);
        if (jumpBinding.Equals("Button North [Gamepad]"))
        {
            jumpVal = 0;
        }
        else if (jumpBinding.Equals("Button West [Gamepad]"))
        {
            jumpVal = 1;
        }
        else if (jumpBinding.Equals("Button East [Gamepad]"))
        {
            jumpVal = 2;
        }
        else if (jumpBinding.Equals("Button South [Gamepad]"))
        {
            jumpVal = 3;
        }

        if (grabBinding.Equals("Button West [Gamepad]"))
        {
            grabVal = 0;
        }
        else if (grabBinding.Equals("Button North [Gamepad]"))
        {
            grabVal = 1;
        }
        else if (grabBinding.Equals("Button East [Gamepad]"))
        {
            grabVal = 2;
        }
        else if (grabBinding.Equals("Button South [Gamepad]"))
        {
            grabVal = 3;
        }

        if (switchBinding.Equals("Button East [Gamepad]"))
        {
            switchVal = 0;
        }
        else if (switchBinding.Equals("Button North [Gamepad]"))
        {
            switchVal = 1;
        }
        else if (switchBinding.Equals("Button West [Gamepad]"))
        {
            switchVal = 2;
        }
        else if (switchBinding.Equals("Button South [Gamepad]"))
        {
            switchVal = 3;
        }

        if (teleportBinding.Equals("Button South [Gamepad]"))
        {
            teleportVal = 0;
        }
        else if (teleportBinding.Equals("Button North [Gamepad]"))
        {
            teleportVal = 1;
        }
        else if (teleportBinding.Equals("Button West [Gamepad]"))
        {
            teleportVal = 2;
        }
        else if (teleportBinding.Equals("Button East [Gamepad]"))
        {
            teleportVal = 3;
        }

        jumpDropdown.GetComponent<TMP_Dropdown>().value = jumpVal;
        grabDropdown.GetComponent<TMP_Dropdown>().value = grabVal;
        switchCharacterDropdown.GetComponent<TMP_Dropdown>().value = switchVal;
        teleportDropdown.GetComponent<TMP_Dropdown>().value = teleportVal;
    }
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
