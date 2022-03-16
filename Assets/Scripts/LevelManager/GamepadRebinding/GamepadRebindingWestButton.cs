using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
public class GamepadRebindingWestButton : MonoBehaviour
{
    [SerializeField] private InputActionReference teleport;
    [SerializeField] private InputActionReference switchCharacter;
    [SerializeField] private InputActionReference grab;
    [SerializeField] private InputActionReference jump;

    [SerializeField] private TMP_Text westToggle;
    [SerializeField] private Button westToggleButton;

    [SerializeField] private GameObject gamepadRemapWestPanel;
    public void TeleportButton()
    {
        var teleportControllerIndex = teleport.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        teleport.action.ApplyBindingOverride(teleportControllerIndex, "<Gamepad>/buttonWest");
        westToggle.text = "TELEPORT";
        gamepadRemapWestPanel.SetActive(false);
        westToggleButton.Select();
    }
    public void GrabButton()
    {
        var grabControllerIndex = grab.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        grab.action.ApplyBindingOverride(grabControllerIndex, "<Gamepad>/buttonWest");
        westToggle.text = "GRAB";
        gamepadRemapWestPanel.SetActive(false);
        westToggleButton.Select();
    }
    public void JumpButton()
    {
        var jumpControllerIndex = jump.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        jump.action.ApplyBindingOverride(jumpControllerIndex, "<Gamepad>/buttonWest");
        westToggle.text = "JUMP";
        gamepadRemapWestPanel.SetActive(false);
        westToggleButton.Select();
    }
    public void SwitchCharacterButton()
    {
        var switchControllerIndex = switchCharacter.action.GetBindingIndex(InputBinding.MaskByGroup("Gamepad"));
        switchCharacter.action.ApplyBindingOverride(switchControllerIndex, "<Gamepad>/buttonWest");
        westToggle.text = "SWITCH CHARACTER";
        gamepadRemapWestPanel.SetActive(false);
        westToggleButton.Select();
    }
}
