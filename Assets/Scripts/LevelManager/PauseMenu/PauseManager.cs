using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pauseButtons;
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private PlayerInput playerInput;
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
    public void ControlsButton()
    {
        controlsPanel.SetActive(true);
        pauseButtons.SetActive(false);
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
            else if (controlsPanel.activeSelf)
            {
                controlsPanel.SetActive(false);
                pauseButtons.SetActive(true);
            }
        }

    }


}
