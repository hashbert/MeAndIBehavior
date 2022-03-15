using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class RebindingDisplay : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpAction = null;
    [SerializeField] private PlayerInput playerInput = null;
    [SerializeField] private string originalDisplayNameText;
    [SerializeField] private TMP_Text bindingDisplayNameText = null;
    [SerializeField] private GameObject startRebindObject = null;
    [SerializeField] private GameObject waitingForInputObject = null;

    [SerializeField] private GameObject jumpDropdown;
    [SerializeField] private GameObject grabDropdown;
    [SerializeField] private GameObject switchCharacterDropdown;
    [SerializeField] private GameObject teleportDropdown;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    private const string RebindsKey = "rebinds";

    private void Awake()
    {
        originalDisplayNameText = bindingDisplayNameText.text;
        Debug.Log(originalDisplayNameText);
        string rebinds = PlayerPrefs.GetString(RebindsKey, string.Empty);

        if (string.IsNullOrEmpty(rebinds)) { return; }

        playerInput.actions.LoadBindingOverridesFromJson(rebinds);

        int bindingIndex = jumpAction.action.GetBindingIndexForControl(jumpAction.action.controls[0]);

        bindingDisplayNameText.text = InputControlPath.ToHumanReadableString(
            jumpAction.action.bindings[bindingIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);
    }

    public void Save()
    {
        string rebinds = playerInput.actions.SaveBindingOverridesAsJson();

        PlayerPrefs.SetString(RebindsKey, rebinds);
    }

    public void StartRebinding()
    {
        startRebindObject.SetActive(false);
        waitingForInputObject.SetActive(true);

        playerInput.SwitchCurrentActionMap("UI");

        rebindingOperation = jumpAction.action.PerformInteractiveRebinding()
            .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => RebindComplete())
            .Start();
    }

    private void RebindComplete()
    {
        int bindingIndex = jumpAction.action.GetBindingIndexForControl(jumpAction.action.controls[0]);

        bindingDisplayNameText.text = InputControlPath.ToHumanReadableString(
            jumpAction.action.bindings[bindingIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);

        rebindingOperation.Dispose();

        startRebindObject.SetActive(true);
        waitingForInputObject.SetActive(false);

        //playerInput.SwitchCurrentActionMap("Player");
    }
    public void RestoreDefaults()
    {
        playerInput.actions.RemoveAllBindingOverrides();
        string rebinds = string.Empty;
        PlayerPrefs.SetString(RebindsKey, rebinds);
        bindingDisplayNameText.text = originalDisplayNameText;


        jumpDropdown.GetComponent<TMP_Dropdown>().value = 0;
        grabDropdown.GetComponent<TMP_Dropdown>().value = 0;
        switchCharacterDropdown.GetComponent<TMP_Dropdown>().value = 0;
        teleportDropdown.GetComponent<TMP_Dropdown>().value = 0;
    }
}