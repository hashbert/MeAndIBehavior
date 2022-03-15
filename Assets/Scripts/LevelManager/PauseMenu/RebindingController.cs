using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class RebindingController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject jumpDropdown;
    [SerializeField] private GameObject grabDropdown;
    [SerializeField] private GameObject switchCharacterDropdown;
    [SerializeField] private GameObject teleportDropdown;

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

        jumpDropdown.GetComponent<TMP_Dropdown>().value = 0;
        grabDropdown.GetComponent<TMP_Dropdown>().value = 0;
        switchCharacterDropdown.GetComponent<TMP_Dropdown>().value = 0;
        teleportDropdown.GetComponent<TMP_Dropdown>().value = 0;
    }
}