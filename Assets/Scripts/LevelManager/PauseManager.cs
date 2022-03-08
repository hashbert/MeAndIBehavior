using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;
using TMPro;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pauseButtons;
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private PlayerInput playerInput;
    public bool IsPaused { get; private set; }
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
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        playerInput.SwitchCurrentActionMap("Player");
        pausePanel.SetActive(false);
        IsPaused = false;
    }

    public void OnPauseInput(InputAction.CallbackContext context)
    {
        if (!IsPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void QuitButton()
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

    public void ControlsButton()
    {
        controlsPanel.SetActive(true);
        pauseButtons.SetActive(false);
    }
}
