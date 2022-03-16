using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
public class GamepadRebindingSouthButton : MonoBehaviour
{
    [SerializeField] private InputActionReference teleport;
    [SerializeField] private InputActionReference switchCharacter;
    [SerializeField] private InputActionReference grab;
    [SerializeField] private InputActionReference jump;

    [SerializeField] private TMP_Text southToggle;
    [SerializeField] private Button southToggleButton;

    [SerializeField] private GameObject gamepadRemapSouthPanel;
    public void TeleportButton()
    {
        var teleportControllerIndex = teleport.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        teleport.action.ApplyBindingOverride(teleportControllerIndex, "<Gamepad>/buttonSouth");
        southToggle.text = "TELEPORT";
        gamepadRemapSouthPanel.SetActive(false);
        southToggleButton.Select();
    }
    public void GrabButton()
    {
        var grabControllerIndex = grab.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        grab.action.ApplyBindingOverride(grabControllerIndex, "<Gamepad>/buttonSouth");
        southToggle.text = "GRAB";
        gamepadRemapSouthPanel.SetActive(false);
        southToggleButton.Select();
    }
    public void JumpButton()
    {
        var jumpControllerIndex = jump.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        jump.action.ApplyBindingOverride(jumpControllerIndex, "<Gamepad>/buttonSouth");
        southToggle.text = "JUMP";
        gamepadRemapSouthPanel.SetActive(false);
        southToggleButton.Select();
    }
    public void SwitchCharacterButton()
    {
        var switchControllerIndex = switchCharacter.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        switchCharacter.action.ApplyBindingOverride(switchControllerIndex, "<Gamepad>/buttonSouth");
        southToggle.text = "SWITCH CHARACTER";
        gamepadRemapSouthPanel.SetActive(false);
        southToggleButton.Select();
    }
}
