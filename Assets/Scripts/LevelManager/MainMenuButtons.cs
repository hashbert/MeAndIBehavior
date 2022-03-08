using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject optionsBackButton;
    [SerializeField] private GameObject audioMenu;
    [SerializeField] private GameObject audioButton;
    [SerializeField] private GameObject masterSliderButton;

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

    }
    public void ControlsButton()
    {

    }
    public void LanguageButton()
    {

    }
    public void OptionsBackButton()
    {
        optionsMenu.SetActive(false);
        startMenu.SetActive(true);
        startButton.GetComponent<Button>().Select();
    }

    #endregion

    public void AudioBackButton()
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
                optionsMenu.SetActive(false);
                startMenu.SetActive(true);
            }
            else if (audioMenu.activeSelf)
            {
                audioMenu.SetActive(false);
                optionsMenu.SetActive(true);
            }
        }

    }
}
