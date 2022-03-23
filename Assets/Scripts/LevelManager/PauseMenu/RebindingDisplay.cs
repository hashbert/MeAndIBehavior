using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class RebindingDisplay : MonoBehaviour
{
    [SerializeField] private InputActionReference teleport = null;
    [SerializeField] private InputActionReference grab = null;
    [SerializeField] private InputActionReference jump = null;
    [SerializeField] private InputActionReference switchCharacters = null;
    [SerializeField] private PlayerInput playerInput = null;
    //[SerializeField] private string originalDisplayNameText;
    [SerializeField] private TMP_Text teleportBindingText = null;
    [SerializeField] private TMP_Text grabBindingText = null;
    [SerializeField] private TMP_Text jumpBindingText = null;
    [SerializeField] private TMP_Text switchBindingText = null;
    [SerializeField] private GameObject startTeleportRebindObject = null;
    [SerializeField] private GameObject startGrabRebindObject = null;
    [SerializeField] private GameObject startJumpRebindObject = null;
    [SerializeField] private GameObject startSwitchRebindObject = null;
    [SerializeField] private GameObject waitingForInputObjectTeleport = null;
    [SerializeField] private GameObject waitingForInputObjectGrab = null;
    [SerializeField] private GameObject waitingForInputObjectJump = null;
    [SerializeField] private GameObject waitingForInputObjectSwitch = null;

    //[SerializeField] private GameObject jumpDropdown;
    //[SerializeField] private GameObject grabDropdown;
    //[SerializeField] private GameObject switchCharacterDropdown;
    //[SerializeField] private GameObject teleportDropdown;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    private const string RebindsKey = "rebinds";

    private void OnEnable()
    {
        //originalDisplayNameText = jumpBindingText.text;
        //Debug.Log(originalDisplayNameText);
        string rebinds = PlayerPrefs.GetString(RebindsKey, string.Empty);

        if (string.IsNullOrEmpty(rebinds)) { return; }

        playerInput.actions.LoadBindingOverridesFromJson(rebinds);

        var teleportKeyboardIndex = jump.action.GetBindingIndex(InputBinding.MaskByGroup("Keyboard&Mouse"));
        var grabKeyboardIndex = jump.action.GetBindingIndex(InputBinding.MaskByGroup("Keyboard&Mouse"));
        var jumpKeyboardIndex = jump.action.GetBindingIndex(InputBinding.MaskByGroup("Keyboard&Mouse"));
        //int bindingIndex = jumpAction.action.GetBindingIndexForControl(jumpAction.action.controls[0]);
        var switchKeyboardIndex = jump.action.GetBindingIndex(InputBinding.MaskByGroup("Keyboard&Mouse"));

        teleportBindingText.text = InputControlPath.ToHumanReadableString(
            teleport.action.bindings[teleportKeyboardIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);
        grabBindingText.text = InputControlPath.ToHumanReadableString(
            grab.action.bindings[grabKeyboardIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);
        jumpBindingText.text = InputControlPath.ToHumanReadableString(
            jump.action.bindings[jumpKeyboardIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);
        switchBindingText.text = InputControlPath.ToHumanReadableString(
            switchCharacters.action.bindings[switchKeyboardIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);
    }

    public void Save()
    {
        string rebinds = playerInput.actions.SaveBindingOverridesAsJson();

        PlayerPrefs.SetString(RebindsKey, rebinds);
    }

    public void StartRebinding(int i)
    {
        switch (i)
        {
            case 1:
                startTeleportRebindObject.SetActive(false);
                waitingForInputObjectTeleport.SetActive(true);

                playerInput.SwitchCurrentActionMap("UI");
                var teleportKeyboardIndex = teleport.action.GetBindingIndex(InputBinding.MaskByGroup("Keyboard&Mouse"));
                rebindingOperation = teleport.action.PerformInteractiveRebinding(teleportKeyboardIndex)
                    .WithControlsExcluding("Mouse").WithControlsExcluding("Gamepad")
                    .OnMatchWaitForAnother(0.1f)
                    .OnComplete(operation => RebindComplete(i))
                    .Start();
                break;
            case 2:
                startGrabRebindObject.SetActive(false);
                waitingForInputObjectGrab.SetActive(true);

                playerInput.SwitchCurrentActionMap("UI");
                var grabKeyboardIndex = grab.action.GetBindingIndex(InputBinding.MaskByGroup("Keyboard&Mouse"));
                rebindingOperation = grab.action.PerformInteractiveRebinding(grabKeyboardIndex)
                    .WithControlsExcluding("Mouse").WithControlsExcluding("Gamepad")
                    .OnMatchWaitForAnother(0.1f)
                    .OnComplete(operation => RebindComplete(i))
                    .Start();
                break;
            case 3:
                startJumpRebindObject.SetActive(false);
                waitingForInputObjectJump.SetActive(true);

                playerInput.SwitchCurrentActionMap("UI");
                var jumpKeyboardIndex = jump.action.GetBindingIndex(InputBinding.MaskByGroup("Keyboard&Mouse"));
                rebindingOperation = jump.action.PerformInteractiveRebinding(jumpKeyboardIndex)
                    .WithControlsExcluding("Mouse").WithControlsExcluding("Gamepad")
                    .OnMatchWaitForAnother(0.1f)
                    .OnComplete(operation => RebindComplete(i))
                    .Start();
                break;
            case 4:
                startSwitchRebindObject.SetActive(false);
                waitingForInputObjectSwitch.SetActive(true);

                playerInput.SwitchCurrentActionMap("UI");
                var switchKeyboardIndex = switchCharacters.action.GetBindingIndex(InputBinding.MaskByGroup("Keyboard&Mouse"));
                rebindingOperation = switchCharacters.action.PerformInteractiveRebinding(switchKeyboardIndex)
                    .WithControlsExcluding("Mouse").WithControlsExcluding("Gamepad")
                    .OnMatchWaitForAnother(0.1f)
                    .OnComplete(operation => RebindComplete(i))
                    .Start();
                break;
        }

    }

    private void RebindComplete(int i)
    {
        switch (i)
        {
            case 1:
                var teleportKeyboardIndex = teleport.action.GetBindingIndex(InputBinding.MaskByGroup("Keyboard&Mouse"));
                teleportBindingText.text = InputControlPath.ToHumanReadableString(
                    teleport.action.bindings[teleportKeyboardIndex].effectivePath,
                    InputControlPath.HumanReadableStringOptions.OmitDevice);

                rebindingOperation.Dispose();

                startTeleportRebindObject.SetActive(true);
                waitingForInputObjectTeleport.SetActive(false);
                break;
            case 2:
                var grabKeyboardIndex = grab.action.GetBindingIndex(InputBinding.MaskByGroup("Keyboard&Mouse"));
                grabBindingText.text = InputControlPath.ToHumanReadableString(
                    grab.action.bindings[grabKeyboardIndex].effectivePath,
                    InputControlPath.HumanReadableStringOptions.OmitDevice);

                rebindingOperation.Dispose();

                startGrabRebindObject.SetActive(true);
                waitingForInputObjectGrab.SetActive(false);
                break;
            case 3:
                var jumpKeyboardIndex = jump.action.GetBindingIndex(InputBinding.MaskByGroup("Keyboard&Mouse"));
                jumpBindingText.text = InputControlPath.ToHumanReadableString(
                    jump.action.bindings[jumpKeyboardIndex].effectivePath,
                    InputControlPath.HumanReadableStringOptions.OmitDevice);

                rebindingOperation.Dispose();

                startJumpRebindObject.SetActive(true);
                waitingForInputObjectJump.SetActive(false);
                break;
            case 4:
                var switchKeyboardIndex = grab.action.GetBindingIndex(InputBinding.MaskByGroup("Keyboard&Mouse"));
                switchBindingText.text = InputControlPath.ToHumanReadableString(
                    switchCharacters.action.bindings[switchKeyboardIndex].effectivePath,
                    InputControlPath.HumanReadableStringOptions.OmitDevice);

                rebindingOperation.Dispose();

                startSwitchRebindObject.SetActive(true);
                waitingForInputObjectSwitch.SetActive(false);
                break;
        }
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/SFX/UI/Rebind Received", gameObject);

        //playerInput.SwitchCurrentActionMap("Player");
    }
    public void RestoreDefaults()
    {
        playerInput.actions.RemoveAllBindingOverrides();
        string rebinds = string.Empty;
        PlayerPrefs.SetString(RebindsKey, rebinds);
        teleportBindingText.text = "T";
        grabBindingText.text = "G";
        jumpBindingText.text = "Space";
        switchBindingText.text = "C";


        //jumpDropdown.GetComponent<TMP_Dropdown>().value = 0;
        //grabDropdown.GetComponent<TMP_Dropdown>().value = 0;
        //switchCharacterDropdown.GetComponent<TMP_Dropdown>().value = 0;
        //teleportDropdown.GetComponent<TMP_Dropdown>().value = 0;
    }
}