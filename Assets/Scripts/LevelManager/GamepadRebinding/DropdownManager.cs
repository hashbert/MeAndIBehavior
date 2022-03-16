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

    [SerializeField] private GameObject northDropdown;
    [SerializeField] private GameObject westDropdown;
    [SerializeField] private GameObject eastDropdown;
    [SerializeField] private GameObject southDropdown;

    private int upVal;
    private int westVal;
    private int eastVal;
    private int southVal;

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
            upVal = 0;
        }
        else if (jumpBinding.Equals("Button West [Gamepad]"))
        {
            westVal = 0;
        }
        else if (jumpBinding.Equals("Button East [Gamepad]"))
        {
            eastVal = 0;
        }
        else if (jumpBinding.Equals("Button South [Gamepad]"))
        {
            southVal = 0;
        }

        if (grabBinding.Equals("Button North [Gamepad]"))
        {
            upVal = 1;
        }
        else if (grabBinding.Equals("Button West [Gamepad]"))
        {
            westVal = 1;
        }
        else if (grabBinding.Equals("Button East [Gamepad]"))
        {
            eastVal = 1;
        }
        else if (grabBinding.Equals("Button South [Gamepad]"))
        {
            southVal = 1;
        }

        if (switchBinding.Equals("Button North [Gamepad]"))
        {
            upVal = 2;
        }
        else if (switchBinding.Equals("Button West [Gamepad]"))
        {
            westVal = 2;
        }
        else if (switchBinding.Equals("Button East [Gamepad]"))
        {
            eastVal = 2;
        }
        else if (switchBinding.Equals("Button South [Gamepad]"))
        {
            southVal = 2;
        }

        if (teleportBinding.Equals("Button North [Gamepad]"))
        {
            upVal = 3;
        }
        else if (teleportBinding.Equals("Button West [Gamepad]"))
        {
            westVal = 3;
        }
        else if (teleportBinding.Equals("Button East [Gamepad]"))
        {
            eastVal = 3;
        }
        else if (teleportBinding.Equals("Button South [Gamepad]"))
        {
            southVal = 3;
        }

        northDropdown.GetComponent<TMP_Dropdown>().value = upVal;
        westDropdown.GetComponent<TMP_Dropdown>().value = westVal;
        eastDropdown.GetComponent<TMP_Dropdown>().value = eastVal;
        southDropdown.GetComponent<TMP_Dropdown>().value = southVal;
    }
    public void HandleNorthInputData(int val)
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
            grab.action.ApplyBindingOverride(new InputBinding
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
                overridePath = "<Gamepad>/buttonNorth"
            });
        }
        else if (val == 3)
        {
            teleport.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonNorth"
            });
        }
    }
    public void HandleWestInputData(int val)
    {
        if (val == 0)
        {
            jump.action.ApplyBindingOverride(new InputBinding
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
                overridePath = "<Gamepad>/buttonWest"
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
            teleport.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonWest"
            });
        }
    }
    public void HandleEastInputData(int val)
    {
        if (val == 0)
        {
            jump.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonEast"
            });

        }
        else if (val == 1)
        {
            grab.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonEast"
            });
        }
        else if (val == 2)
        {
            switchCharacter.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonEast"
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
    public void HandleSouthInputData(int val)
    {
        if (val == 0)
        {
            jump.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonSouth"
            });
        }
        else if (val == 1)
        {
            grab.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonSouth"
            });
        }
        else if (val == 2)
        {
            switchCharacter.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonSouth"
            });
        }
        else if (val == 3)
        {
            teleport.action.ApplyBindingOverride(new InputBinding
            {
                groups = "Gamepad",
                overridePath = "<Gamepad>/buttonSouth"
            });
        }
    }
}
