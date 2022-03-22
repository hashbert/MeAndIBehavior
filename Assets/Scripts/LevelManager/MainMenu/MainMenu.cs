using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    //Start Menu
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject startButton;

    //Load Level Menu
    [SerializeField] private GameObject loadLevelPanel;

    //Options Menu
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject optionsBackButton;

    //Audio Menu
    [SerializeField] private GameObject audioMenu;
    [SerializeField] private GameObject audioButton;
    [SerializeField] private GameObject masterSliderButton;

    //Visual Menu
    [SerializeField] private GameObject visualMenu;

    //Controls Menu
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject gamepadPanel;
    [SerializeField] private GameObject keyboardPanel;
    [SerializeField] private RebindingController rebindingDisplayScript;

    // //GamepadPanels
    [SerializeField] private GameObject gamepadPanelNorth;
    [SerializeField] private GameObject gamepadPanelEast;
    [SerializeField] private GameObject gamepadPanelSouth;
    [SerializeField] private GameObject gamepadPanelWest;
    [SerializeField] private GameObject assignAllButtonsPanel;
    [SerializeField] private Button doneButton;

    //Language Menu
    [SerializeField] private GameObject languageMenu;

    //make look nice
    [SerializeField] private GameObject fader;
    //play particles
    [SerializeField] private ParticleSystem particles;

    #region Start Menu
    public void StartButton()
    {
        fader.SetActive(true);
        fader.GetComponent<Fader>().SetNextSceneName("Cutscene01");
    }
    public void LoadLevelButton()
    {
        startMenu.SetActive(false);
        loadLevelPanel.SetActive(true);
    }
    public void OptionsButton()
    {
        startMenu.SetActive(false);
        optionsMenu.SetActive(true);
        audioButton.GetComponent<Button>().Select();
    }
    public void CreditsButton()
    {
        SceneManager.LoadScene("CreditsScene");
    }
    public void QuitGame()
    {
        if (Application.isPlaying)
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
    #endregion
    public void LoadLevelBackButton()
    {
        GoToStartMenu();
    }
    #region Options Menu
    public void AudioButton()
    {
        optionsMenu.SetActive(false);
        audioMenu.SetActive(true);
        masterSliderButton.GetComponent<Slider>().Select();
    }
    public void VisualButton()
    {
        optionsMenu.SetActive(false);
        visualMenu.SetActive(true);
    }
    public void ControlsButton()
    {
        optionsMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }
    public void LanguageButton()
    {
        optionsMenu.SetActive(false);
        languageMenu.SetActive(true);
    }
    #endregion

    #region Control Menu
    public void KeyboardControlsButton()
    {
        controlsMenu.SetActive(false);
        keyboardPanel.SetActive(true);
    }
    public void GamepadControlsButton()
    {
        controlsMenu.SetActive(false);
        gamepadPanel.SetActive(true);
    }
    public void GoToControlMenu()
    {
        gamepadPanel.SetActive(false);
        keyboardPanel.SetActive(false);
        controlsMenu.SetActive(true);
    }
    public void SaveAndExitBindings()
    {
        if (gamepadPanel.GetComponent<GamepadPanel>().AllButtonsAssigned())
        {
            rebindingDisplayScript.Save();
            gamepadPanel.SetActive(false);
            keyboardPanel.SetActive(false);
            controlsMenu.SetActive(true);
        }
        else
        {
            assignAllButtonsPanel.SetActive(true);
        }
            
    }
    public void RestoreDefaultsButton()
    {
        rebindingDisplayScript.Save();
    }
    public void GoToGamepadMenu()
    {
        gamepadPanelNorth.SetActive(false);
        gamepadPanelEast.SetActive(false);
        gamepadPanelSouth.SetActive(false);
        gamepadPanelWest.SetActive(false);
        doneButton.Select();
    }
    #endregion

    public void GoToStartMenu()
    {
        loadLevelPanel.SetActive(false);
        optionsMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    public void GoToOptionsMenu()
    {
        audioMenu.SetActive(false);
        visualMenu.SetActive(false);
        controlsMenu.SetActive(false);
        gamepadPanel.SetActive(false);
        languageMenu.SetActive(false);
        optionsMenu.SetActive(true);
        optionsBackButton.GetComponent<Button>().Select();
    }

    public void OnBackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (loadLevelPanel.activeSelf)
            {
                GoToStartMenu();
            }
            else if (optionsMenu.activeSelf)
            {
                GoToStartMenu();
            }
            else if (audioMenu.activeSelf)
            {
                GoToOptionsMenu();
            }
            else if (visualMenu.activeSelf)
            {
                GoToOptionsMenu();
            }
            else if (controlsMenu.activeSelf)
            {
                GoToOptionsMenu();
            }
            else if (languageMenu.activeSelf)
            {
                GoToOptionsMenu();
            }
            else if (gamepadPanelNorth.activeSelf || gamepadPanelEast.activeSelf ||
    gamepadPanelSouth.activeSelf || gamepadPanelWest.activeSelf)
            {
                GoToGamepadMenu();
            }
            else if (gamepadPanel.activeSelf)
            {
                if (gamepadPanel.GetComponent<GamepadPanel>().AllButtonsAssigned())
                {
                    rebindingDisplayScript.Save();
                    GoToControlMenu();
                }
                else
                {
                    assignAllButtonsPanel.SetActive(true);
                }
            }
            else if (keyboardPanel.activeSelf)
            {
                GoToControlMenu();
            }

        }
    }

    private void OnEnable()
    {
        particles.Play();
    }
}
