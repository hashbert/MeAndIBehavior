using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class GamepadRebindingEastButton : MonoBehaviour
{
    [SerializeField] private InputActionReference teleport;
    [SerializeField] private InputActionReference switchCharacter;
    [SerializeField] private InputActionReference grab;
    [SerializeField] private InputActionReference jump;

    [SerializeField] private TMP_Text eastToggle;
    [SerializeField] private Button eastToggleButton;

    [SerializeField] private GameObject gamepadRemapEastPanel;
    [SerializeField] private TMP_Text[] buttonArray;
    public void TeleportButton()
    {
        var teleportControllerIndex = teleport.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        teleport.action.ApplyBindingOverride(teleportControllerIndex, "<Gamepad>/buttonEast");
        foreach (TMP_Text txt in buttonArray)
        {
            if (txt.text.Equals("TELEPORT"))
            {
                txt.text = "pick an action";
            }
        }
        eastToggle.text = "TELEPORT";
        gamepadRemapEastPanel.SetActive(false);
        eastToggleButton.Select();
    }
    public void GrabButton()
    {
        var grabControllerIndex = grab.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        grab.action.ApplyBindingOverride(grabControllerIndex, "<Gamepad>/buttonEast");
        foreach (TMP_Text txt in buttonArray)
        {
            if (txt.text.Equals("GRAB"))
            {
                txt.text = "pick an action";
            }
        }
        eastToggle.text = "GRAB";
        gamepadRemapEastPanel.SetActive(false);
        eastToggleButton.Select();
    }
    public void JumpButton()
    {
        var jumpControllerIndex = jump.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        jump.action.ApplyBindingOverride(jumpControllerIndex, "<Gamepad>/buttonEast");
        foreach (TMP_Text txt in buttonArray)
        {
            if (txt.text.Equals("JUMP"))
            {
                txt.text = "pick an action";
            }
        }
        eastToggle.text = "JUMP";
        gamepadRemapEastPanel.SetActive(false);
        eastToggleButton.Select();
    }
    public void SwitchCharacterButton()
    {
        var switchControllerIndex = switchCharacter.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        switchCharacter.action.ApplyBindingOverride(switchControllerIndex, "<Gamepad>/buttonEast");
        foreach (TMP_Text txt in buttonArray)
        {
            if (txt.text.Equals("SWITCH CHARACTER"))
            {
                txt.text = "pick an action";
            }
        }
        eastToggle.text = "SWITCH CHARACTER";
        gamepadRemapEastPanel.SetActive(false);
        eastToggleButton.Select();
    }
}
