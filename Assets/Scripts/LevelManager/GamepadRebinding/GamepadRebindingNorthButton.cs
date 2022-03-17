using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
public class GamepadRebindingNorthButton : MonoBehaviour
{
    [SerializeField] private InputActionReference teleport;
    [SerializeField] private InputActionReference switchCharacter;
    [SerializeField] private InputActionReference grab;
    [SerializeField] private InputActionReference jump;

    [SerializeField] private Button northToggleButton;
    [SerializeField] private TMP_Text northToggle;

    [SerializeField] private GameObject gamepadRemapNorthPanel;
    [SerializeField] private GamepadPanel gamepadPanel;
    [SerializeField] private TMP_Text[] buttonArray;


    public void TeleportButton()
    {
        var teleportControllerIndex = teleport.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        teleport.action.ApplyBindingOverride(teleportControllerIndex, "<Gamepad>/buttonNorth");
        foreach (TMP_Text txt in buttonArray)
        {
            if (txt.text.Equals("TELEPORT"))
            {
                txt.text = "pick an action";
            }
        }
        northToggle.text = "TELEPORT";
        gamepadRemapNorthPanel.SetActive(false);
        northToggleButton.Select();
    }
    public void GrabButton()
    {
        var grabControllerIndex = grab.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        grab.action.ApplyBindingOverride(grabControllerIndex, "<Gamepad>/buttonNorth");
        foreach(TMP_Text txt in buttonArray)
        {
            if (txt.text.Equals("GRAB"))
            {
                txt.text = "pick an action";
            }
        }
        northToggle.text = "GRAB";
        gamepadRemapNorthPanel.SetActive(false);
        northToggleButton.Select();
    }
    public void JumpButton()
    {
        //// Override the binding to the gamepad South button with a binding to
        // the North button.
        var jumpControllerIndex = jump.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        jump.action.ApplyBindingOverride(jumpControllerIndex, "<Gamepad>/buttonNorth");
        foreach (TMP_Text txt in buttonArray)
        {
            if (txt.text.Equals("JUMP"))
            {
                txt.text = "pick an action";
            }
        }
        northToggle.text = "JUMP";
        gamepadRemapNorthPanel.SetActive(false);
        northToggleButton.Select();
    }
    public void SwitchCharacterButton()
    {
        //switchCharacter.action.ApplyBindingOverride(new InputBinding
        //{
        //    groups = "Gamepad",
        //    overridePath = "<Gamepad>/buttonNorth"
        //});
        var switchControllerIndex = switchCharacter.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        switchCharacter.action.ApplyBindingOverride(switchControllerIndex, "<Gamepad>/buttonNorth");
        foreach (TMP_Text txt in buttonArray)
        {
            if (txt.text.Equals("SWITCH CHARACTER"))
            {
                txt.text = "pick an action";
            }
        }
        northToggle.text = "SWITCH CHARACTER";
        gamepadRemapNorthPanel.SetActive(false);
        northToggleButton.Select();
    }
}
