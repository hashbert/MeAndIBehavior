using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class RebindingController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private TMP_Text northToggle;
    [SerializeField] private TMP_Text eastToggle;
    [SerializeField] private TMP_Text southToggle;
    [SerializeField] private TMP_Text westToggle;

    [SerializeField] private TMP_Text teleportBindingText;
    [SerializeField] private TMP_Text grabBindingText;
    [SerializeField] private TMP_Text jumpBindingText;
    [SerializeField] private TMP_Text switchBindingText;

    private const string RebindsKey = "rebinds";

    private void Start()
    {
        string rebinds = PlayerPrefs.GetString(RebindsKey, string.Empty);

        if (string.IsNullOrEmpty(rebinds)) { return; }

        playerInput.actions.LoadBindingOverridesFromJson(rebinds);
    }

    public void Save()
    {
        string rebinds = playerInput.actions.SaveBindingOverridesAsJson();

        PlayerPrefs.SetString(RebindsKey, rebinds);
    }
    public void RestoreDefaults()
    {
        playerInput.actions.RemoveAllBindingOverrides();
        string rebinds = string.Empty;
        PlayerPrefs.SetString(RebindsKey, rebinds);

        northToggle.text = "TELEPORT";
        eastToggle.text = "GRAB";
        southToggle.text = "JUMP";
        westToggle.text = "SWITCH CHARACTER";

        teleportBindingText.text="T";
        grabBindingText.text="G";
        jumpBindingText.text="Space";
        switchBindingText.text="C";
    }
}