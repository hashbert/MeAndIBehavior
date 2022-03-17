using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private RebindingController rebindingController;

    //pause menu
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pauseButtons;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private Button optionsBackButton;
    [SerializeField] private Button resumeButton;

    //options menu
    [SerializeField] private Button audioButton;
    [SerializeField] private GameObject audioMenu;
    [SerializeField] private GameObject visualMenu;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private Button controlBackButton;
    [SerializeField] private GameObject languageMenu;

    //controls
    [SerializeField] private Button gamepadButton;
    [SerializeField] private GameObject gamepadPanel;
    [SerializeField] private Button gamepadDoneButton;
    [SerializeField] private GameObject keyboardPanel;

    //gamepad menus

    [SerializeField] private GameObject gamepadPanelNorth;
    //[SerializeField] private Button teleportButton;
    [SerializeField] private GameObject gamepadPanelEast;
    //[SerializeField] private Button grabButton;
    [SerializeField] private GameObject gamepadPanelSouth;
    //[SerializeField] private Button jumpButton;
    [SerializeField] private GameObject gamepadPanelWest;
    //[SerializeField] private Button switchButton;
    [SerializeField] private GameObject assignAllButtonsPanel;

    public bool IsPaused { get; private set; }

    //changing the material to normal and back again...
    [SerializeField] private Material invertMaterial;
    [SerializeField] private Material plainMaterial;
    [SerializeField] private GameObject kidObject;
    [SerializeField] private GameObject adultObject;
    [SerializeField] private GameObject photoObject;
    [SerializeField] private PlayerColorSwap kidColorSwap;
    [SerializeField] private PlayerColorSwap adultColorSwap;
    [SerializeField] private PlayerColorSwap photoColorSwap;
    [SerializeField] private SwitchCharacter switchCharacterScript;

    // Start is called before the first frame update
    void Start()
    {
        IsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        playerInput.SwitchCurrentActionMap("UI");
        IsPaused = true;

        //changing the material to normal and back again...
        adultObject.GetComponent<SpriteRenderer>().material = plainMaterial;
        kidObject.GetComponent<SpriteRenderer>().material = plainMaterial;
        photoObject.GetComponent<SpriteRenderer>().material = plainMaterial;
    }

    #region Pause Menu
    public void ResumeGame()
    {
        Time.timeScale = 1;
        playerInput.SwitchCurrentActionMap("Player");
        pausePanel.SetActive(false);
        IsPaused = false;
        //changing the material to normal and back again...
        adultObject.GetComponent<SpriteRenderer>().material = invertMaterial;
        kidObject.GetComponent<SpriteRenderer>().material = invertMaterial;
        photoObject.GetComponent<SpriteRenderer>().material = invertMaterial;
        if (switchCharacterScript.KidActive)
        {
            adultColorSwap.ResetSwap();
            adultColorSwap.Swap();
            photoColorSwap.ResetSwap();
            photoColorSwap.Swap();
        }
        else
        {
            kidColorSwap.ResetSwap();
            kidColorSwap.Swap();
            photoColorSwap.ResetSwap();
        }
    }
    public void OptionsButton()
    {
        pauseButtons.SetActive(false);
        optionsMenu.SetActive(true);
        audioButton.Select();
    }
    public void ExitToTitle()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    //options buttons

    public void AudioButton()
    {
        audioMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    public void VisualsButton()
    {
        visualMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    public void ControlsButton()
    {
        controlsMenu.SetActive(true);
        optionsMenu.SetActive(false);
        gamepadButton.Select();
    }
    public void LanguageButton()
    {
        languageMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    //controls menu
    public void GoToGamepadRebinding()
    {
        gamepadPanel.SetActive(true);
        controlsMenu.SetActive(false);
    }
    public void GoToKeyboardRebinding()
    {
        keyboardPanel.SetActive(true);
        controlsMenu.SetActive(false);
    }
    //    public void QuitButton()
    //    {
    //        if (Application.isPlaying)
    //        {
    //#if UNITY_EDITOR
    //            UnityEditor.EditorApplication.isPlaying = false;
    //#else
    //            Application.Quit();
    //#endif
    //        }
    //    }



    #endregion

    public void OnPauseInput(InputAction.CallbackContext context)  //when controlling kid or adult
    {
        if (context.started)
        {
            if (!IsPaused)
            {
                PauseGame();
            }
        }
    }

    public void OnBackInput(InputAction.CallbackContext context) //when in pause menus
    {
        if (context.started)
        {
            if (pauseButtons.activeSelf)
            {
                ResumeGame();
            }
            else if (optionsMenu.activeSelf)
            {
                GoBackToPauseButtons();
            }
            else if (audioMenu.activeSelf)
            {
                GoBackToOptionsMenu();
            }
            else if (visualMenu.activeSelf)
            {
                GoBackToOptionsMenu();
            }
            else if (controlsMenu.activeSelf)
            {
                GoBackToOptionsMenu();
            }
            else if (languageMenu.activeSelf)
            {
                GoBackToOptionsMenu();
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
                    rebindingController.Save();
                    GoBackToControlsMenu();
                }
                else
                {
                    assignAllButtonsPanel.SetActive(true);
                }
            }
            else if (keyboardPanel.activeSelf)
            {
                GoBackToControlsMenu();
            }
        }
    }

    public void GoBackToControlsMenu()
    {
        keyboardPanel.SetActive(false);
        gamepadPanel.SetActive(false);
        controlsMenu.SetActive(true);
        controlBackButton.Select();
    }

    public void GoBackToOptionsMenu()
    {
        audioMenu.SetActive(false);
        visualMenu.SetActive(false);
        controlsMenu.SetActive(false);
        languageMenu.SetActive(false);
        optionsMenu.SetActive(true);
        optionsBackButton.Select();
    }

    public void GoBackToPauseButtons()
    {
        optionsMenu.SetActive(false);
        pauseButtons.SetActive(true);
        resumeButton.Select();
    }

    public void GoToGamepadMenu()
    {
        gamepadPanelNorth.SetActive(false);
        gamepadPanelEast.SetActive(false);
        gamepadPanelSouth.SetActive(false);
        gamepadPanelWest.SetActive(false);
        gamepadDoneButton.Select();
    }

    public void SaveAndGoBack()
    {
        if (gamepadPanel.GetComponent<GamepadPanel>().AllButtonsAssigned())
        {
            rebindingController.Save();
            GoBackToControlsMenu();
        }
        else
        {
            assignAllButtonsPanel.SetActive(true);
        }
    }
}