using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class GamepadPanel : MonoBehaviour
{
    [SerializeField] private InputActionReference teleport;
    [SerializeField] private InputActionReference switchCharacter;
    [SerializeField] private InputActionReference grab;
    [SerializeField] private InputActionReference jump;

    //[SerializeField] private InputBinding teleport1;
    //[SerializeField] private InputAction buttonNorth;

    [SerializeField] private Button northToggle;
    [SerializeField] private Button eastToggle;
    [SerializeField] private Button southToggle;
    [SerializeField] private Button westToggle;

    [SerializeField] private TMP_Text northToggleText;
    [SerializeField] private TMP_Text eastToggleText;
    [SerializeField] private TMP_Text southToggleText;
    [SerializeField] private TMP_Text westToggleText;

    [SerializeField] private GameObject remapNorthButtonPanel;
    [SerializeField] private GameObject remapEastButtonPanel;
    [SerializeField] private GameObject remapSouthButtonPanel;
    [SerializeField] private GameObject remapWestButtonPanel;

    private string northString;
    private string eastString;
    private string southString;
    private string westString;

    private void OnEnable()
    {
        //// Look up binding indices with GetBindingIndex.
        //var teleportControllerIndex = teleport.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        //var teleportBind = teleport.action.GetBindingDisplayString(teleportControllerIndex);
        //Debug.Log(teleportControllerIndex);  //1
        //Debug.Log(teleportBind);
        ////Y     =NORTH

        //var grabControllerIndex = grab.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        //var grabBind = grab.action.GetBindingDisplayString(grabControllerIndex);
        //Debug.Log(grabControllerIndex);  //1
        //Debug.Log(grabBind);
        ////B    =EAST

        //var jumpControllerIndex = jump.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        //var jumpBind = jump.action.GetBindingDisplayString(jumpControllerIndex);
        //Debug.Log(jumpControllerIndex); //1
        //Debug.Log(jumpBind);
        ////Press A         =SOUTH

        //var switchControllerIndex = switchCharacter.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        //var switchBind = switchCharacter.action.GetBindingDisplayString(switchControllerIndex);
        //Debug.Log(switchControllerIndex); //1
        //Debug.Log(switchBind);
        ////X              =WEST

        //var teleportKeyboardIndex = teleport.action.GetBindingIndex(InputBinding.MaskByGroup("Keyboard&Mouse"));
        //var teleportKeyboardBind = teleport.action.GetBindingDisplayString(teleportKeyboardIndex);
        //Debug.Log(teleportKeyboardIndex); //0
        //Debug.Log(teleportKeyboardBind);
        ////T              =T key wohooo.

        //var bindingString = jump.action.GetBindingDisplayString(InputBinding.MaskByGroup("Gamepad"));
        //Debug.Log(bindingString);

        //controlPath--> 

        //    best examples------------
        //    var teleportControllerIndex = teleport.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        //    var teleportBinding = InputControlPath.ToHumanReadableString(teleport.action.bindings[teleportControllerIndex].effectivePath);

        //    var jumpBinding = InputControlPath.ToHumanReadableString(jump.action.bindings[1].effectivePath,
        //InputControlPath.HumanReadableStringOptions.OmitDevice);
        //
        //Input Action:     "<Gamepad>/buttonNorth"
        //Input Binding:    path: "<Gamepad>/buttonSouth"
        //    ------------------------

        var teleportControllerIndex = teleport.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        var teleportBinding = InputControlPath.ToHumanReadableString(teleport.action.bindings[teleportControllerIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);

        var grabControllerIndex = grab.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        var grabBinding = InputControlPath.ToHumanReadableString(grab.action.bindings[grabControllerIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);

        var jumpControllerIndex = jump.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        var jumpBinding = InputControlPath.ToHumanReadableString(jump.action.bindings[jumpControllerIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);

        var switchControllerIndex = switchCharacter.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        var switchBinding = InputControlPath.ToHumanReadableString(switchCharacter.action.bindings[switchControllerIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);
        Debug.Log("teleport binding is: " + teleportBinding);
        Debug.Log("grab binding is: " + grabBinding);
        Debug.Log("jump binding is: " + jumpBinding);
        Debug.Log("switch binding is: " + switchBinding);
            

        if (teleportBinding.Equals("Button North"))
        {
            northString = "TELEPORT";
        }
        else if (teleportBinding.Equals("Button East"))
        {
            eastString = "TELEPORT";
        }
        else if (teleportBinding.Equals("Button South"))
        {
            southString = "TELEPORT";
        }
        else if (teleportBinding.Equals("Button West"))
        {
            westString = "TELEPORT";
        }

        if (grabBinding.Equals("Button North"))
        {
            northString = "GRAB";
        }
        else if (grabBinding.Equals("Button East"))
        {
            eastString = "GRAB";
        }
        else if (grabBinding.Equals("Button South"))
        {
            southString = "GRAB";
        }
        else if (grabBinding.Equals("Button West"))
        {
            westString = "GRAB";
        }

        if (jumpBinding.Equals("Button North"))
        {
            northString = "JUMP";
        }
        else if (jumpBinding.Equals("Button East"))
        {
            eastString = "JUMP";
        }
        else if (jumpBinding.Equals("Button South"))
        {
            southString = "JUMP";
        }
        else if (jumpBinding.Equals("Button West"))
        {
            westString = "JUMP";
        }

        if (switchBinding.Equals("Button North"))
        {
            northString = "SWITCH CHARACTER";
        }
        else if (switchBinding.Equals("Button East"))
        {
            eastString = "SWITCH CHARACTER";
        }
        else if (switchBinding.Equals("Button South"))
        {
            southString = "SWITCH CHARACTER";
        }
        else if (switchBinding.Equals("Button West"))
        {
            westString = "SWITCH CHARACTER";
        }
        northToggleText.text = northString;
        eastToggleText.text = eastString;
        southToggleText.text = southString;
        westToggleText.text = westString;
        
    }
    public void NorthToggleClicked()
    {
        remapNorthButtonPanel.SetActive(true);
    }

    public void EastToggleClicked()
    {
        remapEastButtonPanel.SetActive(true);
    }

    public void SouthToggleClicked()
    {
        remapSouthButtonPanel.SetActive(true);
    }

    public void WestToggleClicked()
    {
        remapWestButtonPanel.SetActive(true);
    }

    public bool AllButtonsAssigned()
    {
        var teleportControllerIndex = teleport.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        var teleportBinding = InputControlPath.ToHumanReadableString(teleport.action.bindings[teleportControllerIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);

        var grabControllerIndex = grab.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        var grabBinding = InputControlPath.ToHumanReadableString(grab.action.bindings[grabControllerIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);

        var jumpControllerIndex = jump.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        var jumpBinding = InputControlPath.ToHumanReadableString(jump.action.bindings[jumpControllerIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);

        var switchControllerIndex = switchCharacter.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        var switchBinding = InputControlPath.ToHumanReadableString(switchCharacter.action.bindings[switchControllerIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);

        HashSet<string> allButtons = new HashSet<string>();
        allButtons.Add(teleportBinding);
        allButtons.Add(grabBinding);
        allButtons.Add(jumpBinding);
        allButtons.Add(switchBinding);

        if (allButtons.Count < 4)
        {
            return false;
        }
        else return true;
    }
}
