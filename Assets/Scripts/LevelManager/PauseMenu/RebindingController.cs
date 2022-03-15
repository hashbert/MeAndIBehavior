using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class RebindingController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject northDropdown;
    [SerializeField] private GameObject westDropdown;
    [SerializeField] private GameObject eastDropdown;
    [SerializeField] private GameObject southDropdown;

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

        northDropdown.GetComponent<TMP_Dropdown>().value = 0;
        westDropdown.GetComponent<TMP_Dropdown>().value = 1;
        eastDropdown.GetComponent<TMP_Dropdown>().value = 2;
        southDropdown.GetComponent<TMP_Dropdown>().value = 3;
    }
}