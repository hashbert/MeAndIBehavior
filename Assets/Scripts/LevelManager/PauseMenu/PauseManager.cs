using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    //pause menu
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pauseButtons;
    [SerializeField] private GameObject optionsMenu;

    //options menu
    [SerializeField] private GameObject audioMenu;
    [SerializeField] private GameObject visualMenu;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject languageMenu;

    //controls
    [SerializeField] private GameObject gamepadPanel;
    [SerializeField] private GameObject keyboardPanel;

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
        playerInput.SwitchCurrentActionMap("UI");
        pausePanel.SetActive(true);
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

    public void ExitToTitle()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

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
                GoToPauseButtons();
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
            else if (gamepadPanel.activeSelf)
            {
                GoToControlsMenu();
            }
            else if (keyboardPanel.activeSelf)
            {
                GoToControlsMenu();
            }
        }
    }

    public void GoToControlsMenu()
    {
        keyboardPanel.SetActive(false);
        gamepadPanel.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void GoToOptionsMenu()
    {
        audioMenu.SetActive(false);
        visualMenu.SetActive(false);
        controlsMenu.SetActive(false);
        languageMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void GoToPauseButtons()
    {
        optionsMenu.SetActive(false);
        pauseButtons.SetActive(true);
    }
}