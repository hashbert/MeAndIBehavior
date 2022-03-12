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

    //Options Menu
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject optionsBackButton;

    ////Audio Menu
    [SerializeField] private GameObject audioMenu;
    [SerializeField] private GameObject audioButton;
    [SerializeField] private GameObject masterSliderButton;

    ////Visual Menu
    [SerializeField] private GameObject visualMenu;

    ////Controls Menu
    [SerializeField] private GameObject controlsMenu;

    ////Language Menu
    [SerializeField] private GameObject languageMenu;
    
    #region Start Menu
    public void StartButton()
    {
        SceneManager.LoadScene("Cutscene1");
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
    public void OptionsBackButton()
    {
        GoToStartMenu();
    }

    private void GoToStartMenu()
    {
        optionsMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    #endregion

    public void AudioBackButton()
    {
        GoToOptionsMenu();
    }

    private void GoToOptionsMenu()
    {
        audioMenu.SetActive(false);
        optionsMenu.SetActive(true);
        optionsBackButton.GetComponent<Button>().Select();
    }

    public void OnBackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (optionsMenu.activeSelf)
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
        }

    }
}
